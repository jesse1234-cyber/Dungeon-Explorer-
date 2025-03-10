using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace DungeonExplorer.Tests
{
    [TestFixture]
    public class GameTests
    {
        private Player _player;
        private Game _game;

        [SetUp]
        public void SetUp()
        {
            _player = new Player("Test Player", 100, 100);
            _game = new Game(_player);
            _game.InitializeRooms();
        }

        [Test]
        public void TestInitializePrototypes()
        {
            // Arrange
            var game = new Game(_player);

            // Act
            game.InitializeRooms();

            // Assert
            Assert.That(game, Is.Not.Null);
        }

        [Test]
        public void TestInitializeRooms()
        {
            // Assert
            Assert.That(_game._rooms, Has.Count.EqualTo(4));
        }

        [Test]
        public void PlayerMovesToNextRoom()
        {
            int indexOfFirstRoom = _game.CurrentRoomIndex;
            _game.BattleCreatures();
            _game.MoveToNextRoom();
            int indexOfSecondRoom = _game.CurrentRoomIndex;
            Assert.That(indexOfSecondRoom, Is.EqualTo(indexOfFirstRoom + 1));
        }

        [Test]
        public void Start_QuitCommand_StopsGame()
        {
            var input = new StringReader("quit");
            Console.SetIn(input);

            _game.Start();

            Assert.That(_game.Playing, Is.False);
        }

        [Test]
        public void BattleCreatures_RemovesCreatureFromListWhenDefeated()
        {
            _game.BattleCreatures();
            Assert.That(_game._rooms[_game.CurrentRoomIndex].GetCreatures().Count, Is.EqualTo(0));
        }

        [Test]
        public void MoveToNextRoom_CreaturesStillAlive_DoesNotMove()
        {
            _game.MoveToNextRoom();
            Assert.That(_game.CurrentRoomIndex, Is.EqualTo(0));
        }

        [Test]
        public void PlayerWinsGame()
        {
            _game.BattleCreatures();
            _game.MoveToNextRoom();
            _game.BattleCreatures();
            _game.MoveToNextRoom();
            _game.BattleCreatures();
            _game.MoveToNextRoom();
            _game.BattleCreatures();

            Assert.That(_game.Start(), Is.EqualTo(true));
        }
        

        [Test]
        public void PickUpItem_PlayerPicksUpItem()
        {
            var item = new Item("Test", 0, 0, 0);
            _player.PickUpItem(item);
            Assert.That(_player.HasItem(item.Name), Is.True);
        }

        [Test]
        public void Heal_PlayerHeals()
        {
            int initialHealth = _player.Health;
            _player.TakeDamage(20);
            _player.PickUpItem(new Item("Healing Potion", healing: 20));
            _player.Heal();

            Assert.That(_player.Health, Is.GreaterThan(initialHealth - 20));
        }
    }
}
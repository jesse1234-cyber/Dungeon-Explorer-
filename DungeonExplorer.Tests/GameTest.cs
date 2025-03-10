using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace DungeonExplorer.Tests
{
    [TestFixture]
    public class GameTests
    {
        private Player _player;
        private Room _room;
        private List<Room> _rooms;
        private Game _game;

        [SetUp]
        public void SetUp()
        {
            _player = new Player("Test Player", 100, 10);
            _room = new Room("Test Room", new List<Item>(), new List<Creature>(), false);
            _rooms = new List<Room> { _room };
            _game = new Game(_player, _rooms);
        }

        [Test]
        public void Start_QuitCommand_StopsGame()
        {
            var input = new StringReader("quit");
            Console.SetIn(input);

            _game.Start();

            ClassicAssert.IsFalse(_game.Playing);
        }

        [Test]
        public void BattleCreatures_NoCreatures_OutputsNoCreaturesMessage()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            _game.BattleCreatures();

            ClassicAssert.AreEqual("There are no creatures to battle.", stringWriter.ToString().Trim());
        }

        [Test]
        public void BattleCreatures_PlayerDefeatsAllCreatures_MovesToNextRoom()
        {
            var creature = new Creature("Test", 0, 0);
            _room = new Room("Test Room", new List<Item>(), new List<Creature> { creature }, false);
            _rooms = new List<Room> { _room };
            _game = new Game(_player, _rooms);

            _game.BattleCreatures();

            ClassicAssert.AreEqual(0, _room.GetCreatures().Count);
        }

        [Test]
        public void MoveToNextRoom_CreaturesStillAlive_DoesNotMove()
        {
            var creature = new Creature("Test", 10, 0);
            _room = new Room("Test Room", new List<Item>(), new List<Creature> { creature }, false);
            _rooms = new List<Room> { _room };
            _game = new Game(_player, _rooms);

            _game.MoveToNextRoom();

            ClassicAssert.AreEqual(0, _game.CurrentRoomIndex);
        }

        [Test]
        public void MoveToNextRoom_NoMoreRooms_OutputsNoMoreRoomsMessage()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            _game.MoveToNextRoom();

            ClassicAssert.AreEqual("There are no more rooms.", stringWriter.ToString().Trim());
        }

        [Test]
        public void PickUpItem_Command_PlayerPicksUpItem()
        {
            var item = new Item("Test", 0, 0, 0);
            _room = new Room("Test Room", new List<Item> { item }, new List<Creature>(), false);
            _rooms = new List<Room> { _room };
            _game = new Game(_player, _rooms);
            var input = new StringReader("pickup");
            Console.SetIn(input);

            _game.Start();

            ClassicAssert.IsTrue(_player.HasItem(item.Name));
        }

        [Test]
        public void Heal_Command_PlayerHeals()
        {
            int initialHealth = _player.Health;
            _player.TakeDamage(20);
            var input = new StringReader("heal");
            Console.SetIn(input);

            _game.Start();

            ClassicAssert.Greater(_player.Health, initialHealth - 20);
        }
    }
}
using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player _player;
        private List<Room> _rooms;
        private int _currentRoomIndex;
        private bool _playing;
        private static readonly Random _random = new Random();

        public Game(Player player, List<Room> rooms)
        {
            _player = player;
            _rooms = rooms;
            _currentRoomIndex = 0;
            _playing = true;
        }

        public void Start()
        {
            while (_playing)
            {
                Console.WriteLine($"Player: {_player.Name}, Health: {_player.Health}");
                Console.WriteLine("Commands: look, pickup, inventory, battle, heal, stats, next, quit");
                Console.Write("Enter command: ");
                string command = Console.ReadLine()?.ToLower();

                switch (command)
                {
                    case "look":
                        Console.WriteLine(_rooms[_currentRoomIndex].GetDescription());
                        break;
                    case "pickup":
                        Item item = _rooms[_currentRoomIndex].GetRandomItem();
                        if (item != null)
                        {
                            _player.PickUpItem(item);
                            Console.WriteLine($"Items left in the room: {_rooms[_currentRoomIndex].GetItems().Count}");
                        }
                        else
                        {
                            Console.WriteLine("There's nothing to pick up.");
                        }
                        break;
                    case "inventory":
                        Console.WriteLine(_player.InventoryContents());
                        break;
                    case "battle":
                        BattleCreatures();
                        if (_rooms[_currentRoomIndex].HasTreasure())
                        {
                            Console.WriteLine("Congratulations! You found the treasure! You win!");
                            _playing = false;
                        }
                        break;
                    case "heal":
                        _player.Heal();
                        break;
                    case "stats":
                        Console.WriteLine(_player.GetStats());
                        break;
                    case "next":
                        MoveToNextRoom();
                        break;
                    case "quit":
                        _playing = false;
                        Console.WriteLine("Exiting game...");
                        break;
                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
                Console.WriteLine("\n");
            }
        }

        private void BattleCreatures()
        {
            var creatures = _rooms[_currentRoomIndex].GetCreatures();
            if (creatures.Count == 0)
            {
                Console.WriteLine("There are no creatures to battle.");
                return;
            }

            for (int i = creatures.Count - 1; i >= 0; i--)
            {
                var creature = creatures[i];
                while (creature.IsAlive() && _player.Health > 0)
                {
                    int playerDamage = _player.GetMaxDamage();
                    bool playerCriticalHit = IsCriticalHit();
                    if (playerCriticalHit)
                    {
                        playerDamage *= 2;
                    }
                    Console.WriteLine($"{_player.Name} swung at the {creature.Name}, dealing {playerDamage} damage. Creature health is now {creature.Health}.");
                    creature.TakeDamage(playerDamage);
                    if (playerCriticalHit)
                    {
                        Console.WriteLine("Critical hit!");
                    }

                    if (!creature.IsAlive())
                    {
                        Console.WriteLine($"{creature.Name} has been defeated.");
                        creatures.RemoveAt(i);
                        break;
                    }

                    int creatureDamage = creature.Damage;
                    bool creatureCriticalHit = IsCriticalHit();
                    if (creatureCriticalHit)
                    {
                        creatureDamage *= 2;
                    }
                    Console.WriteLine($"{creature.Name} attacked {_player.Name}, dealing {creatureDamage} damage.");
                    _player.TakeDamage(creatureDamage);
                    if (creatureCriticalHit)
                    {
                        Console.WriteLine("Critical hit!");
                    }
                }

                if (_player.Health <= 0)
                {
                    Console.WriteLine("You have been defeated.");
                    _playing = false;
                    return;
                }
            }
        }

        private bool IsCriticalHit()
        {
            return _random.Next(100) < 15;
        }

        private void MoveToNextRoom()
        {
            var creatures = _rooms[_currentRoomIndex].GetCreatures();
            if (creatures.Count > 0 && creatures.Exists(c => c.IsAlive()))
            {
                Console.WriteLine("You must defeat all creatures before moving to the next room.");
                return;
            }

            if (_currentRoomIndex < _rooms.Count - 1)
            {
                _currentRoomIndex++;
                Console.WriteLine("You move to the next room.");
            }
            else
            {
                    Console.WriteLine("There are no more rooms.");
            }
        }
    }
}
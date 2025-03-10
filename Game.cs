using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    /// <summary>
    /// Represents the main game logic and controls the game flow.
    /// </summary>
    public class Game
    {
        private Player _player;
        private List<Room> _rooms;
        public int CurrentRoomIndex { get; private set; }
        public bool Playing { get; private set; }
        private Random _random;

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        /// <param name="player">The player character.</param>
        /// <param name="rooms">The list of rooms in the dungeon.</param>
        public Game(Player player, List<Room> rooms)
        {
            _player = player;
            _rooms = rooms;
            CurrentRoomIndex = 0;
            Playing = true;
            _random = new Random();
        }

        /// <summary>
        /// Starts the game loop and processes player commands.
        /// </summary>
        public void Start()
        {
            while (Playing)
            {
                Console.WriteLine($"Player: {_player.Name}, Health: {_player.Health}");
                Console.WriteLine("Commands: look, pickup, inventory, battle, heal, stats, next, quit");
                Console.Write("Enter command: ");
                string command = Console.ReadLine()?.ToLower();

                switch (command)
                {
                    case "look":
                        Console.WriteLine(_rooms[CurrentRoomIndex].GetDescription());
                        break;
                    case "pickup":
                        Item item = _rooms[CurrentRoomIndex].GetRandomItem();
                        if (item != null)
                        {
                            _player.PickUpItem(item);
                            Console.WriteLine($"Items left in the room: {_rooms[CurrentRoomIndex].GetItems().Count}");
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
                        if (_rooms[CurrentRoomIndex].HasTreasure())
                        {
                            Console.WriteLine("Congratulations! You found the treasure! You win!");
                            Playing = false;
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
                        Playing = false;
                        Console.WriteLine("Exiting game...");
                        break;
                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }
                Console.WriteLine("\n");
            }
        }

        /// <summary>
        /// Handles combat between the player and creatures in the current room.
        /// </summary>
        internal void BattleCreatures()
        {
            var creatures = _rooms[CurrentRoomIndex].GetCreatures();
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
                    Playing = false;
                    return;
                }
            }
        }

        /// <summary>
        /// Determines if an attack results in a critical hit.
        /// </summary>
        /// <returns><c>true</c> if the attack is a critical hit; otherwise, <c>false</c>.</returns>
        private bool IsCriticalHit()
        {
            return _random.Next(100) < 15;
        }

        /// <summary>
        /// Moves the player to the next room if conditions are met.
        /// </summary>
        internal void MoveToNextRoom()
        {
            var creatures = _rooms[CurrentRoomIndex].GetCreatures();
            if (creatures.Count > 0 && creatures.Exists(c => c.IsAlive()))
            {
                Console.WriteLine("You must defeat all creatures before moving to the next room.");
                return;
            }

            if (CurrentRoomIndex < _rooms.Count - 1)
            {
                CurrentRoomIndex++;
                Console.WriteLine("You move to the next room.");
            }
            else
            {
                Console.WriteLine("There are no more rooms.");
            }
        }
    }
}
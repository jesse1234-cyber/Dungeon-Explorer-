using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    /// <summary>
    /// Represents the game logic and manages the game state.
    /// </summary>
    public class Game
    {
        private readonly Player _player;
        internal readonly List<Room> _rooms;
        public int CurrentRoomIndex { get; private set; }
        public bool Playing { get; private set; }
        private readonly Random _random;
        private Dictionary<string, Creature> _creaturePrototypes;
        private Dictionary<string, Item> _itemPrototypes;
        public bool HasWon = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        /// <param name="player">The player participating in the game.</param>
        public Game(Player player)
        {
            _player = player;
            _rooms = new List<Room>();
            CurrentRoomIndex = 0;
            Playing = true;
            _random = new Random();
            InitializePrototypes();
        }

        /// <summary>
        /// Initializes the prototypes for creatures and items.
        /// </summary>
        private void InitializePrototypes()
        {
            _creaturePrototypes = new Dictionary<string, Creature>
            {
                { "Goblin", new Creature("Goblin", 30, 10) },
                { "Orc", new Creature("Orc", 50, 20) },
                { "Skeleton", new Creature("Skeleton", 40, 30) },
                { "Dragon", new Creature("Dragon", 100, 40) }
            };

            _itemPrototypes = new Dictionary<string, Item>
            {
                { "Rusty Knife", new Item("Rusty Knife", damage: 100) },
                { "Apple", new Item("Apple", healing: 20) },
                { "Shield", new Item("Shield", armor: 10) },
                { "Potion", new Item("Potion", healing: 50) },
                { "Sword", new Item("Sword", damage: 30) },
                { "Chestplate", new Item("Chestplate", armor: 30) }
            };
        }

        /// <summary>
        /// Initializes the rooms in the game.
        /// </summary>
        public void InitializeRooms()
        {
            _rooms.Add(CreateRoom("A dark cellar. There is a Goblin awaiting your approach.",
                new List<string> { "Rusty Knife", "Apple" }, new List<string> { "Goblin", "Goblin" }, false));
            _rooms.Add(CreateRoom("A damp cave. There is an Orc awaiting your approach.",
                new List<string> { "Shield", "Potion", "Apple" }, new List<string> { "Orc" }, false));
            _rooms.Add(CreateRoom("A narrow corridor. There is a Skeleton awaiting your approach.",
                new List<string> { "Sword", "Apple" }, new List<string> { "Skeleton" }, false));
            _rooms.Add(CreateRoom("A treasure room. There is a Dragon awaiting your approach.",
                new List<string> { "Chestplate", "Potion" }, new List<string> { "Dragon" }, true));
        }

        /// <summary>
        /// Creates a new room with the specified description, items, creatures, and treasure status.
        /// </summary>
        /// <param name="description">The description of the room.</param>
        /// <param name="itemNames">The names of the items in the room.</param>
        /// <param name="creatureNames">The names of the creatures in the room.</param>
        /// <param name="hasTreasure">Indicates whether the room has treasure.</param>
        /// <returns>A new <see cref="Room"/> instance.</returns>
        private Room CreateRoom(string description, List<string> itemNames, List<string> creatureNames, bool hasTreasure)
        {
            List<Item> items = new List<Item>();
            foreach (var itemName in itemNames)
            {
                items.Add((Item)_itemPrototypes[itemName].Clone());
            }

            List<Creature> creatures = new List<Creature>();
            foreach (var creatureName in creatureNames)
            {
                creatures.Add((Creature)_creaturePrototypes[creatureName].Clone());
            }

            return new Room(description, items, creatures, hasTreasure);
        }

        /// <summary>
        /// Starts the game loop.
        /// </summary>
        public bool Start()
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
                        if (!BattleCreatures())
                        {
                            Playing = false;
                            return false;
                        }
                        break;
                    case "heal":
                        _player.Heal();
                        break;
                    case "stats":
                        Console.WriteLine(_player.GetStats());
                        break;
                    case "next":
                        if (_rooms[CurrentRoomIndex].HasTreasure())
                        {
                            HasWon = true;
                            Playing = false;
                            return true;
                        }
                        MoveToNextRoom();
                        break;
                    case "quit":
                        Playing = false;
                        Console.WriteLine("Exiting game...");
                        return false;
                    default:
                        Console.WriteLine("Unknown command.");
                        break;
                }

                Console.WriteLine("\n");
            }

            return false;
        }

        /// <summary>
        /// Handles the battle logic between the player and creatures in the current room.
        /// </summary>
        internal bool BattleCreatures()
        {
            var creatures = _rooms[CurrentRoomIndex].GetCreatures();
            if (creatures.Count == 0)
            {
                Console.WriteLine("There are no creatures to battle.");
                return false;
            }

            for (int i = 0; i < creatures.Count; i++)
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

                    creature.TakeDamage(playerDamage);
                    Console.WriteLine($"{_player.Name} swung at the {creature.Name}, dealing {playerDamage} damage. Creature health is now {creature.Health}.");
                    if (playerCriticalHit)
                    {
                        Console.WriteLine("Critical hit!");
                    }

                    if (!creature.IsAlive())
                    {
                        Console.WriteLine($"{creature.Name} has been defeated.");
                        creatures.RemoveAt(i);
                        i--; // Adjust the index to account for the removed creature
                        break;
                    }

                    int creatureDamage = creature.Damage;
                    bool creatureCriticalHit = IsCriticalHit();
                    if (creatureCriticalHit)
                    {
                        creatureDamage *= 2;
                    }

                    _player.TakeDamage(creatureDamage);
                    Console.WriteLine($"{creature.Name} attacked {_player.Name}, dealing {creatureDamage} damage.");
                    if (creatureCriticalHit)
                    {
                        Console.WriteLine("Critical hit!");
                    }
                }

                if (_player.Health <= 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Determines if a critical hit occurs.
        /// </summary>
        /// <returns><c>true</c> if a critical hit occurs; otherwise, <c>false</c>.</returns>
        private bool IsCriticalHit()
        {
            return _random.Next(100) < 15;
        }

        /// <summary>
        /// Moves the player to the next room if all creatures in the current room are defeated.
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
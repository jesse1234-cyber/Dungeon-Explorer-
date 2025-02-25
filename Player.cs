using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Threading;

namespace DungeonExplorer
{
    public class Player
    {
        // Add a dictionary for opposite directions
        private static readonly Dictionary<string, string> OppositeDirections = new Dictionary<string, string>
        {
            { "North", "South" },
            { "South", "North" },
            { "East", "West" },
            { "West", "East" }
        };

        // Player's Properties
        public string Name { get; set; }
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int EquippedWeaponDamage { get; set; }
        public List<string> Inventory { get; set; }
        public int PlayerX { get; set; }
        public int PlayerY { get; set; }
        public Room CurrentRoom { get; set; }
        public bool lastRoom = false;

        // Player's constructor
        public Player(string name, int startX, int startY, Room currentRoom)
        {
            Name = name;
            MaxHealth = 100;
            Health = MaxHealth;
            Strength = 10;
            Inventory = new List<string>();
            PlayerX = startX;
            PlayerY = startY;
            CurrentRoom = currentRoom;
        }

        // Method to add an item to inventory
        public void AddItem(string item)
        {
            if (GameData.GetWeapons().ContainsKey(item))
            {
                Console.WriteLine("\nYou picked up a weapon, do you want to equip it?");
                Console.Write("1. Yes\t\t2. No\n: ");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    EquippedWeaponDamage = GameData.GetWeapons()[item];
                    Console.WriteLine($"\nEquipped weapon damage: {EquippedWeaponDamage}\n");
                }
            }
        }

        // Method to display player info
        public void DisplayInfo()
        {
            Console.WriteLine($"\nName: {Name}");
            Console.WriteLine($"Health: {Health}/{MaxHealth}");
            Console.WriteLine($"Inventory: {string.Join(", ", Inventory)}\n");
        }

        // Method to move to another room
        public void MoveToRoom(Room[,] Grid, int RoomCount)
        {
            if (CurrentRoom.Enemies.Count > 0)
            {
                Console.WriteLine("\nYou must defeat all enemies in the room before moving to another room.\n");
                return;
            }

            Console.WriteLine("\nYou decide to move to another room, where do you want to go?");
            int end = CurrentRoom.Exits.Count;
            for (int i = 0; i < end; i++)
            {
                Console.WriteLine($"{i + 1}. {CurrentRoom.Exits[i]}");
            }
            Console.Write($"{end + 1}. Cancel\n: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice != (end + 1) && choice <= end)
            {
                // Create and move to the selected room
                RoomCount++;
                string roomID = "Room " + RoomCount;
                string direction = CurrentRoom.Exits[choice - 1];

                // Move the player
                switch (direction)
                {
                    case "North":
                        PlayerY--;
                        break;
                    case "South":
                        PlayerY++;
                        break;
                    case "East":
                        PlayerX++;
                        break;
                    case "West":
                        PlayerX--;
                        break;
                    case "Exit":
                        Console.WriteLine("\nYou have reached the exit, congratulations!\n");
                        Game.IsGameOver = true;
                        break;
                }

                if (RoomCount == 10)
                {
                    lastRoom = true;
                }

                // Checks if the new room already exists
                if (Grid[PlayerX, PlayerY] != null)
                {
                    CurrentRoom = Grid[PlayerX, PlayerY];
                }
                else
                {
                    // Create the new room
                    Room newRoom = new Room(roomID, GameData.GetRandomRoomDescription(), RoomCount);

                    // Add exit to previous room
                    string oppositeDirection = OppositeDirections[direction];
                    newRoom.AddExit(oppositeDirection);

                    // Add new exits, but checks if there should already be one or not
                    bool doorAdded = false;
                    Random random = new Random();

                    while (!doorAdded)
                    {
                        foreach (string key in OppositeDirections.Keys)
                        {
                            int newX = PlayerX, newY = PlayerY;
                            string oppositeExit = "";

                            switch (key)
                            {
                                case "North": newY--; oppositeExit = "South"; break;
                                case "South": newY++; oppositeExit = "North"; break;
                                case "East": newX++; oppositeExit = "West"; break;
                                case "West": newX--; oppositeExit = "East"; break;
                            }

                            // Checks if the new room already has the exit
                            if (newRoom.Exits.Contains(key))
                                continue;

                            // Checks if the player is at the edge of the grid or if there is a room in the way
                            if (newX < 0 || newY < 0 || newX >= Grid.GetLength(1) || newY >= Grid.GetLength(0))
                                continue;
                            if (Grid[newX, newY] != null && !Grid[newX, newY].Exits.Contains(oppositeExit))
                                continue;

                            // Checks if there is a room in the way but it has an exit to the new room
                            if (Grid[newX, newY] != null && Grid[newX, newY].Exits.Contains(oppositeExit))
                            {
                                newRoom.AddExit(key);
                                continue;
                            }

                            // If it passes checks, attempt to add exit
                            int chance = random.Next(1, 5);
                            if (chance == 1)
                            {
                                newRoom.AddExit(key);
                                doorAdded = true;
                            }
                        }
                    }

                    if (!lastRoom)
                    {
                        int amount = 1 + (RoomCount / 3);
                        for (int i = 0; i < amount; i++)
                        {
                            newRoom.AddEnemy(GameData.GetRandomEnemy(0, 1 + (RoomCount / 2)));
                        }
                    }
                    else
                    {
                        newRoom.Description = "You have reached the final room, be careful.";
                        newRoom.Exits.RemoveRange(1, newRoom.Exits.Count - 1);
                        newRoom.AddExit("Exit");
                    }

                    // Add the new room to the grid
                    Grid[PlayerX, PlayerY] = newRoom;

                    // Set the new room as the current room
                    CurrentRoom = newRoom;

                    Console.WriteLine($"\nYou move {direction} into {roomID}.\n");
                }
            }
        }

        // Method to pick up an item
        public void PickUpItem()
        {
            if (CurrentRoom.Items.Count > 0)
            {
                Console.WriteLine("\nYou decide to pick up an item, what do you pick up?");
                int end = CurrentRoom.Items.Count;
                for (int i = 0; i < end; i++)
                {
                    Console.WriteLine($"{i + 1}. {CurrentRoom.Items[i]}");
                }
                Console.Write($"{end + 1}. Cancel\n: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice != (end + 1) && choice <= end)
                {
                    AddItem(CurrentRoom.Items[choice - 1]);
                    CurrentRoom.Items.RemoveAt(choice - 1);
                }
            }
            else
            {
                Console.WriteLine("\nThere are no items to pick up in this room.\n");
            }
        }

        // Method to display a map of the grid
        public void DisplayMap(Room[,] Grid)
        {
            Console.WriteLine();
            for (int y = 0; y < Grid.GetLength(1); y++)
            {
                for (int x = 0; x < Grid.GetLength(0); x++)
                {
                    if (Grid[x, y] != null)
                    {
                        if (x == PlayerX && y == PlayerY)
                        {
                            Console.Write("P ");
                        }
                        else
                        {
                            Console.Write("X ");
                        }
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // Method to fight an enemy
        public void FightEnemy()
        {
            if (CurrentRoom.Enemies.Count > 0)
            {
                Console.WriteLine("\nYou decide to fight an enemy, which enemy do you want to fight?");
                int end = CurrentRoom.Enemies.Count;
                for (int i = 0; i < end; i++)
                {
                    List<object> enemy = (List<object>)CurrentRoom.Enemies[i];
                    Console.WriteLine($"{i + 1}. {enemy[0]}");
                }
                Console.Write($"{end + 1}. Cancel\n: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice != (end + 1) && choice <= end)
                {
                    Thread.Sleep(100);
                    Console.Clear();
                    List<object> enemy = (List<object>)CurrentRoom.Enemies[choice - 1];
                    int enemyMaxHealth = (int)enemy[2];
                    int round = 1;
                    while (true)
                    {
                        round++;
                        Console.WriteLine($"\n===== Fighting {enemy[0]} =====\n");
                        Console.WriteLine($"{Name}'s Health: {Health}/{MaxHealth}");
                        Console.WriteLine($"{enemy[0]} Health: {enemy[2]}/{enemyMaxHealth}");
                        Console.WriteLine("\nWhat do you want to do?");
                        Console.WriteLine("1. Attack\t\t 2. Use item\t\t 3. Run");
                        Console.Write(": ");
                        string choice2 = Console.ReadLine();
                        switch (choice2)
                        {
                            case "1":
                                Random random = new Random();
                                double multiplier = Math.Round(random.NextDouble() + 1, 1);

                                int playerDamage = (int)((Strength + 1 + EquippedWeaponDamage) * multiplier);
                                enemy[2] = (int)enemy[2] - playerDamage;

                                if (round % (int)enemy[3] == 0)
                                {
                                    Health -= (int)enemy[1];
                                }

                                Console.WriteLine($"\nYou deal {playerDamage} damage to {enemy[0]}.\n");
                                Console.WriteLine($"{enemy[0]} deals {enemy[1]} damage to you.\n");

                                if (Health <= 0)
                                {
                                    Console.WriteLine("You have died.\n");
                                    Game.IsGameOver = true;
                                    Thread.Sleep(2000);
                                    return;
                                }

                                if ((int)enemy[2] <= 0)
                                {
                                    Console.WriteLine($"You have defeated {enemy[0]}.\n");
                                    CurrentRoom.Enemies.RemoveAt(choice - 1);
                                    Thread.Sleep(2000);
                                    return;
                                }

                                break;

                            case "2":
                                if (Inventory.Count > 0)
                                {
                                    Console.WriteLine("\nYou decide to use an item, which item do you want to use?");
                                    for (int i = 0; i < Inventory.Count; i++)
                                    {
                                        Console.WriteLine($"{i + 1}. {Inventory[i]}");
                                    }
                                    Console.Write(": ");
                                    int choice3 = Convert.ToInt32(Console.ReadLine());
                                    if (choice3 <= Inventory.Count)
                                    {
                                        Inventory.RemoveAt(choice3 - 1);
                                        Health += 20;
                                        Console.WriteLine("\nYou use a potion and gain 20 health.\n");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nYou have no items to use.\n");
                                }
                                break;

                            case "3":
                                Console.WriteLine("\nYou run away from the fight.\n");
                                return;

                            default:
                                Console.WriteLine("\nInvalid choice. Try again.\n");
                                break;
                        }
                        Thread.Sleep(1500);
                        Console.Clear();
                    }
                }
            }
        }
    }
}

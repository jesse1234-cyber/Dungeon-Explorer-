using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    class Player
    {
        private string playerName;
        private int playerHealth;
        private List<string> playerInventory = new List<string>();

        public Player(string playerName, int playerHealth, List<string> playerInventory)
        {
            Name = playerName;
            Health = playerHealth;
            Inventory = new List<string>();
        }

        public string Name
        {
            get { return playerName; }
            set { playerName = string.IsNullOrWhiteSpace(value) ? "NoName" : value; }
        }
        public int Health
        {
            get { return playerHealth; }
            set { playerHealth = value; }
        }
        public List<string> Inventory
        {
            get { return playerInventory; }
            set { playerInventory = value ?? new List<string>(); }
        }

        public void ChooseName()
        {
            // Ask user for their name
            string inputName;
            Console.WriteLine("What is your name? ");
            inputName = Console.ReadLine();

            // Assign name to Name
            this.Name = inputName;

            // Return the player's details, including name and health
            Console.WriteLine($"Welcome, {Name}! You currently have {Health}hp!");
        }

        public void PickUpItem(string RoomItem)
        {
            // Add item to the inventory
            Inventory.Add(RoomItem);
            // Return the items currently in the inventory
            Console.WriteLine($"Item {RoomItem} picked up!");
            Console.WriteLine($"{Name}, your inventory contains: {string.Join(", ", Inventory)}, and your hp is {Health}");
        }
    }
}
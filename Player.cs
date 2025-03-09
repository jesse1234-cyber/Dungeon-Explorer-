using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DungeonExplorer
{
    /// <summary>
    /// Player class
    /// Contains player's name, player's health and inventory items
    /// </summary>
    public class Player
    {
        private string _playerName = "DefaultName";
        private int _playerHealth;
        private List<string> _playerInventory = new List<string>();

        /// <summary>
        /// Initialises a new instance of the Player class
        /// </summary>
        /// <param name="playerName">The player's name</param>
        /// <param name="playerHealth">The player's health points</param>
        /// <param name="playerInventory">The player's inventory items</param>
        public Player(string playerName, int playerHealth, List<string> playerInventory)
        {
            Name = playerName;
            Health = playerHealth;
            Inventory = playerInventory ?? new List<string>();
        }

        /// <summary>
        /// Gets and sets the name as 'DefaultName' before it has been chosen
        /// </summary>
        public string Name
        {
            get { return _playerName; }
            set { _playerName = string.IsNullOrWhiteSpace(value) ? "DefaultName" : value; }
        }

        /// <summary>
        /// Gets and sets the health of the player
        /// </summary>
        public int Health
        {
            get { return _playerHealth; }
            set { _playerHealth = value; }
        }

        /// <summary>
        /// Gets and sets the inventory items
        /// </summary>
        public List<string> Inventory
        {
            get { return _playerInventory; }
            set { _playerInventory = value ?? new List<string>(); }
        }

        /// <summary>
        /// Asks the user to enter their name, assigns it to the Name variable
        /// </summary>
        public void ChooseName()
        {
            string inputName;

            //Prevent user from entering a blank name
            do
            {
                Console.Write("Please enter a name ");
                inputName = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(inputName));

        // Assign name to Name
        Name = inputName;

            //Prevent user from entering a blank name
            Debug.Assert(Name != null, "Please enter a name");

            // Return the player's details, including name and health
            Console.WriteLine($"Welcome, {Name}! You currently have {Health}hp!");
        }

        /// <summary>
        /// User can pick up an item, adds to Inventory list
        /// </summary>
        /// <param name="RoomItem">Item stored in the room</param>
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
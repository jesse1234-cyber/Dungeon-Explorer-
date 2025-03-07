using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace DungeonExplorer
{
    public class Player
    {
        private string name;
        private int health;
        private List<string> inventory = new List<string>(); // List that hold the player's items.

        // Property used to get and set the player's name.
        public string Name
        {
            get { return name; }
            set
            {
                while (string.IsNullOrEmpty(value)) // Checks to see if the name is empty, if so the user is aasaked to enter the name again.
                {
                    Console.WriteLine("Player name can't be empty.");
                    Console.Write("Enter the player name: ");
                    value = Console.ReadLine();
                }
                name = value; // Sets the name.
            }
        }
        // Property used to set the player's health.
        public int Health
        {
            get { return health; }
            set
            {
                if (value <= 0) // Checks if the health is 0 or negative.
                {
                    Console.WriteLine("Player health cannot be set to zero or be negative.");

                    Console.WriteLine("Player health will be set to 100.");
                    health = 100; // Sets the health to 100 as a default value.

                }
                else
                {
                    health = value; // Sets the health if it isn't 0 or negative.
                }
            }
        }


        // Method which allows the player to pick up items from a room.
        public void PickUpItem(string item, Room currentRoom)
        {

            // Gets the list of items that are in the room.
            List<string> roomItems = currentRoom.GetRoomItems();
            // Finds the specified item within the room (case sensitive).
            string itemToPickUp = roomItems.Find(r => r.Equals(item, StringComparison.OrdinalIgnoreCase));

            if (itemToPickUp != null) // Checks if the item is actually in the room.
            {
                if (!inventory.Contains(itemToPickUp)) // Checks if player already has the item.
                {
                    inventory.Add(itemToPickUp); // Adds the item to the player's inventory.
                    currentRoom.RemoveItem(itemToPickUp); // Removes the item from the room.
                    Console.WriteLine("Picked up: " + itemToPickUp); // Displays pick up message.
                }
                else
                {
                    Console.WriteLine(itemToPickUp + " already in inventory!"); // If player already has this item.
                }
            }
            else
            {
                Console.WriteLine($"{item} not found."); // If the item isn't in the room.
            }
        }


        // Method which returns the contents of the player's inventory.
        public string InventoryContents()
        {
            if (inventory.Count == 0)
            {
                return ("Inventory is empty.");
            }
            else
            {
                return string.Join(", ", inventory);
            }
        }
    }
}


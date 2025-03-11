using System; // Added for Random to be used
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.Remoting.Messaging;

namespace DungeonExplorer
{
    public class Room
    {
        // Changed to public so Start() could access and print the description
        public string description; // Test for if the descriptions would change appropiately
        private Items items; // Instance of Items class
        public Room(string description) // Constructor, blueprint for creating room descriptions
        {  
            items = new Items(); // Variable for the Item class so the method + function can be used in Game.cs
            this.description = description; // "this." refers to current instance of a class
        }
        
        // Method in the Room class directly to call a method in the Items class
        public void InitializeRoomItems()
        {
            if (items == null) // Check to make sure items is initialized and doesn't return null
            {
                items = new Items();
            }
            items.InitializeItem(); // Calls the method in this file, as it cannot be called in Games.cs
        }

        public string SelectItem() //Error handling w/ new function- in case item initialisation doesn't work as it's supposed to (previous tests had it return Null)
        {
            return items?.ItemSelector() ?? "No items avaliable";
        }

        // Made all public + static, so that Game.cs can access it
        // Rooms will all have an object the user is able to pick up (see "ItemSelector()" method)
        public static Room room1 = new Room("Currently, you find yourself in a white room. The sparkle of an item catches your eye."); // Begin in front of a locked door. Tell user they can move left, right, or south.
        public static Room room2 = new Room("Description for room 2"); // Items will be found in each new room
        public static Room room3 = new Room("Description for room 3");
        public static Room room4 = new Room("Description for room 4");

       // New class added
        public class Items //! "item" is a variable within the Player class (for them to pick up and view their inventory)
        {
            string oneItem; // An index of a random object the player picks up (see the function "ItemSelector" below)
            List<string> avaliableItems = new List<string>();  
            
            // Method to add items for the player to possibly get in Game
            public void InitializeItem() // Public for it to be called
            {
                avaliableItems.Add("Box");
                avaliableItems.Add("Knife");
                avaliableItems.Add("Lighter");
                avaliableItems.Add("Key");
            }

            public string ItemSelector() // To be called each time the player enters a different room; they can pick up a different item.
            {
                if(avaliableItems.Count == 0)
                {
                    return null; // Returns nothing is list is empty so code doesn't go into an error. Potential debug here.
                }
                
                Random r = new Random();
                int randomInt = r.Next(avaliableItems.Count);
                oneItem = avaliableItems[randomInt];
                avaliableItems.RemoveAt(randomInt); // Removes item from list once it is picked up by the player, for other items to be picked randomly in other rooms when the function is called again
                
                return oneItem;
            }
            
        }
    }
}
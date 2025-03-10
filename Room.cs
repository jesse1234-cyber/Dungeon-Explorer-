using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room
    {
        // Changed to public so Start() could access and print the description
        public string description; // Test for if the descriptions would change appropiately
        private Items items; // Instance of Items class
        public Room(string description) // Constructor, blueprint for creating room descriptions
        {
            items = new Items();
            this.description = description; // "this." refers to current instance of a class
        }
        
        // Method in the Room class directly to call a method in the Items class
        public void InitializeRoomItems()
        {
            items.InitializeItem(); // Calls the method in this file, as it cannot be called in Games.cs
        }

        // !!!!Room description intialisation, should I move this to the function? (and pass the parameter of the room string so it can print it? ex. turning left in game, and room[number] would have to be fetched)
        // Made all public + static, so that Game.cs can access it
        public static Room room1 = new Room("Description for room 1");
        public static Room room2 = new Room("Description for room 2");
        public static Room room3 = new Room("Description for room 3");

       // New class to interact w/ player
        public class Items //!!! "item" is a variable within the Player class (for them to pick up and view their inventory)
        {
            // Dedicated class for an object to be found in a room (if/else + random chance METHOD?)
            // Exit key should be guranteed in one room (and locked door)
            string oneItem; // Want this variable to be from an index of available *list* times (potentially could be an integer)
            List<string> avaliableItems = new List<string>();  
            
            // Method to add items for the player to possibly get in Game
            public void InitializeItem() // Public for it to be called
            {
                avaliableItems.Add("a");
                avaliableItems.Add("b");
                avaliableItems.Add("c");
                avaliableItems.Add("d");
            }
                
        }
    }
}
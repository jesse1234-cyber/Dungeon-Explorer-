using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room
    {
        // Room description as private field
        private string description;
  
        private static Random random = new Random(); // OLK - Good use of static to make random functions avaliable within class

        //  Method for randomising room descriptions
        public string RandomRoom()
        {
            string[] rooms =    // Create a string array of room descriptions
            {
                "dark damp room",
                "bright cold room",
                "moss covered stone wall room"                
            };

            int index = random.Next(rooms.Length);  // Create  an index, which holds a random number between the number of descriptions in the array            
            description = rooms[index]; // Set description to the random description from the array based on the index
            return description; // Return the description
        }

        // Constructor for the room, sets its description
        public Room(string description)
        {
            this.description = description;
        }

        // Method returning the description of the room
        public string GetDescription()
        {
            return description; // OLK - Good use of encapsulation.
        }
    }
}
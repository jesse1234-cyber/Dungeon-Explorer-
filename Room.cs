using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;

namespace DungeonExplorer
{
    public class Room
    {
        // Git test 
        private string description;
        public string item;

        //Room room1descrip = new Room("the room fills with a cold and sharp air, lava flows down the walls and the floor is covered in bones and skulls");

        //Represents a single room in the game with a description and possibly an item

       
        
        
        
        
        public Room(string description)
        {
            

            this.description = description;   // the class for the room description

        }
       
        public string GetDescription ()
        {          


            return description;
        }

        
      
        
        

    }
}
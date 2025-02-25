using System;
using System.ComponentModel;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;

        //initialize new instance of the room class
        public Room(string description)
        {
            this.description = description;
        }

        public string GetDescription()
        {
            return description;
        }
    }
}
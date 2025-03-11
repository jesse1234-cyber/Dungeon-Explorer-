using System;
using System.Diagnostics.Eventing.Reader;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;

        public Room(string description)
        {
            this.description = description;
        }

        public string GetDescription() { return this.description;  }
            
    }
} 
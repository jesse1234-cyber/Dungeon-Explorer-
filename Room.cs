using System;

namespace DungeonExplorer
{
    /// <summary>
    /// creates the rooms the users navigates
    /// </summary>
    public class Room
    {
        private string description;

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
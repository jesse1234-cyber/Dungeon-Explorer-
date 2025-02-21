using System;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        public string Description
        {
            get { return description;}
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Room description cannot be empty.");
                }
                else
                {
                    description = value;
                }
            }
        }


        public string GetDescription()
        {
            return description;
        }
    }
}
using System.Xml.Linq;
using System;

namespace DungeonExplorer
{
    public class Room
    {
        public int roomNumber;
        private string[] wallDescription;
        private string[] lightDescription;

        public Room(string description)
        {
            this.roomNumber = 0;
            this.wallDescription = new string[] { "pristine", "worn", "weathered", "cracked", "damp", "moldy", "crumbling", "rotten", "decrepit", "collapsed" };
            this.lightDescription = new string[] { "blinding", "bright", "warm", "dim", "flickering", "weak", "dull", "sparse", "barely any", "almost no" };
        }

        public void GetDescription()
        {
            if (roomNumber == 0)
            {
                Console.WriteLine($"The walls caging you seem well kept, bathed by countless torches");
                Console.WriteLine("You notice a sword displayed in the center of the room, and grab it as you march onward into the next room...");
            }
            else
            {
                Console.WriteLine($"The walls around you are {wallDescription[roomNumber]}, there is {lightDescription[roomNumber]} light filling the room");
            }

        }
    }
}
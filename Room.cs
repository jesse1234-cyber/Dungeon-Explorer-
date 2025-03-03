using System.Xml.Linq;
using System;

namespace DungeonExplorer
{
    public class Room
    {
        private Game game; 
        
        public int roomNumber;
        public string Item;
        public bool itemRoom;
        private string[] roomItems;
        private string[] wallDescription;
        private string[] lightDescription;

        private static readonly Random random = new Random();

        public Room(string description)
        {
            this.roomNumber = 0;
            this.Item = "";
            this.itemRoom = true;
            this.roomItems = new string[] { "sword", "shield", "potion", "key", "pile of gold", "Torch", "Lockpick",  };
            this.wallDescription = new string[] { "pristine", "worn", "weathered", "cracked", "damp", "moldy", "crumbling", "rotten", "decrepit", "collapsed" };
            this.lightDescription = new string[] { "blinding", "bright", "warm", "dim", "flickering", "weak", "dull", "sparse", "barely any", "almost no" };
        }

        public void GetDescription()
        {
            if (roomNumber == 0)
            {
                Console.WriteLine("The walls caging you seem well kept, bathed by countless torches");
                Console.WriteLine("You notice a sword displayed in the center of the room, and grab it as you march onward into the next room...");
            }
            else
            {
                Console.WriteLine($"The walls around you are {wallDescription[roomNumber - 1]}, there is {lightDescription[roomNumber - 1]} light filling the room");
                roomNumber++;
            }

        }

        public void GetItemRoom()
        {
            if (random.Next(1, 3) == 1)
            {
                itemRoom = true;
            }
            else 
            {
                itemRoom = false;
            }
        }
        
        public void GetItem()
        {
            Item = roomItems[random.Next(0, roomItems.Length)];
        }
    }
}
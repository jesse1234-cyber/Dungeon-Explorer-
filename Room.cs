using System.Xml.Linq;
using System;

namespace DungeonExplorer
{
    public class Room
    {
        public int roomNumber;
        public string item;
        public int itemChance;
        public bool itemRoom;
        private string[] _roomItems;
        private string[] _wallDescription;
        private string[] _lightDescription;

        private static readonly Random random = new Random();

        public Room()
        {
            this.roomNumber = 0;
            this.item = "";
            this.itemChance = 33; // 33% chance of finding an item in a room
            this.itemRoom = true;
            this._roomItems = new string[] { "sword", "shield", "potion", "key", "pile of gold", "Torch", "Lockpick",  };
            this._wallDescription = new string[] { "pristine", "worn", "weathered", "cracked", "damp", "moldy", "crumbling", "rotten", "decrepit", "collapsed" };
            this._lightDescription = new string[] { "blinding", "bright", "warm", "dim", "flickering", "weak", "dull", "sparse", "barely any", "almost no" };

            Console.Clear();
             // game context
            Console.WriteLine("pulling  yourself to your feet, you begin to examine your surroundings\n");
            Console.WriteLine("The walls caging you seem well kept, bathed by countless torches");
            Console.WriteLine("You notice a sword displayed in the center of the room, and grab it as you march onward into the next room...");
            Console.ReadKey();
            Console.Clear();
        }

        public void GetDescription()
        {
             // generate the room description by iterating through the arrays giving more gloomy descriptions as the room number increases
            Console.WriteLine($"The walls around you are {_wallDescription[roomNumber]}, there is {_lightDescription[roomNumber]} light filling the room");
            roomNumber++;

        }

        public void GetItemRoom()
        {
            // generate a random number between 1 and 100 and compare it against the chance for an item
            if (random.Next(1, 100) <= itemChance)
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
             // generate a random item from the list
            item = _roomItems[random.Next(0, _roomItems.Length)];
        }
    }
}
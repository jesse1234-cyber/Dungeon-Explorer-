using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room
    {
        public static int currentRoom = -1;
            

        private string room1Description = "You enter a room dark and slightly damp. Cool air rushes in from behind you pushing life and energy into this otherwise desolet hole. 2 other entrances span off into the dark adn in the center is a small collection of scrap left here you assume when the mine was left to rot";
        private string room2Description = "get roomeeed (2) :>";
        private string room3Description = "get roomored (3) 8>";

        public static List<string> room1Items = new List<string> {"Dagger, 14 Copper Coins"};
        public static List<string> room2Items = new List<string> { "Sword, 20 Copper Coins" };
        public static List<string> room3Items = new List<string> { "Shield, 30 Gold Coins" };

        public List<string> RoomDescriptions = new List<string>();
        public List<string> RoomItems = new List<string>();

        public Room()
        {
            RoomDescriptions.Add(room1Description);
            RoomDescriptions.Add(room2Description);
            RoomDescriptions.Add(room3Description);

            RoomItems.Add(room1Items.ToString());
            RoomItems.Add(room2Items.ToString());
            RoomItems.Add(room3Items.ToString());
        }

        public string GetDescription()
        {
            currentRoom++;
            string roomDescription = RoomDescriptions[currentRoom];
            string roomItems = RoomItems[currentRoom];
            //Console.WriteLine(roomItems);
            Console.WriteLine(roomDescription);
            return roomDescription;
        }

        public string GetItems()
        {
            string roomItems = RoomItems[currentRoom];
            Console.WriteLine(string.Join(", ", roomItems));
            return roomItems;
        }
    }
}
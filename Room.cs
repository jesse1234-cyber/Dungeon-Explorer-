using System;
using System.Collections.Generic;


namespace DungeonExplorer
{
    public class Room
    {
        private static List<Room> rooms = new List<Room>
        {
            new Room("Large fountain of glowing red liquid can be seen in this room."),
            new Room("Dusty old books are on the shelf of this library."),
            new Room("An empty room with spider web around."),
            new Room("Deadly skeletons lay down around gloomy room."),
            new Room("Prison bars surround this room."),
            new Room("Empty chests of treasure fill up this room"),
            new Room("Ancient stone carvings is all that you see...")
        };
        
        private static Random rndmRoom = new Random();
        private string description;
        

        public Room(string description)
        {
            this.description = description;
        }

        public string GetDescription()
        {
            return description;
        }

        public static Room GetNewRoom(Room previousRoom)
        {
            Room newRoom;
            do
            {
                newRoom = rooms[rndmRoom.Next(rooms.Count)];
            } 
            while (previousRoom == newRoom);
            return newRoom;
        }
    }
}
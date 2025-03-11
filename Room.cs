using System;
using System.Dynamic;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonExplorer
{
    public class Room
    {
        private string roomName;
        private string roomItem;
        private int roomLength;
        private int roomWidth;
        private int roomDoors;

        private Player player;


        public Room(string roomName, string roomItem, int roomLength, int roomWidth, int roomDoors)
        {
            this.roomName = roomName;
            this.roomItem = roomItem;
            this.roomLength = roomLength;
            this.roomWidth = roomWidth;
            this.roomDoors = roomDoors;
        }

        public string RoomName
        {
            get { return roomName; }
            set { roomName = value; }
        }
        public string RoomItem
        {
            get { return roomItem; }
            set { roomItem = value; }
        }
        public void WriteDescription()
        { 
            Console.WriteLine(
                $"You enter {roomName}. This room goes back {roomLength} metres. \n" +
                $"It is {roomWidth} metres wide. The room has {roomDoors} Doors \n");
        }

    }
}
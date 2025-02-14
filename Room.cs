using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    class Room
    {
        private string roomName;
        private string roomItem;

        public Room(string roomName, string roomItem)
        {
            RoomName = roomName;
            RoomItem = roomItem;
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

        public void GetDescription(Player player)
        {
            string pickUpItem;
            //Return a description of the room
            do
            {
                Console.WriteLine
                (
                $@"This room is square. It is well lit with torches.
                There is a {RoomItem} in the room. Would you like to pick it up?
                Y/N"
                );
                //Pass user input to the variable
                pickUpItem = Console.ReadLine();
            }
            //Ensure the user entered either 'Y' or 'N'
            while (pickUpItem != "Y" && pickUpItem != "N");
            //Pick up the item method if they said Y (yes)
            if (pickUpItem == "Y")
            {
                player.PickUpItem(RoomItem);
            }
            //Do nothing if they said N (no)
            else if (pickUpItem == "N")
            {
                Console.WriteLine("Item not picked up");
            }
        }
    }
}
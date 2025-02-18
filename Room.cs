using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    /// <summary>
    /// Room class. Holds information about the room's name and items contained in it.
    /// </summary>
    class Room
    {
        private string _roomName;
        private string _roomItem;

        /// <summary>
        /// Initalises a new instance of the Room class
        /// </summary>
        /// <param name="roomName">The room's name</param>
        /// <param name="roomItem">An item contained in the room</param>
        public Room(string roomName, string roomItem)
        {
            RoomName = roomName;
            RoomItem = roomItem;
        }

        /// <summary>
        /// Gets and sets the room's name
        /// </summary>
        public string RoomName
        {
            get { return _roomName; }
            set { _roomName = value; }
        }

        /// <summary>
        /// Gets and sets the item contained in the room
        /// </summary>
        public string RoomItem
        {
            get { return _roomItem; }
            set { _roomItem = value; }
        }

        /// <summary>
        /// Describes the room, asks if user wants to pick up item
        /// </summary>
        public void GetDescription(Player player)
        {
            string pickUpItem;
            do
            {
                Console.WriteLine(
                    $"This room is square. It is well lit with torches.\n" +
                    $"There is a {RoomItem} in the room. Would you like to pick it up? (Y/N)"
                );
                // Pass user input to the variable
                pickUpItem = Console.ReadLine().ToUpper();
            }
            // Ensure the user entered either 'Y' or 'N'
            while (pickUpItem != "Y" && pickUpItem != "N");
            //Pick up the item method if they said Y (yes)
            if (pickUpItem == "Y")
            {
                player.PickUpItem(RoomItem);
            }
            // Do nothing if they said N (no)
            else if (pickUpItem == "N")
            {
                Console.WriteLine("Item not picked up");
            }
        }
    }
}
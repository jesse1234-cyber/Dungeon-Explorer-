using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;
using System.Threading;

namespace DungeonExplorer
{
    public class Room
    {
        private string Description;
        private bool ItemInside;
        private List<string> ItemsInRoom;
        private string RoomName;

        public Room(string roomName, bool itemInside)
        {
            this.ItemInside = itemInside;
            this.RoomName = roomName;
            ItemsInRoom = new List<string>();
        }

        private void SetDescription(string roomName)
        {
            if (RoomName == "Library")
            {
                this.Description = "A dusty library full of sorcery tomes and alchemy books. The air feels tense and you feel strange. \n" +
                    "You see something glistening at the top of a shelf... and is that a door at the back of the room?\n";
            }
            // else if (roomName = 'Cellar')
        }

        private void SetItems(string RoomName)
        {
            if (RoomName == "Library")
            {
                this.ItemsInRoom.Add("Spell Book");
                this.ItemsInRoom.Add("Mysterious Potion");
                this.ItemsInRoom.Add("Bone Key");
            }
        }

        private void UpdateItems(string item)
        {
            this.ItemsInRoom.Remove(item);
        }

        public string GetDescription()
        {
            this.Description = "A dusty library full of sorcery tomes and alchemy books. The air feels tense and you feel strange." +
                    "You see something glistening at the top of a shelf... and is that a door at the back of the room?";
            return Description;
        }

        public bool RoomContentCheck()
        {
            return ItemInside;
        }

        /* public int GetRoomContents(List<string> itemsInRoom)
        {
            int numberOfItems = itemsInRoom.Count;
            return numberOfItems;
        }
        */

        public string GetRoomName()
        {
            return RoomName;
        }

    }
    
}
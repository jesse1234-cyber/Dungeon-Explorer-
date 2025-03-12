using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonExplorer.Item.Items;

namespace DungeonExplorer.Room
{
    public class Room
    {
        private string description;
        private RoomT roomT;

        public Room(string description, RoomT roomT) {
            // Implement additional text formatting for the type of room
            switch (roomT)
        {

                case RoomT.passive:
                    description += " | PASSIVE ZONE |";
                    break;
                case RoomType.normal:
                    description += " | NORMAL ROOM |";
                    break;
                case RoomType.encounter:
                    description += " | ENCOUNTER ROOM |";
                    break;

                case RoomType.Store:
                    description += " | STORE ROOM |";
                    break;

                case RoomType.Event:
                    description += " | EVENT ROOM |";
                    break;
                default:
                    break;

            }

            this.description = description;

            this.roomT = roomT;
        }


        public string GetDescription() {

            return description;
        }

        public RoomT getRoomT() {
            return roomType;
        }

        public void EnterRoom(Player.Player player)
        {
            switch (roomT)
            {
                case RoomT.Event:
                    player.PickUpItem(new HealthPotion());
                    Console.WriteLine("You found a treasure room! You receive a health potion.");
                    break;
                case RoomT.None:
                    Console.WriteLine("You hit a wall.");
                    break;
                default:
                    Console.WriteLine("You entered a " + roomT.ToString().ToLower() + " room.");
                    break;
            }
        }
    }
}

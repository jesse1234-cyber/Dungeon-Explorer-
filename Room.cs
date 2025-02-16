using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DungeonExplorer
{
    public class Room
    {
        private string roomTitle;
        private string description;
        private bool searched;
        private int roomX;
        private int roomY;


        public Room(int roomX, int roomY)
        {
            this.roomX = roomX;
            this.roomY = roomY;
            List<string> roomInfo = GetNameAndDescription();
            roomTitle = roomInfo[0];
            description = roomInfo[1];
            searched = false;
        }

        private List<string> GetNameAndDescription()
        {
            List<string> outputList = new List<string>();
            List<string> descriptions = new List<string>();
            List<string> titles = new List<string>();
            Random rnd = new Random();
            try
            {
                string line;
                StreamReader sr = new StreamReader(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "//dungeons//Descriptions.txt");
                line = sr.ReadLine();

                while(line != null)
                {
                    string[] temp = line.Split('~');
                    titles.Add(temp[0]);
                    descriptions.Add(temp[1]);

                    line = sr.ReadLine();
                }

                sr.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception Caught: " + e);
            }


            int index = rnd.Next(titles.Count);

            outputList.Add(titles[index]);
            outputList.Add(descriptions[index]);

            return outputList;
        }

        public string GetDescription()
        {
            return description;
        }

        public string GetTitle()
        {
            return roomTitle;
        }

        public int GetRoomX()
        {
            return roomX;
        }

        public int GetRoomY()
        {
            return roomY;
        }

        public void RoomInfoMenu()
        {
            bool roomMenu = true;
            string command = "";
            while (roomMenu)
            {
                Console.WriteLine("Room Info Menu:");
                Console.WriteLine("1) Room Title");
                Console.WriteLine("2) Room Description");
                Console.WriteLine("3) Exit Room Info Menu");
                Console.WriteLine("Choose a command (title, desc, exit): ");
                Console.Write("> ");
                command = Console.ReadLine().ToLower();

                if (command == "title")
                {
                    Console.WriteLine(GetTitle());
                }
                else if (command == "desc")
                {
                    Console.WriteLine(GetDescription());
                }
                else if (command == "exit")
                {
                    roomMenu = false;
                }
                else
                {
                    Console.WriteLine("Invalid Command");
                }
            }
        }
        
        public Player SearchRoom(Player player)
        {
            // Check if the room has already been searched
            if (searched)
            {
                Console.WriteLine("You have already searched this room");
                return player;
            }

            Random rnd = new Random();
            int chance = rnd.Next(1, 101);

            if (chance <= 99)
            {
                Console.WriteLine("You search the room");
                Console.WriteLine("You find a health potion");
                Item healthPotion = new Item(1, "Health Potion", "A potion that restores 5 health");
                player.PickUpItem(healthPotion);
            }
            else
            {
                Console.WriteLine("You search the room");
                Console.WriteLine("You find nothing of interest");
            }
            searched = true;
            return player;
        }
    }
}
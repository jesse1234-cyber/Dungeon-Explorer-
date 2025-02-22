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

        // Room Constructor
        // Arguments:
        // roomX - the x position of the room
        // roomY - the y position of the room
        public Room(int roomX, int roomY)
        {
            // Get a random room title and description
            SetRoomX(roomX);
            SetRoomX(roomY);
            // Get a random room title and description
            List<string> roomInfo = GetNameAndDescription();
            // Set the room title and description
            SetTitle(roomInfo[0]);
            SetDescription(roomInfo[1]);
            SetSearched(false);
        }

        

        // Getters
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


        //Setters
        public void SetDescription(string description)
        {
            this.description = description;
        }
        public void SetTitle(string title)
        {
            this.roomTitle = title;
        }
        public void SetRoomX(int roomX)
        {
            this.roomX = roomX;
        }
        public void SetRoomY(int roomY)
        {
            this.roomY = roomY;
        }
        public void SetSearched(bool searched)
        {
            this.searched = searched;
        }

        //Methods

        // Get a random room title and description
        // Returns: a list containing the room title and description
        private List<string> GetNameAndDescription()
        {

            List<string> outputList = new List<string>();
            List<string> descriptions = new List<string>();
            List<string> titles = new List<string>();
            Random rnd = new Random();
            try
            {
                // Read the room titles and descriptions from Descriptions.txt
                string line;
                StreamReader sr = new StreamReader(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "//dungeons//Descriptions.txt");
                line = sr.ReadLine();

                // Checks if thee is a line to read
                while (line != null)
                {
                    // Splits the line into title and description
                    string[] temp = line.Split('~');
                    // Adds the title and description to the lists
                    titles.Add(temp[0]);
                    descriptions.Add(temp[1]);

                    line = sr.ReadLine();
                }

                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception Caught: " + e);
            }

            // Get a random index
            int index = rnd.Next(titles.Count);
            // Add the title and description to the output list
            outputList.Add(titles[index]);
            outputList.Add(descriptions[index]);

            return outputList;
        }

        // Room Info Menu
        public void RoomInfoMenu()
        {
            bool roomMenu = true;
            string command = "";
            // Room Info Menu
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
                    // Display the room title
                    Console.WriteLine(GetTitle());
                }
                else if (command == "desc")
                {
                    // Display the room description
                    Console.WriteLine(GetDescription());
                }
                else if (command == "exit")
                {
                    // Exit the room menu
                    roomMenu = false;
                }
                else
                {
                    // If the command is not valid
                    Console.WriteLine("Invalid Command");
                }
            }
        }

        // Search the room
        // Arguments:
        // player - the player searching the room
        // Returns: the player after searching the room
        public Player SearchRoom(Player player)
        {
            // Check if the room has already been searched
            if (searched)
            {
                Console.WriteLine("You have already searched this room");
                return player;
            }

            //Generate Random Number between 1 and 100
            Random rnd = new Random();
            int chance = rnd.Next(1, 101);

            // Check the random number
            if (chance <= 99)
            {
                // 99% chance of finding a health potion
                Console.WriteLine("You search the room");
                Console.WriteLine("You find a health potion");
                // Create a health potion item
                Item healthPotion = new Item(1, "Health Potion", "A potion that restores 5 health");
                // Add the health potion to the player's inventory
                player.PickUpItem(healthPotion);
            }
            else
            {
                // 1% chance of finding nothing
                Console.WriteLine("You search the room");
                Console.WriteLine("You find nothing of interest");
            }
            searched = true;
            return player;
        }
    }
}
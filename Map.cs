using System;

namespace DungeonExplorer
{
    public class Map
    {
        public int[,] layout;
        public int width;
        public int height;
        public Room[,] roomLayoutArray;
        // Map Constructor
        // Arguments:
        // width - the width of the map
        // height - the height of the map
        // startingRoom - the room the player starts in
        public Map(int width, int height, Room startingRoom)
        {
            // Create a new map
            this.width = width;
            this.height = height;
            Random rnd = new Random();
            layout = new int[width, height];
            roomLayoutArray = new Room[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    // Player always starts at top left of the map
                    // So top left is always 1
                    // 1 means there is a room and 0 means there isn't a room
                    if (i == 0 && j == 0)
                    {
                        //Starting Room
                        layout[i, j] = 1;
                        roomLayoutArray[i, j] = startingRoom;
                    }
                    else
                    {
                        // Randomly generate rooms
                        layout[i, j] = rnd.Next(0, 2);
                        // If there is a room, create a new room object
                        if (layout[i, j] == 1) roomLayoutArray[i, j] = new Room(i, j);
                    }
                }
            }
            
        }

        //Change the room
        //Arguments: currentRoom - the room the player is currently in
        //Returns: the room the player wants to move to
        public Room changeRoom(Room currentRoom)
        {
            string direction = "";
            int currentX = currentRoom.GetRoomX();
            int currentY = currentRoom.GetRoomY();
            bool roomMenu = true;
            while (roomMenu)
            {
                // Display the change room menu
                Console.WriteLine("Change Room Menu: ");
                Console.WriteLine("Commands:");
                Console.WriteLine("1) Right");
                Console.WriteLine("2) Left");
                Console.WriteLine("3) Up");
                Console.WriteLine("4) Down");
                Console.WriteLine("5) Exit");
                Console.WriteLine("Choose a command (right, left, up, down, exit): ");
                Console.Write("> ");
                direction = Console.ReadLine().ToLower();
                if (direction == "right")
                {
                    // Check if the room to the right exists
                    if (currentX + 1 <= width && layout[currentX +1,currentY] == 1)
                    {
                        // Return the room to the right
                        return roomLayoutArray[currentX + 1, currentY];
                    }
                }
                else if (direction == "left")
                {
                    // Check if the room to the left exists
                    if (currentX - 1 >= 0 && layout[currentX -1, currentY] == 1)
                    {
                        // Return the room to the left
                        return roomLayoutArray[currentX - 1, currentY];
                    }
                }
                else if (direction == "up")
                {
                    // Check if the room "above" exists
                    if (currentY - 1 >= 0 && layout[currentX, currentY -1] == 1)
                    {
                        // Return the room "above"
                        return roomLayoutArray[currentX, currentY - 1];
                    }
                }
                else if (direction == "down")
                {
                    // Check if the room "below" exists
                    if (currentY + 1 <= height && layout[currentX, currentY + 1] == 1)
                    {
                        // Return the room "below"
                        return roomLayoutArray[currentX, currentY + 1];
                    }
                }
                else if (direction == "exit")
                {
                    // Exit the room menu
                    roomMenu = false;
                }
                else
                {
                    // If a command is not recognised
                    Console.WriteLine("Invalid direction");
                }
                // If there is no door in the direction the player wants to go
                Console.WriteLine("There is no door to enter in that direction!");
                
            }
            // Return the currentRoom if the player exits the room menu
            return currentRoom;
        }
        

        // Display the current map
        public void DisplayMap()
        {
            Console.WriteLine("After reading your map you see:");
            for (int j = 0; j < width; j++)
            {
                for (int i = 0; i < height; i++)
                {
                    // Displays a O if there is a room and a X if there isn't
                    if (layout[i, j] == 1)
                    {
                        Console.Write("O");
                    }
                    else
                    {
                        Console.Write("X");
                    }
                }
                Console.WriteLine();
            }
        }
        
    }
}
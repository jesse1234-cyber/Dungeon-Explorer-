using System;

namespace DungeonExplorer
{
    public class Map
    {
        public int[,] layout;
        public int width;
        public int height;
        public Room[,] roomLayoutArray;
        public Map(int width, int height, Room startingRoom)
        {
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
                        layout[i, j] = 1;
                        roomLayoutArray[i, j] = startingRoom;
                    }
                    else
                    {
                        layout[i, j] = rnd.Next(0, 2);
                        if (layout[i, j] == 1) roomLayoutArray[i, j] = new Room(i, j);
                    }
                }
            }
            
        }

        public Room changeRoom(Room currentRoom)
        {
            string direction = "";
            int currentX = currentRoom.GetRoomX();
            int currentY = currentRoom.GetRoomY();
            bool roomMenu = true;
            while (roomMenu)
            {
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
                    if (currentX + 1 <= width && layout[currentX +1,currentY] == 1)
                    {
                        return roomLayoutArray[currentX + 1, currentY];
                    }
                }
                else if (direction == "left")
                {
                    if (currentX - 1 >= 0 && layout[currentX -1, currentY] == 1)
                    {
                        return roomLayoutArray[currentX - 1, currentY];
                    }
                }
                else if (direction == "up")
                {
                    if (currentY - 1 >= 0 && layout[currentX, currentY -1] == 1)
                    {
                        return roomLayoutArray[currentX, currentY - 1];
                    }
                }
                else if (direction == "down")
                {
                    if (currentY + 1 <= height && layout[currentX, currentY + 1] == 1)
                    {
                        return roomLayoutArray[currentX, currentY + 1];
                    }
                }
                else if (direction == "exit")
                {
                    roomMenu = false;
                }
                else
                {
                    Console.WriteLine("Invalid direction");
                }
                Console.WriteLine("There is no door to enter in that direction!");
                
            }
            return currentRoom;
        }
        public void DisplayMap()
        {
            Console.WriteLine("After reading your map you see:");
            for (int j = 0; j < width; j++)
            {
                for (int i = 0; i < height; i++)
                {
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
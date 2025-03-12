using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonExplorer.Player;
using DungeonExplorer.Room;


namespace DungeonExplorer.Managers {
    public class RoomManager {
        private Room.Room[,] rooms;
        private bool[,] visitedRooms;
        private int currentRow;
        private int currentCol;
        private string[,] levelLayout;

        // Creating the first level 
        public RoomManager()
        {
            InitializeRooms();
        }


        private void InitializeRooms()
        {
            // Initialize rooms for the first level of the dungeon using a 2D structure
            levelLayout = new string[,]
            {
                    { "S", "B", "N" },
                    { "N", "#", "N" },
                    { "N", "T", "N" }
            };


            int rows = levelLayout.GetLength(0);
            int cols = levelLayout.GetLength(1);
            rooms = new Room.Room[rows, cols];
            visitedRooms = new bool[rows, cols];


            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    string cell = levelLayout[row, col];
                    RoomType roomType = GetRoomTypeFromChar(cell);
                    if (roomType != RoomType.None)
                    {
                        rooms[row, col] = new Room.Room($"Room ({row},{col})", roomType);
                    }
                }
            }

            // Starts Player in the first room  at (0,0)
            currentRow = 0;
            currentCol = 0;
            visitedRooms[currentRow, currentCol] = true;
        }


        private RoomType GetRoomTypeFromChar(string cell)
        {
            switch (cell)
            {
                case "B":
                    return RoomType.Boss;
                case "N":
                    return RoomType.Normal;
                case "T":
                    return RoomType.Safe;
                case "S":
                    return RoomType.Shop;
                case "E":
                    return RoomType.Event;
                case "#":
                    return RoomType.None; // Wall hit
                default:
                    return RoomType.None;
            }
        }

        public Room.Room GetCurrentRoom()
        {
            return rooms[currentRow, currentCol];
        }


        public bool MovePlayer(string direction, Player.Player player)
        {
            int newRow = currentRow;
            int newCol = currentCol;


            switch (direction.ToLower())
            {
                case "up":
                    newRow--;
                    break;
                case "down":
                    newRow++;
                    break;
                case "left":
                    newCol--;
                    break;
                case "right":
                    newCol++;
                    break;
                default:
                    Console.WriteLine("Invalid input. Enter 'up', 'down', 'left', or 'right'.");
                    return false;
            }


            if (newRow >= 0 && newRow < rooms.GetLength(0) && newCol >= 0 && newCol < rooms.GetLength(1) && rooms[newRow, newCol] != null)
            {
                currentRow = newRow;
                currentCol = newCol;
                visitedRooms[currentRow, currentCol] = true;
                rooms[currentRow, currentCol].EnterRoom(player);  // Triggers room behavior
                return true;
            }
            else
            {
                Console.WriteLine("You can not move that way.");
                return false;
            }
        }

        // Display map  using 2D structure and current player position (P)
        public void DisplayMap()
        {
            int rows = levelLayout.GetLength(0);
            int cols = levelLayout.GetLength(1);

            // Print top border of map
            Console.WriteLine(" "); // For spacing
            Console.WriteLine("+" + new string('-', cols * 2) + "+");

            for (int row = 0; row < rows; row++)
            {
                Console.Write("|"); // Left border of map
                for (int col = 0; col < cols; col++)
                {
                    if (row == currentRow && col == currentCol)
                    {
                        Console.Write("P "); // Current position of PLayer
                    }
                    else if (levelLayout[row, col] == "#")
                    {
                        Console.Write("# "); // Wall
                    }
                    else if (visitedRooms[row, col])
                    {
                        Console.Write(levelLayout[row, col] + " ");
                    }
                    else
                    {
                        Console.Write("? ");
                    }
                }
                Console.WriteLine("|"); // Right border of map
            }

            // Print bottom border of map
            Console.WriteLine("+" + new string('-', cols * 2) + "+");
            Console.WriteLine(" "); // For spacing
        }
    }
}

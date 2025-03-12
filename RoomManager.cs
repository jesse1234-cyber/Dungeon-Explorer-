using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    /// <summary>
    /// Class to manage the creation of new rooms.
    /// </summary>
    public class RoomManager
    {
        /// <summary>
        /// A dictionary to map opposite directions.
        /// </summary>
        private static readonly Dictionary<string, string> OppositeDirections = new Dictionary<string, string>
        {
            { "North", "South" },
            { "South", "North" },
            { "East", "West" },
            { "West", "East" }
        };

        /// <summary>
        /// Creates a new room based on the direction the player is moving.
        /// </summary>
        /// <param name="roomID"> The unique ID of the room.</param>
        /// <param name="direction"> The direction the player is moving.</param>
        /// <param name="roomCount"> The number of rooms in the dungeon.</param>
        /// <param name="grid"> The grid that represents the dungeon.</param>
        /// <param name="playerX"> The new X-coordinate of the player's position.</param>
        /// <param name="playerY"> The new Y-coordinate of the player's position.</param>
        /// <param name="lastRoom"> Check to see if this room is the last room.</param>
        /// <returns> A new room object with exits, enemies and items.</returns>
        public Room CreateNewRoom(string roomID, string direction, int roomCount, Room[,] grid, int playerX, int playerY, bool lastRoom)
        {
            Room newRoom = new Room(roomID, GameData.GetRandomRoomDescription(), roomCount);

            // Add exit to previous room
            string oppositeDirection = OppositeDirections[direction];
            newRoom.AddExit(oppositeDirection);

            // Add new exits, but checks if there should already be one or not
            AddNewExits(newRoom, grid, playerX, playerY);

            // If it's not the last room, add random enemies and items
            if (!lastRoom)
            {
                AddRandomEnemiesAndItems(newRoom, roomCount);
            }
            else
            {
                // If it's the last room, add a final enemy and exit
                newRoom.Description = "You have reached the final room, be careful.";
                newRoom.Exits.RemoveRange(1, newRoom.Exits.Count - 1);
                newRoom.AddExit("Exit");
                newRoom.AddEnemy(GameData.GetRandomEnemy(5, 6));
            }

            return newRoom;
        }

        /// <summary>
        /// Adds new exits to the room based on the player's position.
        /// </summary>
        /// <param name="newRoom"> The room being created.</param>
        /// <param name="grid"> The grid representing the dungeon.</param>
        /// <param name="playerX"> The new X-coordinate of the player's position</param>
        /// <param name="playerY">The new Y-coordinate of the player's position</param>
        private void AddNewExits(Room newRoom, Room[,] grid, int playerX, int playerY)
        {
            bool doorAdded = false;
            Random random = new Random();

            // Loop to add at least one new valid room to the grid
            while (!doorAdded)
            {
                foreach (string key in OppositeDirections.Keys)
                {
                    int newX = playerX, newY = playerY;
                    string oppositeExit = "";

                    switch (key)
                    {
                        case "North": newY--; oppositeExit = "South"; break;
                        case "South": newY++; oppositeExit = "North"; break;
                        case "East": newX++; oppositeExit = "West"; break;
                        case "West": newX--; oppositeExit = "East"; break;
                    }

                    // Checks if the new room already has the exit
                    if (newRoom.Exits.Contains(key))
                        continue;

                    // Checks if the player is at the edge of the grid or if there is a room in the way
                    if (newX < 0 || newY < 0 || newX >= grid.GetLength(1) || newY >= grid.GetLength(0))
                        continue;
                    if (grid[newX, newY] != null && !grid[newX, newY].Exits.Contains(oppositeExit))
                        continue;

                    // Checks if there is a room in the way but it has an exit to the new room
                    if (grid[newX, newY] != null && grid[newX, newY].Exits.Contains(oppositeExit))
                    {
                        newRoom.AddExit(key);
                        continue;
                    }

                    // If it passes checks, attempt to add exit
                    int chance = random.Next(1, 5);
                    if (chance == 1)
                    {
                        newRoom.AddExit(key);
                        doorAdded = true;
                    }
                }
            }
        }

        /// <summary>
        /// Adds random enemies and items to the room based on the room number.
        /// </summary>
        /// <param name="newRoom"> The room being created.</param>
        /// <param name="roomCount"> The number of rooms in the dungeon.</param>
        private void AddRandomEnemiesAndItems(Room newRoom, int roomCount)
        {
            // Add random amount of enemies based on room number
            int amountOfEnemies = 1 + (roomCount / 3);
            for (int i = 0; i < amountOfEnemies; i++)
            {
                newRoom.AddEnemy(GameData.GetRandomEnemy(0, 1 + (roomCount / 2)));
            }

            // Add random amount of items based on room number
            int amountOfItems = 0 + (roomCount / 2);
            Random randomItem = new Random();
            for (int i = 0; i < amountOfItems; i++)
            {
                // For each item, there is a 50% chance of it being a potion or a weapon
                int chance = randomItem.Next(1, 3);
                if (chance == 1)
                {
                    newRoom.AddItem(GameData.GetRandomPotion((0 + roomCount / 5), (1 + roomCount / 3)).Key);
                }
                else
                {
                    newRoom.AddItem(GameData.GetRandomWeapon((2 + roomCount), (5 + roomCount)).Key);
                }
            }
        }
    }
}

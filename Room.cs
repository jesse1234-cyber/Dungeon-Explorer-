using System;
using System.Collections.Generic;

namespace Program
{
    /// <summary>
    /// X and Y Inverted: X is from 0 going DOWN,
    /// Y From 0 going Right
    /// </summary>
    public class Map
    {
        static int sizeX = 10, sizeY = 20;
        static Room[,] Arr = new Room[sizeX, sizeY]; public static Room getRoomFromArr(int x, int y) { return Arr[x, y]; }
       

        static public void Init(int startingposX, int startingposY)
        {
            // Initialize each room in the map array with a default character and description
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    Arr[i, j] = new Room('?', '?', "Description Example.");
                }
            }
            Arr[startingposX, startingposY].setFilledIn('⌂');
            Arr[startingposX, startingposY].setDescription("You're Home! Where you begin your adventure");
            Arr[startingposX, startingposY].FloorItems.Add(new InventoryItem("Sword", 1));

            // Setting up some sample room descriptions
            Arr[(startingposX + 1), startingposY].setDescription("Duelside-Depths");
            Arr[(startingposX - 1), startingposY].setDescription("Green, Grassy Plateu. You feel safe here");
            Arr[(startingposX), startingposY - 1].setDescription("Base of Mount Hylia");
            Arr[(startingposX), startingposY + 1].setDescription("Path To Kakariko");

            // Set the starting position of the player as 'U'
            Arr[startingposX, startingposY].setC('U');
        }


        static public void Show()
        {
            Console.WriteLine("   Current Map:    ");
            Console.WriteLine("[U]: Your Current Location");
            Console.WriteLine("[?]: Not Visited Area");
            // Loop through all the rooms on the map and display their current character (? if user hasnt been there yet)
            for (int i = 0; i < sizeX; i++) // Loop through the X axis (width)
            {
                for (int j = 0; j < sizeY; j++) // Loop through the Y axis (height)
                {
                    Console.Write(Arr[i, j].getC()); // Display the character of the room
                }
                Console.WriteLine(); // Move to the next line after each row of the map
            }
        }


        static public void UpdateMap(int posX, int posY, int NposX, int NposY)
        {
            
            Arr[posX, posY].setC(Arr[posX, posY].getFilledIn());    // Reset old room position            
            Arr[NposX, NposY].setC('U');          // Put U in new space
        }

        static public bool IsValidPosition(int x, int y)
        {
            return x >= 0 && y >= 0 && x < Arr.GetLength(0) && y < Arr.GetLength(1); // Checks that moving wouldnt be invalid IE out of the bounds
        }

    }

    // Class for room with its current map char, C and FilledIn map char (Only readable) so the player can build out the map
    public class Room
    {
        public List<InventoryItem> FloorItems = new List<InventoryItem>();
        char FilledIn; public char getFilledIn() { return FilledIn;  } public void setFilledIn(char c) { FilledIn = c; }
        char C; public char getC() { return C; } public void setC(char c) { C = c;  }
        private string description;

        public Room(char filledIn, char c, string description)
        {
            FilledIn = filledIn;
            C = c;
            this.description = description;
        }
        public void setDescription(string d)
        {
            description = d;
        }
        public string GetDescription()
        {
            return description;
        }
    }
}
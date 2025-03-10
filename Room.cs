using System;

namespace Program
{
    public class Map
    {
        static int sizeX = 10, sizeY = 20;
        static Room[,] Arr = new Room[sizeX, sizeY];

        static public void Init(int startingposX, int startingposY)
        {
            // Initialize each room in the map with a default character and description
            for (int i = 0; i < sizeX; i++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    Arr[i, j] = new Room('?', '?', "Description Example.");
                }
            }

            // Set the starting position of the player as 'U'
            Arr[startingposX, startingposY].setC('U');
        }


        static public void Show()
        {
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
            // Check if both the old and new positions are valid
            if (IsValidPosition(posX, posY) && IsValidPosition(NposX, NposY))
            {
                // Restore the previous room's state by using the "filled-in" character
                Arr[posX, posY].setC(Arr[posX, posY].getFilledIn());                
                Arr[NposX, NposY].setC('U');
            }
        }

        static public bool IsValidPosition(int x, int y)
        {
            return x >= 0 && y >= 0 && x < Arr.GetLength(0) && y < Arr.GetLength(1); // Checks that moving wouldnt be invalid IE out of the bounds
        }

    }

    // Class for room with its current map char, C and FilledIn map char (Only readable) so the player can build out the map
    public class Room
    {
        char FilledIn; public char getFilledIn() { return FilledIn;  }
        char C; public char getC() { return C; } public void setC(char c) { C = c;  }
        private string description;

        public Room(char filledIn, char c, string description)
        {
            FilledIn = filledIn;
            C = c;
            this.description = description;
        }

        public string GetDescription()
        {
            return description;
        }
    }
}
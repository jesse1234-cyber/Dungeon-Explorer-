using System;

namespace Program
{
    public class Map
    {
        static int sizeX = 10, sizeY = 20;
        static Room[,] Arr = new Room[sizeX, sizeY];
        
        static public void Init(int startingposX, int startingposY)
        {
            for (int i = 0; i < (sizeX - 1); i++)
            {
                for (int j = 0; j < (sizeY - 1); j++)
                {
                    Arr[i, j] = new Room('?', '?', "Description Example."); 
                }
            }
            Arr[startingposX, startingposY].setC('U');
        }

        static public void Show()
        {
            for (int i = 0; i < (sizeX - 1); i++)
            {
                for (int j = 0; j < (sizeY - 1); j++)
                {
                    Console.Write(Arr[i, j].getC());
                }
                Console.WriteLine();
            }
        }

        static public void UpdateMap(int posX, int posY, int NposX, int NposY)
        {
            Arr[posX, posY].setC(Arr[posX, posY].getFilledIn());
            Arr[NposX, NposY].setC('U');
        }

    }


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
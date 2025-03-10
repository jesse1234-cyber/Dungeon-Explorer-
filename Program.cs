using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Room roomLeft = new Room("Spider");
            Room roomRight = new Room("Snake");

            Player Player1 = new Player(100);
            Game.GameStart();
            Player1.ShowHealth();     
            Game.StoryOpening();
            switch (Game.RoomChoice1())
            {
                case "left":
                    Player1.CurrentRoom = roomLeft;
                    break;
                   
                case "Right":
                    Player1.CurrentRoom = roomRight;
                    break; 
            }
            Console.WriteLine(Player1.CurrentRoom.GetDescription());
            
        }
    }
}

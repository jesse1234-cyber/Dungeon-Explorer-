using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Media;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        private List<Room> allRooms;

        public Game()
        {
            this.player = new Player("Username", 100);
        }
        public void GenerateRooms()
        {
            string design = @"Before you is a large pair of oak doors,
                held together with wrought iron bolts, rusted due to time.
                Beside the doors, rests small lanterns, they look to have
                been untouched for years. The doors themsleves are inset into
                a marble frame, that itself looks remarkably clean in contrast
                to its surroundings.";
            design = design.Replace("                ", "");
            Room mainEntrance = new Room(design);
            mainEntrance.SetItem("Empty Lantern", "This item can be combined with a candle to create a light source, letting you traverse dark rooms.");
            string action = @"You reach up to where one of the lanterns
                rests. Finding the candle has long since been useable, you 
                extract and discard the residual wax, safely storing the 
                lantern away in your bag.";
            action = action.Replace("                ", " ");
            mainEntrance.SetAction(action);
            mainEntrance.SetIndex(0);
            this.allRooms.Add(mainEntrance);
            design = @"";
            design = design.Replace("                ", " ");
            Room foyer = new Room(design);
            foyer.SetItem("","");
        }
        public void SetCurrentRoom()
        {
            this.currentRoom = allRooms[player.GetRoomIndex()];
        }
        public void Start()
        {
            bool playing = true;
            while (playing)
            {
                Console.WriteLine("1. Look around the room.");
                Console.WriteLine("2. Display status.");
                Console.WriteLine("3. Pickup item");
                Console.WriteLine("4. Move");
                Console.WriteLine("0. Exit Game");
                Console.WriteLine("Please enter a listed value to continue... ");
                bool loop = true;
                
                
                while (loop == true)
                {
                    ConsoleKeyInfo valueTest = Console.ReadKey();
                    
                    if ("1" == valueTest.KeyChar.ToString())
                    {
                        Console.Write($"\n{this.currentRoom.GetDescription()}\n");
                    }
                    else if ("2" == valueTest.KeyChar.ToString())
                    {
                        Console.Write($"\n{this.player.GetStatus()}\n");
                    }
                    else if ("3" == valueTest.KeyChar.ToString())
                    {
                        Console.Write($"\n{currentRoom.GetAction()}\n");
                        player.PickUpItem(currentRoom.GetCollectable());
                    }
                    else if ("4" == valueTest.KeyChar.ToString())
                    {
                        Console.WriteLine("null");
                    }
                    else if ("0" == valueTest.KeyChar.ToString())
                    {
                        Console.Write("\nThank you for playing\nExiting...\nPress any key to continue\n");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("\nThat is not a valid input.\nPlease try again...\n");
                    }
                }
            }
        }
    }
}
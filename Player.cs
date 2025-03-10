using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public static string Name { get; private set; }
        public static int Health { get; private set; }
        private List<string> inventory = new List<string>();
       // public var playerInventory = InventoryContents();

        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
        }
        public void PickUpItem(string item)
        {

        }
        //public static string InventoryContents()
        //{
        //    return string.Join(", ", inventory);
        //}

        public static string GetPlayerName()
        {
            Console.WriteLine("");
            Console.WriteLine("Please enter your name: ");
            var inputName = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(inputName))
            {
                Console.WriteLine("");
                Console.WriteLine("Please enter a valid name");
                return GetPlayerName();
            }
            else
            {
                return inputName;
            }
           

        }

    }
}
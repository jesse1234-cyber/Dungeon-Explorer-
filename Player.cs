using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public static string Name { get; private set; }
        public static int Health { get; private set; }
        
        public static List<string> inventory = new List<string>();
       // public var playerInventory = InventoryContents();

        public Player(string name, int health) 
        {
            Name = name;
            Health = health;

            inventory.Add("30ft of rope");
            inventory.Add("candle");
        }
        public void PickUpItem(string item)
        {
            inventory.Add(item);
        }
        public static void InventoryContents()
        {
            Console.WriteLine($"You have the following items in your inventory: {string.Join(", ", inventory)}");
            Console.WriteLine("Write the item name to equip...");

            var inputInv = Console.ReadLine();

            if (inventory.Contains(inputInv.ToLower()))
            {
                Console.WriteLine($"You have equipped {inputInv}");
            }

        }

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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> inventory = new List<string>();

        public Player(string name, int health) 
        {
            Name = GetName();
            Health = 5;
        }

        public string GetName(string name)
        {
            Console.WriteLine("What is your name?");
            public string Name = Console.ReadLine();
        }

        public void GetItem(string item)
        {
            Random rnd = new Random();
            int itemRoll = rnd.Next(1, 3);
            switch (itemRoll)
            {
                case 1:
                    item = "Dagger"
                    break
                case 2:
                    item = "Spell Book"
                    break
                case 3:
                    item = "Mysterious Potion"
                    break
            }
        }

        public void UseItem(string item, List inventory, int health)
        {
            inInventory = Array.Exists(inventory, element ==> element == item)
            if (inInventory)
            {
                if (item == "Mysterious Potion")
                {
                    Console.WriteLine("You chug the mysterious potion...");
                    int potRoll = rnd.Next(1, 2);
                    switch (potRoll)
                    {
                        case 1:
                            Console.WriteLine("Ew! BLEUGH! That potion was disgusting! You feel weird... queasy... and you lose 1 HP.")
                            health -= 1
                        case 2:
                            Console.WriteLine("Amazing, and... magical? You gain 1 HP, and also a nice taste in your mouth! Yum!")
                            health += 1
                    }
                }
        }

        public void PickUpItem(string item)
        {
            itemRoll = Random.Next()
            inventory.Add(string item);
            Console.WriteLine("You picked up the", item);

        }
        public string InventoryContents()
        {
            return string.Join(", ", inventory);
        }
    }
}
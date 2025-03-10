using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> inventory = new List<string>();
        public bool HasKey;

        public Player(string name, int health, bool HasKey) 
        {
            Name = "default";
            Health = 5;
            HasKey = false;
        }

        public string GetName()
        {
            Console.WriteLine("What is your name?");
            Name = Console.ReadLine();
            return Name;
        }

        public int GetHealth()
        {
            return Health;
        }

        /* public void RandomiseItem(string item)
        {
            Random rnd = new Random();
            int itemRoll = rnd.Next(1, 3);
            switch (itemRoll)
            {
                case 1:
                    item = "Dagger";
                    break;
                case 2:
                    item = "Spell Book";
                    break;
                case 3:
                    item = "Mysterious Potion";
                    break;
            }
        } */

        /* public void UseItem(string item, int health)
        {
            inInventory = Array.Exists(inventory, element => element == item);
            if (inInventory)
            {
                if (item == "Mysterious Potion")
                {
                    Console.WriteLine("You chug the mysterious potion...");
                    int potRoll = rnd.Next(1, 2);
                    switch (potRoll)
                    {
                        case 1:
                            Console.WriteLine("Ew! BLEUGH! That potion was disgusting! You feel weird... queasy... and you lose 1 HP.");
                            health -= 1;
                        case 2:
                            Console.WriteLine("Amazing, and... magical? You gain 1 HP, and also a nice taste in your mouth! Yum!");
                            health += 1;
                    }
                }
            }
        } */

        public void PickUpItem(string item)
        {
            Console.WriteLine($"The glistening turned out to be a {item}! You try to pick it up...");
            Console.WriteLine("Rolling dice...\nYou rolled...\n");
            Thread.Sleep(1000);
            Random rnd = new Random();
            int itemRoll = rnd.Next(1, 10);
            Console.WriteLine(itemRoll + "!");
            if (itemRoll < 7)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"You carefully put the {item} in your backpack.\n");
                inventory.Add(item);
            }
            else
            {
                Console.WriteLine($"Oops! A huge spider crawls out from behind the {item}, startling you. You drop the {item} onto the floor, and it gets stuck under a bookshelf.\n");
            }
        }
        public string GetInventoryContents()
        {
            return string.Join(", ", inventory);
        }

        /*public bool CheckKey()
        {
            bool keyInInv = Array.Exists(Player.inventory, element => element == "Bone Key");
            if (keyInInv == true) {
                bool hasKey = true;
            }
            else
            {
                bool hasKey = false;
            }
            return hasKey;
        } */

        public bool TryOpenDoor()
        {
            bool keyInInv = inventory.Contains("Bone Key");
            if (keyInInv == true)
            {
                Console.WriteLine("You put the key in the lock, and it turns! The door creaks as you push it open...");
                Console.WriteLine("...");
                Thread.Sleep(1000);
                Console.WriteLine("The end... for now");
                return true;
            }
            else
            {
                Console.WriteLine("You try to turn the handle, but it doesn't budge. You should try to find a key...");
                return false;
            }
        }

        public bool UpdateHasKey(string item)
        {
            bool hasKey = true;
            return hasKey;
        }
    }
}
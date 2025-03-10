using System;
using System.Collections.Generic;
using System.Threading;

namespace DungeonExplorer
{
    public class Player
    {
        private string name;
        private int health;
        private List<string> inventory = new List<string>();

        public Player(string name, int health)
        {
            this.name = name;
            this.health = 5;
        }

        public string GetName()
        {
            return this.name;
        }

        public int GetHealth()
        {
            return this.health;
        }
        public string GetInventoryContents()
        {
            return string.Join(", ", inventory);
        }
        public void PickUpItem(string item)
        {
            Console.WriteLine($"The glistening turned out to be a {item}! You try to pick it up...");
            Console.WriteLine("Rolling dice...\nYou rolled...\n");
            Thread.Sleep(1000);
            Random rnd = new Random();
            int itemRoll = rnd.Next(1, 10);
            Console.WriteLine(itemRoll + "!");
            if (itemRoll < 8)
            {
                Thread.Sleep(1000);
                Console.WriteLine($"You carefully put the {item} in your backpack.\n");
                inventory.Add(item);
            }
            else
            {
                Console.WriteLine($"Oops! A huge spider crawls out from behind the {item}, startling you." +
                    $"You drop the {item} onto the floor, and it gets stuck under a bookshelf.\n");
            }
        }

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
    }
}
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
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
        public string PickUpItem(string item)
        {
            inventory.Add(item);
            return item;
        }

        public bool TryOpenDoor()
        {
            bool keyInInv = inventory.Contains("Bone Key");
            if (keyInInv == true) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
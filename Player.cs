using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Linq;

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
            this.health = health;
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
            return string.Join(", ", this.inventory);
        }
        public void PickUpItem(string item)
        {
            this.inventory.Add(item);
        }

        public bool TryOpenDoor()
        {
            return (this.inventory.Contains("Bone Key"));
        }

        public bool IsInvEmpty()
        {
            return !this.inventory.Any();
        }
    }
}
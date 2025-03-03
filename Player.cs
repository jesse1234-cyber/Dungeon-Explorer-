﻿using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        private string name;
        private int health;
        private List<string> inventory;
        static Random rnd = new Random();

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Health
        {
            get { return health; }
            set
            {
                if (value < 0)
                {
                    health = 0;
                }
                else
                {
                    health = value;
                }
            }
        }

        public List<string> Inventory
        {
            get { return inventory; }
            set { inventory = value; }
        }

        public Player(string name, int health, List<string> inventory) 
        {

            name = Name;
            health = Health;
            inventory = Inventory;

        }

        public void PickUpItem(string item)
        {
            inventory.Add(item);
        }
        public string InventoryContents()
        {
            return string.Join(", ", inventory);
        }
    }
}
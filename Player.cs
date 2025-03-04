﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> inventory = new List<string>();
        private int roomIndex = 0;

        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
        }
        public void PickUpItem(string[] collectable)
        {
            this.inventory.AddRange(collectable);
        }
        public string InventoryContents()
        {
            return string.Join("\n", inventory);
        }
        public string GetStatus()
        {
            string healthString = Health.ToString();
            string archive = InventoryContents();
            int archiveCount = archive.Length;
            if (archiveCount <=2)
            {
                archive = "Empty";
            }
            return $"Health: {healthString}\nInventory:\n{archive}";
            
        }
        public int GetRoomIndex()
        {
            return this.roomIndex;
        }
        public void SetRoomIndex(int roomIndexUpdate)
        {
            this.roomIndex = roomIndexUpdate;
        }
    }
}
using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player : Intro
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> inventory = new List<string>();

        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
        }

        public void DisplayUsername()
        {
            PrintLetterByLetter($"{Name}", 50);
        }
        public void PickUpItem(string item)
        {
            PrintLetterByLetter($"Picked up: {item}", 50);
        }
        public string InventoryContents()
        {
            return string.Join(", ", inventory);
        }
    }
}
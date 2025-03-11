using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        private string PlayerName = "player";
        private int PlayerHealth;
        private List<string> PlayerInventory = new List<string>();

        public Player(string PlayerName, int PlayerHealth, List<string> PlayerInventory) 
        {
            Name =  PlayerName;
            Health = PlayerHealth;
            Inventory = PlayerInventory;
        }
        public string Name
        {
            get { return PlayerName; }
            set { PlayerName = string.IsNullOrWhiteSpace(value) ? "player" : value; }
        }
        public int Health
        {
            get { return PlayerHealth; }
            set { PlayerHealth = value; }
        }
        public List<string> Inventory
        {
            get { return PlayerInventory; }
            set { PlayerInventory = value ?? new List<string>(); }
        }
        public void setPlayerName()
        {
            string playerNameInput;
            do
            {
                Console.WriteLine("What name do you wish to play under: ");
                playerNameInput = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(playerNameInput));

            Name = playerNameInput;
            Console.WriteLine($"Hello, {Name}! You are starting with {Health} health points");
        }
        public void PickUpItem(string roomItem)
        {
            string pickUpItem;
            do
            {
                Console.WriteLine($"There is {roomItem} in this room. Do you wish to pick it up? (Y/N): ");
                pickUpItem = Console.ReadLine().ToUpper();
            }
            while (pickUpItem != "Y" && pickUpItem != "N");

            if (pickUpItem == "Y")
            {
                PlayerInventory.Add(roomItem);
                Console.WriteLine($"Item {roomItem} picked up!");
                Console.WriteLine($"{Name}, your inventory contains: {InventoryContents()}, and your hp is {Health}");
            }
            else if (pickUpItem == "N")
            {
                Console.WriteLine($"{roomItem} not picked up");
            }
        }
        public string InventoryContents()
        {
            return string.Join(", ", Inventory);
        }
    }
}
using System.Collections.Generic;
using System;

public class Player
{
    public string Name { get; set; }
    public int Health { get; set; }
    public Room CurrentRoom { get; set; }
    public List<string> Inventory { get; set; } = new List<string>();

    // Constructor to initialize player with name, health, and starting room
    public Player(string name, int health, Room currentRoom)
    {
        Name = name;
        Health = health;
        CurrentRoom = currentRoom;
    }

    // Method to pick up an item from the current room
    public void PickUpItem()
    {
        if (CurrentRoom.HasItem())
        {
            string item = CurrentRoom.Item;
            Console.WriteLine($"You picked up the {item}!");
            Inventory.Add(item);
            CurrentRoom.RemoveItem(); // Remove the item from the room
        }
        else
        {
            Console.WriteLine("There is no item to collect here.");
        }
    }

    // Property to show the contents of the inventory
    public string InventoryContents => Inventory.Count > 0 ? string.Join(", ", Inventory) : "Your inventory is empty.";
}

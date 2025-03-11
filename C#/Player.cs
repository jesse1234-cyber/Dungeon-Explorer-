using System.Collections.Generic;
using System;

public class Player
{
    public string Name { get; set; }
    public int Health { get; set; }
    public Room CurrentRoom { get; set; }
    public List<string> Inventory { get; set; } = new List<string>();

    //Initialise the player attributes
    public Player(string name, int health, Room currentRoom)
    {
        Name = name;
        Health = health;
        CurrentRoom = currentRoom;
    }

    public void PickUpItem(string item)
    {
        Console.WriteLine($"You picked up the {item}!");
        Inventory.Add(item);
    }

    public string InventoryContents => Inventory.Count > 0 ? string.Join(", ", Inventory) : "Your inventory is empty.";
}

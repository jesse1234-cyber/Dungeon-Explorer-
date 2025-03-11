using System.Collections.Generic;

public class Room
{
    public string Description { get; private set; }
    public List<string> Items { get; private set; }
    public List<string> Monsters { get; private set; }

    public Room(string description, List<string> items, List<string> monsters)
    {
        Description = description;
        Items = items ?? new List<string>();
        Monsters = monsters ?? new List<string>();
    }

    public bool HasItems() => Items.Count > 0;
    public bool HasMonsters() => Monsters.Count > 0;

    public void RemoveItem(string item)
    {
        Items.Remove(item);
    }

    public void RemoveMonster(string monster)
    {
        Monsters.Remove(monster);
    }

    // New method to return a detailed description of the room
    public string GetDescription()
    {
        string itemText = HasItems() ? $"Items: {string.Join(", ", Items)}" : "No items here.";
        string monsterText = HasMonsters() ? $"Monsters: {string.Join(", ", Monsters)}" : "No monsters here.";

        return $"{Description}\n\n{itemText}\n{monsterText}";
    }
}

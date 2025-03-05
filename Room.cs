public class Room
{
    public string Description { get; private set; }
    public string Item { get; private set; }
    public bool HasItem() => !string.IsNullOrEmpty(Item); // Check if there's an item in the room

    public Room(string description, string item)
    {
        Description = description;
        Item = item;
    }

    public void RemoveItem()
    {
        Item = null; // Remove the item from the room
    }
}

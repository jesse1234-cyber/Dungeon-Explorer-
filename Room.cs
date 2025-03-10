public class Room {
    private string _description;
    private string _item;

    public Room(string description, string item = "") {
        _description = description;
        _item = item;
    }

    // Get room description
    public string GetDescription() => _description;

    // Check if the room has an item
    public bool HasItem() => !string.IsNullOrEmpty(_item);

    // Method to take the item (if exists)
    public string TakeItem() {
        if (HasItem()) {
            string item = _item;
            _item = ""; // Remove item from room
            return item;
        } else {
            throw new InvalidOperationException("No item in this room!");
        }
    }
}
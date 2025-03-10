public class Player {
    // Private fields with encapsulation
    private string _name;
    private int _health;
    private string _inventory;

    public Player(string name) {
        _name = name;
        _health = 100; // Default health
        _inventory = ""; // Single item
    }

    // Getters and setters
    public string Name { get => _name; }
    public int Health { 
        get => _health; 
        set {
            if (value < 0) _health = 0;
            else _health = value;
        }
    }
    public string Inventory { get => _inventory; }

    // Method to pick up an item
    public void PickUpItem(string item) {
        if (string.IsNullOrEmpty(_inventory)) {
            _inventory = item;
        } else {
            throw new InvalidOperationException("Inventory is full!");
        }
    }

    // Display player status
    public string GetStatus() {
        return $"Name: {_name}\nHealth: {_health}\nInventory: {_inventory}";
    }
}
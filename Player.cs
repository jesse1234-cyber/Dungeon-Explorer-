public class Player
{
    public string name;
    private int health;
    private string inventory;

    // Contructor to track player's name and a single attribute sucha s health or a basic inventory.
    public Player(string name, int health = 100)
    {
        Debug.Assert(!string.IsNullOrWhiteSpace(name))," No empty or white space for player's name"); // Debug assertion

        Name = name; // Use property instead of direct field access
        Health = health;
        Inventory = ""; // Empty default inventory


    }

    // getter and setter for player's name

    public string Name
    {
        get { return name; }
        set
        {
            Debug.Assert(string.IsNullOrWhiteSpace(value), "Name can't be empty!"); // Debug assertion  
        }
    }

    // getter and setter for Health and validation
    public int Health
    {
        get { return health; }
        set
        {
            if (value < 0)
                health = 0; // prevents assingment to negative numbers
            else if (value > 100)
                health = 100; // ensure maximum health is 100
            else
                health = value;


        }
    }

    //getter and asetter for inventory

    public string Inventory
    {
        get { return inventory; }
        set
        {
            inventory = !string.IsNullOrWhiteSpace(value) ? value : "Empty"; // Default value

        }
    }

    // Method to pick up item
    public void PickUpItem(string item)
    {
        if (!string.IsNullOrEmpty(item))
        {
            inventory = item;
            Console.WriteLine($"You picked up an {item}");
        }
        else
        {
            Console.WriteLine("There is nothing to pick up.");

        }
    }


    //Method for dislaying player info

    public void DisplayPlayer()
    {
        Console.WriteLine($"Player:{Name} , Health:{Health}, Inventory:{Inventory}");
    }

}




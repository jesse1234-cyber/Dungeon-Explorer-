public class Game
{
    private Player player;
    private List<Room> rooms;   // Store multiple rooms
    private Room currentRoom;

    public Game()
    {
        player = new Player("Player1", 100);
        
        // Initialize rooms
        rooms = new List<Room>
        {
            new Room("The First Room", "A dark, quiet room."),
            new Room("The Second Room", "A brightly lit room with a painting on the wall."),
            new Room("The Treasure Room", "A room filled with treasure.")
        };

        // Set the initial room
        currentRoom = rooms[0];  // Start in the first room
    }

    public void Start()
    {
        bool playing = true;
        while (playing)
        {
            Console.Clear();
            Console.WriteLine(currentRoom.GetDescription());
            DisplayPlayerStatus();

            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine("1. View Status");
            Console.WriteLine("2. Explore Next Room");
            Console.WriteLine("3. Exit Game");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    DisplayPlayerStatus();
                    break;
                case "2":
                    ExploreNextRoom();
                    break;
                case "3":
                    Console.WriteLine("Exiting game...");
                    playing = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private void ExploreNextRoom()
    {
        // Move to the next room (if available)
        int currentIndex = rooms.IndexOf(currentRoom);
        if (currentIndex < rooms.Count - 1)
        {
            currentRoom = rooms[currentIndex + 1];  // Move to the next room
        }
        else
        {
            Console.WriteLine("You have reached the last room.");
        }
    }

    private void DisplayPlayerStatus()
    {
        Console.WriteLine($"Player: {player.Name}");
        Console.WriteLine($"Health: {player.Health}");
        Console.WriteLine($"Inventory: {player.InventoryContents()}");
    }
}

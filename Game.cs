public class Game {
    private Player _player;
    private Room _currentRoom;

    public Game() {
        // Initialize player and starting room
        _player = new Player("Hero");
        _currentRoom = new Room(
            "You are in a dark room. There's a rusty key on the floor.", 
            "rusty key"
        );
    }

    // Start the game loop
    public void Start() {
        Console.WriteLine("=== Dungeon Explorer ===");
        Console.WriteLine(_currentRoom.GetDescription());

        bool isRunning = true;
        while (isRunning) {
            Console.WriteLine("\nWhat do you want to do?");
            Console.WriteLine("1. Check status\n2. Pick up item\n3. Quit");
            string input = Console.ReadLine();

            switch (input) {
                case "1":
                    Console.WriteLine(_player.GetStatus());
                    break;
                case "2":
                    try {
                        string item = _currentRoom.TakeItem();
                        _player.PickUpItem(item);
                        Console.WriteLine($"You picked up: {item}");
                    } catch (InvalidOperationException e) {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case "3":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid input!");
                    break;
            }
        }
    }
}
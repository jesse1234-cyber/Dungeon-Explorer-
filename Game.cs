// Game class

public class Game
{
    private Player player;
    private Room thisRoom;

    // begins the game and initializes player and first room
    public void BeginGame()
    {
        Console.Write("Please enter your player's name: ");
        string playerName = Console.ReadLine();
        player = new Player(playerName);
        player.Name = playerName;

        // initialize first room
        thisRoom = new Room("A dark, gloomy dungeon room. A sword is on the ground.", "A sword");

        Console.WriteLine("\nWelcome to Dungeon Explorer!");
        GameLoop();



    }
    //Main game Loop
    private void GameLoop()
    {
        bool playing = true;
        while (playing)
        {
            Console.WriteLine("\n" + thisRoom.GetDesccription()); // shows room description
            Console.WriteLine("Options: (1) Pick up item , (2) Check status , (3) Exit ");

            string option= Console .ReadLine();
            switch (option)
            {
                case "1":
                    player.PickUpItem(this.thisRoom.GetItem()); // pick up item from room

                    break;
                case "2":
                    player.DisplayPlayer(); //Shows player's stats

                    break;
                case "3":
                    playing = false;

                    Console.WriteLine("Thanks for playing!");
                    break;
                default:
                    Console.WriteLine("Invalid option, Try again!");
                    break;



            }
        }
    }

}
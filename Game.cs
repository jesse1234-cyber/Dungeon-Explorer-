using System;

public class Game
{
    private Player newPlayer;
    private Room currentRoom;

    public void menuSystem()
    {
        Console.WriteLine("{ 1 } Explore the hidden secrets...\n{ 2 } Exit Game");
    }

    public Game()
    {
        // Initialize the game with one room and one player
        Room startingRoom = new Room("Cold stone presses against your back as you awaken in the dim glow of flickering torches." +
            "The air is thick with dust and decay. A heavy wooden door stands slightly ajar, its rusted hinges groaning in the silence." +
            "Bones and tattered cloth litter the corners, grim reminders of past explorers. In the distance, water drips, echoing through the unseen depths beyond.", "Torch");

        this.currentRoom = startingRoom;

        // Now this works since the Player constructor takes 3 arguments
        newPlayer = new Player("Hero", 100, startingRoom);

        Console.WriteLine("\n----- DUNGEON EXPLORER -----");
        Start();
    }

    public void Start()
    {
        bool playing = true;
        while (playing)
        {
            try
            {
                menuSystem();
                Console.Write("Enter Choice: ");
                int userChoice = int.Parse(Console.ReadLine());

                if (userChoice == 1)
                {
                    Console.Clear();
                    Console.WriteLine($"Player: {newPlayer.Name} \nHealth: {newPlayer.Health}");
                    Console.WriteLine($"Inventory: {newPlayer.InventoryContents}");
                    Console.WriteLine($"\nRoom description: \n{newPlayer.CurrentRoom.Description}");
                    

                    Console.WriteLine("There is an item, would you like to pick it up?\nY or N");
                    string itemPickUp = Console.ReadLine().ToUpper();

                    if (itemPickUp == "Y")
                    {
                        newPlayer.PickUpItem(); // Call method to pick up the item
                        Console.WriteLine($"Inventory: {newPlayer.InventoryContents}"); // Show updated inventory
                        break;
                    }
                    else if (itemPickUp == "N")
                    {
                        Console.WriteLine("You chose not to pick up the item.");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 'Y' or 'N'.");
                    }
                }
                else if (userChoice == 2)
                {
                    Console.WriteLine("Your adventure continues another day...");
                    playing = false;
                }
                else
                {
                    Console.WriteLine("Invalid choice, please try again.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has occurred: {ex.Message}");
                Console.Clear();
            }
        }
    }
}

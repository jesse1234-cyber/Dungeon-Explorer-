namespace DungeonExplorer
using System;

namespace DungeonExplorer
{
    /// <summary>
    /// Represents a room in the dungeon with a description and potential items.
    /// The room may contain an item (e.g., sword, shield, potion), and the player can interact with the room.
    /// </summary>
    public class Room
    {
        // Static Random object for generating random item selection
        private static readonly Random Random = new Random();
        
        // Static array of possible room descriptions
        private static readonly string[] RoomDescriptions = 
        {
            "The walls are pristine and adorned with torches.",
            "You see cobwebs hanging from the ceiling.",
            "A foul stench fills the air."
        };

        // Static array of possible items that could be in a room (including null for empty rooms)
        private static readonly string[] RoomItems = 
        { 
            "sword", "shield", "potion", "key", null 
        };

        // Public properties for room description and item found in the room
        public string Description { get; private set; }
        public string Item { get; private set; }

        /// <summary>
        /// Constructor that initializes a room with a description and item.
        /// The description is chosen based on the room number (modulo the number of available descriptions).
        /// The item is randomly chosen from the list of possible items.
        /// </summary>
        /// <param name="roomNumber">The number of the room, which helps determine the description.</param>
        public Room(int roomNumber)
        {
            // Assign a description based on the room number (wrapping around if necessary)
            Description = RoomDescriptions[roomNumber % RoomDescriptions.Length];

            // Randomly select an item for the room (or null for an empty room)
            Item = RoomItems[Random.Next(RoomItems.Length)];
        }

        /// <summary>
        /// Displays the room's description and prompts the player to interact with any item found in the room.
        /// If an item is found, the player can choose to pick it up.
        /// </summary>
        /// <param name="player">The player interacting with the room.</param>
        public void DescribeAndInteract(Player player)
        {
            // Output the room's description to the player
            Console.WriteLine(Description);

            // Check if the room contains an item
            if (!string.IsNullOrEmpty(Item))
            {
                // Ask the player if they want to pick up the item
                Console.WriteLine($"You found a {Item}. Would you like to pick it up? (Y/N)");
                
                // Validate input to ensure the player enters either "Y" or "N"
                string choice;
                do
                {
                    choice = Console.ReadLine()?.ToUpper();
                } while (choice != "Y" && choice != "N");

                // If the player chooses "Y", pick up the item
                if (choice == "Y")
                {
                    player.PickUpItem(Item); // Add the item to the player's inventory
                    Item = null; // Remove the item from the room (it has been picked up)
                }
            }
            else
            {
                // Inform the player that the room is empty if there's no item
                Console.WriteLine("The room is empty.");
            }
        }
    }
}

namespace DungeonExplorer
{
    // To keep things simple, could call the class "Room" each time for every different room to input string in
    public class Room
    {
        private string description; // Each object for this class would be each room. How would the descriptions change?

        public Room(string description) // Constructor, blueprint for creating room descriptions
        {
            this.description = description; // "this." refers to current instance of a class
        }

        // !!!!Room description intialisation, should I move this to the function? (and pass the parameter of the room string so it can print it? ex. turning left in game, and room[number] would have to be fetched)
        Room room1 = new Room("Description for room 1");
        Room room2 = new Room("Description for room 2");
        Room room3 = new Room("Description for room 3");

        // Removed "GetDescription()" (can see from last commit) function, may return to it

       // New class to interact w/ player
        class AvailableItems // "item" is a variable within the Player class (for them to pick up and view their inventory)
        {
            // Dedicated class for an object to be found in a room (if/else + random chance?)
            // Exit key should be guranteed in one room (and locked door)
            string oneItem;

             // !! Can make a constructor for the attributes within this class to be different items
        }
    }
}
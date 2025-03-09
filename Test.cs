using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Policy;

namespace DungeonExplorer
{
    internal class Test
    {
        public Player TestPlayer { get; private set; }
        public Room TestRoom { get; private set; }

        /// Tests various parts of the program.
        public void RunTests()
        {
            Console.WriteLine("Running tests...");

            // Testing the username.
            TestPlayer = new Player("Username", 10);
            Debug.Assert(TestPlayer.Name == "Username", "Player name should be Username.");
            // Tests that the inventory starts empty.
            Debug.Assert(TestPlayer.InventoryContents() == "Nothing :(", "A new players inventory should be empty.");
            // Tests that the items picked up are moved to the inventory.
            TestPlayer.PickUpItem("Health Potion");
            Debug.Assert(TestPlayer.InventoryContents().Contains("Health Potion"), "Inventory should have a health potion.");
            // Testing the room description.
            TestRoom = new Room();
            string RoomDescription = TestRoom.GetDescription();
            Debug.Assert(!string.IsNullOrEmpty(RoomDescription), "The Room description shoudln't be empty.");
            // Testing the rooms item.
            string RoomItem = TestRoom.GetItems();
            Debug.Assert(!string.IsNullOrEmpty(RoomItem), "The room item shouldn't be empty");

            Console.WriteLine("All tests finished successfully.");



        }
    }
}

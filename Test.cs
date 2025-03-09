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

        public void RunTests()
        {
            Console.WriteLine("Running tests...");

            TestPlayer = new Player("Username", 10);
            Debug.Assert(TestPlayer.Name == "Username", "Player name should be Username.");

            Debug.Assert(TestPlayer.InventoryContents() == "Nothing :(", "A new players inventory should be empty.");

            TestPlayer.PickUpItem("Health Potion");
            Debug.Assert(TestPlayer.InventoryContents().Contains("Health Potion"), "Inventory should have a health potion.");

            TestRoom = new Room();
            string RoomDescription = TestRoom.GetDescription();
            Debug.Assert(!string.IsNullOrEmpty(RoomDescription), "The Room description shoudln't be empty.");

            string RoomItem = TestRoom.GetItems();
            Debug.Assert(!string.IsNullOrEmpty(RoomItem), "The room item shouldn't be empty");

            Console.WriteLine("All tests finished successfully.");



        }
    }
}

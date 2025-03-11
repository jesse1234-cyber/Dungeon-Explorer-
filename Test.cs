using System;
using System.Diagnostics;

namespace DungeonExplorer
{
    /// <summary>
    /// This is a testing class that uses 'debug.assert' to verify aspcts of the code.
    /// </summary>
    internal class Tests
    {
        public static void RunTests()
        {
            TestPlayer();
            TestPickUpItem();
            TestPickupSword();
            Console.WriteLine("All tests completed. :)");
        }

        // Tests for the player initialization  
        private static void TestPlayer()
        {
            Player testPlayer = new Player("Player", 100);
            Debug.Assert(testPlayer.Name == "Player", "The player's name is not set correctly.");
            Debug.Assert(testPlayer.Health == 100, "The player's health is not set to 100.");
        }

        // Tests for PickupItem()
        private static void TestPickUpItem()
        {
            Player testPlayer = new Player("Player", 100);
            testPlayer.PickUpItem("torch");
            Debug.Assert(testPlayer.InventoryContents().Contains("torch"), "Item pickup has failed.");
        }

        // Tests for PickUpSword()
        private static void TestPickupSword()
        {
            Game testGame = new Game();
            Player testPlayer = new Player("Player", 100);
            Room testRoom = new Room("Room of Doom", "A huge room with bats.");
            testRoom.AddItem("sword");
            Debug.Assert(testRoom.ContainsItem("sword"), "The sword should be in Room of Doom.");
            testPlayer.PickUpItem("sword");
            Debug.Assert(testPlayer.InventoryContents().Contains("sword"), "The player should have picked up the sword.");
        }
    }
}

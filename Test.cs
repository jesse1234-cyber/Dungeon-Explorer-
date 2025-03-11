using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace DungeonExplorer
{
    public class Test
    {
        public static void RunTests()
        {
            TestEnemyGeneration();
            TestPlayerHealth();
            TestItemPickUp();
            Console.WriteLine("All tests executed.");
        }

        private static void TestEnemyGeneration()
        {
            Game testGame = new Game();
            var enemies = testGame.GenerateEnemies();
            Debug.Assert(enemies.Count == 3, "Expected 3 enemies, count is incorrect.");
            Console.WriteLine("TestEnemyGeneration passed.");
        }

        private static void TestPlayerHealth()
        {
            Player testPlayer = new Player("Test", 100);
            Debug.Assert(testPlayer.GetHealth() == 100, "Health is not 100.");
            testPlayer.SetHealth(50);
            Debug.Assert(testPlayer.GetHealth() == 50, "Health update failed.");
            Console.WriteLine("TestPlayerHealth passed.");
        }

        private static void TestItemPickUp()
        {
            Player testPlayer = new Player("Test", 100);
            Item testItem = new Item("Knife", ItemType.Weapon, Rarity.Rare);
            testPlayer.PickUpItem(testItem);
            Debug.Assert(testPlayer.inventoryItem != null, "Item pickup did not work.");
            Debug.Assert(testPlayer.inventoryItem.Name == "Knife", "Incorrect item assigned.");
            Console.WriteLine("TestItemPickup passed.");
        }
    }
}
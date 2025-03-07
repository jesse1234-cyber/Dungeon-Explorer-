using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace DungeonExplorer
{
    class Testing
    {
        // Creates a test player and a test room
        private Player testPlayer = new Player();
        private Room testRoom = new Room();

        // Method tests testPlayer values.
        public void PlayerTest()
        {
            testPlayer.Health = 100;
            Console.Write("Enter name for player test: ");
            testPlayer.Name = Console.ReadLine();

            Debug.Assert(testPlayer.Health > 0, "Health cannot be 0.");
            Debug.Assert(!string.IsNullOrEmpty(testPlayer.Name), "Player name cannot be empty.");
        }

        // Method tests testRoom values
        public void RoomTest()
        {
            testRoom.Description = File.ReadAllText(@"Descriptions/testroom.txt");
            Debug.Assert(!string.IsNullOrEmpty(testRoom.Description), "Room description cannot be empty.");
        }
    }
}

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
        private Player testPlayer = new Player();
        private Room testRoom = new Room();


        public void PlayerTest()
        {
            testPlayer.Health = 100;
            Console.Write("Enter name for player test: ");
            testPlayer.Name = Console.ReadLine();

            Debug.Assert(testPlayer.Health != 0, "Health cannot be 0.");
            Debug.Assert(testPlayer.Name is null, "Player name cannot be empty.");
            console.WriteLine(testPlayer.Name);
        }


        public void RoomTest()
        {
            testRoom.Description = File.ReadAllText(@"Descriptions/testroom.txt");
            Debug.Assert(testRoom.Description is null, "Room description cannot be empty.");
            testRoom.AddItem("Test Key");
            testRoom.GetDescription();
        }
    }
}
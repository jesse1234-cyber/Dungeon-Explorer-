using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DungeonExplorer
{
    class TestProgram
    {
        public TestProgram()
        {
            this.TestRoomFactory();
            this.TestPlayer();
            this.TestRoom();
        }

        public void TestRoomFactory()
        {
            Debug.Assert(RoomFactory.CreateRoomInstance("invalidIdentifier") == null);
            Room room = RoomFactory.CreateRoomInstance("Library");
            Debug.Assert(room != null);
            Debug.Assert(room.GetName() == "Library");
        }

        public void TestPlayer()
        {
            Player testPlayer = new Player("test", 0);
            Debug.Assert(testPlayer.GetName() == "test");
            Debug.Assert(testPlayer.GetHealth() == 0);
            Debug.Assert(testPlayer.GetInventoryContents() == "");
        }

        public void TestRoom()
        {
            Room testRoom = new Room("test", "this is a test room", new List<string> {"Dagger, Apple"});
            Debug.Assert(testRoom.GetName() == "test");
            Debug.Assert(testRoom.GetDescription() == "this is a test room");
        }
    }
}

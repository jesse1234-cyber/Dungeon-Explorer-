using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room
    {
        public static int currentRoom = 0;

        private string room1Description = "get roomed (1) :>";
        private string room2Description = "get roomeeed (2) :>";
        private string room3Description = "get roomored (3) 8>";

        private List<string> room1Items = new List<string> {"Dagger"};

        private List<string> RoomDescriptions = new List<string>();

        public Room()
        {
            RoomDescriptions.Add(room1Description);
            RoomDescriptions.Add(room2Description);
            RoomDescriptions.Add(room3Description);
        }

        public string GetDescription()
        {
            currentRoom++;
            string roomDescription = RoomDescriptions[currentRoom];
            return roomDescription;
        }
    }
}
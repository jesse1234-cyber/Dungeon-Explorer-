using System.Collections.Generic;

namespace DungeonExplorer
{
    public static class RoomFactory
    {
        public static Room CreateRoomInstance(string roomIdentifier)
        {
            switch (roomIdentifier)
            {
                case "Library":
                    return new Room(
                        "Library",
                        "A dusty library full of sorcery tomes and alchemy books. The air feels tense and you feel strange. \n" +
                        "You see something glistening at the top of a shelf... and is that a door at the back of the room?\n",
                        new List<string> { "Spell Book", "Mysterious Potion", "Bone Key" }
                    );
                default:
                    return null; //add error handling here
            }
        }
    }
}
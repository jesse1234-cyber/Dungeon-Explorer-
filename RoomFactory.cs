using System.Collections.Generic;

namespace DungeonExplorer
{
    /// <summary>
    /// A factory class responsible for creating instances of <see cref="Room"/> based on a room identifier.
    /// </summary>
    public static class RoomFactory
    {
        /// <summary>
        /// Creates an instance of <see cref="Room"/> based on a passed room identifier.
        /// </summary>
        /// <param name="roomIdentifier"> The identifier to create a <see cref="Room"/> instance from.</param>
        /// <returns>The corresponding instance of <see cref="Room"/>, or null if no room identifier can be matched.</returns>
        public static Room CreateRoomInstance(string roomIdentifier)
        {
            switch (roomIdentifier)
            {
                case "Library":
                    return new Room(
                        "Library",
                        "\nA dusty library full of sorcery tomes and alchemy books. The air feels tense and you feel strange. \n" +
                        "You see something glistening at the top of a shelf... and is that a door at the back of the room?\n" +
                        "\nYour options...\n" +
                        "A: Investigate the peculiar glistening\nB: Try to open the door\n" +
                        "C: Explore the rest of the library\n" +
                        "S, I, R, exit for other options!\n",
                        new List<string> {"Spell Book", "Mysterious Potion", "Bone Key"}
                    );
                default:
                    return null;
            }
        }
    }
}
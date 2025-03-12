using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    /// <summary>
    /// Configurations for the game.
    /// </summary>
    class Config
    {
        /// <summary>
        /// Room descriptions which are randomly selected by the room generator in the Room class
        /// </summary>
        public static List<String> RoomDescriptions = new List<string>() { "A monster lurks in the corners... potentially", "You hear moaning sounds coming from the corner...", "Hold onto your belongins carefully..."  };
    }
}
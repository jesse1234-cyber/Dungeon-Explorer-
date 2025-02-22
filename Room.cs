using System.Collections.Generic;
using System;

namespace DungeonExplorer
{
    public class Room
    {
        private List<string> RoomDescriptions;

        public Room()
        {
            RoomDescriptions = new List<string> { "\nRows of rusted chains hang from the ceiling, the walls lined with crude iron shackles. In the center of the room stands, a single, bloodstained alter.",
            "\nA damp, musty odor lingers in this ancient burial chamber. Cracked sarcophagi line the walls. The air is unnervingly still.",
            "\nTowering bookshelves, coated in centuries of dust. Ancient tomes and scrolls lay scattered on the floor. A thick fog clings to the ground.",
            "\nMirrors of varying sizes cover the walls from floor to ceiling. Some reflections move independently, their eyes filled with malice. A fine layer of mist creeps along the floor.",
            "\nThe floor squelches with every step as thick slime coats the stone floors. Occasional bubbles rise and pop. The walls ooze with the same sticky substance",
            "\nThis vast, domed chamber seems unnaturally large. Shadows flicker abnormally. In the center of the room, a pedestal holds a cracked hourglass" };
        }

        public string GetDescription()
        {
            Random rand = new Random();
            return RoomDescriptions[rand.Next(RoomDescriptions.Count)];
        }
    }
}
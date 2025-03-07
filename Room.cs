using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    public class Room
    {
        private string name;
        private string description;

        private readonly Random random = new Random();

        public static readonly Dictionary<string, string> RoomDescriptions = new Dictionary<string, string>
        {
            { "The prison cells..", "A damp cold cell with fractured walls, 3 metal bars are attatched to a wall, perhaps an old prison cell..."},
            { "The library of the Forgotten..", "A lost and forgoten library, texts in a indecipherable languages seeming to referance some kind of higher power..." },
            { "The flooded Cavern..", "The flooded cavern, no light can seem to seep its way into the unforgiving darkness, it is flooded, with which substance is a story for another day..." },
            { "The fractured Mirror Maze..", "The maze, The intense reflections from the blinding mirrors and overwhelming amount of light may not be the only thing we have to worry about..." },
            { "The portal Chamber..", "The portal room.. apart from the bright pink and purple portal in the centre There are texts on the walls, they seem to be written in Sumerian and translate to: Some things were never meant to be found. To seek them is to lose yourself." },
            { "The living Quarters..", "A suprisingly well kept and almost cozy room finished with an acient fireplace, all in all a very welcoming and pleasant room." },
            { "The endless Staircase..", "Created with the acient power from the portal chamber a staircase that has no end. walk for 10 seconds and you've hardly moved, walk for 10 days and you've hardly moved." },
            { "The plan..", "What an odd room, This room seems to have nothing at all, completely empty, apart from a single camera in the dead centre, always rolling, an acient text on the wall reads 'The plan' " },
            { "The throne Room..", "A grand golden plated room, it seems to be kept in perfect condition with a pure gold royal throne north of the enterance, does someone still live here?" },
            { "The path of insanity..", "A path that seems to be made of a wickedly hot substance similar to that of burning coals, would it be wise to continue?"},
        };

        public static readonly List<string> CurrentRoomIntro = new List<string>
        {
            "You stumble along and reach a new area within the dungeon...",
            "You find your way to the next enterance...",
            "The flickering torchlight reveals a new corridor ahead...",
            "A hidden passageway creaks open...",
            "Your footsteps echo as you push through the darkness, revealing a new part of the dungeon..."
        };

        public Room()
        {
            int index = random.Next(RoomDescriptions.Count);
            var randomRoom = RoomDescriptions.ElementAt(index);

            name = randomRoom.Key;
            description = randomRoom.Value;
        }
        
        public string GetTitle()
        {
            return name;
        }

        public string GetDescription()
        {
            return description;
        }
        
        public string GetRoomIntro()
        {
            int index = random.Next(CurrentRoomIntro.Count);
            return CurrentRoomIntro.ElementAt(index);
        }
    }
    public class RoomRng
    {
        // A simple rng method that is flexible and can have different rng values
        public static int Rng(int low, int high)
        {
            Random random = new Random();
            return random.Next(low, high);
        }

        // return false for 1 != 1 and all other outcomes are true, the chance of any room containing an item is 66%
        public bool ContainsItems()
        {
            return Rng(1, 3) != 1;
        }

        private static readonly Dictionary<string, int> Items = new Dictionary<string, int>
        {
            { "Dagger", 25},
            {"short sword", 20},
            {"toothpaste", 5},
            {"Css lanyard", 10},
            {"laser pen", 15},
            {"Tornado in a bottle", 3},
            {"Dark orb", 8},
            {"Goblin flute", 7},
            {"spell tome", 5},
            {"Gravity glove", 2},
        };

        public static string GetRandomItem()
        {
            int Weighting = 0;
            foreach(var item in Items.Values)
            {
                Weighting += item;
            }

            int randomNum = Rng(1, Weighting + 1);
            int TotalWeight = 0;

            foreach (var item in Items)
            {
                TotalWeight += item.Value;
                if (randomNum <= TotalWeight)
                {
                    return item.Key;
                }
            }
            return "Unknown item";
        }
    }
}
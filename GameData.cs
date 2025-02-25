using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    class GameData
    {
        private static Random random = new Random();

        // Dictionary of weapons and their damage
        private static Dictionary<string, int> weapons = new Dictionary<string, int>()
        {
            { "Rusty Dagger", 5 },
            { "Wooden Club", 8 },
            { "Stone Axe", 12 },
            { "Bronze Sword", 15 },
            { "Iron Spear", 18 },
            { "Steel Mace", 22 },
            { "Silver Rapier", 25 },
            { "Obsidian Knife", 28 },
            { "Elven Bow", 30 },
            { "Dwarven Warhammer", 35 },
            { "Dark Steel Katana", 40 },
            { "Dragonbone Greatsword", 45 },
            { "Phoenix Fire Staff", 50 },
            { "Elder Wand", 55 },
            { "Godslayer Blade", 60 }
        };

        // Dictionary of potions and their health
        private static Dictionary<string, int> potions = new Dictionary<string, int>()
        {
            {"Lesser Health Potion", 10 },
            {"Health Potion", 20 },
            {"Greater Health Potion", 30 }
        };

        // Dictionary of enemies and their damage, health and speed
        private static List<List<object>> enemies = new List<List<object>>()
        {
            new List<object> { "Goblin", 10, 50, 1 },
            new List<object> { "Orc", 20, 60, 1 },
            new List<object> { "Troll", 30, 70, 2 },
            new List<object> { "Giant", 40, 80, 3 },
            new List<object> { "Wizard", 35, 90, 3 },
            new List<object> { "Dragon", 50, 120, 4 }
        };

        private static List<string> roomDescriptions = new List<string>()
        {
            "A damp, moss-covered chamber with a faint dripping sound echoing from the walls.",
            "A narrow corridor lit by flickering torches, casting long shadows on the rough stone walls.",
            "A large hall with towering pillars, each carved with intricate runes that glow faintly in the dark.",
            "A circular room with a shattered altar in the center, surrounded by broken statues of ancient gods.",
            "A cold, dark cell with iron bars and a single, rusted chain hanging from the ceiling.",
            "A treasure vault filled with glittering gold coins, precious gems, and ancient artifacts.",
            "A room filled with strange, glowing fungi that emit an eerie, pulsating light.",
            "A chamber with a deep, dark pit in the center, surrounded by a narrow walkway.",
            "A library filled with dusty tomes and scrolls, some of which seem to move on their own.",
            "A room with walls covered in strange, pulsating veins that seem to breathe.",
            "A grand hall with a massive chandelier hanging from the ceiling, its candles still burning brightly.",
            "A room filled with the bones of long-dead adventurers, their equipment scattered among the remains.",
            "A chamber with a large, ornate mirror that reflects a distorted version of the room.",
            "A room with a bubbling cauldron in the center, emitting a foul-smelling smoke.",
            "A narrow passageway with walls that seem to close in as you walk further.",
            "A room with a massive, ancient tree growing in the center, its roots breaking through the stone floor.",
            "A chamber with a pool of still, black water that reflects nothing but darkness.",
            "A room with a massive, locked door covered in strange symbols and glowing runes.",
            "A chamber with a large, circular platform in the center, surrounded by a deep chasm.",
            "A room with walls covered in ancient murals depicting a long-forgotten battle.",
            "A chamber with a massive, glowing crystal in the center, pulsating with energy.",
            "A room filled with the sound of distant whispers, though no one is there.",
            "A chamber with a large, stone throne covered in cobwebs and dust.",
            "A room with a massive, iron gate that creaks open as you approach.",
        };

        public static KeyValuePair<string, int> GetRandomWeapon(int min, int max)
        {
            int index = random.Next(min, max);
            return weapons.ElementAt(index);
        }

        public static KeyValuePair<string, int> GetRandomItem(int min, int max)
        {
            int index = random.Next(min, max);
            return potions.ElementAt(index);
        }

        public static List<object> GetRandomEnemy(int min, int max)
        {
            int index = random.Next(min, max);
            List<object> enemyTemplate = enemies.ElementAt(index);
            return new List<object> { enemyTemplate[0], enemyTemplate[1], enemyTemplate[2], enemyTemplate[3] };
        }


        public static string GetRandomRoomDescription()
        {
            int index = random.Next(roomDescriptions.Count);
            return roomDescriptions[index];
        }

        public static Dictionary<string, int> GetWeapons()
        {
            return weapons;
        }
    }
}

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;


namespace DungeonExplorer
{
    public class Room
    {
        private readonly string description;
        private readonly List<string> loot;
        private readonly List<Room> neighbours;
        private readonly Random rnd = new Random();

        public Room()
        {
            description = GenerateDescription();

            // Randomise if loot is present
            bool hasLoot = true;
            int loot_chance = rnd.Next(4);
            if (loot_chance == 1)
            {
                hasLoot = false;
            }

            // If the room has loot generate it
            if (hasLoot)
            {
                this.loot = GenerateLoot();
            }
            // If not set it as null
            else
            {
                this.loot = null;
            }
            

        }

        private string GenerateDescription()
        {
            // Call a random description from an text file full of many.
            string new_description;
            string source = "C:\\Users\\jrhys\\Source\\Repos\\DungeonExplorer\\room_descriptions.txt";

            try
            {
                // Ensure file exists
                if (!File.Exists(source))
                {
                    return "File does not exist.";
                }
                
                StreamReader reader = new StreamReader(source);

                // Get text from the file
                string text = reader.ReadToEnd();
                string[] descriptions = text.Split('\n');
                reader.Dispose();

                // Randomly select a description
                new_description = descriptions[this.rnd.Next(0, descriptions.Length)];
            }
            catch (Exception ex)
            {
                return $"Failed to read file: {ex}";
            }

            // If nothing was added
            if (string.IsNullOrEmpty(new_description))
            {
                return "ERROR FINDING DESCRIPTION";
            }

            // Else return the description
            return new_description;
        }

        private static List<string> GenerateLoot()
        {
            List<string> new_loot = new List<string>();

            new_loot.Add("Rusted Pipe");

            return new_loot;
        }

        private void GenerateNeighbour()
        {
            Room neighbour = new Room();

            if (neighbours.Contains(neighbour))
            {
                GenerateNeighbour();
            }
            else
            {
                neighbours.Add(neighbour);
            }
        }

        private void LootRoom(Player current_player, Game game)
        {
            if (this.loot != null)
            {
                Console.Clear();
                Console.WriteLine($"\nThe room contains:\n{this.GetLoot()}");

                string loot_txt = @"
Enter the item you'd like to loot or enter 'None' if you'd like to leave it.
";
                List<string> loot_inputs = new List<string>(this.loot);
                loot_inputs.Add("None");

                string loot_choice = game.GetOption(loot_inputs, loot_txt);
                if (loot_choice != "None")
                {
                    current_player.PickUpItem(loot_choice);
                }
            }
        }

        public string GetDescription()
        {
            /// <summary>
            /// Returns the room description
            /// </summary>
            return description;
        }


        public string GetLoot()
        {
            return string.Join(", ", loot);
        }

        public void RemoveLoot(string item)
        {
            if (loot.Contains(item))
            {
                loot.Remove(item);
            }

        }

        public void DisplayRoom(Player current_player)
        {
            string title_str = @"
=================================================
                  RUST & RUIN                  
=================================================
";
            string room_txt = $@"{title_str}

{this.GetDescription()}
";
            string room_menu = @"
What will you do next?

1. Loot the room
2. Adventure on
3. Check Self
4. Quit Game
Choose an option [1 - 3]
";
            List<string> room_options = new List<string>() { "1", "2", "3", "4"};

            Game game = new Game();
            Console.WriteLine(room_txt);
            string choice = game.GetOption(room_options, room_menu);

            switch (choice)
            {
                case "1":
                    this.LootRoom(current_player, game);
                    break;

                case "2":
                    break;

                case "3":
                    current_player.PlayerMenu();
                    break;

                case "4":
                    string confirm_txt = "Are you sure you'd like to quit? [Y/N]";
                    List<string> yes_no = new List<string>() { "Y", "N" };

                    string confirm_choice = game.GetOption(yes_no, confirm_txt); 
                    
                    if (confirm_choice == "Y")
                    {
                        game.Menu();
                    }
                    else
                    {
                        DisplayRoom(current_player);
                    }
                        
                    break;
            }
        }

    }
}
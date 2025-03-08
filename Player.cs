using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private readonly List<string> inventory = new List<string>();

        public Player(string name, int health) 
        {
            Name = name;
            Health = health;
        }
        public void PickUpItem(string item)
        {
            inventory.Add(item);
        }

        private string GetInventoryContents()
        {
            return string.Join(", ", inventory);
        }

        public void GetName()
        {
            string name_input = String.Empty;

            string new_name_txt = @"
=================================================
                  RUST & RUIN                  
=================================================

Before we begin we must know your name adventurer.
What will we call you on this adventure...
";
            Console.Clear();
            Console.WriteLine(new_name_txt);
            Console.Write("\n :: ");
            name_input = Console.ReadLine();

            if (name_input != null)
            {
                this.Name = name_input;
            }
            else
            {
                GetName();
            }

        }

        public void PlayerMenu()
        {
            string output = $@"
Name: {this.Name} HP: {this.Health} 

Inventory:

{this.GetInventoryContents()}

";

            Console.Clear();
            Console.WriteLine(output);
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();

        }


    }
}
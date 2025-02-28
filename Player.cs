using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        private static Random random = new Random();
        private string name;
        public int health;
        private List<string> inventory = new List<string>();

        public Player(string name) 
        {
            this.name = name;
            this.health = random.Next(14, 18);
        }

        public string GetPlayerData()
        {

            return "Name: " + this.name + "\n" + "Health: " + this.health;
        }
    }
}
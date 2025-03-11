using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    // This class contains the get and set methods for the monster's attributes and other methods. 
    internal class Monster
    {
        // Private get and set methods so that there is no accidental overlap or re-defining of the health and name variables. 
        private int Health { get; set; }
        private string Name { get; set; }
        public Monster(string Name, int Health)
        {
            this.Name = Name;
            this.Health = Health;
        }
        public int GetHealth()
        {
            return this.Health;
        }
        public string Damage()
        {
            // Decreases the monster's health by 5 each time it is called. 
            this.Health = this.Health - 5;
            return $"You hit the monster as hard as you could... It now has {this.Health} health.";
        }
        public void Heal()
        {
            // Increases the monster's health by 10 each time it is called. 
            Health = Health + 10;
        }
    }
}

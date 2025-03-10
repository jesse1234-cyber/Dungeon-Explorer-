using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        private string n; // 'n' for name
        private int h; // 'h' for health
        private string stuff; // inventory

        public Player(string name, int health)
        {
            n = name;
            h = health;
            stuff = null;
        }

        public void pickup(string t)
        {
            if (GetStuff() == null)
            {
                SetStuff(t);
                System.Console.WriteLine(GetN() + " got " + t);
            }
            else
            {
                System.Console.WriteLine(GetN() +  " can't pickup");
            }
        }
        public string inv()
        {
            if (GetStuff() != null) { //If not empty
                return GetStuff();
            } else {
                return "empty";
            }
        }

        // Getters
        public string GetN() { return n; }
        public int GetH() { return h; }
        public string GetStuff() { return stuff; }

        // Setters
        public void SetN(string newName) { n = newName; }
        public void SetH(int newHealth) { h = newHealth; }
        public void SetStuff(string newStuff) { stuff = newStuff; }
    }
}

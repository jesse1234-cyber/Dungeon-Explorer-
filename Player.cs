using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> inventory = new List<string>();

        public Player(string name, int health) 
        {

            Name = name;
            Health = health;
=======
            get { return name; }
            set { name = value; }
        }

        public int Health
        {
            get { return health; }
            set
            {

                if (value < 0)
                {
                    health = 0;
                }
                else
                {
                    health = value;
                }
            }
        }
        
        public List<string> Inventory
        {
            get { return inventory; }
            set { inventory = value; }
        }
        
        public Player(string Name, int Health, List<string> Inventory) 
        {
            name = Name;
            health = Health;
            inventory = Inventory;
>>>>>>> Stashed changes
        }
        public void PickUpItem(string item)
        {

        }
        public string InventoryContents()
        {
            return string.Join(", ", inventory);
        }
    }
}
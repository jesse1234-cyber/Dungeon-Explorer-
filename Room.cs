namespace DungeonExplorer
{
    public class Room
    {
        public Monster Monster { get; private set; }
        public Potion Potion { get; private set; }
        public Weapon Weapon { get; private set; }
        private string Description; // Accessed through methods detailed below.
        public Room(Monster monster, Potion potion, Weapon weapon)
        {
            Monster = monster;
            Potion = potion;
            Weapon = weapon;
            Description = "";
        }
        // Generates a description of the room.
        public void CreateDescription()
        {
            string description = "Room Contents:";
            description += "\nMonster: ";
            if (Monster == null)
            {
                description += "There is no monster in the room.";
            }
            else
            {
                description += Monster.Name;
            }
            description += "\nPotion: ";
            if (Potion == null)
            {
                description += "There is no potion in the room.";
            }
            else
            {
                description += Potion.Name;
            }
            description += "\nWeapon: ";
            if (Weapon == null)
            {
                description += "There is no weapon in the room.";
            }
            else
            {
                description += Weapon.Name;
            }
            Description = description;
        }
        // Returns the description of the room after making sure that it is up to date with the current contents.
        public string GetDescription()
        {
            CreateDescription();
            return Description;
        }
        // Methods to remove items/monsters from the room.
        public void RemoveWeapon()
        {
            Weapon = null;
        }
        public void RemovePotion()
        {
            Potion = null;
        }
        public void RemoveMonster()
        {
            Monster = null;
        }
        public bool IsEmpty()
        {
            return Monster == null && Potion == null && Weapon == null;
        }
    }
}
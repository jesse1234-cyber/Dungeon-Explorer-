using System;

namespace DungeonExplorer
{
    /// <summary>
    /// Represents an item that can be used by the player.
    /// </summary>
    public class Item : ICloneable
    {
        public string Name { get; private set; }
        public int Damage { get; private set; }
        public int Healing { get; private set; }
        public int Armor { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class.
        /// </summary>
        /// <param name="name">The name of the item.</param>
        /// <param name="damage">The damage value of the item.</param>
        /// <param name="healing">The healing value of the item.</param>
        /// <param name="armor">The armor value of the item.</param>
        public Item(string name, int damage = 0, int healing = 0, int armor = 0)
        {
            Name = name;
            Damage = damage;
            Healing = healing;
            Armor = armor;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="Item"/> class that is a copy of the current instance.
        /// </summary>
        /// <returns>A new <see cref="Item"/> instance that is a copy of this instance.</returns>
        public object Clone()
        {
            return new Item(Name, Damage, Healing, Armor);
        }
    }
}
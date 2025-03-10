using System;

namespace DungeonExplorer
{
    /// <summary>
    /// Represents a creature in the game.
    /// </summary>
    public class Creature : Entity, ICloneable
    {
        public int Damage { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Creature"/> class.
        /// </summary>
        /// <param name="name">The name of the creature.</param>
        /// <param name="health">The health of the creature.</param>
        /// <param name="damage">The damage value of the creature.</param>
        public Creature(string name, int health, int damage) : base(name, health)
        {
            Damage = damage;
        }

        /// <summary>
        /// Creates a new instance of the <see cref="Creature"/> class that is a copy of the current instance.
        /// </summary>
        /// <returns>A new <see cref="Creature"/> instance that is a copy of this instance.</returns>
        public object Clone()
        {
            return new Creature(Name, Health, Damage);
        }
    }
}
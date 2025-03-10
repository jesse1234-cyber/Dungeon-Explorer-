using System;

namespace DungeonExplorer
{
    /// <summary>
    /// Represents a base entity with common properties and methods.
    /// </summary>
    public abstract class Entity
    {
        public string Name { get; }
        public int Health { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class.
        /// </summary>
        /// <param name="name">The name of the entity.</param>
        /// <param name="health">The health of the entity.</param>
        protected Entity(string name, int health)
        {
            Name = name;
            Health = health;
        }

        /// <summary>
        /// Reduces the health of the entity by the specified damage amount.
        /// </summary>
        /// <param name="damage">The amount of damage to take.</param>
        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
        }

        /// <summary>
        /// Determines if the entity is alive.
        /// </summary>
        /// <returns><c>true</c> if the entity is alive; otherwise, <c>false</c>.</returns>
        public bool IsAlive()
        {
            return Health > 0;
        }
    }
}
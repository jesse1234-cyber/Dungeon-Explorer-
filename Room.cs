using System;
using System.ComponentModel;

namespace DungeonExplorer
{
    /// <summary>
    /// the main coding logic for a room class
    /// </summary>
    public class Room
    {
        /// <remarks>
        /// a string called description is created so that it can be used
        /// </remarks>
        private string description;

        /// <param name="description">
        /// the description of the room
        /// </param>
        public Room(string description)
        {
            ///<remarks>
            ///the current string description will be whatever the parameter for the
            ///initialization of the class is
            /// </remarks>
            this.description = description;
        }

        /// <summary>
        /// This function returns the description and can be called by other filed
        /// </summary>

        /// <returns>
        /// the description definded in the code above
        /// </returns>
        public string GetDescription()
        {
            return description;
        }


    }
}
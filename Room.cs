using System.Net.Http.Headers;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private string[] directions = {"N", "W", "S", "E"};
        private Item 

        public Room(string description)
        {
            this.description = description;
        }

        public string GetDescription()
        {
            return this.description;
        }
        
        public void SetAdjacent(string[] availabledirection)
        {
            this.directions = availabledirection;
        }
        public string[] GetDirections()
        {
            return this.directions;
        }
    }
}
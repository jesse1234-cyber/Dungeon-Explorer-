namespace DungeonExplorer
{
    public class Room
    {
        private string description;

        public Room(string description)
        {
            this.description = "A dusty library full of sorcery tomes and alchemy books. The room is filled with a strange, tense energy... and, what's that in the corner of the room?"
        }

        public string GetDescription()
        {
            return description;
        }
    }
}
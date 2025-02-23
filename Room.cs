namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private bool monster;
        static Random rnd = new Random();

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

         public bool Monster
         {
             get { return monster; }
             set
             {
                 int randomNum = rnd.Next(1, 2);
                 if (randomNum == 1)
                 {
                     monster = true;
                 }
                 else if (randomNum == 2) 
                 {
                    monster = false;
                 }
             }
         }

            public Room(string description)
            {
                description = Description;
                monster = Monster;
            }
        public string GetDescription()
        {
            return description;
        }
    }
}

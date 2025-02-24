using System;

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
        public Room(string description, bool monster)
        {
            description = Description;
            monster = Monster;
        }

        public string ChooseRoom()
        {
            int roomNum = rnd.Next(1, 5);
            string chosenRoom = "";
            switch (roomNum)
            {
                case 1:
                    chosenRoom = "You enter a small, dimly lit room. There is a small health potion placed on a table in the far left corner.";
                    break;
                case 2:
                    chosenRoom = "You enter a completely dark room. It is impossible to see anything. Your fumble around in the darkness searching for a door to the next room.";
                    break;
                case 3:
                    chosenRoom = "You enter a large, brightly lit room. There is a large health potion hidden under a cloth in the near left corner of the room.";
                    break;
                case 4:
                    chosenRoom = "You enter a cave-like room. There are no items in here, just an ominous shadow in the corner...";
                    break;
            }
            return chosenRoom;
        }
        public string GetDescription()
        {
            return description;
        }
    }
}
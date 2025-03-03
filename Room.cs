using System;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private bool monster;
        private string item;
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
                int randomMonster = rnd.Next(1, 3);
                if (randomMonster == 1)
                {
                    monster = true;
                }
                else if (randomMonster == 2)
                {
                    monster = false;
                }
            }
        }

        public string Item
        {
            get { return item; }
            set { item = value; }
        }
            public string ChooseItem()
        {

            int randomItem = rnd.Next(1, 4);
            string item = "";
            switch (randomItem)
            {
                case 1:
                    item = "small health potion";
                    break;
                case 2:
                    item = "regular health potion";
                    break;
                case 3:
                    item = "large health potion";
                    break;
            }
            return item;
        }
        public Room(string description, bool monster, string item)
        {
            description = Description;
            monster = Monster;
            item = ChooseItem();
        }

        public string ChooseRoom()
        {
            int roomNum = rnd.Next(1, 5);
            string chosenRoom = "";
            switch (roomNum)
            {
                case 1:
                    chosenRoom = "You enter a small, dimly lit room";
                    break;
                case 2:
                    chosenRoom = "You enter a completely dark room. It is impossible to see anything. Your fumble around in the darkness searching for a door to the next room.";
                    break;
                case 3:
                    chosenRoom = "You enter a large, brightly lit room";
                    break;
                case 4:
                    chosenRoom = "You enter a cave-like room. There is an ominous shadow in the corner...";
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
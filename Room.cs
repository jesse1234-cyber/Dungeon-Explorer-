using System.Data;
using System.Dynamic;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private int[] directions = {-1, -1, -1, -1};
        private string[] collectable = new string[2];
        private string action = "Error";
        private bool itemPickedUp = false;
        private int index;
        public Room(string description){this.description = description;}

        public string GetDescription(){return this.description;}
        
        public void SetAdjacent(int north, int east, int south, int west)
        {
            this.directions[0] = north;
            this.directions[1] = east;
            this.directions[2] = south;
            this.directions[3] = west;
        }
        public int[] GetDirections(){return this.directions;}
        public void SetItem(string itemName, string itemDescription)
        {
            this.collectable[0] = itemName;
            this.collectable[1] = itemDescription;
        }
        public void SetAction(string itemAction){this.action = itemAction;}
        public string[] GetCollectable()
        {
            string[] empty = new string[1];
            if (this.itemPickedUp == false)
            {
                this.UpdateAction();
                return this.collectable;
            }
            else{return empty;}
        }
        public string GetAction(){return this.action;}
        public void UpdateAction()
        {
            this.action = "You have already gotten the item from this room";
            this.itemPickedUp = true;
        }
        public bool GetItemPickedUp(){return this.itemPickedUp;}
        public void SetIndex(int submittedindex){this.index=submittedindex;}
        public int GetIndex(){return this.index;}

    }
}
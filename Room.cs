using System.Dynamic;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace DungeonExplorer
{
    public class Room
    {
        private string description;
        private string[] directions = {"N", "W", "S", "E"};
        private string[] collectable = new string[2];
        private string action = "Error";
        private bool itemPickedUp = false;
        private int index;
        public Room(string description){this.description = description;}

        public string GetDescription(){return this.description;}
        
        public void SetAdjacent(string[] availabledirection){this.directions = availabledirection;}
        public string[] GetDirections(){return this.directions;}
        public void SetItem(string itemName, string itemDescription)
        {
            this.collectable[0] = itemName;
            this.collectable[1] = itemDescription;
        }
        public void SetAction(string itemAction){this.action = itemAction;}
        public string[] GetCollectable(){return this.collectable;}
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
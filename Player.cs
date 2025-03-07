using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Item

    {
        public string _itemName;
        public string _itemDescription;

        public string ItemName
        {
            get
            {
                return _itemName;
            }

            private set
            {
                _itemName = value;
            }
        }
        public string Itemdescription
        {
            get
            {
                return _itemDescription;
            }

            private set
            {
                _itemDescription = value;
            }
        }

        public Item(string itemName, string itemDescription)
        {
            this.ItemName = itemName;
            this.Itemdescription = itemDescription;
        }
    }
    public class Player

    {
        public string _Name;
        public int _Health = 100;
        private List<Item> _Inventory = new List<Item>();

        public string Name
        {
            get
            {
                return _Name;
            }

            private set
            {
                _Name = value;
            }
        }
        public int Health
        {
            get
            {
                return _Health;
            }

            private set
            {
                _Health = value;
            }
        }
        public List<Item> Inventory
        {
            get
            {
                return _Inventory;
            }

            private set
            {
                _Inventory = value;
            }
        }
        public Player(string name, int health, List<Item> inventory)
        {
            this.Name = name;
            this.Health = health;
            this.Inventory = inventory;
        }




        public void PickUpItem(Item item)
        {
            _Inventory.Add(item);

        }
        public string InventoryContents()
        {

            return string.Join(", ", _Inventory);

        }


    }

}
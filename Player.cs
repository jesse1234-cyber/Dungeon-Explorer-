using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    /// <summary>
    /// Item class
    /// Gives the user a the name and the description of what the item does 
    /// </summary>
    public class Item

    {
        public string _itemName;
        public string _itemDescription;

        /// <summary>
        /// gets and sets the name and description of items 
        /// </summary>
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

        /// <summary>
        /// initialises a new item
        /// </summary>
        /// <param name="itemName"> the name of the item</param>
        /// <param name="itemDescription">the description of the item</param>
        public Item(string itemName, string itemDescription)
        {
            this.ItemName = itemName;
            this.Itemdescription = itemDescription;
        }
        //displays item name in inventory 
        public override string ToString()
        {
            return ItemName;
        }
    }


    /// <summary>
    /// Player class 
    /// gives the user a health pool and a inventory they can store items in 
    /// </summary>
    public class Player

    {
        public string _Name;
        public int _Health = 100;
        private List<Item> _Inventory = new List<Item>();

        /// <summary>
        /// gets and sets players name and health pool
        /// </summary>
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
        /// <summary>
        /// `inisialises player
        /// </summary>
        /// <param name="name">the name of the player </param>
        /// <param name="health">the health of the player </param>
        /// <param name="inventory">tthe pplayers inventory</param>
        public Player(string name, int health, List<Item> inventory)
        {
            this.Name = name;
            this.Health = health;
            this.Inventory = inventory;
        }



        /// <summary>
        /// allows users to pick up items
        /// </summary>
        public void PickUpItem(Item item)
        {
            //adds items to inventory 
            _Inventory.Add(item);

        }
        // shows items in inventory
        public string InventoryContents()
        {

            return string.Join(", ", _Inventory);

        }


    }

}
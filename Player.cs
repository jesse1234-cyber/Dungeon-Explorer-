using System.Collections.Generic;
using System;
using System.Linq;

namespace Program
{
    class ActionMenuAction
    {
        public Action A;
        public string N;
        public ActionMenuAction(Action iA, string iN)
        {
            A = iA;
            N = iN;
        }
    }

    // Class for the player, with health attributes and an instance of the inventory object
    public class Player
    {
        
        List<ActionMenuAction> ActionMenuFunctions = new List<ActionMenuAction>();
        int posX; public void setPosX(int i) { posX = i; } public int getPosX() { return posX; }
        int posY; public void setPosY(int i) { posY = i; } public int getPosY() { return posY; }
        int Health { get; set; }
        int MaxHealth { get; set; }
        public PlayerInventory pInv;


        public Player() {
            pInv = new PlayerInventory(5);
            posX = 5;
            posY = 8;
            ActionMenuFunctions.Add(new ActionMenuAction(MoveMenu, "Move Menu"));
            ActionMenuFunctions.Add(new ActionMenuAction(pInv.fShowInventory, "Show Inventory"));

        }

       
        private void MoveMenu()
        {
            List<char> Valids = new List<char> { 'w', 'a', 's', 'd' };

            // Get a valid key input for movement (W, A, S, D)
            char input = GameInputs.K(Valids);

            int newX = posX;
            int newY = posY;

            // Handle movement based on the key pressed
            switch (input)
            {
                case 'a':
                    newY--;
                    break;
                case 'w':
                    newX--;
                    break;
                case 'd':
                    newY++;
                    break;
                case 's':
                    newX++;
                    break;
                default:
                    break;
            }

            // Check if the new position is valid
            if (Map.IsValidPosition(newX, newY))
            {
                // Update the map and player position
                Map.UpdateMap(posX, posY, newX, newY);
                posX = newX; // Update player's X position
                posY = newY; // Update player's Y position

                // Clear the screen and show the updated map
                Console.Clear();
                Map.Show();
            }
        }


        public void ActionMenu()
        {
            Console.WriteLine("   Action Menu:    ");
            Console.WriteLine("Press W, A, S or D to move to the adjacnt room in that direction");
            for (int i = 0; i < ActionMenuFunctions.Count; i++)
            {
                Console.WriteLine("[" + (i+1) + "] " + ActionMenuFunctions[i].N);
            }
            ActionMenuFunctions[(GameInputs.V(ActionMenuFunctions.Count()) - 1)].A();

            
            
        }

    }


    // Player inventory class, with various functions to manage the inventory
    public class PlayerInventory
    {
        public PlayerInventory(int inCapacity)
        {
            iCapacity = inCapacity;
           
             Inventory.Add(new InventoryItem("Sausage Roll", 10, 3)); // Initializes the list of inventory items
            
        }
        private int iCapacity;
        public int getICapacity() { return iCapacity;  }
        public void setICapacity(int setV) { iCapacity = setV; }


        private List<InventoryItem> Inventory = new List<InventoryItem>();

        public string fPickUpItem(InventoryItem ItemToAdd) // Adds an item to players inventory (Checking its not full first)
        {
            if (Inventory.Count == iCapacity)
            {
                return "Your inventory is full! You must drop something first";
            }
            Inventory.Add(ItemToAdd);
            return "Item Added";
        }
        public void fShowInventory() // Shows the player the current items in there inventory
        {
            for (int i = 0; i < Inventory.Count; i++)
            {
                Console.WriteLine("[" + (i + 1).ToString() + "] " + Inventory[i].sName + ": " + Inventory[i].noOfItem.ToString() + "/" + Inventory[i].maxNoOfItem.ToString());
            }

        }
        private string fDeleteItem(InventoryItem ItemToRemove, InventoryItem ItemToAdd) // Remove item from the inventory
        {
            Inventory.Remove(ItemToRemove);
            return null;
        }

    }

    public class InventoryItem
    {
        public int maxNoOfItem { get; set; }
        public int noOfItem { get; set; }
        public string sName { get; set; }
        public InventoryItem(string name, int maxNoOfItem)
        {
            this.sName = name;
            this.maxNoOfItem = maxNoOfItem;
            this.noOfItem = 1;
        }
        public InventoryItem(string name, int maxNoOfItem, int noOfItem)
        {
            this.sName = name;
            this.maxNoOfItem = maxNoOfItem;
            this.noOfItem = noOfItem;
        }
    }
}
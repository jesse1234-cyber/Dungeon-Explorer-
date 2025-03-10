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
        public Room CurrentRoom;
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
            CurrentRoom = Map.getRoomFromArr(posX, posY);
            ActionMenuFunctions.Add(new ActionMenuAction(MoveMenu, "Move Menu"));
            ActionMenuFunctions.Add(new ActionMenuAction(pInv.fShowInventory, "Show Inventory"));
            ActionMenuFunctions.Add(new ActionMenuAction(ShowRoomDescription, "Show Room Description"));
            ActionMenuFunctions.Add(new ActionMenuAction(ScoutForItems, "Scout Around For Items"));
        }

        private void ScoutForItems()
        {
            if (CurrentRoom.FloorItems.Count == 0)
                Console.WriteLine("Theres nothing around here...");
            else
            {
                for (int i = 0; i < CurrentRoom.FloorItems.Count; i++)
                {
                    Console.WriteLine("[" + (i + 1) + "] " + CurrentRoom.FloorItems[i].sName);
                }
            }
            Console.WriteLine("Type the number of the item you would like to inspect / pick up.\nIf you dont want to pick any up, press 0");
            int MChoice = GameInputs.V(CurrentRoom.FloorItems.Count, 0);
            if (MChoice == 0)
            {
                return;
            }
            Console.WriteLine(CurrentRoom.FloorItems[MChoice - 1].sName + ": " + CurrentRoom.FloorItems[MChoice - 1].sDescription + "\n[1] Pickup\n[2] Leave");
            if (GameInputs.V(2) == 1)
            {
                pInv.fPickUpItem(CurrentRoom.FloorItems[MChoice - 1]);
                CurrentRoom.FloorItems.RemoveAt((MChoice - 1));
            } else
            {
                Console.WriteLine("You Return");
            }
        }

        private void ShowRoomDescription()
        {
            Console.WriteLine(CurrentRoom.GetDescription() + "\nPress Enter To Continue");
            Console.ReadLine();
        }
       
        private void MoveMenu()
        {
            Console.WriteLine("Press W, A, S or D to move to the adjacnt room in that direction");
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
                posX = newX; 
                posY = newY; 

                CurrentRoom = Map.getRoomFromArr(posX, posY); // Updates current room

                // Clear the screen and show the updated map
                Console.Clear();
                Map.Show();
            }


        }


        public void ActionMenu()
        {
            Console.WriteLine("   Action Menu:    ");
            
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
            if (Inventory.Count == 0)
            {
                Console.WriteLine("Inventory Empty!! Press Enter To Return");
                Console.ReadLine();
                return;
            }
            for (int i = 0; i < Inventory.Count; i++)
            {
                Console.WriteLine("[" + (i + 1).ToString() + "] " + Inventory[i].sName + ": " + Inventory[i].noOfItem.ToString() + "/" + Inventory[i].maxNoOfItem.ToString());
            }
            Console.WriteLine("Type the number to inspect, or 0 to skip");
            int MChoice = (GameInputs.V(Inventory.Count, 0) - 1);
            if (MChoice == -1)
                return;
            Console.WriteLine(Inventory[MChoice].sName + ": " + Inventory[MChoice].sDescription);
            Console.WriteLine("[1] Remove One\n[2] Remove All");
            if (GameInputs.V(2) == 2)
            {
                fDeleteItem(Inventory[MChoice], true);
            } else
            {
                fDeleteItem(Inventory[MChoice], false);
            }

            
        }
        private void fDeleteItem(InventoryItem ItemToRemove, bool All) // Remove item from the inventory
        {
            if (All)
                Inventory.Remove(ItemToRemove);
            for (int i = 0; i < Inventory.Count; i++)
            {
                if (Inventory[i] == ItemToRemove)
                {
                    Inventory[i].noOfItem--;
                }
            }

            

        }

    }

    public class InventoryItem
    {
        public int maxNoOfItem { get; set; }
        public int noOfItem { get; set; }
        public string sName { get; set; }
        public string sDescription;
        public InventoryItem(string name, int maxNoOfItem)
        {
            sDescription = "PLACEHOLDER";
            this.sName = name;
            this.maxNoOfItem = maxNoOfItem;
            this.noOfItem = 1;
        }
        public InventoryItem(string name, int maxNoOfItem, int noOfItem)
        {
            sDescription = "A common food item in hyrule. eating will restore health!";
            this.sName = name;
            this.maxNoOfItem = maxNoOfItem;
            this.noOfItem = noOfItem;
        }
    }
}
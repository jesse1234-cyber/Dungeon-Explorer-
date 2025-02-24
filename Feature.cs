using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class Feature
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Attribute { get; set; }
        public string SpecificAttribute { get; set; }
        public List<Item> ItemList { get; set; }
        public Feature(string name, string description = "Nothing of note meets the eye.", bool attribute = true, string specificAttribute = "locked", List<Item> itemList = null)
        {

            Name = name;
            Description = description;
            Attribute = attribute;
            SpecificAttribute = specificAttribute;
            ItemList = itemList;
        }
        public string investigateFeature()
        {
            return Description;
        }
        public void search(List<Item> inventory, List<Weapon> weaponInventory)
        {
            Console.WriteLine($"Rummaging about the {Name}, you find the following;");
            int r = 1;
            string message = $"{Description}\n";
            if (Name == "bookcase" && ItemList.Count != 0)
            {
                message += "Your keen eye notices a lone page just underneath the collapsed shelf, snagged at the back.\n";
            }
            if (Name == "rosewood chest" && Attribute == false) 
            {
                message += "You prise open the chest's lid. It yields to your firm grip with an ominous creak.\n";
            }
            if (Name == "rosewood chest" && Attribute == false && ItemList.Count != 0)
            {
                message += "Your furtive fingers scrabble at the panel at the bottom of the chest. After some effort, you manage to at last unveil a hidden compartment...\n";
            }
            List<Item> itemList = new List<Item>();
            if (ItemList != null)
            {
                if (ItemList.Count != 0)
                {
                    foreach (Item x in ItemList)
                    {
                        itemList.Add(x);
                    }
                }
            }
            if (ItemList != null)
            {
                if (Name == "rosewood chest")
                {
                    if (ItemList.Count != 0 && !Attribute)
                    {

                        foreach (Item item in itemList)
                        {
                            message += $"[{r}] {item.Name}\n";
                            r++;
                        }

                        



                        bool continueLoop = true;
                        int a = 0;
                        
                        while (continueLoop)
                        {
                            Console.WriteLine(message);
                            
                            if (a > 0) { Console.WriteLine("Select another item from the list above or enter 'no'."); }
                            else { Console.WriteLine("\nWould you like to take a closer look at any of these items?"); }
                            string reply = Console.ReadLine().Trim().ToLower();
                            if (reply == "no" || reply == "n")
                            {



                                return;


                            }
                            try
                            {
                                int reply1 = int.Parse(reply);
                                if (reply1 < 1 || reply1 > r - 1)
                                {
                                    Console.WriteLine($"Please enter a number between 1 and {r - 1}.");
                                    continue;
                                }
                                else
                                {
                                    try
                                    {
                                        bool success = false;
                                        string objName = message.Substring(message.IndexOf(reply1.ToString()) + 3, message.IndexOf((reply1 + 1).ToString()) - 2 - (message.IndexOf(reply1.ToString()) + 3));
                                        Console.WriteLine(objName);
                                        bool freshLoop = false;
                                        foreach (Item x in inventory)
                                        {
                                            if (x.Name == objName)
                                            {
                                                Console.WriteLine($"You've already stashed the {x.Name} in your pack.");
                                                freshLoop = true;
                                                break;
                                            }
                                        }

                                        foreach (Weapon x in weaponInventory)
                                        {
                                            if (x.Name == objName)
                                            {
                                                Console.WriteLine($"You've already taken the {x.Name}.");
                                                freshLoop = true;
                                                break;
                                            }
                                        }
                                        if (freshLoop) { continue; }
                                        foreach (Item i in itemList)
                                        {
                                            if (i.Name == objName)
                                            {
                                                try
                                                {
                                                    i.pickUpItem(inventory, weaponInventory, 6, 0, i, null, ItemList);

                                                }
                                                catch
                                                {
                                                    foreach (Weapon y in itemList)
                                                    {
                                                        if (y.Name == objName)
                                                        {
                                                            y.pickUpItem(inventory, weaponInventory, 6, 0, null, y, ItemList);

                                                        }
                                                    }
                                                }
                                                finally { success = true; }
                                            }
                                        }

                                    }// need another catch for if ItemList is left with no items inside
                                    catch//for if there is only one item in list or chosen item is at top of list
                                    {
                                        try
                                        {
                                            bool success = false;
                                            string objName = message.Substring(message.IndexOf((r - 1).ToString()) + 3, message.Length - 1 - (message.IndexOf((r - 1).ToString()) + 3));
                                            Console.WriteLine(objName);
                                            bool freshLoop = false;
                                            foreach (Item x in inventory)
                                            {
                                                if (x.Name == objName)
                                                {
                                                    Console.WriteLine($"You've already stashed the {x.Name} in your pack.");
                                                    freshLoop = true;
                                                    break;
                                                }
                                            }

                                            foreach (Weapon x in weaponInventory)
                                            {
                                                if (x.Name == objName)
                                                {
                                                    Console.WriteLine($"You've already taken the {x.Name}.");
                                                    freshLoop = true;
                                                    break;
                                                }
                                            }
                                            if (freshLoop) { continue; }
                                            try
                                            {
                                                foreach (Item i in itemList) { if (i.Name == objName) { i.pickUpItem(inventory, weaponInventory, 6, 0, i, null, ItemList); success = true; break; } }
                                            }
                                            catch
                                            {
                                                foreach (Weapon w in itemList) { if (w.Name == objName) { w.pickUpItem(inventory, weaponInventory, 6, 0, null, w, ItemList); success = true; break; } }
                                            }
                                        }
                                        catch
                                        {
                                            Console.WriteLine($"You've stashed the item in your pack.");
                                            return;
                                        }
                                    }

                                }
                                Console.WriteLine(message);
                                Console.WriteLine($"Would you like to peruse another item from the {Name}?");
                                
                                while (true)
                                {
                                    string answer = Console.ReadLine().Trim().ToLower();
                                    if (answer == "yes" || answer == "y")
                                    {
                                        continueLoop = true;
                                        break;
                                    }
                                    else if (answer == "no" || answer == "n")
                                    {

                                        continueLoop = false;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error! Please answer 'yes' or 'no'.");
                                    }
                                }
                                a++;
                            }
                            catch
                            {
                                Console.WriteLine("Please enter a number corresponding to your choice of action.");
                                continue;
                            }

                        }

                    }
                    else
                    {
                        if (Name == "bookcase" || (Name == "rosewood chest" && Attribute))
                        {
                            Console.WriteLine($"{Description} \nTry as hard as you might, you find no more items hidden about the {Name}. It has been thoroughly {SpecificAttribute}.");

                        }
                        else if ( Name == "rosewood chest" && !Attribute)
                        {
                            Console.WriteLine($"{Description} \nTry as hard as you might, you find no more items hidden within or around the {Name}. Even though it's been {SpecificAttribute} it still yields none of its secrets... if it has any.");
                        }
                        else
                        {
                            Console.WriteLine($"{Description} \nTry as hard as you might, you find no items hidden about the {Name}. It remains {SpecificAttribute}.");
                        }
                        return;
                    }
                }
                else if (ItemList.Count != 0)
                {
                    foreach (Item item in itemList)
                    {
                        message += $"[{r}] {item.Name}\n";
                        r++;
                    }

                    



                    bool continueLoop = true;
                    int a = 0;
                    
                    while (continueLoop)
                    {
                        Console.WriteLine(message);
                        if (a > 0) { Console.WriteLine("Select another item from the list above or enter 'no'."); }
                        else { Console.WriteLine("\nWould you like to take a closer look at any of these items?"); }
                        
                        string reply = Console.ReadLine().Trim().ToLower();
                        if (reply == "no" || reply == "n")
                        {



                            return;


                        }
                        try
                        {
                            int reply1 = int.Parse(reply);
                            if (reply1 < 1 || reply1 > r - 1)
                            {
                                Console.WriteLine($"Please enter a number between 1 and {r - 1}.");
                                continue;
                            }
                            else
                            {
                                try
                                {
                                    bool success = false;
                                    string objName = message.Substring(message.IndexOf(reply1.ToString()) + 3, message.IndexOf((reply1 + 1).ToString()) - 2 - (message.IndexOf(reply1.ToString()) + 3));
                                    Console.WriteLine(objName);
                                    bool freshLoop = false;
                                    foreach (Item x in inventory)
                                    {
                                        if (x.Name == objName)
                                        {
                                            Console.WriteLine($"You've already stashed the {x.Name} in your pack.");
                                            freshLoop = true;
                                            break;
                                        }
                                    }

                                    foreach (Weapon x in weaponInventory)
                                    {
                                        if (x.Name == objName)
                                        {
                                            Console.WriteLine($"You've already taken the {x.Name}.");
                                            freshLoop = true;
                                            break;
                                        }
                                    }
                                    if (freshLoop) { continue; }
                                    foreach (Item i in itemList)
                                    {
                                        if (i.Name == objName)
                                        {
                                            try
                                            {
                                                i.pickUpItem(inventory, weaponInventory, 6, 0, i, null, ItemList);

                                            }
                                            catch
                                            {
                                                foreach (Weapon y in itemList)
                                                {
                                                    if (y.Name == objName)
                                                    {
                                                        y.pickUpItem(inventory, weaponInventory, 6, 0, null, y, ItemList);

                                                    }
                                                }
                                            }
                                            finally { success = true; }
                                        }
                                    }

                                }// need another catch for if ItemList is left with no items inside
                                catch//for if there is only one item in list or chosen item is at top of list
                                {
                                    try
                                    {
                                        bool success = false;
                                        string objName = message.Substring(message.IndexOf((r - 1).ToString()) + 3, message.Length - 1 - (message.IndexOf((r - 1).ToString()) + 3));
                                        Console.WriteLine(objName);
                                        bool freshLoop = false;
                                        foreach (Item x in inventory)
                                        {
                                            if (x.Name == objName)
                                            {
                                                Console.WriteLine($"You've already stashed the {x.Name} in your pack.");
                                                freshLoop = true;
                                                break;
                                            }
                                        }

                                        foreach (Weapon x in weaponInventory)
                                        {
                                            if (x.Name == objName)
                                            {
                                                Console.WriteLine($"You've already taken the {x.Name}.");
                                                freshLoop = true;
                                                break;
                                            }
                                        }
                                        if (freshLoop) { continue; }
                                        try
                                        {
                                            foreach (Item i in itemList) { if (i.Name == objName) { i.pickUpItem(inventory, weaponInventory, 6, 0, i, null, ItemList); success = true; break; } }
                                        }
                                        catch
                                        {
                                            foreach (Weapon w in itemList) { if (w.Name == objName) { w.pickUpItem(inventory, weaponInventory, 6, 0, null, w, ItemList); success = true; break; } }
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine($"You've stashed the item in your pack.");
                                        return;
                                    }
                                }

                            }

                            
                            while (true)
                            {
                                Console.WriteLine(message);
                                Console.WriteLine($"Would you like to peruse another item from the {Name}?");
                                
                                string answer = Console.ReadLine().Trim().ToLower();
                                try
                                {
                                    reply1 = int.Parse(answer);
                                    if (reply1 < 1 || reply1 > r - 1)
                                    {
                                        Console.WriteLine("Please enter a number between 1 and 3");
                                    }
                                    try
                                    {
                                        bool success = false;
                                        string objName = message.Substring(message.IndexOf(reply1.ToString()) + 3, message.IndexOf((reply1 + 1).ToString()) - 2 - (message.IndexOf(reply1.ToString()) + 3));
                                        Console.WriteLine(objName);
                                        bool freshLoop = false;
                                        foreach (Item x in inventory)
                                        {
                                            if (x.Name == objName)
                                            {
                                                Console.WriteLine($"You've already stashed the {x.Name} in your pack.");
                                                freshLoop = true;
                                                break;
                                            }
                                        }

                                        foreach (Weapon x in weaponInventory)
                                        {
                                            if (x.Name == objName)
                                            {
                                                Console.WriteLine($"You've already taken the {x.Name}.");
                                                freshLoop = true;
                                                break;
                                            }
                                        }
                                        if (freshLoop) { continue; }
                                        foreach (Item i in itemList)
                                        {
                                            if (i.Name == objName)
                                            {
                                                try
                                                {
                                                    i.pickUpItem(inventory, weaponInventory, 6, 0, i, null, ItemList);

                                                }
                                                catch
                                                {
                                                    foreach (Weapon y in itemList)
                                                    {
                                                        if (y.Name == objName)
                                                        {
                                                            y.pickUpItem(inventory, weaponInventory, 6, 0, null, y, ItemList);

                                                        }
                                                    }
                                                }
                                                finally { success = true; }
                                            }
                                        }

                                    }// need another catch for if ItemList is left with no items inside
                                    catch//for if there is only one item in list or chosen item is at top of list
                                    {
                                        try
                                        {
                                            bool success = false;
                                            string objName = message.Substring(message.IndexOf((r - 1).ToString()) + 3, message.Length - 1 - (message.IndexOf((r - 1).ToString()) + 3));
                                            Console.WriteLine(objName);
                                            bool freshLoop = false;
                                            foreach (Item x in inventory)
                                            {
                                                if (x.Name == objName)
                                                {
                                                    Console.WriteLine($"You've already stashed the {x.Name} in your pack.");
                                                    freshLoop = true;
                                                    break;
                                                }
                                            }

                                            foreach (Weapon x in weaponInventory)
                                            {
                                                if (x.Name == objName)
                                                {
                                                    Console.WriteLine($"You've already taken the {x.Name}.");
                                                    freshLoop = true;
                                                    break;
                                                }
                                            }
                                            if (freshLoop) { continue; }
                                            try
                                            {
                                                foreach (Item i in itemList) { if (i.Name == objName) { i.pickUpItem(inventory, weaponInventory, 6, 0, i, null, ItemList); success = true; break; } }
                                            }
                                            catch
                                            {
                                                foreach (Weapon w in itemList) { if (w.Name == objName) { w.pickUpItem(inventory, weaponInventory, 6, 0, null, w, ItemList); success = true; break; } }
                                            }
                                        }
                                        catch
                                        {
                                            Console.WriteLine($"You've stashed the item in your pack.");
                                            return;
                                        }
                                    }

                                }
                                catch
                                {
                                    if (answer == "yes" || answer == "y")
                                    {
                                        continueLoop = true;
                                        break;
                                    }
                                    else if (answer == "no" || answer == "n")
                                    {

                                        continueLoop = false;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error! Please answer 'yes' or 'no'.");
                                    }
                                }
                            }
                            a++;
                        }
                        catch
                        {
                            Console.WriteLine("Please enter a number corresponding to your choice of action.");
                            continue;
                        }

                    }
                }
                else
                {
                    if (Name == "bookcase" || Name == "rosewood chest")
                    {
                        Console.WriteLine($"{Description} \nTry as hard as you might, you find no more items hidden about the {Name}. It has been thoroughly {SpecificAttribute}.");

                    }
                    else
                    {
                        Console.WriteLine($"{Description} \nTry as hard as you might, you find no items hidden about the {Name}. It remains {SpecificAttribute}.");
                    }
                    return;
                }
            }
            else
            {
                if (Name == "bookcase" || Name == "rosewood chest")
                {
                    Console.WriteLine($"{Description} \nTry as hard as you might, you find no more items hidden about the {Name}. It has been thoroughly {SpecificAttribute}.");

                }
                else
                {
                    Console.WriteLine($"{Description} \nTry as hard as you might, you find no items hidden about the {Name}. It remains {SpecificAttribute}.");
                }
                return;
            }
            
        }
    }

    }


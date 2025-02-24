﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class Room
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> ItemList { get; set; }
        public List<Feature> FeatureList { get; set; }
        public Room(string name, string description, List<Item> itemList, List<Feature> featureList)
        {
            Name = name;
            Description = description;
            ItemList = itemList;
            FeatureList = featureList;
        }
        public void investigate(List<Item> inventory, List<Weapon> weaponInventory, int b, Player player)
        {
            Dice D20 = new Dice(20);
            List<string> ministryOfSillyWalks = new List<string> {
            "You blithely saunter",
            "You make your merry way",
            "You sashay up",
            "You do a jolly skip over",
            "You prance",
            "You dance your way",
            "You jog up",
            "You step over",
            "You walk over",
            "You strut your sexy stuff up",
            "You glide over",
            "You sidle up",
            "You do a leisurely stroll",
            "You titter your way over",
            "You giggle as you sidle up",
            "You flounce over",
            "You swagger up",
            "You bounce up",
            "You hop up",
            "You rollick your way up"
            };
            if (b < 1)
            {
                Console.WriteLine($"Will you investigate the {Name}'s...");
                Console.WriteLine("[1] Northern wall?");
                Console.WriteLine("[2] Westernmost wall?");
                Console.WriteLine("[3] South wall?");
                Console.WriteLine("[4] Eastern Wall?");
                bool continueInvestigate = true;
                int reply2 = 0;
                while (continueInvestigate)
                {
                    string reply = "";
                    if (reply2 == 0)
                    {
                        reply = Console.ReadLine().Trim().ToLower();
                    }
                    else
                    {
                        reply = reply2.ToString();
                    }


                    if (string.IsNullOrWhiteSpace(reply))
                    {
                        Console.WriteLine($"Will you glance over the {Name}'s...");
                        Console.WriteLine("[1] Northern wall?");
                        Console.WriteLine("[2] Westernmost wall?");
                        Console.WriteLine("[3] South wall?");
                        Console.WriteLine("[4] Eastern Wall?"); continue;
                    }

                    try
                    {
                        int reply1 = int.Parse(reply);
                        if (reply1 < 1 || reply1 > 4) { Console.WriteLine("Please enter a number from 1 to 4."); reply2 = 0; continue; }
                        else if (reply1 == 1)
                        {
                            string message = Description.Substring(Description.IndexOf("\n") + 1, Description.IndexOf("\t") - Description.IndexOf("\n"));
                            Console.WriteLine(message);

                        }
                        else if (reply1 == 2)
                        {
                            string message = Description;
                            message = message.Substring(message.IndexOf("\n") + 2, message.Length - 2 - message.Substring(0, message.IndexOf("\n")).Length);
                            message = message.Substring(message.IndexOf("\n") + 1, message.Length - 2 - message.Substring(0, message.IndexOf("\n")).Length);
                            message = message.Substring(0, message.IndexOf("\t"));
                            Console.WriteLine(message);
                        }
                        else if (reply1 == 3)
                        {
                            string message = Description;
                            message = message.Substring(message.IndexOf("\n") + 2, message.Length - 2 - message.Substring(0, message.IndexOf("\n")).Length);
                            message = message.Substring(message.IndexOf("\n") + 2, message.Length - 2 - message.Substring(0, message.IndexOf("\n")).Length);
                            message = message.Substring(message.IndexOf("\n") + 1, message.Length - 2 - message.Substring(0, message.IndexOf("\n")).Length);
                            message = message.Substring(0, message.IndexOf("\t"));
                            Console.WriteLine(message);
                        }
                        else if (reply1 == 4)
                        {
                            string message = Description;
                            message = message.Substring(message.IndexOf("\n") + 2, message.Length - 2 - message.Substring(0, message.IndexOf("\n")).Length);
                            message = message.Substring(message.IndexOf("\n") + 2, message.Length - 2 - message.Substring(0, message.IndexOf("\n")).Length);
                            message = message.Substring(message.IndexOf("\n") + 2, message.Length - 2 - message.Substring(0, message.IndexOf("\n")).Length);
                            message = message.Substring(message.IndexOf("\n") + 1, message.Length - 2 - message.Substring(0, message.IndexOf("\n")).Length);
                            message = message.Substring(0, message.IndexOf("\t"));
                            Console.WriteLine(message);
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please enter the number corresponding to a listed choice.");
                    }
                    Console.WriteLine("Do you wish to investigate any of the other sides of the room?");
                    reply2 = 0;
                    while (true)
                    {
                        string nextAnswer = Console.ReadLine().Trim().ToLower();
                        try
                        {
                            reply2 = int.Parse(nextAnswer);
                            break;
                        }
                        catch
                        {


                            if (nextAnswer == "yes" || nextAnswer == "y")
                            {
                                continueInvestigate = true;
                                break;
                            }
                            else if (nextAnswer == "no" || nextAnswer == "n")
                            {
                                continueInvestigate = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please enter 'yes' or 'no'");

                            }
                        }
                    }



                }
            }
            Console.WriteLine($"Would you like to perhaps make a closer inspection of the {Name}'s features, pick up some of the {Name}'s items?\nOr would you prefer a different course of action for now?");
            int k = 1;
            Dice D9 = new Dice(9);
            List<string> searchWords = new List<string> { "Search", "Scour", "Investigate", "Inspect", "Scrutinise", "Examine", "Probe", "Check", "Ransack" };
            string options = "";
            
            List<Item> itemList = new List<Item>();
            if (ItemList != null)
            {
                foreach (Item x in ItemList)
                {
                    itemList.Add(x);
                }
            }
            foreach (Feature f in FeatureList) { int i = D9.Roll(D9) - 1; options += $"[{k}] {searchWords[i]} the {f.Name}.\n"; k++; }
            
            
            foreach (Item g in itemList) { options += $"[{k}] Pick up the {g.Name}\n"; k++; }
            options += $"[{k}] Try something else";
            Console.WriteLine(options);
            while (true)
            {
                string answer = Console.ReadLine().Trim().ToLower();
                if (string.IsNullOrEmpty(answer))
                {
                    Console.WriteLine("Choose a number corresponding to the list above.");
                    Console.WriteLine(options); 
                    continue;
                }
                else
                {
                    try
                    {
                        int answer1 = int.Parse(answer) - 1;
                        if (answer1 < 0 || answer1 > k-1)
                        {
                            Console.WriteLine($"Please enter a number between 1 and {k}.");
                            continue;
                        }
                        else if (answer1 < FeatureList.Count)
                        {
                            if (player.Traits.ContainsKey("friends with fairies"))
                            {
                                Console.WriteLine($"\n{ministryOfSillyWalks[D20.Roll(D20) - 1]} to the {FeatureList[answer1].Name}...\n");            
                            }
                            FeatureList[answer1].investigateFeature();
                            FeatureList[answer1].search(inventory, weaponInventory);
                            
                            Console.WriteLine(options);
                            continue;
                        }
                        else if (answer1 < k - 1) 
                        {
                            try
                            {
                                bool freshLoop = false;
                                foreach (Item x in inventory)
                                {
                                    if (x.Name == itemList[answer1 - FeatureList.Count].Name)
                                    {
                                        Console.WriteLine($"You've already stashed the {x.Name} in your pack.");
                                        freshLoop = true;
                                        break;
                                    }
                                }

                                foreach (Weapon x in weaponInventory)
                                {
                                    if (x.Name == ItemList[answer1 - FeatureList.Count].Name)
                                    {
                                        Console.WriteLine($"You've already taken the {x.Name}.");
                                        freshLoop = true;
                                        break;
                                    }
                                }
                                if (freshLoop) { continue; }
                                List<Item> weaponSplice = new List<Item> { itemList[answer1 - FeatureList.Count] };
                                List<Weapon> weapon1 = weaponSplice.Cast<Weapon>().ToList();
                                weapon1[0].pickUpItem(inventory, weaponInventory, 4, 0, null, weapon1[0], null, ItemList);
                            }
                            catch
                            {
                                bool freshLoop = false;
                                foreach (Item x in inventory)
                                {
                                    if (x.Name == itemList[answer1 - FeatureList.Count].Name)
                                    {
                                        Console.WriteLine($"You've already stashed the {x.Name} in your pack.");
                                        freshLoop = true;
                                        break;
                                    }
                                }

                                foreach (Weapon x in weaponInventory)
                                {
                                    if (x.Name == itemList[answer1 - FeatureList.Count].Name)
                                    {
                                        Console.WriteLine($"You've already taken the {x.Name}.");
                                        freshLoop = true;
                                        break;
                                    }
                                }
                                if (freshLoop) { continue; }
                                itemList[answer1 - FeatureList.Count].pickUpItem(inventory, weaponInventory, 4, 0, itemList[answer1 - FeatureList.Count], null, null, ItemList); 
                                    
                                
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    catch (Exception e) { Console.WriteLine("Please enter the number corresponding to your choice of action."); }
                }

            }
        }
    } 
}

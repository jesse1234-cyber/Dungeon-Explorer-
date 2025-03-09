using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Attribute { get; set; }
        public string SpecifyAttribute { get; set; }
        public int SpecialEffect { get; set; }
        public string Special { get; set; }
        public Item(string name, string description = "Nothing of note meets the eye.", bool attribute = true, string specifyAttribute = "unshattered", int specialEffect = 0, string special = null)
        {

            Name = name;
            Description = description;
            Attribute = attribute; // true (unshattered) or false
            SpecifyAttribute = specifyAttribute; // unshattered --> shattered
            SpecialEffect = specialEffect; // alters Weapon.Boon
            Special = special;  //describes special effect on console
        }

        private void StashItem(Item item, List<Item> inventory) // player1.inventory?
        {
            inventory.Add(item);
        }
        private void StashWeapon(Weapon weapon, List<Weapon> weaponInventory)
        {
            weaponInventory.Add(weapon);
        }
        public string studyItem(Item item)
        {
            return item.Description;
        }
        /// <summary>
        /// pickupitem can be used to pick up weapons or items, however the distinction
        /// must be made clear in the parameters beforehand. range and value work to distinguish,
        /// in effect, when and where the picking up is taking place. Are you picking up the item
        /// from within the room, around a feature, from within your pack, during battle? 
        /// While there is no explicit parameter demarcating these instances, range and/or value, do
        /// the work to ensure there's no confusion. They are primarily about customising the
        /// wording printed to the console when picking up your weapon or item. But by virtue of this
        /// they double as a means of determining the context within which items are being picked up too.
        /// 
        ///
        /// </summary>
        /// <param name="inventory"></param>
        /// <param name="weaponInventory"></param>
        /// <param name="range"></param>
        /// <param name="value"></param>
        /// <param name="item"></param>
        /// <param name="weapon"></param>
        /// <param name="featureItems"></param>
        /// <param name="roomItems"></param>
        public void pickUpItem(List<Item> inventory, List<Weapon> weaponInventory,  int range, int value = 0, Item item = null, Weapon weapon = null, List<Item> featureItems = null, List<Item> roomItems = null, Weapon yourRustyChains = null)
        {
            //the following are customised messages for when an item is picked up. 
            List<string> messages = new List<string> { $"The {Name} now rests in your hands.", $"You reach over and pick up the {Name}.", $"You grasp the {Name} in your hands.", $"The {Name} is now clasped firmly in your hands.", $"With some trepidation, your clammy hand grips the {Name}.", $"You prise the {Name} from it's resting place", $"You slide the {Name} into your hands.", $"The {Name} is now nestled in your hands." };
            if (value == 0)
            {
                var random = new Random();
                int index = random.Next(0, range + 1);
                Console.WriteLine(messages[index]);
            }
            else
            {
                int index = value;
                Console.WriteLine(messages[index]);
            }
            /// Note the change in wording depending on the value of range.
            if (range == 3 || range == 4|| range == 6)
            {
                Console.WriteLine($"\nWould you like to:\n [1]study the {Name} closer \n[2]stash it upon your person \n[3]place it back where you found it?");
            }
            else if (range == 5)
            {
                Console.WriteLine($"\nWould you like to:\n [1]study the {Name} closer \n[2]stash it back in your pack \n[3]discard it?");
            }
            do
            {
                string answer = Console.ReadLine();
                if (answer.Trim() == "")
                {
                    Console.WriteLine("Please enter '1', '2', or '3'");
                    if (range == 3 || range == 4 || range == 6)
                    {
                        Console.WriteLine($"\nWould you like to:\n [1]study the {Name} closer \n[2]stash it upon your person \n[3]place it back where you found it?");
                    }
                    else if (range == 5)
                    {
                        Console.WriteLine($"\nWould you like to:\n [1]study the {Name} closer \n[2]stash it back in your pack \n[3]discard it?");
                    }
                    continue;
                }
                /// this was incase the user typed something like 'option 2' or something
                int size = answer.Trim().Length;
                char answerChar = answer.Trim()[size - 1];
                answer = answerChar.ToString();
                try
                {
                    int answerNum = int.Parse(answer);
                    if (answerNum < 1 || answerNum > 3)
                    {
                        Console.WriteLine("Please choose option 1, 2, or 3.");
                        continue;
                    }
                    else if (answerNum == 1)//study the item
                    {
                        if (weapon == null)//if item is not a weapon
                        {
                            Console.WriteLine(studyItem(item));
                            if (range == 3 || range == 4 || range == 6)
                            {
                                Console.WriteLine($"\nWould you now like to:\n [1]study the {Name} again \n[2]stash it upon your person \n[3]place it back where you found it?");
                            }
                            else if (range == 5)
                            {
                                Console.WriteLine($"\nWould you now like to:\n [1]study the {Name} again \n[2]stash it back in your pack \n[3]discard it?");
                            }
                            continue;
                        }
                        else//if item is a weapon
                        {
                            Console.WriteLine(studyItem(weapon));
                            if (range == 3 || range == 4 || range == 6)
                            {
                                Console.WriteLine($"\nWould you like to:\n [1]study the {Name} closer \n[2]stash it upon your person \n[3]place it back where you found it?");
                            }
                            else if (range == 5)
                            {
                                Console.WriteLine($"\nWould you like to:\n [1]study the {Name} closer \n[2]stash it back in your pack \n[3]discard it?");
                            }
                            continue;
                        }
                    }
                    else if (answerNum == 2)
                    {
                        if (range == 3) // monsters must always carry only things the player does not already have.
                        {
                            if (item == null)
                            {
                                StashWeapon(weapon, weaponInventory);
                                Console.WriteLine($"{Name} has been stashed in inventory.");
                                return;
                            }
                            else
                            {
                                StashItem(item, inventory);
                                Console.WriteLine($"{Name} has been stashed in inventory.");
                                return;
                            }
                        }
                        else if (range == 4)//searching room
                        {
                            if (item == null)
                            {
                                if (weapon.Name == "rusty chains")
                                {
                                    
                                    
                                    
                                    
                                    StashWeapon(yourRustyChains, weaponInventory);
                                }
                                else
                                {


                                    StashWeapon(weapon, weaponInventory);
                                }
                                if (weapon.Name != "bowl fragments" && weapon.Name != "rusty chains" && weapon.Name != "garment")
                                {
                                    roomItems.Remove(weapon);
                                    
                                }
                                if (weapon.Name == "rusty chains") 
                                { 
                                    Item rustyChains = new Item("rusty chains", "The rest of these chains crumble underfoot. They're of no use to anyone."); 
                                    roomItems.Add(rustyChains); 
                                }
                                Console.WriteLine($"{Name} has been stashed in inventory.");

                                return;
                            }
                            else
                            {
                                StashItem(item, inventory);
                                if (item.Name != "bowl fragments" && item.Name != "rusty chains" && item.Name != "garment")
                                {
                                    roomItems.Remove(item);
                                }
                                Console.WriteLine($"{Name} has been stashed in inventory.");

                                return;
                            }
                        }
                        else if (range == 6)// searching feature
                        {
                            if (item == null)
                            {
                                StashWeapon(weapon, weaponInventory);
                                featureItems.Remove(item);
                                Console.WriteLine($"{Name} has been stashed in inventory.");

                                return;
                            }
                            else
                            {
                                StashItem(item, inventory);
                                featureItems.Remove(item);
                                Console.WriteLine($"{Name} has been stashed in inventory.");

                                return;
                            }
                        }
                        else { Console.WriteLine("You place the item back in your pack."); return; }
                    }
                    else
                    {
                        if (range == 5)//if discarding weapon/item from your pack
                        {
                            if (weapon == null)
                            {
                                inventory.Remove(item);
                                roomItems.Add(item);
                                Console.WriteLine($"You discard your {item.Name}. Who needs that old thing anyway?");
                                return;
                            }
                            else//would have to cast weapon as item to store in roomitems - possible but unnecessary given story context
                            {
                                
                                Console.WriteLine($"Erm... Upon consideration you think discarding your {weapon.Name}, or any weapon, might be a bad idea...");
                                return;
                            }
                        }
                        else
                        {
                            if (weapon == null)
                            {
                                Console.WriteLine($"You place the {item.Name} back where you found it.");
                                return;
                            }
                            else
                            {
                                Console.WriteLine($"You place the {weapon.Name} back where you found it.");
                                return;
                            }
                        }
                    }
                }
                catch //if a number was not entered
                {
                    Console.WriteLine("Please enter '1', '2', or '3'");
                    if (range == 3 || range == 4 || range == 6)
                    {
                        Console.WriteLine($"\nWould you like to:\n [1]study the {Name} closer \n[2]stash it upon your person \n[3]place it back where you found it?");
                    }
                    else if (range == 5)
                    {
                        Console.WriteLine($"\nWould you like to:\n [1]study the {Name} closer \n[2]stash it back in your pack \n[3]discard it?");
                    }
                    continue;
                }
            } while (true);
        }
        /// <summary>
        /// there are three functions below that essentially do the same thing. useItem is
        /// for using an item on another item. useItem1 is for using an item on a feature.
        /// useItem3 is for using an item on the player character. 
        /// A dictionary is used to determine whether an item can be used on something else. 
        /// After checking this dictionary, if successfully found, the item will cause the other object
        /// to change the value of it's attribute and specialAttribute (unless player character)
        /// Doors that were locked become unlocked, etc. 
        ///   Special commentary is added for important features or items that can be effected
        /// and that further the plot.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="feature"></param>
        /// <param name="usesDictionary"></param>
        /// <param name="inventory"></param>
        /// <param name="weaponInventory"></param>
        /// <param name="binkySkull"></param>
        /// <returns></returns>
        public bool useItem1(Item item, Feature feature, Dictionary<Item, List<Feature>> usesDictionary, List<Item> inventory, List<Weapon> weaponInventory, Item binkySkull = null)
        {
            if (usesDictionary[item].Contains(feature))
            {
                feature.Attribute = !feature.Attribute; // key lock unlock, weapon intact broken, magical charm uncharmed charmed, etc
                if (feature.Attribute == false)
                {
                    feature.SpecificAttribute = "un" + feature.SpecificAttribute;
                    if (item.Name == "steel key" && feature.Name == "rosewood chest")
                    {
                        Console.WriteLine("The key slides easily into the lock. With one sharp twist the clasp comes undone");
                        Console.WriteLine("Now that the rosewood chest is unlocked, would you like to search it?");
                        while (true)
                        {
                            string answer = Console.ReadLine().Trim().ToLower();
                            if (string.IsNullOrWhiteSpace(answer))
                            {
                                Console.WriteLine("Now that the rosewood chest is unlocked, would you like to search it?");
                                continue;
                            }
                            else if (answer == "yes" || answer == "y")
                            {
                                feature.search(inventory, weaponInventory);
                                break;
                            }
                            else if (answer == "no" || answer == "n")
                            {
                                Console.WriteLine("You decide on some other course of action for now...");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please enter 'yes' or 'no'.");
                                continue;
                            }
                        }
                    }
                    else if ((item.Name == "healing potion" || item.Name == "Elixir of Feline Guile" || item.Name == "Felix Felicis") && binkySkull != null)
                    {
                        Console.WriteLine($"The {item.Name} works its magic as you gloop the elixir over the skull. You blink and before you know it the skeleton let's loose a string of delightful curses worthy of the most mischievous of pixies.\n" +
                            $"\t'I say, capital to meet you, good sir,' it remarks gaily, 'I would doff my hat, if I had one. Sadly all I've got on me is a SKULL CAP!'\n" +
                            $"It wheezes a few raspy laughs. \nThe joke flies over your head like a squadron of fairies..." +
                            $"\nYou ask if he by any chance knows a way out of this cell." +
                            $"\n\t'Well, now. I reckon that broken bowl ought to do the trick.'" +
                            $"\nYou interject, wondering how it can be useful when it's shattered in two halves..." +
                            $"\n\t'Precisely,' is the skeleton's cryptic reply. 'Besides, if that fails to " +
                            $"get the job done, then you could always play a tune. I think that's right...? My ribs make a good xylophone" +
                            $"to get you started.'\nYou say you'd love to play a ditty some time but you've got an unknown evil adversary" +
                            $" to smite and if you don't do it then who will?\n\t'Well,' the skeleton remarks drily, 'that there's no" +
                            $"laughing matter. No. Not HUMERUS at all!" +
                            $"\nAgain, this sails whooshing over your head." +
                            $"\nPerhaps you can take me with you?' the skeleton says, 'I'm great at advice.'\n" +
                            $"You thank him and ask his name. he responds, 'Binky.' you ask where he got such an unusual name. He replies that's the name the developer gave to all his trial characters. \n\t'Hmmm...' You respond.");
                        Console.WriteLine("\nYou add Binky to your pack!");

                        inventory.Add(binkySkull);
                        return true;

                    }
                    else
                    {
                        feature.SpecificAttribute = feature.SpecificAttribute.Substring(2, feature.SpecificAttribute.Length - 2);
                        
                    }
                    return true;
                }
                else
                {
                    feature.SpecificAttribute = feature.SpecificAttribute.Substring(2, feature.SpecificAttribute.Length - 2);
                    if (feature.Name == "skeleton")
                    {
                        feature.ItemList.Add(binkySkull);//binkySkull in this instance is steel key
                        feature.Description = "Its empty sockets fasten you with a stern gaze. It serves as a macabre reminder of what might yet befall you...";
                        Console.WriteLine($"Using your weapon you smash the skeleton's bones from the constricting chains. You succeed, but in the process your {item.Name} shatters into pieces. Finally you can move the {feature.SpecificAttribute} skeleton, piece by piece, out of the way, revealing something glimmering underneath...");
                        List<Item> weaponList = new List<Item> { item };
                        List<Weapon> weaponSplice = weaponList.Cast<Weapon>().ToList();

                        weaponInventory.Remove(weaponSplice[0]);
                        Console.WriteLine("Would you now like to search the skeleton?");
                        while (true)
                        {
                            string answer = Console.ReadLine().Trim().ToLower();
                            if (string.IsNullOrWhiteSpace(answer))
                            {
                                Console.WriteLine("Would you now like to search the skeleton?");
                                continue;
                            }
                            else if (answer == "yes" || answer == "y")
                            {
                                feature.search(inventory, weaponInventory);
                                break;
                            }
                            else if (answer == "no" || answer == "n")
                            {
                                Console.WriteLine("You decide on some other course of action for now...");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please enter 'yes' or 'no'.");
                                continue;
                            }
                        }
                    }
                    return true; }
            }
            else { return false; }
        }
        public List<bool> useItem(Item item1, Item item2, Dictionary<Item, List<Item>> usesDictionary, Feature feature = null, Item plusItem = null, Room room = null, Player player = null, Feature addFeature = null, Dictionary<Item, List<Feature>> usesDictionaryItemFeature = null, Dictionary<Item, List<Player>> usesDictionaryItemChar = null, Player player1 = null, Combat trialBattle = null)
        {
            List<bool> tlist = new List<bool> { false, false };
            if (usesDictionary[item1].Contains(item2))
            {
                item2.Attribute = !item2.Attribute; // key lock unlock, weapon intact broken, magical charm uncharmed charmed, etc
                if (item2.Attribute == false)
                {
                    item2.SpecifyAttribute = item2.SpecifyAttribute.Substring( 2, item2.SpecifyAttribute.Length-2);
                    if (item1.Name == "magnifying glass" && item2.Name == "garment" && player.Traits.ContainsKey("jinxed"))
                    {
                        Console.WriteLine("You slump to the floor, if not exactly resigned then idling in an absent minded flight of fancy. You toy with the magnifying glass, a bored expression on your face as you twist it this way and that.\nIt's minutes before an acrid scent hits your nostrils. Is that fried bacon?");
                        Console.ReadKey(true);
                        Console.WriteLine($"You look down and yelp as you realise the magnifying glass had focused the light from the brazier. The garment you'd picked up has caught fire!");
                        Console.ReadKey(true);
                        Console.WriteLine("You flail it around trying to put out the flames like a crazed whirlwind of oafishness, spreading the fire in the process. Already a pool of dark, cloying smoke billows about the ceiling as the dank cell heats up like a furnace. You throw the garment at the door, before banging on it for all your worth. \nYou yell out that there's a fire. It's not long before boots stomp their way towards your door. Tumblers turn, then a powerful kick flings it open.");
                        Console.ReadKey(true);
                        Console.WriteLine("You brace yourself for the fight of your life...");
                        Console.ReadKey(true);
                        player.Inventory.Remove(item2);
                        bool fire = true;
                        if (trialBattle.fight(usesDictionary, usesDictionaryItemFeature, room, player1, usesDictionaryItemChar, addFeature, fire))
                        {
                            tlist[0] = true;
                            tlist[1] = true;
                            
                            return tlist;
                        }

                        
                        else { System.Environment.Exit(0); }
                    }
                    else if(item1.Name == "magnifying glass" && item2.Name == "garment")
                    {
                        Console.WriteLine("If you can't start a fire with the naked flame, then you guess the only way will be with the magnifying glass.\nHolding it close to the brazier to capture and harness the most light, you focus its rays upon the garment, beads of nervous sweat prickling your brow as you concentrate.");
                        Console.ReadKey(true);
                        Console.WriteLine("It's not before too long that you've managed to get the garment to smoulder. Cupping it in your hands you gently breathe over it, teasing forth the flames.\nOnce its burning you tuck the blazing garment under the door, letting the smoke billow out into the corridor. Now, at last, you hammer upon the door, yelling that the room's ablaze...");
                        Console.ReadKey(true);
                        Console.WriteLine("You planned for it to burn slowly.");
                        Thread.Sleep(3000);
                        Console.WriteLine("You planned for the fire to be controlled.");
                        Thread.Sleep(3000);
                        Console.WriteLine("However, its not long before your feigned panic congeals into very real terror. Before your eyes, and in spite of your frantic attempts to stomp it out, the fire has spread to the other garments littered throughout the room.");
                        Console.WriteLine("You begin to scream out for help, when your yells are answered. Heavy boots stomp their way towards your door. Tumblers turn, then a powerful kick flings it wide.");
                        Console.ReadKey(true);
                        Console.WriteLine("You brace yourself for the fight of your life...");
                        Console.ReadKey(true);
                        player.Inventory.Remove(item2);
                        bool fire = true;
                        if (trialBattle.fight(usesDictionary, usesDictionaryItemFeature, room, player1, usesDictionaryItemChar, addFeature, fire))
                        {
                            tlist[0] = true;
                            tlist[1] = true;
                            return tlist;
                        }
                        else { System.Environment.Exit(0); }
                    }
                    else if (item2.Name == "note" && item1.Name == "magnifying glass")
                    {
                        Console.WriteLine("  You peer through the magnifying glass and suddenly the note's mysterious, tiny scrawl starts to make sense...");
                        item2.Description = "Someone has scrawled upon the note in hasty erratic cursive. It reads, 'I don't have long now. If you're reading this then you're likely another foolhardy adventurer like myself who got his'self kidnapped just as I woz. I don' have much space so mark my words. Whatever they tell you - its a lie. They're going to harm you. They're most likely going to kill you in one of their mad experiments. There's a music box. I kept it locked away and hidden from sight. It's in the chest. It may look empty but set in its bottom is a panel that can be removed. You'll find it there. If you play it the guard loses his marbles about it. Can't stand the tune, the little blighter! It's like nails on a chalkboard to 'em creatures. When it enters, subdue the loathsome thing. It's the only way out of 'ere. Hopefully, if I don't make it, at least someone else will...' The rest deteriorates into an illegible scribble at the bottom of the page.";
                        if (feature.ItemList.Count==0) 
                        { 
                            feature.ItemList.Add(plusItem); 
                        }
                        Console.WriteLine(item2.Description);
                        Console.WriteLine($"After having finally read the note, you eye the rosewood chest with renewed interest...");
                    }
                    else if ((item2.Name == "other half of a cracked bowl" && item1.Name == "half a cracked bowl")||(item1.Name == "other half of a cracked bowl" && item2.Name == "half a cracked bowl"))
                    {
                        Console.WriteLine("Your tongue parts your lips just slightly as you pick up the two halves of the bowl, one in each hand.\nYour shrewd gaze turns from one to the other, tongue still protruding slightly in derpy concentration. Then you place the two halves together to make a (w)hole. \nYou then place this (w)hole in the ceiling creating an exit to the room above.\nWait? You catch yourself. Does this make sense? \n\t'Sure it does!' your fairy friends assure you. \nYeah...yeah, of course. Thanks guys!");
                        room.FeatureList.Add(addFeature);// feature = holeInCeiling
                        player.Inventory.Remove(item1);
                        player.Inventory.Remove(item2);
                        room.ItemList.Remove(item1);
                        room.ItemList.Remove(item2);
                        Console.WriteLine($"You now have a way out of the {room.Name}!");
                    }
                }
                else
                {
                    item2.SpecifyAttribute = "un" + item2.SpecifyAttribute;
                }
                tlist[0] = true;
                return tlist;
            }
            else { return tlist; }

        }
        public bool useItem3(Item item1, Player player, Dictionary<Item, List<Player>> usesDictionary)
        {
            try {
                if (usesDictionary[item1].Contains(player))
                {


                    Dice D6 = new Dice(6);
                    string propString = item1.Special.Substring(0, Special.IndexOf(":"));
                    //PropertyInfo boost = typeof(int).GetProperty(propString);
                    //object value = boost.GetValue(player, null);
                    //int CharacterAttribute = Convert.ToInt32(value);
                    if (propString == "Stamina")
                    {
                        if (player.Traits.ContainsKey("medicine man"))
                        {
                            int boost = D6.Roll(D6) + D6.Roll(D6) + D6.Roll(D6) + D6.Roll(D6) + D6.Roll(D6) + D6.Roll(D6);
                            if (player.Stamina == player.InitialStamina)
                            {
                                Console.WriteLine($"{item1.Name} has no effect. You're already as fit as can be.");
                            }
                            else if (player.Stamina + boost > player.InitialStamina)
                            {
                                player.Stamina = player.InitialStamina;
                                Console.WriteLine("\nYou've fully healed!");
                            }
                            else
                            {
                                player.Stamina += boost;
                                Console.WriteLine($"\nYou've healed by {boost} stamina points!");
                            }
                        }
                        else if (player.Traits.ContainsKey("friends with fairies"))
                        {
                            Dice D40 = new Dice(40);
                            Dice D4 = new Dice(4);
                            int boost = D40.Roll(D40);
                            if (player.Stamina + 2*player.Skill >= player.InitialStamina)
                            {
                                if (boost < 13)
                                {
                                    Console.WriteLine($"The {item1.Name} was super tasty, but had no effect. You are already as fit as can be. So scrumptious though... Your fairy friends urge you to drink another. Yum!");
                                }
                                else if (boost < 27)
                                {
                                    Console.WriteLine($"You feel the {item1.Name} awakening some dormant Fey magic! The world seems to whirl dizzyingly around you as you follow the fairies' dance. Your footwork and fighting stance become a bewilderingly erratic and unpredictable shuffle, scrape and stomp of feverish steps as you're swept up in the danse macabre with your pixie friends...");
                                    foreach (Weapon w in player.WeaponInventory)
                                    {


                                        w.Boon += D4.Roll(D4) - 1;


                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"Urgh! That {item1.Name} didn't taste like the Fey 'magic' you've grown accustomed to... \nYou lose {boost/5} stamina points!");
                                    player.Stamina -= boost/5;
                                }
                            }
                            else if (player.Stamina + boost > player.InitialStamina)
                            {
                                player.Stamina = player.InitialStamina;
                                Console.WriteLine("\nYou've fully healed! \nAnd your chakras feel all sparkly too...");
                            }
                            else
                            {
                                player.Stamina += boost;
                                Console.WriteLine($"\nYou've healed by {boost} stamina points!");
                            }
                        }
                        else
                        {
                            int boost = D6.Roll(D6) + D6.Roll(D6) + D6.Roll(D6) + D6.Roll(D6);
                            if (player.Stamina == player.InitialStamina)
                            {
                                Console.WriteLine("You're already at full health! But at least the potion tastes good...");
                            }
                            else if (player.Stamina + boost > player.InitialStamina)
                            {
                                player.Stamina = player.InitialStamina;
                                Console.WriteLine("\nYou've fully healed!");
                            }
                            else
                            {
                                player.Stamina += boost;
                                Console.WriteLine($"\nYou've healed by {boost} stamina points!");
                            }
                        }
                        player.Inventory.Remove(item1);
                        return true;
                    }
                    else if (propString == "Skill")
                    {
                        int boost = item1.SpecialEffect;
                        if (player.Skill + boost > 10)
                        {
                            Console.WriteLine($"{item1.Name} has no effect. You couldn't be more skilled if you tried.");
                        }
                        else
                        {
                            player.Skill += boost;
                            Console.WriteLine(player.describeSkill() + "Your skill has increased!");
                        }
                        player.Inventory.Remove(item1);
                        return true;
                    }
                    else if (propString == "Luck")
                    {
                        
                        

                        
                        
                        
                        foreach (Weapon w in player.WeaponInventory)
                        {


                            w.Boon += item1.SpecialEffect;


                        }
                        player.Inventory.Remove(item1); 
                        
                        return true;
                    }
                    else { Console.WriteLine($"~~{item1.Name} is an unknown quantity~~"); return false; }

                    }
                else
                {
                    Console.WriteLine("You can't use that item on yourself or anything to hand!");
                    return false;
                }
            }
            catch
            {
                Console.WriteLine("Not possible to use that item on yourself!"); return false;
            }
            }
    }
    // weapon child of item includes different types and number of dice to roll
    public class Weapon : Item
    {
        private List<Dice> Damage { get; set; }
        private List<string> CritAttack { get; }
        private List<string> GoodAttack { get; }
        public int Boon { get; set; }
        public bool Equipped { get; set; }
        public Weapon(string name, string description, List<Dice> damage, List<string> critAttack, List<string> goodAttack, int boon = 0, bool equipped = false) : base(name, description)
        {
            Name = name;
            Description = description;
            Damage = damage;
            CritAttack = critAttack;
            GoodAttack = goodAttack;
            Boon = boon;
            Equipped = equipped;

        }
        /// <summary>
        /// the following calculates the damagedealt and any other special comments to be 
        /// posted to console during one turn of combat. both monsters and players use
        /// this function.
        /// </summary>
        /// <param name="skill"></param>
        /// <param name="opponentSkill"></param>
        /// <param name="enemyStamina"></param>
        /// <param name="commentary"></param>
        /// <param name="monsterName"></param>
        /// <param name="player"></param>
        /// <param name="another"></param>
        /// <param name="room"></param>
        /// <param name="holeInCeiling"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public int Attack(int skill, int opponentSkill, int enemyStamina, bool commentary, Monster monsterName, Player player, string another, Room room, Feature holeInCeiling, bool start = false)
        {
            Dice D18 = new Dice(18);
            Dice D3 = new Dice(3);
            Dice D4 = new Dice(4);
            System.Diagnostics.Debug.Assert(room.ItemList.Count > 2, "Items in the room must number at least three if there is any chance of combat occuring else an ArgumentNullException will occur for the 6th element of jinxedMisses.");
            List<string> jinxedMisses = new List<string>
            {
                $"The {monsterName.Name} has you now! Finally, relishing it's soon-to-be freedom from your cursed, jinxy hide, it raises its {monsterName.Items[0].Name} to strike... and gets it stuck in the {room.FeatureList[D4.Roll(D4) - 1].Name}. You scurry away as the {monsterName.Name} curses, trying to free it. \nThe {monsterName.Name} loses 1 stamina.",
                $"The ever-increasingly vexed {monsterName.Name} attacks, misses, and gets really bad tennis-elbow. Ooh! that's gotta hurt... \nThe {monsterName.Name} loses 2 stamina.",
                $"The {monsterName.Name} lunges at you! As you trip over yourself, clumsily scrambling for cover, you hear a tremendous crash. \nThe {monsterName.Name} ran into the {room.FeatureList[D4.Roll(D4) - 1].Name}. Ow! It loses 5 Stamina.",
                $"The {monsterName.Name} at last has you pinned. It looms over you with a leer, ready to deliver the killing blow, when part of the {room.Name}'s ceiling caves in upon its head. \nThe {monsterName.Name} loses 7 stamina!",
                $"The {monsterName.Name} bellows a string of foul curses as each frenzied attack miraculously leaves you unscathed. It bites its own tongue in the process. Youch! \nAs you slip away, the {monsterName.Name} loses 1 stamina...",
                $"The {monsterName.Name} bounds after you in circles, flailing wildly. It careers into a {room.ItemList[D3.Roll(D3) - 1].Name}, grazing its knee. Oof! That's a nasty splinter! \nThe {monsterName.Name} loses 3 stamina.",
                $"You stammer as you try reasoning with the {monsterName.Name}. Surely you can just talk things out over a lovely cup of mead... The {monsterName.Name} doesn't listen. It lunges at you, only to crash into the {room.FeatureList[D4.Roll(D4) - 1].Name}. Yikes! \nThe {monsterName.Name} loses 11 stamina.",
                $"In frustration the {monsterName.Name} hurls its {monsterName.Items[0].Name} at you! It bounces off your armour back at the {monsterName.Name}. \n The {monsterName.Name} loses 6 stamina.",
                $"The {monsterName.Name} attacks wildly, wanting nothing more than to end the whirlwind of chaos your ill-fortune brings. It trips. Ouch! That's going to need a bandage... \nThe {monsterName.Name} loses 7 stamina.",
                $"The {monsterName.Name} at last has you cornered. It looms over you with a leer, ready to at last deliver the killing blow. Then the {room.Name}'s ceiling caves in.\n The {monsterName.Name}'s engulfed by an avalanche of cascading debris. A trickle of dust takes a moment to stop. Then finally, one loose floorboard topples from the floor above and crowns the heap.",
                $"The {monsterName.Name} gets hit by a random meteorite - or was it a shooting star? Either way, what are the chances? \n The {monsterName.Name}'s head falls off as you make a wish... ",
                $"The {monsterName.Name} stubs its toe on the {room.ItemList[D3.Roll(D3) - 1].Name}...\nShortly afterwards it is crushed by the full force of the extreme probability wave generated by the Felix Felicis you drank, blasting the creature apart like an abstract nuclear device of pure mathematics. Paradoxes open and close in the underlying fabric of reality, swallowing the {monsterName.Name} whole before burping out the toe.\nHuh, you say as you take a second glance at the potion's ingredients list...",
                $"The {monsterName.Name}'s armour chafes, building up a freakish amount of static charge. A bolt of lightning strikes the {monsterName.Name} from, uh, somewhere(?)... \nThat was sure unlucky. You ponder the odds as more lightning bolts repeatedly fry the {monsterName.Name} to a crisp."
                
                
            };
            ///The above is special comments for jinxed characters, characters
            ///who drink felix felicis, or for the last three characters who
            ///have the trait 'friends with fairies' and drink felix felicis.
            int goodHit;
            bool crit = false;
            bool good = false;
            int hitThreshold = 0;// hit threshold is the number under which you need to roll on a D20 to hit an enemy
            // commentary is only true if the player is attacking
            if (commentary && player.Traits.ContainsKey("opportunist"))
            {
                hitThreshold = 18 + skill / 2 - opponentSkill / 2;
            }
            //if monster is attacking and human armadillo.
            else if (!commentary && player.Traits.ContainsKey("human armadillo"))
            {
                hitThreshold = 13 + skill / 3 - opponentSkill / 2;
            }
            else
            {
                hitThreshold = 15 + skill / 2 - opponentSkill / 2;
            }
            Dice D20 = new Dice(20);
            int hitRoll = D20.Roll(D20);

            hitRoll -= Boon;
            int damageDealt = 0;
            ///if the player/monster scores a hit...
            if (hitRoll < hitThreshold)
            {
                if (commentary) //if the player is attacking...
                {
                    Console.WriteLine($"Roll for your {Name}...");
                    foreach (Dice d in Damage)
                    {
                        Console.ReadKey(true);
                        int roll = d.Roll(d);
                        damageDealt += roll;
                        Console.WriteLine($"You rolled a {roll}");

                    }
                }
                else
                {
                    if (!start)
                    {
                        List<string> enemyCounters = new List<string>
                            {
                            $"The {monsterName.Name} recovers and launches its attack!",
                            $"The {monsterName.Name} swipes your next attack away and braces to counter!",
                            $"The {monsterName.Name} just manages to fend you off and lunges at you!",
                            $"The {monsterName.Name} reels from your attack! It attempts a counter."
                            };
                        if (hitThreshold - hitRoll > 3 * hitThreshold / 4)
                        {
                            Console.WriteLine(enemyCounters[3]);
                        }
                        else if (hitThreshold - hitRoll > hitThreshold / 2)
                        {
                            Console.WriteLine(enemyCounters[2]);
                        }
                        else if (hitThreshold - hitRoll > hitThreshold / 4)
                        {
                            Console.WriteLine(enemyCounters[0]);
                        }
                        else
                        {
                            Console.WriteLine(enemyCounters[1]);
                        }
                    }

                    foreach (Dice d in Damage)
                    {

                        int roll = d.Roll(d);
                        damageDealt += roll;


                    }

                }
                int baseDamage = damageDealt;
                string damageFlag = $"You've dealt {damageDealt} damage ";







                if ((hitThreshold - hitRoll) - 3 > opponentSkill)
                {
                    goodHit = (hitThreshold - opponentSkill);
                    good = true;
                    damageFlag += "plus a good hit bonus!";
                }
                else
                {
                    goodHit = 0;

                }
                if (hitRoll <= skill / 3 && (hitThreshold - hitRoll - 3) > opponentSkill)
                {
                    if (player.Traits.ContainsKey("sadist"))
                    {
                        damageDealt += (skill / 2) * damageDealt * 5 / 4;
                    }
                    else if (skill == 1)
                    {
                        damageDealt += damageDealt;
                    }
                    else
                    {
                        damageDealt += (skill / 2) * damageDealt;
                    }
                    crit = true;
                    damageFlag = $"Critical Hit! You've dealt {baseDamage} x (skill score)/2 + {goodHit / 2} damage!";
                }
                if (commentary)
                {
                    //Console.WriteLine($"\n {damageFlag}\n");
                    ///there are specific comments for whether a good attack or a crit attack
                    ///lands and determined by both player skill and how much relative damage they do as a proportion 
                    ///to the enemy's remaining stamina.
                    if (crit)
                    {

                        if (skill > 8)
                        {
                            if (enemyStamina - (damageDealt + goodHit / 2) < 1)
                            {
                                Console.WriteLine(CritAttack[0]);
                            }
                            else if (enemyStamina - (damageDealt + goodHit / 2) < enemyStamina / 3)
                            {
                                Console.WriteLine(CritAttack[1]);
                            }
                            else if (enemyStamina - (damageDealt + goodHit / 2) < 2 * enemyStamina / 3)
                            {
                                Console.WriteLine(CritAttack[2]);
                            }
                            else
                            {
                                Console.WriteLine(CritAttack[3]);
                            }

                        }
                        else if (skill > 5)
                        {
                            if (enemyStamina - (damageDealt + goodHit / 2) < 1)
                            {
                                Console.WriteLine(CritAttack[4]);
                            }
                            else if (enemyStamina - (damageDealt + goodHit / 2) < enemyStamina / 3)
                            {
                                Console.WriteLine(CritAttack[5]);
                            }
                            else if (enemyStamina - (damageDealt + goodHit / 2) < 2 * enemyStamina / 3)
                            {
                                Console.WriteLine(CritAttack[6]);
                            }
                            else
                            {
                                Console.WriteLine(CritAttack[7]);
                            }
                        }
                        else if (skill > 2)
                        {
                            if (enemyStamina - (damageDealt + goodHit / 2) < 1)
                            {
                                Console.WriteLine(CritAttack[8]);
                            }
                            else if (enemyStamina - (damageDealt + goodHit / 2) < enemyStamina / 3)
                            {
                                Console.WriteLine(CritAttack[9]);
                            }
                            else if (enemyStamina - (damageDealt + goodHit / 2) < 2 * enemyStamina / 3)
                            {
                                Console.WriteLine(CritAttack[10]);
                            }
                            else
                            {
                                Console.WriteLine(CritAttack[11]);
                            }
                        }
                        else
                        {
                            if (enemyStamina - (damageDealt + goodHit / 2) < 1)
                            {
                                Console.WriteLine(CritAttack[12]);
                            }
                            else if (enemyStamina - (damageDealt + goodHit / 2) < enemyStamina / 3)
                            {
                                Console.WriteLine(CritAttack[13]);
                            }
                            else if (enemyStamina - (damageDealt + goodHit / 2) < 2 * enemyStamina / 3)
                            {
                                Console.WriteLine(CritAttack[14]);
                            }
                            else
                            {
                                Console.WriteLine(CritAttack[15]);
                            }
                        }
                        Console.WriteLine("\n");
                    }
                    else if (good)
                    {
                        Console.WriteLine("\n");
                        if (skill > 8)
                        {
                            if (enemyStamina - (damageDealt + goodHit / 2) < 1)
                            {
                                Console.WriteLine(GoodAttack[0]);
                            }
                            else if (enemyStamina - (damageDealt + goodHit / 2) < enemyStamina / 3)
                            {
                                Console.WriteLine(GoodAttack[1]);
                            }
                            else if (enemyStamina - (damageDealt + goodHit / 2) < 2 * enemyStamina / 3)
                            {
                                Console.WriteLine(GoodAttack[2]);
                            }
                            else
                            {
                                Console.WriteLine(GoodAttack[3]);
                            }

                        }
                        else if (skill > 5)
                        {
                            if (enemyStamina - (damageDealt + goodHit / 2) < 1)
                            {
                                Console.WriteLine(GoodAttack[4]);
                            }
                            else if (enemyStamina - (damageDealt + goodHit / 2) < enemyStamina / 3)
                            {
                                Console.WriteLine(GoodAttack[5]);
                            }
                            else if (enemyStamina - (damageDealt + goodHit / 2) < 2 * enemyStamina / 3)
                            {
                                Console.WriteLine(GoodAttack[6]);
                            }
                            else
                            {
                                Console.WriteLine(GoodAttack[7]);
                            }
                        }
                        else if (skill > 2)
                        {
                            if (enemyStamina - (damageDealt + goodHit / 2) < 1)
                            {
                                Console.WriteLine(GoodAttack[8]);
                            }
                            else if (enemyStamina - (damageDealt + goodHit / 2) < enemyStamina / 3)
                            {
                                Console.WriteLine(GoodAttack[9]);
                            }
                            else if (enemyStamina - (damageDealt + goodHit / 2) < 2 * enemyStamina / 3)
                            {
                                Console.WriteLine(GoodAttack[10]);
                            }
                            else
                            {
                                Console.WriteLine(GoodAttack[11]);
                            }
                        }
                        else
                        {
                            if (enemyStamina - (damageDealt + goodHit / 2) < 1)
                            {
                                Console.WriteLine(GoodAttack[12]);
                            }
                            else if (enemyStamina - (damageDealt + goodHit / 2) < enemyStamina / 3)
                            {
                                Console.WriteLine(GoodAttack[13]);
                            }
                            else if (enemyStamina - (damageDealt + goodHit / 2) < 2 * enemyStamina / 3)
                            {
                                Console.WriteLine(GoodAttack[14]);
                                another = "another";
                            }
                            else
                            {
                                Console.WriteLine(GoodAttack[15]);
                                another = "another";
                            }
                        }
                        Console.WriteLine("\n");
                    }
                }


                if (!commentary && player.Traits.ContainsKey("thick-skinned")) { return (4 * (damageDealt + goodHit / 2) / 5); }
                else
                {
                    return (damageDealt + (goodHit / 2));
                }
            }
            else // you or the monster misses!
            {
                if (commentary)
                {
                    Console.WriteLine("Your attack misses!");
                }
                else
                {
                    int playerBoon = 0;
                    
                    if (player.Traits.ContainsKey("jinxed")) { playerBoon = 6; }
                    int o = 0;
                    foreach (Weapon w in player.WeaponInventory)
                    {
                        
                        
                        if (w.Boon > 9)
                        {
                            o++;
                        }
                        
                    }
                    if (o == player.WeaponInventory.Count && player.WeaponInventory.Count!=0)
                    {
                        playerBoon += 10; // Felix Felicis effect
                    }
                    if (20 - (10 - skill) / 3 < hitRoll + playerBoon)// ensures only boon of 5 or more (i.e. jinxed or flix drinkers) receive these events.
                    {
                        ///Jinxed critmisses for the monster, including possible instant death
                        if (player.Traits.ContainsKey("friends with fairies") && playerBoon > 9)
                        {
                            Dice D26 = new Dice(26);
                            int rollmiss = D26.Roll(D26);
                            if (rollmiss > 20) 
                            {
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);
                                damageDealt = -9999;
                            }

                            else if (rollmiss > 18 && enemyStamina < 2 * enemyStamina / 3)
                            {
                                damageDealt = -9999;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);
                                room.FeatureList.Add(holeInCeiling);
                            }
                            else if (rollmiss > 18)
                            {
                                Console.WriteLine(jinxedMisses[(rollmiss - D18.Roll(D18) - 1) / 2]);
                            }
                            else if (rollmiss > 16)
                            {
                                damageDealt = -7;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            else if (rollmiss > 14)
                            {
                                damageDealt = -6;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            else if (rollmiss > 12)
                            {
                                damageDealt = -11;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            else if (rollmiss > 10)
                            {
                                damageDealt = -3;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            else if (rollmiss > 8)
                            {
                                damageDealt = -1;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            else if (rollmiss > 6)
                            {
                                damageDealt = -7;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            else if (rollmiss > 4)
                            {
                                damageDealt = -5;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            else if (rollmiss > 2)
                            {
                                damageDealt = -2;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            else
                            {
                                damageDealt = -1;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                        }
                        else if (player.Traits.ContainsKey("jinxed") || playerBoon>9)
                        { 
                            int rollmiss = D20.Roll(D20);
                            
                            if(rollmiss > 18 && enemyStamina < 2*enemyStamina/3)
                            {
                                damageDealt = -9999;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);
                                room.FeatureList.Add(holeInCeiling);
                            }
                            else if (rollmiss > 18)
                            {
                                Console.WriteLine(jinxedMisses[(rollmiss - D18.Roll(D18) - 1) / 2]);
                            }
                            else if (rollmiss > 16)
                            {
                                damageDealt = -7;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            else if (rollmiss > 14)
                            {
                                damageDealt = -6;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            else if (rollmiss > 12)
                            {
                                damageDealt = -11;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            else if (rollmiss > 10)
                            {
                                damageDealt = -3;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            else if(rollmiss > 8)
                            {
                                damageDealt = -1;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            else if(rollmiss > 6)
                            {
                                damageDealt = -7;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            else if(rollmiss > 4)
                            {
                                damageDealt = -5;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            else if(rollmiss > 2)
                            {
                                damageDealt = -2;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            else
                            {
                                damageDealt = -1;
                                Console.WriteLine(jinxedMisses[(rollmiss - 1) / 2]);

                            }
                            // ~~~ code that selects effect / drop weapon, room feature falls on head, breaks item in room, crashes through door, etc. ~~~
                        }
                        else { Console.WriteLine($"The {monsterName.Name}'s attack misses!"); }
                    }
                    else { Console.WriteLine($"The {monsterName.Name}'s attack misses!"); }
                }
                return damageDealt;
            }
        }


    }
}

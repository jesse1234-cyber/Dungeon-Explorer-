using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class Character
    {
        public string Name { get; set; }
        public int Skill { get; set; }
        public int Stamina { get; set; }
        public List<Item> Inventory { get; set; }

        public Character(string name = "Someone", int skill = 0, int stamina = 0, List<Item> inventory = null)
        {
            Name = name;
            Skill = skill;
            Stamina = stamina;
            Inventory = inventory;

        }
        public void equip(Weapon weapon, List<Weapon> inventory, Player player)
        {
            foreach (Weapon x in inventory)
            {
                x.Equipped = false;
            }
            if (player.Traits.ContainsKey("jinxed")) { weapon.Boon = 6; }
            weapon.Equipped = true;
        }
        public void unequip(List<Weapon> inventory)
        {
            foreach (Weapon x in inventory)
            {
                x.Equipped = false;
            }
        }
    }
    public class Player : Character
    {
        public int InitialStamina { get; set; }
        public List<Weapon> WeaponInventory { get; set; }
        public Dictionary<string, string> Traits { get; set; }

        public Player(string name, int skill, int stamina, List<Weapon> weaponInventory, List<Item> inventory, Dictionary<string, string> traits)
        {
            Name = name;
            Skill = skill;
            Stamina = stamina;
            InitialStamina = stamina;
            WeaponInventory = weaponInventory;
            Inventory = inventory;
            Traits = traits;

        }
        public string displayName() { return Name; }
        public int displaySkill() { return Skill; }
        public int displayStamina() { return Stamina; }
        public string describeSkill()
        {
            if (Skill > 9)
            {
                return "Lithe as a panther, you don't walk but slink with the undulating grace and poise of a feline predator. Your reactions, like your wits, are sharper than even the keenest blade and you can move with a speed that is at once frightening and uncanny. Were there such a thing as a weapon you're not yet proficient with, your instincts and dextrous hands would achieve its mastery in mere seconds.";
            }
            else if (Skill > 7)
            {
                return "You're fast, you're skilled and you're deadly. You've an assassin's flair for marking your target and striking with such cool precision and alacrity that they've scarcely a hope of retaliating. Few can stand against you and the right blade.";
            }
            else if (Skill > 6)
            {
                return "You have admirable proficiency with more than a few basic weapons. You can feint, dodge and parry, if not elegantly, then at least with some confidence. With the right weapon in hand, you might just make it through this quest.";
            }
            else if (Skill > 5)
            {
                return "Your skills are nothing spectacular. With enough training you could accomplish a competent proficiency with any weapon, but you haven't exactly been training too hard.";
            }
            else if (Skill > 4)
            {
                return "You weren't paying attention to sparring matches or fights or even light-hearted kafuffles when you had the chance. Now you may come to regret it...";
            }
            else if (Skill > 3)
            {
                return "When you were growing up, it wasn't often you were ever entrusted with anything too sharp. In your hands, a weapon can be a lethal thing, but rarely to anyone else.";
            }
            else if (Skill > 1)
            {
                return "It is told that there exists an ancient hex in some arcane tome that when cast upon people, removes their opposable thumbs, fingers and sometimes their head... They swing a sword better than you.";
            }
            else
            {
                return "One-legged elephants can tip-toe quieter than you can. \nThey're more likely to do it without toppling over too...";
            }
        }
        public string describeStamina()
        {
            if (Stamina < InitialStamina / 8)
            {
                return "You've blood gushing from somewhere, your vision blurs and sharpens sporadically, and you have to drag your foot behind you in a severe limp. You're almost keeling over, your heart thumping weaker and weaker. You can feel your life hanging by a thread.";
            }
            else if (Stamina < 2 * InitialStamina / 8)
            {
                return "You might be able to muster enough strength and courage to make a gallant last stand, but it'd be a feat of exceptional luck or divine providence to come out of it alive.";
            }
            else if (Stamina < 3 * InitialStamina / 8)
            {
                return "Things are beginning to look bleak. If you don't find a way to heal yourself now you might not last.";
            }
            else if (Stamina < InitialStamina / 2)
            {
                return "Your wounds are serious. Your physical condition does not bear grave news yet, but something must be done to remedy this sooner rather than later.";
            }
            else if (Stamina < 5 * InitialStamina / 8)
            {
                return "You're struggling with the pain. It's not an exaggeration to say that you're in need of healing, but if push comes to shove, you can keep going for a while longer.";
            }
            else if (Stamina < 3 * InitialStamina / 4)
            {
                return "In addition to more than a few brazes, you've also received one or two open wounds that need tending too, but thankfully not with any urgency";
            }
            else if (Stamina < 7 * InitialStamina / 8)
            {
                return "You can spot a few cuts and brazes on your body, but hardly anything to be concerned about. You can press on without too much anxiety.";
            }
            else
            {
                return "You're as fit and lively as you've ever been. You've a spring in your step as you bound ever forward in your quest.";
            }
        }
        public string describeInitialStamina()
        {
            if (InitialStamina < 70)
            {
                return "It's called exercise, yeah? You should try it... Yesterday.";
            }
            else if (InitialStamina < 80)
            {
                return "You learned quickly that telling people you're an adventurer isn't the way to go. Their snorts of laughter tend to draw unwanted attention to your mission. Better to keep quiet and pass unnoticed. Stealth and quick wits aren't just a precaution for you, but a necessity.";
            }
            else if (InitialStamina < 90)
            {
                return "When you tell the gentle folk of many fantastical villages that you're an intrepid adventurer, most raise a quizzical (if not sceptical) eyebrow in response. Though they're too polite to say it, most likely mistook you for a bookish chronicler, or perhaps an underfed squire to the much burlier knight they'd been expecting.";
            }
            else if (InitialStamina < 100)
            {
                return "You may once have been lithe and well-built, but if so, you aren't now. You're far from the strongest person to champion such a cause, but you're also far from the weakest too. You may yet live to see another dawn, if you're lucky...";
            }
            else if (InitialStamina < 110)
            {
                return "You've kept active, honing your muscles from time to time. You may not be a natural athlete, but your confidence in your own endurance seems well-placed - Just so long as you're not overly confident.";
            }
            else if (InitialStamina < 120)
            {
                return "You're as strong as an ox and physically capable of most challenges thrown your way. When you're not passing the time bending horseshoes single-handed, you're scouting for beasts to fell with your mighty weapon and otherwise being a nuisance to sorcerous demagogues and warlock tyrants.";
            }
            else
            {
                return "To describe you as one of the seven wonders of the world would frankly be an understatement. Your raw, physical prowess leaves those lucky enough to clap eyes on you trembling in your wake. Your 'sweet bod' is the sort of exemplary specimen even Conan the Barbarian would grudgingly admire.";
            }
        }
        public void searchPack(List<Item> roomItems)
        {
            Console.WriteLine("Rummaging through your effects you find the following;");
            int r = 1;
            string message = "";
            foreach(Weapon w in WeaponInventory)
            {
                message += $"[{r}] {w.Name}\n";
                r++;
            }
            foreach(Item item in Inventory)
            {
                message += $"[{r}] {item.Name}\n";
                r++;
            }
            Console.WriteLine(message);
            

            bool continueLoop = true;
            int a = 0;
            Console.WriteLine("\nWhich of these items will you take a closer look at?");
            while (continueLoop)
            {
                if (a > 0) { Console.WriteLine(message); Console.WriteLine("Select another item from the list above."); }
                string reply = Console.ReadLine().Trim().ToLower();

                try
                {
                    int reply1 = int.Parse(reply);
                    if (reply1 < 1 || reply1 > r-1)
                    {
                        Console.WriteLine($"Please enter a number between 1 and {r-1}.");
                        continue;
                    }
                    else 
                    {
                        try
                        {
                            bool success = false;
                            string objName = message.Substring(message.IndexOf(reply1.ToString()) + 3, message.IndexOf((reply1 + 1).ToString()) - 2 - (message.IndexOf(reply1.ToString()) + 3)).Trim();
                            Console.WriteLine(objName);
                            foreach (Item i in Inventory) { if (i.Name == objName) { i.pickUpItem(Inventory, WeaponInventory, 5, 0, i, null,null, roomItems); success = true; break; } }
                            foreach (Weapon w in WeaponInventory) { if (w.Name == objName) { w.pickUpItem(Inventory, WeaponInventory, 5, 0, null, w,null, roomItems); success = true; break; } }
                            if (!success) { Console.WriteLine($"You threw your {objName} away!"); }

                        }
                        catch 
                        {
                            bool success = false;
                            string objName = message.Substring(message.IndexOf((r-1).ToString()) + 3, message.Length - 1 - (message.IndexOf((r-1).ToString()) + 3)).Trim();
                            Console.WriteLine(objName);
                            foreach (Item i in Inventory) { if (i.Name == objName) { i.pickUpItem(Inventory, WeaponInventory, 5, 0, i, null, null, roomItems); success = true; break; } }
                            foreach (Weapon w in WeaponInventory) { if (w.Name == objName) { w.pickUpItem(Inventory, WeaponInventory, 5, 0, null, w, null, roomItems); success = true; break; } }
                            if (!success) { Console.WriteLine($"You threw your {objName} away!"); }
                        }
                    }
                    Console.WriteLine("Would you like to peruse another item from your pack?");
                    
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
    }
    public class Monster : Character
    {
        public string Description { get; set; }
        public List<Item> Items { get; set; }
        public Weapon Veapon { get; set; }
        public Monster(string name, string description, List<Item> items, int stamina, int skill, Weapon weapon)
        {
            Name = name;
            Description = description;
            Items = items;
            Stamina = stamina;
            Skill = skill;
            Veapon = weapon;
        }
        public string getDescription() { return Description; }
        public string getName() { return Name; }
        public void search(List<Item> inventory, List<Weapon> weaponInventory)
        {
            bool continueSearch = true;
            string message = "You find";
            foreach (Item x in Items)
            {
                message += " " + x.Name + ",";

            }

            message = message.Substring(0, message.Length - 1);
            message += $" upon the {Name}.";
            if (Items.Count() == 0)
            {
                message = "You find nothing of note";
                continueSearch = false;
            }
            Console.WriteLine(message);
            int i = 0;
            if (continueSearch && Items.Count() > 1)
            {
                Console.WriteLine("Would you like to pick up one of these artefacts?");
            }
            else if (continueSearch)
            {
                Console.WriteLine("Would you like to pick up this item?");
            }
            bool alreadyStashed = false;
            bool skip = false;
            while (continueSearch)
            {
                if (i > 0)
                {
                    Console.WriteLine(message, "\nWould you like to pick up another one of the above items?");
                }
                string answer = Console.ReadLine().Trim().ToLower();
                while (answer.ToLower() == "yes" || answer.ToLower() == "y" || answer.ToLower() == "n" || answer.ToLower() == "no")
                {
                    if (answer.ToLower() == "yes" || answer.ToLower() == "y")
                    {
                        Console.WriteLine("Please type the name of the item you wish to pick up.");
                        answer = Console.ReadLine().Trim().ToLower();
                        break;
                    }
                    else
                    {
                        continueSearch = false;
                        break;
                    }
                }
                alreadyStashed = false;
                foreach (Item z in inventory)
                {
                    if (z.Name.ToLower() == answer)
                    {
                        alreadyStashed = true;
                    }
                }
                foreach (Weapon z in weaponInventory)
                {
                    if (z.Name.ToLower() == answer)
                    {
                        alreadyStashed = true;
                    }
                }
                if (Items.Count == 0)
                {
                    message = "You find nothing more of note";
                    continueSearch = false;
                }
                skip = false;
                List<Item> weaponSplice = new List<Item>();
                for (i = Items.Count - 1; i >= 0; i--)
                {
                    if (Items[i] is Weapon)
                    { weaponSplice.Add(Items[i]); }
                }
                List<Weapon> weapon1 = weaponSplice.Cast<Weapon>().ToList();
                List<string> checkWeapon = new List<string>();
                foreach (Item weapon in Items) { checkWeapon.Add(weapon.Name.Trim().ToLower()); }
                for (i = weapon1.Count - 1; i >= 0; i--)
                {
                    Weapon x = weapon1[i]; // change monster class to having two lists, or start with reviewing all weapons throughout and construct new item from weapon details
                    if (alreadyStashed)
                    {
                        Console.WriteLine("You've already taken that item!");
                        break;
                    }
                    else if (x.Name.Trim().ToLower() == answer)
                    {

                        x.pickUpItem(inventory, weaponInventory, 3, 0, null, x);
                        answer = "";
                        skip = true;

                        try
                        {
                            if (weaponInventory.Contains(x))
                            {
                                Items.Remove(x);
                            }


                            else if (inventory.Contains(x))
                            {
                                Items.Remove(x);
                            }
                        }
                        catch { }

                        break;
                    }



                }
                for (i = Items.Count - 1; i >= 0; i--)
                {
                    if (skip) { break; }
                    Item x = Items[i];
                    if (alreadyStashed)
                    {
                        Console.WriteLine("You've already taken that item!");
                        break;
                    }

                    else if (x.Name.Trim().ToLower() == answer)
                    {
                        x.pickUpItem(inventory, weaponInventory, 3, 0, x);
                        try
                        {
                            if (weaponInventory.Contains(x))
                            {
                                Items.Remove(x);
                            }


                            else if (inventory.Contains(x))
                            {
                                Items.Remove(x);
                            }
                        }
                        catch { }
                        break;
                    }


                }
                if (Items.Count == 0)
                {
                    Console.WriteLine($"You finish searching the {Name} for items.");
                    break;
                }
                else if (!checkWeapon.Contains(answer))
                {
                    Console.WriteLine($"Please type in an item or weapon name listed above or else answer 'no' to finish your search of the {Name}.");

                }
            }
        }
    }


}

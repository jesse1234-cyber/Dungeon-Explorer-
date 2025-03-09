using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DungeonCrawler
{
    class Program
    {

        
        static void Main(string[] args)
        {
            //Instantiating a six sided dice to be used for dealing damage with a particular weapon. 
            // Damage works in combat by rolling dice. Each weapon has a different set of dice. Hence,
            // one might deal a different range, with different prob distribution, of damage amounts
            // depending on choice of weapon. This has been inspired by D&D and also more directly BG3.
            Dice D6 = new Dice(6);
            List<Dice> chainDamage = new List<Dice> { D6};
            //The following are lists of messages that might chance to appear in combat if certain, 
            //requirements are met, such as critical or good hits.
            List<String> defaultCritHits = new List<String>
                {
                "One instant your weapon is by your side, the next it hovers in the air, held in one still hand as blood spatters the ground beneath it. Behind you the foul enemy totters for but a moment before slumping to the ground in a cascade of guts. The only sound that fills the crackling silence is the ringing of your blade as you once again sheathe it. Your enemy was no match for your lightning reflexes, it seems. A smug smile slips upon your lips.",
                "You unleash a flurry of blows against the creature in a well-practiced staccato, so fluid as to almost be like a dance. Your enemy howls as it reels away from you, barely able to fend you off before regrouping for one final, desperate last stand...",
                "Your acrobatic prowess pays off as you weave your lithe body effortlessly past the enemy's defences in a series of spinning leaps and dives, like a leaf floating gracefully upon the wind. You pick your moment with well-timed precision. Your strike lands true and cripples your enemy.",
                "Despite your unmatched skill your enemy proves to be tough. A cold bead of sweat trickles down your brow as even your best strike has yet to slow them down. If anything, your powerful attack has only incensed them further, as they flail wildly to desperately keep you at bay.",
                "Sweat shimmers your brow as you ruggedly persevere through your opponent's defences with steely grit. Finally, they fall and you take your chance. It's not long before all that lays before you is a bloodied tangle of intestines and gore. Breathing a heavy sigh of relief, you thank your stars that it's over.",
                "You swing your weapon and manage to finally knock your opponent off balance. Before you land the killing blow, however, they roll back to their feet, cursing you as they clutch a bloody gash in their side. Time is running out for them, and they know it, but it only seems to strengthen their resolve.",
                "You parry your opponents strike and riposte. Your strike is received with a blood-curdling yowl of anguish as the enemy staggers backwards. They are momentarily fazed by your attack. But it's not long before they once again close in for the kill.",
                "It's hard to deny now that your fastidious training is falling short in this fight. The enemy is imposing, and your best strike, though damaging, hasn't stopped your adversary. They advance on you...",
                "The enemy leers ravenously as they lunge towards you. Screaming in fright, you flail wildly, your eyes shut because you can't bear to look. When you open them you find you're slashing at empty air and your enemy lies dead. \nWell, if skill won't see you through, I suppose sheer dumb luck just might...",
                "The enemy closes in but are almost as surprised as you are when you land a lucky blow. Their eyes bulge as blood gushes forth from the gaping wound delivered by your quivering hands. They glower your way. A lump catches in your throat as you realise that they're done toying with you...",
                "Your inexpert strikes and frenzied ripostes are just enough to chance a lucky hit. The enemy is caught off guard as they find themselves seriously wounded. Your hopes are buoyed as the fight continues.",
                "In a desperate bid to see another dawn you unleash a volley of desperate, febrile blows. They are mostly dodged with ease. Only one lands true, but severe as the blow is, your best effort isn't even close to bringing this beast down...",
                "Your knees knock, your heart thumps against your chest, and your hands shake so badly they're scarcely able to keep hold of the weapon in front of you. \nWho are you kidding? You're no fighter. Why didn't you just follow your heart and take up crochet? \nThe enemy bounds towards you ready to strike. You hurl away your weapon and dive for the corner, folding in on yourself and hoping the fierce enemy will just forget about you or something...\nWhen you finally chance a glance back, you find the enemy slowly rocking on their feet, an expression as if they were hang gliding over hell is etched on their face. Then you look down. \nYour weapon appears to have ricocheted to where the sun don't shine. \nThe enemy looks at you with pleading eyes, before those eyes cross, and the enemy flops backwards. \nHenceforth, word shall be told of this deed, and your enemies will shudder.",
                "In a flurry of instants so bizarre they belong in a circus, you flail your weapon losing your balance in the process and slamming into the enemy 'drunken-fist' style, before themselves tripping over you, and somehow skewering themselves on your weapon. You only just manage to retrieve it before the enemy, bleeding profusely, dizzily stumbles upright.",
                "The enemy get's over-confident. Relishing your knee-knocking terror, they attempt a display of might only to fall flat on their face.",
                "You hurl your diary at the creature. It gets a paper-cut. Critical hit."
                };
            List<String> defaultGoodHits = new List<String>
                {
                "With a mighty heave your weapon cleaves the creature in two.",
                "The enemy staggers back before your onslaught.",
                "Your expert strikes are rapidly bringing the enemy low",
                "The enemy may be tough, but you're tougher. They've been badly hurt.",
                "With a thunderous roar you finally overpower your enemy. Their head topples from their shoulders.",
                "The enemy is sent reeling from your powerful blows.",
                "The enemy is winded badly. You press the attack.",
                "The enemy is wounded but they're tougher than expected. You'll have to draw on some greater reserve of strength to best them yet.",
                "You finally land the killing blow. You're surprised you've survived this fight, but you steel yourself; there are more yet to come.",
                "Your inexpert strike somehow hits home. The enemy looks mortally wounded.",
                "You send the enemy reeling with a haymaker to the jaw. It might lack finesse, but its effective.",
                "You've hurt the enemy more than usual, but you know with some trepidation that it's no where near enough.",
                "The enemy snaps their own neck whilst fighting you. \nNo, we don't know how that happened either...",
                "The enemy somehow stabs themselves on your weapon. Then proceeds to do it nine times more...",
                "The enemy somehow stabs themselves on your weapon.",
                "The enemy gets a spontaneous nosebleed."
                };
            string newNote = "Someone has scrawled upon the note in hasty erratic cursive. It reads, 'I don't have long now. If you're reading this then you're likely another foolhardy adventurer like myself who got his'self kidnapped just as I woz. I don' have much space so mark my words. Whatever they tell you - its a lie. They're going to harm you. They're most likely going to kill you in one of their mad experiments. There's a music box. I kept it locked away and hidden from sight. It's in the chest. It may look empty but set in its bottom is a panel that can be removed. You'll find it there. If you play it the guard loses his marbles about it. Can't stand the tune, the little blighter! It's like nails on a chalkboard to 'em creatures. When it enters, subdue the loathsome thing. It's the only way out of 'ere. Hopefully, if I don't make it, at least someone else will...' The rest deteriorates into an illegible scribble at the bottom of the page.";
            //Items to be located somewhere in the room or upon the player character
            Item binkySkull = new Item("Binky", "~~ He's a bonafide friend in need, a bonny true soul indeed, he's brimming with revelry when you bring bonhomie, Hey! don't be a bonana, 'cause you've got a BONANZA, of a friend in me! ~~");
            Item steelKey = new Item("steel key", "You find it under the skeleton's bones. You guess whoever it was had swallowed it before death. The key itself is rather nondescript - just a humble key. You suppose it must unlock something...");
            Item healPotion = new Item("healing potion", "It has flecks of gold floating amidst a gel like suspension. The label reads; 'When you're feeling blue, down with the flu, and monsters are out to get you, taste this goo! Merigold's magical elixir will see you through!'", true, "used", 0, "Stamina: When you're blue, and monsters are out to get you, taste this goo! Merigold's magical elixir will see you through!");
            Item note = new Item("note", "The note is dogeared and yellowed with age.\nSomeone has scrawled upon it but the writing is too small to make out. Snatches of words, poorly spelt, unveil themselves to you when you strain your eyes. However, no coherent message can be deciphered. Something about a false bottom? If only there was some spell to enlarge letters, you muse... If only you knew any spells!", true, "unread");
            Item halfOfCrackedBowl = new Item("half a cracked bowl", "Its a cheap bowl made of clay - half of one anyway - chipped in places around the rim and bearing a hairline crack down its left side.");
            Item otherHalfOfCrackedBowl = new Item("other half of a cracked bowl", "It's not much less damaged than its counterpart");
            Item musicBox = new Item("music box", "A curious artefact with a hand-crafted ebony exterior, inlaid with gold. It has glass panels displaying well oiled brass cogs gently whirring inside.", true, "unopened", 1, "strange lullaby");
            Weapon rustyChains = new Weapon("rusty chains", "They're so caked with rust that they're links have stiffened with age. You doubt these could hold any prisoner. Perhaps that's why they weren't used on you. Handling one of them, you figure it'd make a halfway decent, impromptu weapon - if you've really no other choice.", chainDamage, defaultCritHits, defaultGoodHits);
            Item garment = new Item("garment", "Haphazardly strewn about the rickety floor of your cell, they're worn, faded and moth-eaten. Hardly a fashion accessory.", true, "unburned");
            Item elixirFeline = new Item("Elixir of Feline Guile", "It's pungent aroma makes you recoil. Upon the label it reads, 'Is 'butter-fingers' your middle name? Do you like jumping from great heights, but don't like the dying that usually follows? Merigold's Wondrous Elixir of Feline Guile is the thing for you! Please note Merigold is not responsible for fatal falls during or after this potion takes effect. Please use responsibly. Pleasant fragrance not included.'", true, "unshattered", 1, "Skill: Boosts your skill by 1 point. Caution: excessive use may cause an over-fondness for catnip.");
            Item FelixFelicis = new Item("Felix Felicis", "It bubbles, roils and froths within its bottle. You almost sense a quiver through the glass, like the crystalline liquid inside is trying to escape. The label on the side is illegible; someone has written over it with a shaky cursive, 'Don't drink it! Whatever you do, don't drink it! For the love of all that is holy, if you care for anyone around you keep the stopper on!!! ~ Yours sincerely, Merigold.'", true, "unshattered", 10, "Luck: Drink and accomplish your wildest dreams..."); // access to 'jinxed' critmisses for 1 battle only
            Item magnifyingGlass = new Item("magnifying glass", "Peering through its slightly misted lens objects appear at least three times their size. You wonder why the skeleton had hold of it...");
            Item bowlFragments = new Item("bowl fragments", "They're sharp. You best avoid stepping on them.", false, "shattered");
            List<Item> cellInventory = new List<Item> { rustyChains, halfOfCrackedBowl, otherHalfOfCrackedBowl, bowlFragments, garment };

            // Features of the room, some with items hidden upon or within them. Both
            // Items and features can be interacted with but only items can be picked up
            // and features remain in place unless shattered or unlocked or burned depending on
            // their special attribute.
            List<Item> inRosewoodChest = new List<Item> { };
            List<Item> onSkeleton = new List<Item> { healPotion, magnifyingGlass};
            Feature skeleton = new Feature("skeleton", "Its empty sockets fasten you with a stern gaze. It's been bound by chains to the wall, making it difficult to move. Something shiny is trapped out of reach behind it.", false, "unshattered", onSkeleton);
            Feature brazier = new Feature("brazier", "If these braziers do indeed burn it is not with any normal fire. Upon closer inspection, their dim flickering glow seemingly cannot be expunged. They barely keep the looming shadows at bay.", true, "lit", null);
            Feature rosewoodDoor = new Feature("rosewood door", "It's a curiously ornate door with smooth well-polished panels. The wood's warmth is somewhat diminished by the heavy iron hinges holding it in place.");
            Feature rosewoodChest = new Feature("rosewood chest", "Its smooth, burnished surface matches the grain and style of the door and like the door its elegance is jarred by the heavy steel lock sealing it. It makes you wonder if this room hadn't always been a dank cell.", true, "locked", inRosewoodChest);
            List<Item> inBookcase = new List<Item> { note };
            Feature bookCase = new Feature("bookcase", "The ostensibly empty bookcase is a little worse for wear. One of it's shelves is lopsided. Another at the bottom has collapsed. Cobwebs span its dusty corners.", true, "searched", inBookcase);
            Feature holeInCeiling = new Feature("hole in the ceiling", "You gaze from the heap of debris that has buried the creature alive to the hole through the ceiling above. You bet you could climb the heap and enter the room above yours.");
            
            // I instantiate a room with a list of items and features inside it and a description and room name
            List<Feature> cellfeatures = new List<Feature> {rosewoodDoor, rosewoodChest, bookCase, skeleton, brazier, brazier };
            Room room = new Room("dank cell", "The foreboding cell is bathed in the earthy glow of lit braziers, barely lighting cold stony walls, a heavy rosewood door studded with iron hinges, and only the sparsest of furnishings.\nThe door is set within the north wall, two flickering braziers casting orbs of low light either side of it so as to look like great fiery eyes watching you from the murk.\t\nTo the west wall there is a large chest, mingled with a cascade of rusted and disused iron shackles.\t\nTo the south wall is a small bookcase and some garments haphazardly strewn about you.\t\nTo the east wall is the last occupant; a skeleton with a permanent grin that  almost seems to watch you from dark wells where once there were its eyes. It holds something in its bony fist.\t\t", cellInventory, cellfeatures);
            
            ///
            /// This is where the game begins for now, until i make a game class.
            /// It begins with a prologue the player can choose to skip.
            /// As such player input is required and hence the while loop that ensures a
            /// correct response is given and catches any errors. We'll see this structure a lot throughout this 
            /// program. This one below is simpler than some of the others I deployed. But they
            /// are all of the same basic formula
            ///
            Console.Write("Would you like to skip the prologue? ");
            while (true)
            {
                string response1 = Console.ReadLine().Trim().ToLower();
                if (string.IsNullOrWhiteSpace(response1))
                {
                    Console.Write("\nWould you like to skip the prologue? ");
                    continue;
                }
                else if (response1 == "yes" || response1 == "y")
                {
                    break;
                }
                else if (response1 == "no" || response1 == "n")
                {





                    Console.ReadKey(true);
                    Console.WriteLine($"  You can't be certain what terrible events led you here" +
                        $". However as you look around the {room.Name.ToLower()} you can make a shrewd guess" +
                        $" as to why you've been held captive... and who's behind it. After all, you're not the first to be captured around these parts. \nYou're just the first to survive it.");
                    Console.ReadKey(true);
                    Console.WriteLine($"  {room.Description.Substring(0, room.Description.IndexOf("\n"))} It reminds you of no room you've seen before in your other, perhaps less-ambitious adventures." +
                        $"If you'd had a better grasp of the danger ahead of you, then perhaps that nebulous anxiety that'd conspired to turn your stomach into a roiling knot of snakes might've warded you away three nights ago. But you weren't to know then what you know now.");
                    Console.ReadKey(true);
                    Console.WriteLine("  A near-palpable sense of dread had hung over" +
                        " that village like a full moon when you'd arrived upon its " +
                        "outskirts. The steepled roofs of Myrovia rose like fingers" +
                        " towards the void of a starless sky, almost as though the" +
                        " settlement, nestled between craggy mountain peaks and" +
                        " whispering pines, itself was reaching for something elusive. " +
                        "Shutters creaked in the eerie silence as your feet clapped upon the road." +
                        " \n  You'd found yourself wondering if this really was the place that had" +
                        " sent out that call for adventurers like yourself, swords-for-hire with " +
                        "a taste for danger. There was no one to greet you. \n" +
                        "  Leaves rustled and stirred in a chill breeze, whisked up along the deserted alleyways and streets" +
                        " of what the poster had claimed to be a mountain haven and sanctuary from the other terrors gripping" +
                        " the land. \nInstantly, you could tell something was wrong.");
                    Console.ReadKey(true);
                    Console.WriteLine("\t'Hurry! Get inside!' One of the locals beseeched you from through a door half ajar. " +
                        "Their voice, an urgent whisper, nevertheless carried down the street like the grinding of deadly claws on stone. " +
                        "He hurriedly ushered you inside paying no mind to your questioning look. " +
                        "\n\t'It starts when the moon waxes its fullest,' he breathes by way of explanation, as his tremulous fingers frenziedly " +
                        "slammed the door's deadbolts back in place. 'You've arrived at the worst possible time.'" +
                        "");
                    Console.ReadKey(true);
                    Console.WriteLine("You look around the room, suddenly surprised to find other eyes watching you, gleaming in the murk. ");
                    Console.ReadKey(true);
                    Console.WriteLine(
                        "\t'This place used to be my tavern' your dubious (saviour?) informs you following your gaze as it takes in the dilapidated forest of chairs and tables, dusty disused counter and glinting bottles lining the back, long since emptied of their liquor. \n" +
                        "\t'I can still offer you board and lodgings... for a price'");
                    Console.ReadKey(true);
                    Console.WriteLine(
                        "You're about to ask him why you'd accept the steep price he ends up requesting, when a shaft of moonlight drifts through the slats of a boarded up window. Moments later blood-curdling howls shatter the eerie silence.");
                    Console.ReadKey(true);
                    Console.WriteLine(
                        "\t'Or you can always take your chances out there...' he levels you an expression at once both secretly fearful and yet implacable.");
                    Console.ReadKey(true);
                    Console.WriteLine(
                        "  You ask this innkeep just what on earth is happening out there. He responds only with a shake of his head and a finger pressed to his lips.");
                    Console.WriteLine("  You hear strange creatures prowling the streets, scuffling just outside of the door, their shadows slipping under the doorframe as they linger outside. One moment they claw for entry, panting heavily like no fell wight you've ever heard before; big - no, huge. The size of any man, at least. Then the mystery creatures slip away to the next house, ravenous." +
                        "\t'They're hunting,' the innkeep, your 'saviour', mutters to himself, 'they won't leave 'til someone saves us from them. Someone who knows how...' " +
                        "You tell him you came in answer to the poster and are ready for the challenge.");
                    Console.ReadKey(true);
                    Console.WriteLine("He slowly turns to you, eyeing you appraisingly.");
                    Console.ReadKey(true);
                    Console.WriteLine("\t'You'll need rest. We'll talk all about it in the morning. Go upstairs. Take the room left on the landing. And don't make a sound.'");
                    Console.ReadKey(true);
                    Console.WriteLine("  You do as he requests. you find the room in question and are surprised when you find the lodgings to be far cosier than what the tavern below had lead you to expect. The bed is soft, with ample duvets and pillows, and the decor invites comfort with every passing glance. You wonder for a few moments how you might ever sleep with what's going on outside. There are no windows in the room, but you can still hear the howls. Thing is, they don't sound like any wolves you've heard before...");
                    Console.WriteLine("  Then the innkeep brings you a drink to ease your mind. After that sleep comes easily.");
                    Console.ReadKey(true);
                    Console.WriteLine("  Too easily.");
                    Console.ReadKey(true);
                    Console.WriteLine("  The room had spun around you as your body staggered, collapsing to the bed in a heap. You'd just caught the innkeep's last words before darkness had lunged upon you like a predator that'd been lurking in the shadows. ");
                    Console.ReadKey(true);
                    Console.WriteLine(
                        "\t'I'm sorry friend. But there's only one who can lift this curse, and he ain't paid in gold...'");
                    Console.ReadKey(true);
                    Console.WriteLine("  Next thing you know, you're waking up in this dank cell, with only the realisation that the poster that'd sent you here had been a trap. No doubt countless adventurers before you had fallen for it too. And there's one other accompanying clue - One macabre sliver of insight that alights your mind as your thoughts race; You, and all those other adventurers...");
                    Console.ReadKey(true);
                    Console.WriteLine("  Whoever this curse-breaker is, YOU'RE the price he's demanded.");
                    Console.ReadKey(true);
                    Console.WriteLine("  Now, however, it's time to decide if you accept this fate cruelly dealt to you. \nAre" +
                        " you a fighter? A warrior? Perhaps a hero? Or could you aspire to be something else entirely? What choices will you make? \nNow is time to decide... \n");
                    Console.ReadKey(true);
                    break;
                }
                else
                {
                    Console.WriteLine("ERROR! Please enter 'yes' or 'no'.");
                }
            }

            string pk; // not important, it's just for the console.readline at the end of the program.
            bool continueChar = true; //for while loop involved in making character and player instantiation.
            /// These two methods below are involved when the player chooses what traits they would like.
            /// There were a number of ways I could have gone about this but this was the one that used least
            /// memory and was most efficient as opposed to creating a separate list for traits, appended
            /// to during character creation.
            /// Besides, this was more fun :D
            /// Essentially i create a list of traits to choose from in the form of a string,
            /// printed to the console. I then use the position of certain numbers and reoccurring 
            /// symbols to know where to truncate the string and isolate the key that 
            /// exists in the dictionary of traits and corresponds to the values which are its description.
            string truncateString(string traitsString)
            {
                int index = traitsString.LastIndexOf("\n");
                
                string tString = traitsString.Substring(0, index);
                return tString;
            }
            string makeKey(string traitsString)
            {
                int ind = traitsString.LastIndexOf("\n");
                int length = traitsString.Length;
                string key = traitsString.Substring(ind + 5, length-ind-5);
                key = key.Trim().ToLower();
                return key;
            }
            int number;
            string name = ""; // name is to be the name of your hero character.
            Dice D4 = new Dice(4);
            Dice D2 = new Dice(2);
            Dice D3 = new Dice(3);
            // instantiating a few dice needed for calculating skill and stamina stats
            Dice D8 = new Dice(8);
            //these lists of dice to be thrown for titular stats
            List<Dice> skillDice = new List<Dice>();
            int skill = 0;
            List<Dice> staminaDice = new List<Dice>();
            int stamina = 0;
            List<Weapon> weaponInventory = new List<Weapon>();
            List<Item> inventory = new List<Item>();
            // separate lists for weapons and items. Even though weapons inherit from items
            // they don't work well when grouped together (they become difficult to disentangle
            // and recast as weapons). It's best to use two separate lists.
            //
            //This is the dictionary of player chosen traits.
            Dictionary<string, string> traits = new Dictionary<string, string>();
            // instantiating a 'foundation' player. to be overwritten a bit later.
            Player player1 = new Player(name, skill, stamina, weaponInventory, inventory, traits);
            bool askquestion = true; // keep asking a question until appropriate response is given.
            int n = 0; //for adding appropriate number of dice at start of character creation
            while (continueChar == true)
            {
                Console.Write("Please enter your hero's name here: ");
                name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name))
                {
                    player1.Name = name;
                }
                else { continue; } 
                //must enter a name, although player has free rein to make this name
                // whatever he or she chooses.
                if (n == 0)
                {
                    skillDice.Add(D4);
                    skillDice.Add(D4);
                    skillDice.Add(D4);
                }
                
                Console.WriteLine("Rolling your character's skill (3 4-sided dice)...");
                player1.Skill = 0;
                skill = 0;
                // By pausing with console.Readkey between dice rolls, randomness is ensured
                foreach (Dice d in skillDice) { Console.ReadKey(true); int roll = d.Roll(d); skill += roll; Console.WriteLine($"You rolled a {roll}"); }
                skill = skill - 2;
                //
                player1.Skill = skill;
                //player1.Skill = 2;
                Console.WriteLine($"Your skill is {skill + 2} - 2 = {skill}");
                //
                
                //
                if (n == 0)
                {
                    staminaDice.Add(D2);
                    staminaDice.Add(D2);
                    staminaDice.Add(D2);
                    staminaDice.Add(D2);
                    staminaDice.Add(D2);
                    staminaDice.Add(D2);
                }
                player1.Stamina = 0;
                player1.InitialStamina = 0;
                stamina = 0;
                Console.WriteLine("Rolling your character's stamina (6 coin flips)...");
                foreach (Dice d in staminaDice) { Console.ReadKey(true); int roll = d.Roll(d); stamina += roll; Console.WriteLine($"You flipped a {roll}"); }
                stamina = stamina * 10;
                player1.Stamina = stamina;
                player1.InitialStamina = stamina;
                //Initial stamina determines the maximum health a player can have.
                Console.WriteLine($"Your stamina is {stamina}");
                

                Dictionary<string, string> traitList = new Dictionary<string, string>();
                traitList.Add("opportunist", "Carpe diem is your motto! You are the sort of person that strikes while the iron is hot and strikes hard. \nYour eagerness to exploit any advantage gives you a bonus in battle.");
                traitList.Add("human armadillo", "You've invested in quality steel armour and only ever take it off to polish it to a dazzling sheen. \nYour chances of being hit in combat are reduced as blows regularly bounce off you.");
                traitList.Add("thick-skinned", "Sticks and stones may break my bones, but... Well actually, no, they don't! You've a high pain tolerance and can weather trials with, if not a cool stoicism, then a devil-may-care attitude. \nThe damage you receive from enemy blows is sizeably reduced.");
                traitList.Add("diligent", "Either possessed by a hidden doubt, a desire for vengeance or perhaps simply a drive to excel, you've trained in the art of combat every day. You may not have started as a natural warrior, but you've pushed your own limits further than anyone else you know. \nYour skill is increased.");
                traitList.Add("jinxed", "When gentle folk of peaceful villages see you they cross to the other side of the street. They may even make gestures to ward away misfortune. To put it bluntly, you are a walking maelstrom of oafishness, a paragon of bad luck and a walking catastrophe the likes of which leaves everyone around you stunned. Calamities fall like rain around you as you naively blunder your merry way through every encounter.\nYour skill is reduced but you greatly increase your chance to score Critical Hits. Bring forth the maelstrom!");
                traitList.Add("hale, hot and hearty", "Regardless of whether or not you exercise regularly, or the state of your diet, you've always seemed to effortlessly stay in good shape. You find the captivated gaze of others often following you, admiring your most pleasing physique. \nYour stamina is increased.");
                traitList.Add("medicine man", "You've plenty of experience patching up many a wound, administering care and treating the sick. Even if your knowledge is limited, at least your doctorly disposition puts your patients more at ease.\nHealing potions have a greater effect on you.");
                traitList.Add("sadist", "Somewhere down the line you've secretly discovered the delectable, depraved pleasures of anguish - specifically other people's. You often find yourself relishing the thought of your next fight, and you feed your nasty fantasies by studying exactly where to strike to elicit the most exquisite pain... \nThe damage you deal from critical hits is greatly increased.");
                traitList.Add("thespian", "An actor without compare! A performer extraordinaire! And on occasion, mayhaps, the odd con, or two... or three. The future belongs to they that dares! \nAs for yourself, you *dare* to pretend to be that for which you are ill-equipped and trained, either for stolen glory, bountiful free booze or to gain company and favour with, shall we say, notable members of the opposite sex?\nYou may be lousy with a sword, but you look the part, and with a pen or a stage who needs such crude implements. Now! Where's your audience? \nYou have advantage in dialogue interactions and deception.");
                traitList.Add("friends with fairies", "For many moons you have been blessed with the extraordinary gift of being able to see and tap into the magical world of the Fey! You often converse with fairies, congregate with pixies and engage in entirely 110% meaningful philosophical discourse with your ethereal friends. Your other, more mundane friends, on the other hand, just think you're stark raving bonkers. But you know better...you think?\nWhere is the line between reality and fantasy? You decide! Prepare for strange encounters, bizarre events and your own, unique blend of logic to solve puzzles. Effects of magical potions become wild and unpredictable.");
                Console.WriteLine("You may also choose up to two of the following traits:\n");

                string traitsString = "\n[1] Opportunist\n[2] Human Armadillo\n[3] Thick-skinned\n[4] Friends With Fairies\n";
                int q = 5;
                if (skill > 5 && stamina > 80)
                {
                    traitsString += $"[{q}] Sadist\n";
                    q++;
                }
                else
                {

                    traitList.Remove("sadist");
                }
                if (skill <6 && stamina > 90)
                {
                    traitsString += $"[{q}] Thespian\n";
                    q++;
                }
                else
                {
                    traitList.Remove("thespian");
                }
                
                if (skill > 4 && skill < 10)
                {
                    traitsString += $"[{q}] Diligent\n";
                    q++;
                }
                else
                {

                    traitList.Remove("diligent");
                }
                if (skill < 5 && stamina < 100)
                {
                    traitsString += $"[{q}] Jinxed\n";
                    q++;
                }
                else
                {

                    traitList.Remove("jinxed");
                }
                if (stamina < 120 && stamina > 70)
                {
                    traitsString += $"[{q}] Hale, Hot and Hearty\n";
                    q++;
                }
                else
                {

                    traitList.Remove("hale, hot and hearty");
                }
                if (skill > 5)
                {
                    traitsString += $"[{q}] Medicine Man\n";
                    q++;
                }
                else
                {

                    traitList.Remove("medicine man");
                }
                Console.WriteLine(traitsString);
                bool continueChoice = true;
                int t = 0;// t is 'traits chosen so far'
                ///I've established below a loop that allows the player to 
                ///peruse the different traits available according to rolled 
                ///skill and stamina scores. Descriptions are displayed and 
                ///then there is a check to see if the player really wants to 
                ///select this trait. There is a maximum of two that can be 
                ///chosen.
                while (continueChoice && t < 2)
                {

                    string key = ""; 
                    string answer = Console.ReadLine().Trim().ToLower();
                    if (int.TryParse(answer, out number)) // if number entered
                    {
                        string traitchoice = traitsString;
                        
                        if (int.Parse(answer) < 1 || int.Parse(answer) >= q)
                        {
                            Console.WriteLine("Please enter a number corresponding to the list of traits above, or type 'done' when you are finished.");
                            continue;
                        }
                        else if (int.Parse(answer) == q-1)
                        {
                            traitchoice = truncateString(traitsString);
                            key = makeKey(traitchoice);
                            
                        }
                        else if (int.Parse(answer) == q - 2)
                        {
                            traitchoice = truncateString(traitsString);
                            traitchoice = truncateString(traitchoice);
                            key = makeKey(traitchoice);
                            
                        }
                        else if (int.Parse(answer) == q - 3)
                        {
                            traitchoice = truncateString(traitsString);
                            traitchoice = truncateString(traitchoice);
                            traitchoice = truncateString(traitchoice);
                            key = makeKey(traitchoice);
                            
                        }
                        else if (int.Parse(answer) == q - 4)
                        {
                            traitchoice = truncateString(traitsString);
                            traitchoice = truncateString(traitchoice);
                            traitchoice = truncateString(traitchoice);
                            traitchoice = truncateString(traitchoice);
                            key = makeKey(traitchoice);
                            
                        }
                        else if (int.Parse(answer) == q - 5)
                        {
                            traitchoice = truncateString(traitsString);
                            traitchoice = truncateString(traitchoice);
                            traitchoice = truncateString(traitchoice);
                            traitchoice = truncateString(traitchoice);
                            traitchoice = truncateString(traitchoice);
                            key = makeKey(traitchoice);
                            
                        }
                        else if (int.Parse(answer) == q - 6)
                        {
                            traitchoice = truncateString(traitsString);
                            traitchoice = truncateString(traitchoice);
                            traitchoice = truncateString(traitchoice);
                            traitchoice = truncateString(traitchoice);
                            traitchoice = truncateString(traitchoice);
                            traitchoice = truncateString(traitchoice);
                            key = makeKey(traitchoice);
                            
                        }
                        else if (int.Parse(answer) == q - 7)
                        {
                            traitchoice = truncateString(traitsString);
                            traitchoice = truncateString(traitchoice);
                            traitchoice = truncateString(traitchoice);
                            traitchoice = truncateString(traitchoice);
                            traitchoice = truncateString(traitchoice);
                            traitchoice = truncateString(traitchoice);
                            traitchoice = truncateString(traitchoice);
                            key = makeKey(traitchoice);
                            
                        }
                        else if (int.Parse(answer) == q - 8)
                        {
                            traitchoice = truncateString(traitsString);
                            traitchoice = truncateString(traitchoice);
                            traitchoice = truncateString(traitchoice);
                            traitchoice = truncateString(traitchoice);
                            traitchoice = truncateString(traitchoice);
                            traitchoice = truncateString(traitchoice);
                            traitchoice = truncateString(traitchoice);
                            traitchoice = truncateString(traitchoice);
                            key = makeKey(traitchoice);
                            
                        }
                        Console.WriteLine($"{traitList[key]}\nWould you like to select this trait?");
                        while (true)
                        {
                            string nextAnswer = Console.ReadLine().Trim().ToLower();
                            if (nextAnswer == "yes" || nextAnswer == "y")
                            {
                                try // can't select same trait twice.
                                {
                                    player1.Traits.Add(key, traitList[key]);
                                    t++;
                                    break;
                                }
                                catch { Console.WriteLine("You've already chosen that trait! Choose another."); askquestion = false; break; }
                            }
                            else if (nextAnswer == "no" || nextAnswer == "n")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Please enter 'yes' or 'no'");

                            }
                        }
                        if (t < 2 && askquestion)
                        {
                            Console.WriteLine("Would you like to pick another trait for your character?");
                        }
                        askquestion = true;
                    }
                    else // if trait typed out or player does not wish to continue trait selection
                    {
                        if (!traitList.ContainsKey(answer) && answer != "done")
                        {
                            Console.WriteLine("Type in a specific trait from the list above, its corresponding number, or type 'done' when you are finished.");
                            continue;
                        }
                        else if (answer == "done")
                        {
                            continueChoice = false;
                        }
                        else
                        {
                            Console.WriteLine($"{traitList[answer]}\nWould you like to select this trait?");
                            while (true)
                            {
                                string nextAnswer = Console.ReadLine().Trim().ToLower();
                                if (nextAnswer == "yes" || nextAnswer == "y")
                                {
                                    try
                                    {
                                        player1.Traits.Add(answer, traitList[answer]);
                                        t++;
                                        break;
                                    }
                                    catch { Console.WriteLine("You've already chosen that trait! Choose another."); askquestion = false; break; }
                                }
                                else if (nextAnswer == "no" || nextAnswer == "n")
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Please enter 'yes' or 'no'");

                                }
                            }
                            if (t < 2 && askquestion)
                            {
                                Console.WriteLine("Would you like to pick another trait for your character?");
                            }
                            askquestion = true;
                        }
                    }
                }
                string characterTrait = "";
                foreach (var k in player1.Traits)
                {
                    characterTrait += $"{player1.Traits[k.Key]}\n";
                }
                //
                if (player1.Traits.ContainsKey("opportunist"))
                {
                    // hT +3
                    //Console.WriteLine("Increase hitThreshold during combat by 2 if commentary = true");
                }
                if (player1.Traits.ContainsKey("human armadillo"))
                {
                    // enemy ht - 1 and skill/3 to hit
                    //Console.WriteLine("Decrease hitThreshold for opponent by 2 when commentary is false");
                }
                if (player1.Traits.ContainsKey("thick-skinned"))
                {
                    // 20% reduction in incoming damage
                    //Console.WriteLine("Modify incoming damageDealt by 3/4 when commentary is true.");
                }
                if (player1.Traits.ContainsKey("jinxed"))
                {
                    if (player1.Skill < 3) { player1.Skill = 1; }
                    else { player1.Skill = 2; }
                    //Console.WriteLine("Boon is +6 for all weapons, but skill is reduced to 2 or stays at 1.
                }
                if (player1.Traits.ContainsKey("diligent"))
                {
                    if (player1.Skill > 5) { player1.Skill += 1; }
                    else { player1.Skill = 7; }
                    //Console.WriteLine("if skill is 5 then +2 else +1");
                }
                if (player1.Traits.ContainsKey("hale, hot and hearty"))
                {
                    if(player1.Stamina < 110 && player1.Stamina > 80) { player1.Stamina += 20; player1.InitialStamina += 20; }
                    else if (player1.Stamina == 80) { player1.Stamina = 110; player1.InitialStamina = 110; }
                    else { player1.Stamina = 120; player1.InitialStamina = 120; }
                    //Console.WriteLine("if stamina is 80 +30, if stamina is below 110 +20, if 110 +10");
                }
                if (player1.Traits.ContainsKey("medicine man"))
                {
                    Console.WriteLine("Healing potions receive an extra dice roll");
                }
                if (player1.Traits.ContainsKey("friends with fairies"))
                {
                    // healing potions change type of dice rolled so that results vary wildly. Luck potion(felix
                    // felicis) causes new jinxed miss events. you can escape using the bowl fragments
                    // you can use healing potion on the skeleton to gain a companion and
                    // add messages with you dancing or skipping, sashaying, etc to various room items
                }
                if (player1.Traits.ContainsKey("thespian"))
                {
                    // you can talk your way out of your cell if successful dialogue 
                    // else you talk the guard into opening cell door but your con is 
                    // uncovered and you have to fight.
                }
                //Finally, a description of the character created whose composition is
                //the result of player choices and stats levels
                Console.WriteLine($"\n{name}'s details are as follows:\n{player1.describeSkill()}\n{player1.describeInitialStamina()}\n{characterTrait}");
                ///Check that player is happy with created character or wishes to start over.
                Console.WriteLine("Are you happy with this character?");
                while (true)
                {
                    string nextAnswer = Console.ReadLine().Trim().ToLower();
                    if (nextAnswer == "yes" || nextAnswer == "y")
                    {
                        continueChar = false;
                        break;

                    }
                    else if (nextAnswer == "no" || nextAnswer == "n")
                    {
                        player1.Traits = new Dictionary<string, string>();
                        Console.WriteLine("\x1b[3J");
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter 'yes' or 'no'");

                    }
                }
                n++;
            }






            //
            //
            //
            //
            //
            //

            
            void fungShui(string itemName)
            {
                int fungShui = 0;
                foreach (Item x in room.ItemList)
                {
                    if (x.Name == itemName)
                    {
                        fungShui++;
                    }
                }
                if (fungShui > 1)
                {

                    for (int i = room.ItemList.Count - 1;i>=0; i-- )
                    {
                        if (room.ItemList[i].Name == itemName && fungShui > 1)
                        {
                            room.ItemList.Remove(room.ItemList[i]);
                            fungShui--;
                        }
                    }
                }
            }
            //
            
            //
            

            //
            
            //
            List<Dice> damage = new List<Dice> { D4, D4 };
            List<Dice> damage1 = new List<Dice> { D3, D3, D2 };
            List<Dice> vanquisherDamage = new List<Dice> {D3, D3, D3, D3};
            // weapons to be used in battles
            Weapon vanquisher = new Weapon("Sword of Sealed Souls", "This sword almost seems to whisper as it slices the air like silk. You can almost imagine hearing wails off in the distance as though from the victims of some banshee haunting a blighted moor.", vanquisherDamage, defaultCritHits, defaultGoodHits, 2);
            Weapon breadKnife = new Weapon("Bread Knife", "This knife's blade is dulled with age. Any aspirations to slice anything other than very, very \nsoft butter might be met with something less than success", damage, defaultCritHits, defaultGoodHits);
            Weapon scimitar = new Weapon("rusty scimitar", "The scimitar's blade is flecked with rust. Crude and brittle, you doubt it'd last long parrying a better sword.", damage1, defaultCritHits, defaultGoodHits);
            Weapon bite = new Weapon("gnashing maw", "Sharp hook-like fangs lathered with drooling saliva, nestle within this creatures jaw, ready to draw blood.", damage1, defaultCritHits, defaultGoodHits);
            Weapon dagger = new Weapon("dagger", "The dagger's blade gleams like a crooked smile in some dubious tavern.", damage1, defaultCritHits, defaultGoodHits);
            
           // player1.WeaponInventory.Add(breadKnife);
           // player1.Inventory.Add(healPotion);
            player1.Inventory.Add(FelixFelicis);
            player1.Inventory.Add(elixirFeline);
           
            ///Instantiating monsters to be fought later
            List<Item> goblinInventory = new List<Item> { scimitar, breadKnife };
            List<Item> gnollInventory = new List<Item> { dagger };
            Item bracelet = new Item("Enchanted Bracelet of Blurred Image");
            List<Item> minotaurInventory = new List<Item> { vanquisher };
            Monster minotaur = new Monster("minotaur", "towering above you at eight feet, the minotaur levels its horns towards you, tenses its powerful muscles, and charges!", minotaurInventory, 120, 10, vanquisher);
            Monster goblin = new Monster("goblin", "The goblin's swarthy, pock-marked skin does little to lessen the effect of its ugly snarl.", goblinInventory, 50, 2, scimitar);
            goblin.Items.Add(bracelet);
            Monster gnoll = new Monster("gnoll", "The ravenous gnoll stares at you with hungry eyes. It seeks to feast, and you would make an excellent appetiser...", gnollInventory, 50, 6, bite);
            ///Instantiating battles to be used later.
            Combat trialBattle = new Combat(goblin, player1);
            Combat toughestBattle = new Combat(minotaur, player1);
            Combat tougherBattle = new Combat(gnoll, player1);

            // Dictionaries for items used on other effects (items or features)
            List<Dice> rustyDamage = new List<Dice> { D6 };
            Weapon yourRustyChains = new Weapon("rusty chain-flail", "Compared to the rest of the chains littered throughout the room these are relatively sturdy. A lone manacle at the end serves as an almost-effective morning-star.", rustyDamage, defaultCritHits, defaultGoodHits);
            var usesDictionaryItemItem = new Dictionary<Item, List<Item>> { [magnifyingGlass]= new List<Item> { note} };
            var usesDictionaryItemFeature = new Dictionary<Item, List<Feature>> { [steelKey] = new List<Feature> { rosewoodChest }, [yourRustyChains] = new List<Feature> { skeleton, bookCase },[breadKnife] = new List<Feature> { skeleton, bookCase }, [scimitar] = new List<Feature> { skeleton, bookCase }, [dagger] = new List<Feature> { skeleton, bookCase }, [vanquisher] = new List<Feature> { skeleton, bookCase } };

            if (player1.Traits.ContainsKey("friends with fairies"))
            {
                usesDictionaryItemItem.Add(halfOfCrackedBowl, new List<Item> { otherHalfOfCrackedBowl });
                usesDictionaryItemItem.Add(otherHalfOfCrackedBowl, new List<Item> { halfOfCrackedBowl });
                usesDictionaryItemFeature.Add(healPotion, new List<Feature> { skeleton });
                usesDictionaryItemFeature.Add(FelixFelicis, new List<Feature> { skeleton });
                usesDictionaryItemFeature.Add(elixirFeline, new List<Feature> { skeleton });
            }
           
            
            usesDictionaryItemItem[magnifyingGlass].Add(garment);
            
            Dictionary<Item, List<Player>> usesDictionaryItemChar = new Dictionary<Item, List<Player>> { [healPotion] = new List<Player> { player1 } , [FelixFelicis] = new List<Player> { player1}, [elixirFeline] = new List<Player> { player1} };
            List<Feature> features = new List<Feature>();

            Console.WriteLine($"You rouse yourself from your self-reflection. " +
                $"Who knows who, or what, this dubious curse-breaker is? Who knows what they have in store for you - or how their twisted designs might alleviate whatever Myrovia's curse is?");
            if (player1.Traits.ContainsKey("thespian"))
            {
                Console.WriteLine("And who, i tell you, *who* could possibly have thought your antics of feigned gallantry and cons would ever land you in this... predicament. You knew you should have stuck to stage acting.");
            }
            Console.WriteLine($" You resolve to find a way out of your predicament and this {room.Name}, and you intend to do it fast...");
            Console.ReadKey(true);
            Console.WriteLine("Will you...");
            Console.WriteLine("[1] Check what items are still on your person?");
            Console.WriteLine("[2] Investigate the room?");
            Console.WriteLine("[3] Try calling for help?");
            int a = 0;
            int b = 0;
            int c = 0;
            int e = 0;
            ///The previous choices are your base capabilities you'll keep returning to
            ///until more options open up. classes and their functions are repeatedly called 
            ///within each, making the game deeper than might first be expected.
            bool escapedRoom1 = false;
            bool escapedThroughDoor = true;
            bool fieryEscape = false;
            while (!escapedRoom1)
            {
                for (int i = room.ItemList.Count - 1; i>=0; i--)
                {
                    fungShui(room.ItemList[i].Name);
                }
                string reply = Console.ReadLine().Trim().ToLower();
                ///If player answers by typing number in list...
                try
                {
                    
                    int reply1 = int.Parse(reply);
                    if (((a<1 || b<1) && (reply1 < 1 || reply1 > 3))||(reply1>4)&&!player1.Inventory.Contains(musicBox) || reply1>5)
                    {
                        Console.WriteLine("Please enter a number corresponding to a choice of action.");
                        continue;
                    }
                    else if (reply1 == 1) 
                    { 
                        player1.searchPack(room.ItemList); 
                        a++;
                    }
                    else if (reply1 == 2) 
                    {
                        ///when player discards rusty chains they may appear more than once. 
                        ///fungshui() is present to preempt that and prevent duplicates.
                        
                        room.investigate(player1.Inventory, player1.WeaponInventory, b, player1, yourRustyChains); 
                        b++;
                    }
                    else if (reply1 == 3) 
                    { c++;
                        if (player1.Traits.ContainsKey("thespian"))
                        {
                            Console.WriteLine("~~ Insert dialogue choices here that may lead to freedom or a fight ~~");
                            if (trialBattle.fight(usesDictionaryItemItem,usesDictionaryItemFeature,room, player1, usesDictionaryItemChar, holeInCeiling))
                            {
                                trialBattle.wonFight();
                                if (room.FeatureList.Contains(holeInCeiling))
                                {
                                    while (true)
                                    {
                                        Console.WriteLine("You now have a choice! Will you... \n[1] Escape the room through the door your goblin jailor left unlocked?\n[2] Or will you instead escape through the hole left in the ceiling? ");
                                        string answ3r = Console.ReadLine().Trim().ToLower();
                                        if (string.IsNullOrWhiteSpace
                                            (answ3r))
                                        {
                                            continue;
                                        }
                                        try
                                        {
                                            int answ3r1 = int.Parse(answ3r);
                                            if (answ3r1 < 1 || answ3r1 > 2)
                                            {
                                                Console.WriteLine("Please enter either 1 or 2");
                                                continue;
                                            }
                                            else if (answ3r1 == 1)
                                            {
                                                Console.WriteLine("You rush through the door to escape!");
                                                Console.ReadKey(true);
                                                escapedRoom1 = true;
                                                break;
                                                
                                            }
                                            else if (answ3r1 == 2)
                                            {
                                                Console.WriteLine("You clamber up through the hole to escape!");
                                                Console.ReadKey(true);
                                                escapedRoom1 = true;
                                                escapedThroughDoor = false;
                                                break;
                                            }
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Please enter 1 or 2");
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("You rush through the door to escape!");
                                    Console.ReadKey(true);
                                    escapedRoom1 = true;
                                    break;
                                }
                                
                            }
                            else { System.Environment.Exit(0); }
                        }
                        else {
                            if (c == 1 && player1.Traits.ContainsKey("friends with fairies") && !player1.Traits.ContainsKey("thespian"))
                            {
                                Console.WriteLine("You march up to the door, put on your serious face, and set about yelling for succour. You bang on the door. You bang so hard you think eventually you might just bang your way through it. Then your jailor would be mourning the loss of this rosewood door... \nPfft... mourning...<titter>...wood. You roll on the floor in a fit of giggles. Your fairy friends nod their heads with approval.\n");
                                Console.WriteLine("You waste precious minutes!");
                                e++;

                            }
                            else if (player1.Traits.ContainsKey("friends with fairies") && !player1.Traits.ContainsKey("thespian"))
                            {
                                Console.WriteLine("You almost can't look at the door without a ripple of mirth shuddering through you. No... you must focus! You tug your own face into a grumpy frown, fighting the laughter.");
                            }
                            if (c == 1)
                            {
                                Console.WriteLine($"Somewhere not too far from beyond the confines of the {room.Name} a bestial guffaw can be heard. It seems whoever, or whatever, guards your cell cares little for your predicament.");
                            }
                            else
                            {
                                Console.WriteLine($"Whatever creature lurks beyond the rosewood door does not respond or stir to your clamouring. They remain unconcerned.");
                            }
                        }
                        Console.ReadKey(true);
                        
                    }
                    /// I'm going to change all the following code (using item on 
                    /// something else) into two polymorphic methods - one 
                    /// for combat and the other for use outside of combat.
                    /// The one for combat will need an extra parameter, the monster,
                    /// so this should work well, and save space.
                    /// 
                    /// Essentially i first ask which item the player wishes to
                    /// use from their pack. I then ask what they wish to use it on.
                    /// The success of this action is determined by a dictionary 
                    /// (usesDictionaryItemItem or usesDictionaryItemFeature) where an item may
                    /// have a list of items corresponding to it. If it does, the item
                    /// can be used on the feature or effected item. otherwise the usesItem function
                    /// returns a false value and a stock response is given to let the user know, 
                    /// the item cannot be used that way.
                    /// 
                    /// the usesitem function comes from the
                    /// Item class and so weapons can also be used this way,
                    /// as weapons inherit from items, though I've yet to implement this by
                    /// upgrading the usesDictionaries accordingly.
                    /// 
                    /// There are 3 usesItem functions. one for effecting items,
                    /// another for effecting features and lastly for effecting 
                    /// the player themselves. Nestled try and catch statements are used 
                    /// to determine which of these functions must be used.
                    
                    else if (reply1 == 4) // for when player has searched their pack and the room at least once.
                    {
                        e++;
                        List<bool> success = new List<bool>();
                        success = player1.UseItemOutsideCombat(room, musicBox, binkySkull, steelKey, rosewoodChest, holeInCeiling, usesDictionaryItemChar, usesDictionaryItemItem, usesDictionaryItemFeature, trialBattle);

                        if (room.FeatureList.Contains(holeInCeiling))
                        {
                            Console.WriteLine("Without further delay, you scramble up the mound of debris left by the hole and up into the next room.");
                            Console.ReadKey(true);
                            escapedRoom1 = true;
                            escapedThroughDoor = false;
                            continue;
                        }
                        if (success[1])
                        {
                            Console.WriteLine("With the whole cell blazing around you, you flee through the door. A fiery haze billows in your wake as you throw yourself into a corridor and slam the rosewood door shut behind you.");
                            if (player1.Inventory.Contains(bowlFragments)) { Console.WriteLine($"It's a moment before you realise your backpack is still smoking!\nOpening it up you scramble to save the contents, fishing out the {bowlFragments.Name} before they can burn everything, but it's too late. \nEverything inside your pack is burned and unusable!"); player1.Inventory.Clear(); Console.ReadKey(true); } 
                            
                            escapedRoom1 = true;
                            escapedThroughDoor = true;
                            fieryEscape = true;
                            foreach (Item x in player1.Inventory) { while (x.Name.Contains("blazing") || x.Name.Contains("fiery") || x.Name.Contains("burning") || x.Name.Contains("smouldering") || x.Name.Contains("smoking")) { x.Name = x.Name.Substring(x.Name.IndexOf(" ")).Trim(); } }
                            foreach (Weapon x in player1.WeaponInventory) { while (x.Name.Contains("blazing") || x.Name.Contains("fiery") || x.Name.Contains("burning") || x.Name.Contains("smouldering") || x.Name.Contains("smoking")) { x.Name = x.Name.Substring(x.Name.IndexOf(" ")).Trim(); } }
                            continue;
                        }
                    }
                    else if (reply1 == 5) // The player solved the puzzle and must fight the goblin.
                    {
                        Console.WriteLine("You gaze at the innocuous music box nestled snugly in the palm of your hand. Biting your lip, you look to the rosewood door. The note said that whatever kept guard would be enraged by the tune this thing plays. Once opened there will be no going back...");
                        Console.WriteLine("Are you sure you wish to proceed?");
                        while (true)
                        {
                            string r3ply = Console.ReadLine();
                            if (r3ply == "no" || r3ply == "n")
                            {
                                Console.WriteLine("You gingerly place the music box back in your pack for now...");
                                break;
                            }
                            else if (r3ply == "yes" || r3ply == "y")
                            {
                                Console.WriteLine("You prise open the music box. Immediately its brass cogs begin to whir as a jaunty melody fills the room. You find the tune to be lively and cheery, but it's not long before a furious, rage-filled roar erupts from beyond the door. In a flurry of instants, boots have pounded closer, someone fumbles at the lock of your door, and finally a frenzied goblin bursts inside, scimitar drawn. For a moment you think he'll smash the music box, but instead he lunges towards you...");
                                if (trialBattle.fight(usesDictionaryItemItem, usesDictionaryItemFeature, room, player1, usesDictionaryItemChar, holeInCeiling))
                                {
                                    if (player1.Inventory.Contains(binkySkull))
                                    {
                                        Console.ReadKey(true);
                                        Console.WriteLine("\n\t'Just look at that,' Binky tuts, peering out of your backpack as you see if you've room for any more items. 'Honestly, where have all the good monsters gone these days, eh? I mean he isn't any Medusa or Circe or anything, but slouching on the job?' \n Your gaze matches his as you contemplate the sprawling bloody mess that was your foe. You answer that you're pretty sure the goblin's dead... right? As you speak a fly lands over its exposed eyeball before buzzing away. \n\t'Dead? Of course not! You're this story's hero! Hero's are never murderers, he's just bone idle!' \nYeah, you answer, you guess that makes sense... No, of course it does!\nWith your gleeful heart as light as an ever-so-teensy-bit-eccentric feather you skip over the corpse and ever onward in your quest!");
                                    }
                                    trialBattle.wonFight();
                                    if (room.FeatureList.Contains(holeInCeiling))
                                    {
                                        while (true)
                                        {
                                            Console.WriteLine("You now have a choice! Will you... \n[1] Escape the room through the door your goblin jailor left unlocked?\n[2] Or will you instead escape through the hole left in the ceiling? ");
                                            string answ3r = Console.ReadLine().Trim().ToLower();
                                            if (string.IsNullOrWhiteSpace
                                                (answ3r))
                                            {
                                                continue;
                                            }
                                            try
                                            {
                                                int answ3r1 = int.Parse(answ3r);
                                                if (answ3r1 < 1 || answ3r1 > 2)
                                                {
                                                    Console.WriteLine("Please enter either 1 or 2");
                                                    continue;
                                                }
                                                else if (answ3r1 == 1)
                                                {
                                                    Console.WriteLine("You rush through the door to escape!");
                                                    Console.ReadKey(true);
                                                    escapedRoom1 = true;
                                                    break;
                                                }
                                                else if (answ3r1 == 2)
                                                {
                                                    Console.WriteLine("You clamber up through the hole to escape!");
                                                    Console.ReadKey(true);
                                                    escapedRoom1 = true;
                                                    escapedThroughDoor = false;
                                                    break;
                                                }
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Please enter 1 or 2");
                                            }
                                        } 
                                    }
                                    else
                                    {
                                        Console.WriteLine("You rush through the door to escape!");
                                        Console.ReadKey(true);
                                        escapedRoom1 = true;
                                        break;
                                    }
                                }
                                else { System.Environment.Exit(0); }

                            }
                            else { Console.WriteLine("Please enter either 'yes' or 'no'."); }
                        }
                    }
                    if (e > 3) // if the player fails to find an escape within a certain number of moves, then it's game over.
                    {
                        Console.WriteLine("You've tried as hard as you " +
                        "might to find some way out of the dank cell, but your " +
                        "time has finally run out. Heavy boots clomp outside your " +
                        "cell, a sardonic cackle sounds from the other side and" +
                        " you catch eerie, softly-spoken words; a new voice. It'" +
                        "s ominous tones state how you'll make for an excellent" +
                        " specimen. \n For a moment you hope the door to your " +
                        "cell might be opened - that you might have a chance to" +
                        " overpower the enemy. Instead an incantation is made" +
                        " and you reel from the braziers as their ethereal glow" +
                        " smoulders, plumes of dense smog erupting either side " +
                        "of the door.  The smoke fills the room, leaving you ha" +
                        "cking and choking, until you succumb to the enchanted " +
                        "gas' spell and plunge into a sleep from which you'll " +
                        "never awake. \n If there is one small mercy, it is that" +
                        " you'll be spared a species of terror utterly alien to" +
                        " you, as you'll never know how they " +
                        "defile your body.\n");
                        Console.ReadKey(true);
                        Console.WriteLine("Your adventure ends here...");
                        Console.ReadKey(true);
                        System.Environment.Exit(0);
                    }
                    if (!escapedRoom1)
                    {
                        Console.WriteLine("Now what will you do?");
                        Console.WriteLine("[1] Check what items are still on your person?");
                        Console.WriteLine("[2] Investigate the room?");
                        Console.WriteLine("[3] Try calling for help?");

                        if (a > 0 && b > 0)
                        {
                            Console.WriteLine("[4] Try using one of your items on something...");
                        }
                        if (player1.Inventory.Contains(musicBox))
                        {
                            Console.WriteLine("[5] Open the music box?");
                        }
                    }
                    
                }
                catch //and a check to make sure they know the correct input.
                {
                    Console.WriteLine("Please enter a number corresponding to your choice of action.");
                    continue; 
                }
                


            }
            ///Past this point is the next room 
            
            if (escapedThroughDoor)
            {
                if (fieryEscape) 
                { 
                    Console.WriteLine("Looking back, the door will only hold for so long against the flames and time is not your friend. What will you do?"); 
                }
                else
                {
                    Console.WriteLine("With the way ahead clear, what will you do?");
                }

            }
            else
            {
                Console.WriteLine("Finding yourself in a new room and on a new level of this perplexing (tower?), what will you decide to do next?");
            }


            if (trialBattle.fight(usesDictionaryItemItem, usesDictionaryItemFeature, room, player1, usesDictionaryItemChar, holeInCeiling))
            {
                trialBattle.wonFight();
                if (tougherBattle.fight(usesDictionaryItemItem, usesDictionaryItemFeature, room, player1, usesDictionaryItemChar, holeInCeiling))
                {
                    tougherBattle.wonFight();
                    if (toughestBattle.fight(usesDictionaryItemItem, usesDictionaryItemFeature, room, player1, usesDictionaryItemChar, holeInCeiling)) { tougherBattle.wonFight(); }
                }
            }

            pk = Console.ReadLine();
        }
        
        
        

        
        
        
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public class Combat
    {
        Item SpecialItem { get; set; }
        Monster Monster { get; set; } // monster.Veapon
        Player Player { get; set; } // playerWeapon = null; foreach (weapon x in Player.inventory){if x.Equipped{ playerWeapon = x}} if playerWeapon = null{playerWeapon = Weapon(fists, etc.)}
        public Combat(Monster monster, Player player, Item specialItem = null)
        {
            SpecialItem = specialItem;
            Monster = monster;
            Player = player;
        }
        public void wonFight()
        {
            Console.WriteLine($"Would you like to search the {Monster.Name} for items?");

            while (true)
            {
                string answer = Console.ReadLine().Trim().ToLower();
                if (answer == "yes" || answer == "y")
                {
                    Monster.search(Player.Inventory, Player.WeaponInventory);
                    break;
                }
                else if (answer == "no" || answer == "n") { break; }
                else { Console.WriteLine("ERROR! Please answer 'yes' or 'no'."); }
            }
        }
        public bool fight(Dictionary<Item, List<Item>> usesDictionaryItemItem, Dictionary<Item, List<Feature>> usesDictionaryItemFeature, Room room, Player player, Dictionary<Item, List<Player>> usesDictionaryItemChar, Feature holeInCeiling)
        {
            player = Player;
            Dice D2 = new Dice(2);
            Dice D3 = new Dice(3);
            Dice D4 = new Dice(4);
            Dice D5 = new Dice(5);
            Dice D6 = new Dice(6);
            List<Dice> pugilism = new List<Dice>();
            int i = 0;
            string another = "a";
            while (i < (2 + Player.Skill) / 3)
            {
                if (i < 2)
                {
                    pugilism.Add(D2);
                }
                else if (i < 3)
                {
                    pugilism.Add(D3);
                }
                else
                {
                    pugilism.Add(D5);
                }
                i++;
            }
            List<string> jinxedMisses = new List<string>
            {
                $"The {Monster.Name} has you now! Finally, relishing it's soon-to-be freedom from your cursed, jinxy hide, it raises its {Monster.Items[0].Name} to strike... and gets it stuck in the {room.FeatureList[D3.Roll(D3) - 1].Name}. You scurry away as the {Monster.Name} curses, trying to free it. \nThe {Monster.Name} loses 1 stamina.",
                $"The ever-increasingly vexed {Monster.Name} attacks, misses, and gets really bad tennis-elbow. Ooh! that's gotta hurt... \nThe {Monster.Name} loses 2 stamina.",
                $"The {Monster.Name} lunges at you! As you trip over yourself, clumsily scrambling for cover, you hear a tremendous crash. \nThe {Monster.Name} ran into the {room.FeatureList[D3.Roll(D3) - 1].Name}. Ow! It loses 5 Stamina.",
                $"The {Monster.Name} at last has you pinned. It looms over you with a leer, ready to deliver the killing blow, when part of the {room.Name}'s ceiling caves in upon its head. \nThe {Monster.Name} loses 7 stamina!",
                $"The {Monster.Name} bellows a string of foul curses as each frenzied attack miraculously leaves you unscathed. It bites its own tongue in the process. Youch! \nAs you slip away, the {Monster.Name} loses 1 stamina...",
                $"The {Monster.Name} bounds after you in circles, flailing wildly. It careers into a {room.ItemList[D3.Roll(D3) - 1].Name}, grazing its knee. Oof! That's a nasty splinter! \nThe {Monster.Name} loses 3 stamina.",
                $"You stammer as you try reasoning with the {Monster.Name}. Surely you can just talk things out over a lovely cup of mead... The {Monster.Name} doesn't listen. It lunges at you, only to crash into the {room.FeatureList[D3.Roll(D3) - 1].Name}. Yikes! \nThe {Monster.Name} loses 11 stamina.",
                $"In frustration the {Monster.Name} hurls its {Monster.Items[0].Name} at you! It bounces off your armour back at the {Monster.Name}. \n The {Monster.Name} loses 6 stamina.",
                $"The {Monster.Name} attacks wildly, wanting nothing more than to end the whirlwind of chaos your ill-fortune brings. It trips. Ouch! That's going to need a bandage... \nThe {Monster.Name} loses 7 stamina.",
                $"The {Monster.Name} at last has you cornered. It looms over you with a leer, ready to at last deliver the killing blow. Then the {room.Name}'s ceiling caves in.\n The {Monster.Name}'s engulfed by an avalanche of cascading debris. A trickle of dust takes a moment to stop. Then finally, one loose floorboard topples from the floor above and crowns the heap."
            };
            List<String> pugilismCritHits = new List<String>
                {
                $"Extending your palm into a spear-like thrust, you strike the {Monster.Name}'s chest cavity. Their ribs shatter as your hand plunges deep inside. An instant later your fist is clenched around their still beating heart, held before their awed eyes just before the light leaves them forever.",
                $"The {Monster.Name} charges towards you. With cat-like reflexes you assume the 'soaring crane' position practiced by martial monks of old. You serenely close your eyes to the {Monster.Name}'s battle roar, silencing your mind. When you open them again, you've landed with uncanny grace back on your feet. Your whirlwind kick has sent the {Monster.Name} sailing through the air. They're not done yet, but it won't be long...",
                $"The {Monster.Name}'s guard is just strong enough to turn your killer karate chop, into a nevertheless brutal strike. The {Monster.Name} is left winded and greviously wounded.",
                $"A bead of cold sweat traces your brow as you're forced to admit that even your lethal hands are struggling to find any weak spot to exploit. Your best blows have yet to slow the {Monster.Name} down. It seems its anger has only increased.",
                $"After a series quick jabs to the ribs, the {Monster.Name}'s guard collapses. You seize your chance, landing a powerful blow across its jaw. There's an audible crack as the {Monster.Name}'s neck snaps. With its head twisted 180 degrees the wrong way, it collapses backwards (forwards?) as stiff as a board to the floor.",
                $"You rain haymaker after haymaker down upon the {Monster.Name}. With one dislocated limb, they still manage to somehow wheel away from you before you can land the killing blow. They stagger to their feet.",
                $"Your uppercut drives deep into the {Monster.Name}'s gut. It is left wheezing for breath. For a moment it looks like it might collapse to its knees. But slowly it rises up again to continue the fight...",
                $"You land blow after blow, but the {Monster.Name} appears to be able to tap into ever more reserves of stamina. This fight may go either way yet... ",
                $"Your flailing fists chance a lucky blow. The {Monster.Name}'s nose splinters as it charges into your fist, it's momentum rather than your own felling the creature. Its brain is pulverised as bone fragments ricochet inside its skull. A portion of its brain dribbles from its nostril, before it keels over.",
                $"Your blows are almost effortlessly deflected by the {Monster.Name}, until your elbow clobbers them over the head. The {Monster.Name} looks like it might suffer a concussion, but even this fortunate hit isn't enough to finish them yet...",
                $"You trip over your own foot, but somehow the {Monster.Name} comes out the worst for it! Their blow sails over your head, sending them off balance and toppling to the ground. You manage to land a few kicks into their back before they get up again.",
                $"You kick the {Monster.Name}'s shins as it makes to grapple you. Despite your amateurish attacks, you've caused it a lot of pain. However, it has done little to end this fight.",
                $"Cornered, you duck the {Monster.Name}'s devastating blow, before scrambling along the floor under its feet. As it scrambles for your ankles, gazing at you through its own legs, something cracks. The {Monster.Name}'s back locks in place! It topples over in a knot of limbs. You flail at it with your wimpy wrists until it expires.",
                $"Something gets stuck in your eye. Groping blindly you run into the {Monster.Name}. Somehow this turns into a devastating body slam. The {Monster.Name} staggers to its feet, rueing the day it met you...",
                $"Your oafish attacks rarely land, until you tumble. Your flailing foot clumsily connects with the {Monster.Name}'s nethers. Weapon raised, they continue to aggressively... waddle towards you.",
                $"You nip the {Monster.Name}'s fingers as it grapples you. As you slip away it trips over its own feet. Ouch! The {Monster.Name} looks more infuriated than ever as it continues scrambling after you around the room."
                };
            List<String> pugilismGoodHits = new List<String>
                {
                $"Your scissor kick finally puts the {Monster.Name}'s lights out.",
                $"You execute a flawless palm strike. {Monster.Name} is close to death.",
                $"You deliver a series of crushing hammer-fist blows to the {Monster.Name}.",
                $"You administer a flurry of lightning jabs to the {Monster.Name}'s pressure points.",
                $"Your sucker punch lifts the {Monster.Name} off their feet. They don't get back up.",
                $"A crude but powerful push kick sends the {Monster.Name} crashing to the floor.",
                $"A flurry of light jabs rearranges the {Monster.Name}'s face.",
                $"Your punches have been strong, but you'll require something better yet to defeat this foe",
                $"One final, solid punch sends the {Monster.Name} tottering over. They are finally vanquished.",
                $"Your unrefined pugilism has somehow reduced the {Monster.Name} to its final shred of life.",
                $"Your fist blow has for once wholly bypassed the {Monster.Name}'s defences.",
                $"You chance a lucky hit, but not lucky enough - the {Monster.Name} remains unfazed. You're going to have to really pull something out of the bag to win this fight...",
                $"Your jinxed nature rubs off on your adversary. The {Monster.Name} somehow clobbers itself over the noggin. It's head topples from its shoulders.",
                $"In a strange twist of fate, the {Monster.Name} injures itself with its {Monster.Veapon.Name} as it chases you around in circles.",
                $"The {Monster.Name} keeps stepping on loose floorboards... Then steps on a nail. Yeesh!",
                $"The {Monster.Name} steps on a loose floorboard. It whacks them in the face. Ouch!"
                };
            Weapon playerWeapon = new Weapon("fists", "Your tremulous hands aren't fast enough to swat a fly, let alone hurt anyone", pugilism, pugilismCritHits, pugilismGoodHits);
            if (Player.Skill < 4)
            {
                playerWeapon = new Weapon("fists", "Your tremulous hands aren't fast enough to swat a fly, let alone hurt anyone", pugilism, pugilismCritHits, pugilismGoodHits);
            }
            else if (Player.Skill < 7)
            {
                playerWeapon = new Weapon("fists", "Your soft hands are less than accustomed to the rough life adventuring brings. They're more often used for leafing through a good book than fighting.", pugilism, pugilismCritHits, pugilismGoodHits);
            }
            else if (Player.Skill < 10)
            {
                playerWeapon = new Weapon("fists", "Your callused hands are well accustomed to the rough life adventuring brings, and have made a noted debut at many a pub brawl.", pugilism, pugilismCritHits, pugilismGoodHits);
            }
            else
            {
                playerWeapon = new Weapon("fists", "Your firm hands are deadly weapons in themselves; artfully precise implements of destruction that've been hardened by years of punching tree trunks and doing press ups on blazing hot coals.", pugilism, pugilismCritHits, pugilismGoodHits);
            }

            foreach (Weapon y in Player.WeaponInventory)
            {
                if (y is Weapon)
                {
                    if (y.Equipped) { playerWeapon = y; break; }
                }
            }
            foreach (Weapon x in Player.WeaponInventory) { playerWeapon.Boon = 0; }// potion of luck, felix felicis, works for one battle only
            if (player.Traits.ContainsKey("jinxed"))
            {
                //

                //
                playerWeapon.Boon = 6;
                
            }
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

            Console.WriteLine(Monster.Description);
            Dice D20 = new Dice(20);
            bool initiative = false;
            if (Player.Skill + D20.Roll(D20) >= Monster.Skill + D20.Roll(D20))
            {
                Console.WriteLine($"The {Monster.Name} is caught off guard. You take the initiative!");
                initiative = true;
            }
            else
            {
                Console.WriteLine($"Your reactions aren't fast enough. {Monster.Name} takes the initiative!");
            }
            private int turn = 0;
            if (initiative)
            {

                int damageDealt = playerWeapon.Attack(Player.Skill, Monster.Skill, Monster.Stamina, true, Monster, player, another, room, holeInCeiling);
                Monster.Stamina -= damageDealt;
                Console.WriteLine($"The {Monster.Name} lost {damageDealt} points of stamina!");
                turn = 1;
                Console.ReadKey(true);
            }

            while (Monster.Stamina > 0 && Player.Stamina > 0)
            {
                bool start = false;
                if (turn == 0)
                {
                    start = true;
                }
                if (Monster.Stamina < 1) { break; }
                int damageDealt = Monster.Veapon.Attack(Monster.Skill, Player.Skill, Player.Stamina, false, Monster, player, another, room, holeInCeiling, start);
                if (damageDealt >= 0)
                {
                    Player.Stamina -= damageDealt;
                    Console.WriteLine($"You've lost {damageDealt} points of stamina!");
                }
                else if (damageDealt < 0)
                {
                    
                    Monster.Stamina += damageDealt;
                    
                }
                if (Monster.Stamina < 1) { break; }
                if (Player.Stamina < 1) { break; }
                
                Console.WriteLine(Player.describeStamina());
                Console.Write($"Do you wish to continue attacking with your {playerWeapon.Name}? ");
                while (true)
                {
                    string answer = Console.ReadLine().Trim().ToLower();
                    if (answer == "yes" || answer == "y")
                    {
                        pugilism = new List<Dice>();
                        i = 0;
                        while (i < (2 + Player.Skill) / 3)
                        {
                            if (i < 2)
                            {
                                pugilism.Add(D2);
                            }
                            else if (i < 3)
                            {
                                pugilism.Add(D3);
                            }
                            else
                            {
                                pugilism.Add(D5);
                            }
                            i++;
                        }
                        if (playerWeapon.Boon > 9)
                        {
                            if (Player.Skill < 4)
                            {
                                playerWeapon = new Weapon("fists", "Your tremulous hands aren't fast enough to swat a fly, let alone hurt anyone", pugilism, pugilismCritHits, pugilismGoodHits, 10);
                            }
                            else if (Player.Skill < 7)
                            {
                                playerWeapon = new Weapon("fists", "Your soft hands are less than accustomed to the rough life adventuring brings. They're more often used for leafing through a good book than fighting.", pugilism, pugilismCritHits, pugilismGoodHits, 10);
                            }
                            else if (Player.Skill < 10)
                            {
                                playerWeapon = new Weapon("fists", "Your callused hands are well accustomed to the rough life adventuring brings, and have made a noted debut at many a pub brawl.", pugilism, pugilismCritHits, pugilismGoodHits, 10);
                            }
                            else
                            {
                                playerWeapon = new Weapon("fists", "Your firm hands are deadly weapons in themselves; artfully precise implements of destruction that've been hardened by years of punching tree trunks and doing press ups on blazing hot coals.", pugilism, pugilismCritHits, pugilismGoodHits, 10);
                            }
                        }
                        else
                        {
                            if (Player.Skill < 4)
                            {
                                playerWeapon = new Weapon("fists", "Your tremulous hands aren't fast enough to swat a fly, let alone hurt anyone", pugilism, pugilismCritHits, pugilismGoodHits);
                            }
                            else if (Player.Skill < 7)
                            {
                                playerWeapon = new Weapon("fists", "Your soft hands are less than accustomed to the rough life adventuring brings. They're more often used for leafing through a good book than fighting.", pugilism, pugilismCritHits, pugilismGoodHits);
                            }
                            else if (Player.Skill < 10)
                            {
                                playerWeapon = new Weapon("fists", "Your callused hands are well accustomed to the rough life adventuring brings, and have made a noted debut at many a pub brawl.", pugilism, pugilismCritHits, pugilismGoodHits);
                            }
                            else
                            {
                                playerWeapon = new Weapon("fists", "Your firm hands are deadly weapons in themselves; artfully precise implements of destruction that've been hardened by years of punching tree trunks and doing press ups on blazing hot coals.", pugilism, pugilismCritHits, pugilismGoodHits);
                            }
                        }
                        foreach (Weapon y in Player.WeaponInventory)
                        {
                            if (y.Equipped) { playerWeapon = y; break; }
                        }
                        if (playerWeapon.Boon < 10 && player.Traits.ContainsKey("jinxed"))
                        {
                            playerWeapon.Boon = 6;
                        }
                        
                        damageDealt = playerWeapon.Attack(Player.Skill, Monster.Skill, Monster.Stamina, true, Monster, player, another, room, holeInCeiling);
                        Monster.Stamina -= damageDealt;

                        Console.WriteLine("\n");
                        if (damageDealt > 0)
                        {
                            Console.WriteLine($"The {Monster.Name} lost {damageDealt} points of stamina!");
                        }
                        else
                        {
                            turn = -1;
                            Console.WriteLine($"{Monster.Name} seizes their chance to attack!");
                        }
                        Console.ReadKey(true);
                        break;
                    }
                    else if ((answer == "no") || (answer == "n"))
                    {
                        turn = -1;
                        Console.WriteLine("Will you spend your turn \n[1] Equipping a new weapon?\n[2] Unequipping your weapon?\n[3] Using one of your items on something or someone?\n[4]Hesitating and considering your choices in life?");
                        while (true)
                        {
                            string answer1 = Console.ReadLine().Trim().ToLower();
                            if (answer1 == "1" || answer1 == "one")
                            {
                                int j = 0;
                                List<Weapon> availableWeapons = new List<Weapon>();
                                foreach (Weapon h in Player.WeaponInventory)
                                {
                                    j++;
                                    if (!h.Equipped)
                                    {
                                        availableWeapons.Add(h);
                                    }
                                }
                                if (j < 1)
                                {
                                    Console.WriteLine("You waste time frenziedly rummaging through your rucksack, but you've no new weapons to choose from!");
                                    break;
                                }
                                string message = "You can choose from ";
                                int numWeapons = availableWeapons.Count;
                                int k = 1;
                                foreach (Weapon h in availableWeapons)
                                {
                                    message += "\n[" + k + "] " + h.Name;
                                    k++;
                                }
                                Console.WriteLine(message);
                                while (true)
                                {
                                    string response = Console.ReadLine().Trim().ToLower();
                                    try
                                    {
                                        int numResponse = int.Parse(response);
                                        Player.equip(availableWeapons[numResponse - 1], Player.WeaponInventory, player);
                                        Console.WriteLine($"\n{availableWeapons[numResponse - 1].Description}");
                                        foreach (Weapon y in Player.WeaponInventory)
                                        {
                                            if (y.Equipped) { playerWeapon = y; break; }
                                        }
                                        Console.WriteLine($"You admire your {availableWeapons[numResponse - 1].Name} for only an instant before the {Monster.Name} lunges at you...");
                                        break;
                                    }
                                    catch
                                    {
                                        Console.WriteLine($"Please enter a number from 1 to {numWeapons}");
                                        continue;
                                    }

                                }
                                break;

                            }
                            else if (answer1 == "2" || answer1 == "two")
                            {
                                if (playerWeapon.Name == "fists")
                                {
                                    Console.WriteLine($"You're not sure how you might 'unequip' your own fists, and as you contemplate this conundrum the {Monster.Name} comes in for the attack...");
                                    break;
                                }
                                else
                                {
                                    Player.unequip(Player.WeaponInventory);
                                    pugilism = new List<Dice>();
                                    i = 0;
                                    while (i < (2 + Player.Skill) / 3)
                                    {
                                        if (i < 2)
                                        {
                                            pugilism.Add(D2);
                                        }
                                        else if (i < 3)
                                        {
                                            pugilism.Add(D3);
                                        }
                                        else
                                        {
                                            pugilism.Add(D5);
                                        }
                                        i++;
                                    }
                                    if (Player.Skill < 4)
                                    {
                                        playerWeapon = new Weapon("fists", "Your tremulous hands aren't fast enough to swat a fly, let alone hurt anyone", pugilism, pugilismCritHits, pugilismGoodHits);
                                    }
                                    else if (Player.Skill < 7)
                                    {
                                        playerWeapon = new Weapon("fists", "Your soft hands are less than accustomed to the rough life adventuring brings. They're more often used for leafing through a good book than fighting.", pugilism, pugilismCritHits, pugilismGoodHits);
                                    }
                                    else if (Player.Skill < 10)
                                    {
                                        playerWeapon = new Weapon("fists", "Your callused hands are well accustomed to the rough life adventuring brings, and have made a noted debut at many a pub brawl.", pugilism, pugilismCritHits, pugilismGoodHits);
                                    }
                                    else
                                    {
                                        playerWeapon = new Weapon("fists", "Your firm hands are deadly weapons in themselves; artfully precise implements of destruction that've been hardened by years of punching tree trunks and doing press ups on blazing hot coals.", pugilism, pugilismCritHits, pugilismGoodHits);
                                    }
                                    Console.WriteLine($"{playerWeapon.Description}\nYou resolve to fight bare fisted, mano e mano. \n Meanwhile, the {Monster.Name} charges towards you...");
                                    break;
                                }
                            }
                            else if (answer1 == "3" || answer1 == "three")
                            {
                                bool success = false;
                                if (player.Inventory.Count > 0)
                                {
                                    Console.WriteLine("Which item in your pack do you wish to use?");
                                    int g = 1;
                                    foreach (Item item in player.Inventory)
                                    {
                                        Console.WriteLine($"[{g}] {item.Name}");
                                        g++;
                                    }
                                    Item chosenItem = null;
                                    while (true)
                                    {
                                        string reply = Console.ReadLine().Trim().ToLower();

                                        try
                                        {
                                            int reply1 = int.Parse(reply) - 1;
                                            try
                                            {
                                                chosenItem = player.Inventory[reply1];
                                                break;
                                            }
                                            catch { Console.WriteLine("Please enter a number corresponding to an item listed above!"); }

                                        }
                                        catch
                                        {
                                            foreach (Item item in player.Inventory)
                                            {
                                                if (item.Name == reply)
                                                {
                                                    chosenItem = item;

                                                }

                                            }
                                        }
                                        if (chosenItem == null)
                                        {
                                            Console.WriteLine($"{reply} could not be found in your backpack. Select another item.");
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    Console.WriteLine("What or who would you like to use it on?");
                                    
                                    
                                        g = 1;
                                        foreach(Item item in room.ItemList)
                                        {
                                            Console.WriteLine($"[{g}] {item.Name} in the room.");
                                            g++;
                                        }

                                        foreach (Item item in Monster.Items)
                                        {
                                            Console.WriteLine($"[{g}] The {Monster.Name}'s {item.Name}");
                                            g++;
                                        }
                                        foreach (Feature feature in room.FeatureList)
                                        {
                                            Console.WriteLine($"[{g}] {feature.Name} in the room.");
                                            g++;
                                        }
                                        Console.WriteLine($"[{g}] Yourself");
                                    if (playerWeapon.Name != "fists")
                                    {
                                        Console.WriteLine($"[{g+1}] The weapon in your hand.");
                                    }
                                        
                                    while (true)
                                    {
                                        string effectedItemString = Console.ReadLine().Trim().ToLower();
                                        try
                                        {
                                            int effectedItemNum = int.Parse(effectedItemString);
                                            if (effectedItemNum < 1 || effectedItemNum > g+1) { Console.WriteLine("Please select a number that corresponds with an item listed above."); }
                                            else if (playerWeapon.Name != "fists" && effectedItemNum == g + 1)
                                            {
                                                try
                                                {
                                                    foreach(Weapon w in player.WeaponInventory)
                                                    {
                                                        if (w.Equipped)
                                                        {
                                                            success = w.useItem(chosenItem, w, usesDictionaryItemItem);
                                                            Console.WriteLine($"You coat your {playerWeapon} in the {chosenItem}");
                                                            player.Inventory.Remove(chosenItem);
                                                            break;
                                                        }

                                                    }
                                                    break;
                                                }
                                                catch { Console.WriteLine($"You can't use {chosenItem} on that!"); break; }
                                            }
                                            else if ( effectedItemNum == g)
                                            {
                                                try
                                                {
                                                    success = chosenItem.useItem3(chosenItem, player, usesDictionaryItemChar);
                                                    
                                                    if (chosenItem.Name.Trim().ToLower() == "healing potion") {
                                                        Console.WriteLine("Liquid rejuvenation trickles down your parched throat. A warm feeling swells from your heart as you feel your wounds salved and your flesh knitting itself back together.");
                                                            }
                                                    else if (chosenItem.Name.Trim().ToLower() == "elixir of feline guile")
                                                    {
                                                        Console.WriteLine("You glug the potent elixir down. Your stomach ties itself in knots for a moment, before you feel your instincts and reflexes sharpen.");
                                                    }
                                                    else // luck potion grants boon to all weapons.
                                                    {
                                                        Console.WriteLine("The sweet liquid tastes like nirvana. It's effervescent body dances on your tongue and delights the senses. Suddenly you feel like anything is possible...");
                                                        playerWeapon.Boon = 10;
                                                    }
                                                    break;
                                                }
                                                catch { Console.WriteLine("Ermm...No. Upon reflection, you'd rather not use that on yourself.");break; }
                                                    
                                            }
                                            else if (effectedItemNum < g && effectedItemNum > room.ItemList.Count + Monster.Items.Count)
                                            {
                                                try
                                                {
                                                    success = chosenItem.useItem1(chosenItem, room.FeatureList[effectedItemNum - 1 - room.ItemList.Count - Monster.Items.Count], usesDictionaryItemFeature, player.Inventory, player.WeaponInventory);
                                                    break;
                                                }
                                                catch { Console.WriteLine($"You try using the {chosenItem.Name} on the {room.FeatureList[effectedItemNum - 1-room.ItemList.Count-Monster.Items.Count].Name}. You're not sure what results you were expecting to happen, but sufficed to say they haven't materialised...");break; }
                                            }
                                            else if( effectedItemNum > room.ItemList.Count)
                                            {
                                                try
                                                {
                                                    success = chosenItem.useItem(chosenItem, Monster.Items[effectedItemNum - 1 - room.ItemList.Count], usesDictionaryItemItem, null, null, room, player, holeInCeiling);
                                                    if (room.FeatureList.Contains(holeInCeiling)) 
                                                    {
                                                        Console.WriteLine(jinxedMisses[9]);
                                                        Monster.Stamina -= 9999;
                                                    }
                                                    break;
                                                }
                                                catch { Console.WriteLine($"You try using the {chosenItem.Name} on the {Monster.Items[effectedItemNum - 1-room.ItemList.Count].Name}. You're not sure what results you were expecting to happen, but sufficed to say they haven't materialised..."); break; }
                                            }
                                            else
                                            {
                                                try
                                                {
                                                    success = chosenItem.useItem(chosenItem, room.ItemList[effectedItemNum - 1], usesDictionaryItemItem, null, null, room, player, holeInCeiling);
                                                    if (room.FeatureList.Contains(holeInCeiling))
                                                    {
                                                        Console.WriteLine(jinxedMisses[9]);
                                                        Monster.Stamina -= 9999;
                                                    }
                                                    break;
                                                    break;
                                                }
                                                catch { Console.WriteLine($"You try using the {chosenItem.Name} on the {room.ItemList[effectedItemNum -1].Name}. You're not sure what results you were expecting to happen, but sufficed to say they haven't materialised...");break; }
                                            }
                                        }
                                        catch { Console.WriteLine("Please enter the number corresponding to the list above!"); }
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("You've no items in your backpack!");
                                }
                                if (success && !room.FeatureList.Contains(holeInCeiling))
                                {
                                    Console.WriteLine($"\nIt's not long after your actions take effect before the {Monster.Name} attacks you!");
                                    break;
                                }
                                else if (!success && !room.FeatureList.Contains(holeInCeiling))
                                {
                                    Console.WriteLine($"\nYour actions have only given the {Monster.Name} the opportunity to attack again!");
                                    break;
                                }
                                else { break; }
                            }
                                
                                    
                                   
                            else if (answer1 == "4" || answer1 == "four")
                            {
                                Console.WriteLine($"The {Monster.Name} closes in for another vicious attack!");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("ERROR! Please answer either '1', '2', '3' or '4'.");
                                continue;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter either 'yes' or 'no'.");
                        continue;
                    }
                    break;
                }
                turn++;
                continue;
            }
            if (Player.Stamina > 0)
            {
                Console.WriteLine("Congratulations! You've slain the monster!");
                return true;
            }
            else
            {
                Console.WriteLine($"The {Monster.Name}'s last attack proves fatal. You collapse in shameful defeat, a trickle of blood running from your mouth as your limp body drops to its knees. The {Monster.Name} has proven too much for you. Your adventure ends here...");
                return false;
            }
        }
        //special rules
        //streamlined battle rounds
        //special moves dependent on weapon and skill
        //special messages  misses skill > oppSkill skill < oppSkill and skill = oppSkill
    }
}

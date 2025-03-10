using System;
using System.Media;
using System.Linq;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player Player;
        private Room CurrentRoom;
        private bool Playing;

        public Game(Player player, Room startingRoom)
        {
            Player = player;
            CurrentRoom = startingRoom;
            Playing = true;

        }
        public void Start()
        {
            // Basic game loop.
            while (Playing)
            {
                TakeAction();
            }
            if (!Playing)
            {
                Console.WriteLine("Game Over");
            }
        }
        // Method that enables the user to interract with the game environment.
        private void TakeAction()
        {
            // Displays the room description.
            Console.WriteLine($"\n{CurrentRoom.GetDescription()}");
            // Calculates and displays the player's available actions.
            string actions = "\nActions: \nM) Menu";
            if (CurrentRoom.Monster == null)
            {
                if (CurrentRoom.Potion != null)
                {
                    actions += $"\nP) Take {CurrentRoom.Potion.Name}";
                }
                if (CurrentRoom.Weapon != null)
                {
                    actions += $"\nW) Take {CurrentRoom.Weapon.Name}";
                }
                actions += "\nR) Explore a new room";
            }
            else
            {
                actions += $"\nA) Attack {CurrentRoom.Monster.Name}";
            }
            Console.WriteLine(actions);
            // Asks for and validates user input. While true loop until a valid input is given.
            while (true)
            {
                Console.Write(">");
                string userChoice = Console.ReadLine().ToUpper();
                if (userChoice == "P" && CurrentRoom.Potion != null)
                {
                    Player.PlayerInventory.AddPotion(CurrentRoom.Potion);
                    Console.WriteLine($"You take the {CurrentRoom.Potion.Name}.");
                    CurrentRoom.RemovePotion();
                    break;
                }
                else if (userChoice == "W" && CurrentRoom.Weapon != null)
                {
                    Player.PlayerInventory.AddWeapon(CurrentRoom.Weapon);
                    Console.WriteLine($"You take the {CurrentRoom.Weapon.Name}.");
                    CurrentRoom.RemoveWeapon();
                    break;
                }
                else if (userChoice == "A" && CurrentRoom.Monster != null)
                {
                    FightMonster(CurrentRoom.Monster);
                    break;
                }
                else if (userChoice == "M")
                {
                    Player.Menu();
                    break;
                }
                else if (userChoice == "R")
                {
                    CurrentRoom = NewRoom();
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid input.");
                }
            }
            Console.Write("Press Enter to continue.");
            Console.ReadLine();
        }
        // Method to generate a new room. Randomly generates a monster, weapon, and potion, with the possibility of null values.
        private Room NewRoom()
        {
            Random random = new Random();
            Monster[] monsters = new Monster[]
            {
                new Monster("Goblin", 10, 5, 1),
                new Monster("Hobgoblin", 15, 8, 2),
                new Monster("Orc", 20, 10, 3),
                new Monster("Troll", 30, 15, 5),
                null
            };
            Weapon[] weapons = new Weapon[]
            {
                new Weapon("Dagger", 5),
                new Weapon("Sword", 10),
                new Weapon("Great Sword", 15),
                null
            };
            Monster monster = monsters[random.Next(0, monsters.Length)];
            Weapon weapon = weapons[random.Next(0, weapons.Length)];
            Potion potion = null;
            // Generates potion stats and name. Stats may be 0.
            string potionName = "";
            int potionHealthRestore = 0;
            int potionHealthBonus = 0;
            int potionDamageBonus = 0;
            if (random.Next(0, 2) == 0)
            {
                potionHealthRestore = random.Next(5, 16);
                potionName = $"Health({potionHealthRestore})";
            }
            if (random.Next(0, 6) == 0)
            {
                potionHealthBonus = random.Next(1, 6);
                if (potionHealthRestore != 0)
                {
                    potionName += ", ";
                }
                potionName += $"Vitality({potionHealthBonus})";
            }
            if (random.Next(0, 11) == 0)
            {
                potionDamageBonus = random.Next(1, 6);
                if (potionHealthRestore != 0 || potionHealthBonus != 0)
                {
                    potionName += ", ";
                }
                potionName += $"Strength({potionDamageBonus})";
            }
            // If all stats are 0, the potion remains null.
            if (!(potionHealthRestore == 0 && potionHealthBonus == 0 && potionDamageBonus == 0))
            {
                potionName += " Potion";
                potion = new Potion(potionName, potionDamageBonus, potionHealthRestore, potionHealthBonus);
            }
            return new Room(monster, potion, weapon);
        }
        // Method to make player and monster fight.
        private void FightMonster(Monster monster)
        {
            while (Player.IsAlive)
            {
                // If no weapon is equipped, the players's weapon is named bare hands.
                string weapon = "your ";
                if (Player.EquippedWeapon == null)
                {
                    weapon += "bare hands";
                }
                else
                {
                    weapon += Player.EquippedWeapon.Name;
                }
                Console.WriteLine($"\nYou attack the {monster.Name} with {weapon}!");
                Player.AttackTarget(CurrentRoom.Monster);
                Console.ReadKey(); //ReadKey used to segment fight sequence.
                if (CurrentRoom.Monster.IsAlive)
                {
                    Console.WriteLine($"\nThe {monster.Name} attacks you!");
                    CurrentRoom.Monster.AttackTarget(Player);
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine($"\nYou defeat the {monster.Name}!");
                    CurrentRoom.RemoveMonster();
                    break;
                }
            }
            if (!Player.IsAlive)
            {
                Console.WriteLine("\nYou have died.");
                Playing = false; // Main game loop ends if player dies.
            }
            else
            {
                Console.WriteLine($"You have {Player.CurrentHealth} health remaining.");
            }
        }
    }
}
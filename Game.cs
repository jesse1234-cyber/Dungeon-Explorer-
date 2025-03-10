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
            // Change the playing logic into true and populate the while loop
            string actions = "";
            while (Playing)
            {
                Console.WriteLine($"\n{CurrentRoom.GetDescription()}");
                actions = "\nActions: \nM) Menu";
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
                }
                else
                {
                    actions += $"\nA) Attack {CurrentRoom.Monster}";
                }
                Console.WriteLine(actions);
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
                    else
                    {
                        Console.WriteLine("Please enter a valid input.");
                    }   
                }
                Console.Write("Press Enter to continue.");
                Console.ReadLine();
            }
            if (Playing == false)
            {
                Console.WriteLine("Game Over");
            }
        }
        private void FightMonster(Monster monster)
        {
            while (Player.IsAlive)
            {
                Console.WriteLine($"You attack the {monster.Name}!");
                Player.AttackTarget(CurrentRoom.Monster);
                Console.ReadKey();
                if (CurrentRoom.Monster.IsAlive)
                {
                    Console.WriteLine($"The {monster.Name} attacks you!");
                    CurrentRoom.Monster.AttackTarget(Player);
                }
                else
                {
                    Console.WriteLine($"You defeat the {monster.Name}!");
                    break;
                }
            }
            if (!Player.IsAlive)
            {
                Console.WriteLine("You have died.");
                Playing = false;
            }
            else
            {
                Console.WriteLine($"You have {Player.CurrentHealth} health remaining.");
            }
        }
    }
}
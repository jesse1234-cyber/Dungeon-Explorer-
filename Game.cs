﻿using System;
using System.Media;
using System.Threading;

namespace DungeonExplorer
{
    internal class Game
    {
        private string m_gameName;
        private Player m_player;
        private Room m_currentRoom;
        private int m_numberOfRooms;
        private Random m_random;
        

        public Game(string gameName, int amountOfRooms, Player player)
        {
            m_gameName = gameName;
            m_numberOfRooms = amountOfRooms;
            m_player = player;
            // Initialize the game with one room and one player
            m_random = new Random();
        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            int roomNumber = 0;
            GameStartDisplay();
            m_currentRoom = CreateMonsterRoom();
            while (roomNumber < m_numberOfRooms)
            {
                // Let's create a game where the player needs to fight monsters in multiple rooms before completing the game to find a treasure in the final room
                // Each room has one monster which the player much fight before the door to the next room is unlocked
                // The player can pick up different types of weapons- these will affect his damage to the monster
                // The player must also manage their health bar, the monster can defend against attacks
                m_currentRoom.WelcomePlayer(roomNumber);
                int decision = m_player.GetDecision();
                if (decision == 0)
                {
                    //Player wants to view inventory
                    m_player.ViewInventory();
                }
                else if (decision == 1)
                {
                    //player has chosen to change their equipped item
                    int weaponChosen = m_player.ShowWeaponsInInventory();
                    m_player.EquipDifferentWeapon(weaponChosen);
                }
                else if (decision == 2)
                {
                    //player has chosen to pickup a weapon
                    if (m_player.GetTotalItemsInInventory() == m_player.maxInventorySpace)
                    {
                        Console.WriteLine("Your inventory is full, you may not collect any more weapons");
                    }
                    else
                    {
                        m_player.PickUpWeapon(m_currentRoom.WeaponInTheRoom);
                        m_currentRoom.WeaponPickedUp();
                    }
                }
                else if (decision == 3)
                {
                    //Player wants to fight
                    PlayerFightsMonster(m_player, m_currentRoom.Monster, m_currentRoom);
                }
                else if (decision == 4)
                {
                    //Retreat and heal-
                    int healthRecovered = m_player.MaxHealth - m_player.Health;
                    m_player.Health = m_player.MaxHealth;
                    Console.WriteLine($"\nYou have stepped back and regained {healthRecovered} health");
                }
                else if (decision == 5)
                {
                    //Player wants to goes to next room
                    if (NextRoom(m_currentRoom))
                    {
                        roomNumber += 1;
                        m_currentRoom = CreateMonsterRoom();
                    }
                }

                
                Thread.Sleep(5000);
                ClearConsole();
            }
            // Once the player has defeated all of the rooms, the last room will have the treasure
            // When the player retrieves the loot they have won the game
            FinishGame();
            return;
        }
        public void ClearConsole()
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J");
            return;
        }
        public void GameStartDisplay()
        {
            ClearConsole();
            Console.WriteLine($"Welcome to {m_gameName}");
            Console.WriteLine($"You must battle your way through each room. In each room you will have to defeat a monster who will have the the key to unlock the door!");
            Console.WriteLine("Press any key to start the game. . .");
            Console.ReadKey();
            ClearConsole();
            return;
        }
        public Room CreateMonsterRoom(string roomName = "", string roomDescription = "", int monsterHealth = 100, int monsterDamage = 20)
        {
            Monster currentMonster = new Monster(monsterHealth, monsterDamage);
            int roomX = m_random.Next(5, 12) + 2; //Adding 2 so that the walls inside are accounted for
            int roomY = m_random.Next(4, 10) + 2;
            int[] roomDimensions = new int[2] { roomX, roomY }; //This should be viewed as room area, we add +2 to each axis to give room for walls
            int doorPosition = m_random.Next(5, roomX) - 2; // The door is always placed at the top of the room. Door Position controls the horizontal position
            int monsterX = m_random.Next(1, roomX - 2); //monsterX can take the value that the room's x could be
            int monsterY = m_random.Next(3, roomY - 2); //monsterY must be at least 2 away from the bottom most wall
            //monsterCoord and treasureCoord assume that the bottom left tile is at (0,0)
            int[] monsterCoords = new int[2] { monsterX, monsterY };
            int randomDamage = m_random.Next(35, 70);
            Weapon weapon = new Weapon(randomDamage);
            if (roomName != "" && roomDescription != "")
            {
                return new Room(roomName, roomDescription, roomDimensions, doorPosition, currentMonster, monsterCoords);
            }
            return new Room(roomDimensions, doorPosition, currentMonster, monsterCoords, weapon);
        }
        public bool NextRoom(Room room)
        {
            if (room.DoorIsLocked == false)
            {
                Console.WriteLine("The door is unlocked. You proceed to the next room. . .");
                return true;
            }
            Console.WriteLine("The door is locked! Have you defeated the monster?");
            return false;
        }
        public void PlayerFightsMonster(Player player, Monster monster, Room room)
        {
            int playerAttackDamage = player.GetAttackDamage();
            monster.Health -= playerAttackDamage;
            int monsterAttackDamage = monster.GetAttackDamage();
            player.Health -= monsterAttackDamage;
            if (player.Health <= 0)
            {
                Console.WriteLine($"The monster has killed you! You took {monsterAttackDamage} damage. Game Over");
                Environment.Exit(1);
            }
            else if (monster.Health <= 0)
            {
                Console.WriteLine($"You have killed the monster! You did {playerAttackDamage} damage. Congratulations!");
                room.Monster = null;
                room.DoorIsLocked = false;
            }
            else
            {
                Console.WriteLine($"You have hit the monster for {playerAttackDamage} damage. The monster now has {monster.Health}/{monster.MaxHealth}");
                Console.WriteLine($"The monster has hit you for {monsterAttackDamage} damage. You now have {player.Health}/{player.MaxHealth}");
            }
            return;
        }
        public void FinishGame()
        {
            Console.WriteLine("Congratulations. You have won! Here is your treasure");
            return;
        }
    }
}
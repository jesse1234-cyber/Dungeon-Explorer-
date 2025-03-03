using System;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using DungeonExplorer;

namespace DungeonExplorer
{
    public class Game_commands
    {
        public void ClearTerminal()
        {
            Console.Clear();
        }
        public bool Choice(string message, string choice1, string choice2)
        {
            Console.Write(message);
            while (true)
            {
                string choices = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(choices))
                {
                    Console.WriteLine("Input cannot be Empty.");
                    continue;
                }

                if (choices.Equals(choice1, StringComparison.OrdinalIgnoreCase)) return true;
                if (choices.Equals(choice2, StringComparison.OrdinalIgnoreCase)) return false;

                Console.WriteLine($"Invalid choice, Please select {choice1} or {choice2}");
            }
        }
        public bool Endgame()
        {
            return Choice("(Y/N) Would you like to replay?", "Y", "N");
        }
    }
    public class Intro
    {
        private Game_commands _Game_commands;

        public Intro()
        {
            _Game_commands = new Game_commands();
        }
        public void Print(string Info)
        {
            Console.Write(Info);
        }

        // A simple method that utilizes Console.Write, for the letter by letter typing effect with a fractional delay depending on length of the text
        public void PrintLetterByLetter(string info, int delay)
        {
            foreach (char c in info)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
        }
        /* Creating a Display intro method that will utilize methods such as PrintLetterByLetter, we are also using thread.sleep for short delay's to allow
         * the user adequate time to read along with the story, and we will also be using _clear.Terminal For a higher quality reading experiance,*/
        public void Displayintro()
        {
            PrintLetterByLetter("Hello.", 100);
            Thread.Sleep(1000);

            Print(".");
            Thread.Sleep(1000);

            PrintLetterByLetter(". *You whisper quietly*", 50);
            Thread.Sleep(1000);

            _Game_commands.ClearTerminal();
            Thread.Sleep(2000);
            PrintLetterByLetter("*You hear a calm swoosh, a blazing tourch dimly lights up the room*", 50);
            Thread.Sleep(2000);

            _Game_commands.ClearTerminal();
            PrintLetterByLetter("*You look down and are met with a pair of heavy handcuffs, however they're no longer attatched to your wrists*", 50);
            Thread.Sleep(2000);

            _Game_commands.ClearTerminal();
            PrintLetterByLetter("*You turn around and find yourself facing a wooden door.*", 50);
            Thread.Sleep(2000);

            _Game_commands.ClearTerminal();
            PrintLetterByLetter("You have a choice to make:\n\n", 50);
            PrintLetterByLetter("(1) Exit through the wooden door\n", 50);
            PrintLetterByLetter("(2) Explore the Dungeon...\n\n", 50);
        }

        public bool YouHaveAChoice()
        {
            return _Game_commands.Choice("Make your choice: ", "1", "2");    
        }
        public bool HandleYouHaveAChoice()
        {
            bool choice = YouHaveAChoice();

            if (choice)
            {
                PrintLetterByLetter("Logic", 50);
                return false;
            }
            else
            {
                _Game_commands.ClearTerminal();
                PrintLetterByLetter("You choose to try out the wooden door to find a cobbled stair case leading to the surface, you swifly make your exit.\n", 50);
                Thread.Sleep(500);
                PrintLetterByLetter("did you win or lose? that is up to your own philosophy of the term 'winning'.\n\n", 50);
                PrintLetterByLetter("The End.\n\n", 300);
                PrintLetterByLetter("Your trait: 'The Reluctant Adventurer'", 50);
                return _Game_commands.Endgame();
            }
        }
    }

    internal class Game
    {
        private Player player;
        private Room currentRoom;
        private Intro intro;
        private Game_commands _game_Commands;

        public Game()
        {
            _game_Commands = new Game_commands();
            intro = new Intro();
        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            while (playing)
            {
                intro.Displayintro();
                bool continueplaying = intro.HandleYouHaveAChoice();
                playing = intro.HandleYouHaveAChoice();
                {
                    if (playing)
                    {
                        _game_Commands.ClearTerminal();
                    }
                }
            }
        }
    }
}
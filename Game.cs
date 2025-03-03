using System;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using DungeonExplorer;

namespace DungeonExplorer
{
    // User quality of life terminal clear
    public class Game_commands
    {
        public void Clear()
        {
            Console.Clear();
        }
        public bool Choice(string choice1, string choice2)
        {
            while (true)
            {
                string choices = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(choices))
                {
                    Console.WriteLine("Input cannot be Empty.");
                    continue;
                }

                switch (choices.ToLower())
                {
                    case var input when input == choice1.ToUpper(): return false;
                    case var input when input == choice2.ToUpper(): return true;

                    default:
                        Console.WriteLine($"Invalid choice, Please select {choice1} or {choice2}");
                        break;
                }
            }
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

            _Game_commands.Clear();
            Thread.Sleep(2000);
            PrintLetterByLetter("*You hear a calm swoosh, a blazing tourch dimly lights up the room*", 50);
            Thread.Sleep(2000);

            _Game_commands.Clear();
            PrintLetterByLetter("*You look down and are met with a pair of heavy handcuffs, however they're no longer attatched to your wrists*", 50);
            Thread.Sleep(2000);

            _Game_commands.Clear();
            PrintLetterByLetter("*You turn around and find yourself facing a wooden door.*", 50);
            Thread.Sleep(2000);

            _Game_commands.Clear();
            PrintLetterByLetter("You have a choice to make:\n\n", 50);
            PrintLetterByLetter("(1) Exit through the wooden door\n", 50);
            PrintLetterByLetter("(2) Explore the Dungeon...\n\n", 50);
            PrintLetterByLetter("Make your choice: ", 50);
        }

        public bool YouHaveAChoice()
        {
            return _Game_commands.Choice("1", "2");    
        }
        public void HandleYouHaveAChoice()
        {
            bool choice = YouHaveAChoice();

            if (choice)
            {
                PrintLetterByLetter("Logic", 50);
            }
            else
            {
                _Game_commands.Clear();
                PrintLetterByLetter("You choose to try out the wooden door to find a cobbled stair case leading to the surface, you swifly make your exit.\n", 50);
                Thread.Sleep(500);
                PrintLetterByLetter("did you win or lose? that is up to your own philosophy of the term 'winning'.\n\n", 50);
                PrintLetterByLetter("The End.\n\n", 300);
                PrintLetterByLetter("Your trait: 'The Reluctant Adventurer'", 50);
            }
        }
    }

    internal class Game
    {
        private Player player;
        private Room currentRoom;
        private Intro intro;

        public Game()
        {
            intro = new Intro();
        }
        public void Start()
        {
            // Change the playing logic into true and populate the while loop
            bool playing = true;
            while (playing)
            {
                intro.Displayintro();
                intro.HandleYouHaveAChoice();
                playing = false;
            }
        }
    }
}
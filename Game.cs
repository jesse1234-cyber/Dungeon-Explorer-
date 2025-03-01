using System;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using DungeonExplorer;

namespace DungeonExplorer
{
    // User quality of life terminal clear
    public class Clear
    {
        public void Terminal()
        {
            Console.Clear();
        }
    }
    public class Intro
    {
        private Clear _clear;

        public Intro()
        {
            _clear = new Clear();
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

            _clear.Terminal();
            Thread.Sleep(2000);
            PrintLetterByLetter("*You hear a calm swoosh, a blazing tourch dimly lights up the room*", 50);
            Thread.Sleep(2000);

            _clear.Terminal();
            PrintLetterByLetter("*You look down and are met with a pair of heavy handcuffs, however they're no longer attatched to your wrists*", 50);
            Thread.Sleep(2000);

            _clear.Terminal();
            PrintLetterByLetter("*You turn around and find yourself facing a wooden door.*", 50);
            Thread.Sleep(2000);

            _clear.Terminal();
            PrintLetterByLetter("You have a choice to make:\n\n", 50);
            PrintLetterByLetter("(1) Exit through the wooden door\n", 50);
            PrintLetterByLetter("(2) Explore the Dungeon...\n\n", 50);
            PrintLetterByLetter("Make your choice: ", 50);
        }

        public bool YouHaveAchoice()
        {
            while (true) {
                string choices = Console.ReadLine();

                switch (choices)
                {
                    case "1": return false;

                    case "2": return true;

                    default:
                        Console.WriteLine("Invalid choice, Please select 1 or 2");
                        break;
        public void YouHaveAChoiceOutcome()
        {

        }
                }   
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
                intro.YouHaveAchoice();
                playing = false;
            }
        }
    }
}
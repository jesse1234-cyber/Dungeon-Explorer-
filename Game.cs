using System;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using DungeonExplorer;

namespace DungeonExplorer
{
    public class Intro
    {
        public void Print(string text)
        {
            Console.WriteLine(text);
        }

        public void Showintro()
        {
            Print("Hello.");
            Thread.Sleep(1000);
            Print("Hello..");
            Thread.Sleep(1000);
            Print("Hello...");
            Thread.Sleep(1000);
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
                intro.Showintro();
                playing = false;
            }
        }
    }
}
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
            int attempt = 1;
            while (true) 
            {
                if (attempt > 1)
                {
                    Console.WriteLine("\x1b[3J");
                    Console.Clear();
                    Console.WriteLine("Would you like to play again?");
                    while (true)
                    {
                        string nextAnswer = Console.ReadLine().Trim().ToLower();
                        if (nextAnswer == "yes" || nextAnswer == "y")
                        {

                            break;

                        }
                        else if (nextAnswer == "no" || nextAnswer == "n")
                        {
                            Console.WriteLine("Thanks for playing!");
                            System.Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("Please enter 'yes' or 'no'");

                        }
                    }
                }
                Game CurseBreaker = new Game($"CurseBreaker ~ game {attempt}");
                CurseBreaker.Start();
                attempt++;
            }
        }
        
        
        

        
        
        
    }
}

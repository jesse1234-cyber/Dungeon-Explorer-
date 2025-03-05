using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
namespace DungeonCrawler
{
    /// <summary>
    /// Dice is a class that has one attribute only, namely the number of its
    /// faces. It's single function, Roll, produces a random integer from 1 to
    /// the number of faces it has. Throughout my code these virtual dice are typically
    /// labelled Dx where x stands for the number of its faces, so D6 or D20 for example. 
    /// Dice form the basis for combat and a lot of other random events in the game. 
    /// They are also important in character creation.
    /// </summary>
    public class Dice
    {
        int faces { get; set; }
        public Dice(int face)
        {
            faces = face;
        }
        public int Roll(Dice dice)
        {
            var random = new Random();
            int rollResult = random.Next(1, faces + 1);
            return rollResult;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
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

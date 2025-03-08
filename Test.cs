using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DungeonExplorer
{
    class GameTests
    {
        Room roomTest = new Room();
        Player playerTest = new Player();
        Game gameTest = new Game();

        public void RunTests(bool test)
        {
            Debug.Assert(test, "Testing Failed...");
        }
    }
}

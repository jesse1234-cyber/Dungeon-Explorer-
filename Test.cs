using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DungeonExplorer
{
    class GameTests
    {


        public void RunTests(bool test)
        {
            Debug.Assert(test, "Testing Failed...");
        }
    }
}

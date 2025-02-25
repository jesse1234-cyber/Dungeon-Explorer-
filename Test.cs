using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    class Test
    {
        
        public Test()
        {

        }
        public void TestCase(bool testing)
        {
            Debug.Assert(testing, "Test failed");
        }
    }
}

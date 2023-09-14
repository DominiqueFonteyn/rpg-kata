using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rpg.Tests
{
    public class PositionTest
    {
        [Fact]
        public void DistanceCalculation_Correct()
        {
            var pos1 = new Position {x = 1};
            var pos2 = new Position { x = -123 };
            Assert.Equal(124, pos1.DistanceTo(pos2));
        }
    }
}

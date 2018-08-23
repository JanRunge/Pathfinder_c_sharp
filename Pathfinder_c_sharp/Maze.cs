using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinder_c_sharp
{
    public class Maze
    {
        public int?[][] Coords;
        public int[][] startingPoints;
        public int[] endpoint;
        public Maze(int?[][] Board, int[][]startingPoints, int[] endpoint)
        {
            this.Coords = Board;
            this.startingPoints = startingPoints;
            this.endpoint = endpoint;
        }
    }
}

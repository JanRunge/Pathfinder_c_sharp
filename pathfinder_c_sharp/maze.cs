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
        public void reset()
        {
            for (int i = 0; i <Coords.Length; i++)
            {
                for (int k = 0; k < Coords[i].Length; k++)
                {
                    if (Coords[i][k] > 0)
                    {
                        Coords[i][k] = null;
                    }
                }
            }
        }
    }
}

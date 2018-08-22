using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pathfinder_c_sharp
{
    class Solver
    {
        static List<int[]> currentFields;//All Fields, that were filled with numbers last run
        public Maze currentMaze;
        public Form1 myForm;
        public Solver(Form1 form)
        {
            myForm = form;
        }
        public void getBoard(int sizeX, int sizeY, int Density)
        {

            int amount_startingpoints=3;
            int[][] startingpoints = new int[amount_startingpoints][];
            int?[][] Board = new int?[sizeX][];
            Random ran = new Random();
            Maze currentMaze=new Maze(Board, startingpoints);
            while (!solvable(currentMaze))
            {
                for (int i = 0; i < Board.Length; i++)
                {

                    Board[i] = new int?[sizeY];
                    for (int k = 0; k < Board[i].Length; k++)
                    {
                        if (k == 0 || k == sizeY || i == 0 || i == sizeX)
                        {
                            Board[i][k] = 0;//ostacle/wall
                        }
                        else
                        {
                            if (ran.Next(1, 101) - Density > 0)
                            {
                                Board[i][k] = null;//unoccupied
                            }
                            else
                            {
                                Board[i][k] = 0;//ostacle/wall
                            }
                        }


                    }
                }
                currentFields.Clear();
                for (int i = 0; i < amount_startingpoints; i++)
                {
                    startingpoints[i] = new int[] { 0, ran.Next(1 + (((sizeY - 1) / amount_startingpoints) * (i - 1)), ((sizeY - 1) / amount_startingpoints) * i) };
                    currentFields.Add(new int[] { startingpoints[i][0], startingpoints[i][1] });
                    Board[startingpoints[i][0]][startingpoints[i][1]] = 1;
                }
                
                currentMaze = new Maze(Board, startingpoints);
            }
            this.currentMaze = currentMaze;
            myForm.showMaze(currentMaze);
        }
        private bool solvable(Maze i_maze)
        {
            if (i_maze.Coords==null || i_maze.Coords[0]==null || i_maze.Coords[0][0] != 0)//Maze doesnt have limiting walls
            {
                return false;
            }
            return true;
        }
        
    }
}

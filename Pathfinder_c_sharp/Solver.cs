using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

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
            int[] endpoint = new int[2];
            Random ran = new Random();
            Maze currentMaze=new Maze(Board, startingpoints, endpoint);
            currentFields = new List<int[]>();
            while (!solvable(currentMaze))
            {
                for (int i = 0; i < Board.Length; i++)
                {

                    Board[i] = new int?[sizeY];
                    for (int k = 0; k < Board[i].Length; k++)
                    {
                        if (k == 0 || k == sizeY-1 || i == 0 || i == sizeX-1)
                        {
                            Board[i][k] = 0;//ostacle/wall
                        }
                        else
                        {
                            if (k == 1 || k == sizeY - 2 || i == 1 || i == sizeX - 2)
                            {
                                Board[i][k] = null;//unoccupied
                            }else if (ran.Next(1, 101) - Density > 0)
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
                    startingpoints[i] = new int[] { 1,
                                                    (int)Math.Round(
                                                                    (float) ran.Next(1 + (((sizeY - 1) / amount_startingpoints) * (i ))
                                                                                   ,((sizeY - 1) / amount_startingpoints) * (i+1)
                                                                                   )
                                                              
                                                              )
                                                    };
                    currentFields.Add(new int[] { startingpoints[i][0], startingpoints[i][1] });
                    Board[startingpoints[i][0]][startingpoints[i][1]] = 1;
                }
                endpoint = new int[] { Board.Length - 1, (int)Math.Round((float)ran.Next(1, Board[0].Length - 2)) };
                //Board[endpoint[0]][endpoint[1]] = null;
                currentMaze = new Maze(Board, startingpoints,endpoint);
            }
            this.currentMaze = currentMaze;
            myForm.showMaze(currentMaze);
        }
        private bool solvable(Maze i_maze)
        {
            return !(i_maze.Coords == null || i_maze.Coords[0] == null || i_maze.Coords[0][0] != 0);//Maze doesnt have limiting walls
           
        }
        public void solve(bool withAnimation, int delay)
        {
            bool solved = false;
            List<int[]> nextcurrentfields=new List<int[]>();
            while (!solved)
            {
                Console.WriteLine(currentFields.Count + " currentfields");

                foreach (int[] currentField in currentFields)//never happens because the ending is blocked, not null. if the ending should be null, it needs to lay inside of the maze, not on the edge
                {
                    if (currentField == currentMaze.endpoint)
                    {
                        solved = true;
                        break;

                    }
                    else
                    {
                        int nextVal = (int)currentMaze.Coords[currentField[0]][currentField[1]] + 1;
                        if (currentMaze.Coords[currentField[0] + 1][currentField[1]] == null)
                        {
                            currentMaze.Coords[currentField[0] + 1][currentField[1]] = nextVal;
                            nextcurrentfields.Add(new int[] { currentField[0]+1,currentField[1] });
                        }
                        if (currentMaze.Coords[currentField[0] - 1][currentField[1]] == null)
                        {
                            currentMaze.Coords[currentField[0] - 1][currentField[1]] = nextVal;
                            nextcurrentfields.Add(new int[] { currentField[0] - 1, currentField[1] });
                        }
                        if (currentMaze.Coords[currentField[0]][currentField[1] - 1] == null)
                        {
                            currentMaze.Coords[currentField[0]][currentField[1] - 1] = nextVal;
                            nextcurrentfields.Add(new int[] { currentField[0], currentField[1] - 1 });

                        }
                        if (currentMaze.Coords[currentField[0]][currentField[1] + 1] == null)
                        {
                            currentMaze.Coords[currentField[0]][currentField[1] + 1] = nextVal;
                            nextcurrentfields.Add(new int[] { currentField[0], currentField[1] + 1 });
                        }

                    }
                }
                if (withAnimation)
                {
                    myForm.showMaze(currentMaze);
                }
                Thread.Sleep(delay);
                currentFields.Clear();
                currentFields.AddRange( nextcurrentfields);
                nextcurrentfields.Clear();

            }
            
        }
        
    }
}

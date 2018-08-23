﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Pathfinder_c_sharp
{
    class Solver
    {
        private List<int[]> currentFields;//All Fields, that were filled with numbers last run
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
                            Board[i][k] = -1;//obstacle/wall
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
                                Board[i][k] = -1;//obstacle/wall
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
                    Board[startingpoints[i][0]][startingpoints[i][1]] = 0;
                }
                endpoint = new int[] { Board.Length - 1, (int)Math.Round((float)ran.Next(1, Board[0].Length - 2)) };
                Board[endpoint[0]][endpoint[1]] = -2;
                currentMaze = new Maze(Board, startingpoints,endpoint);
            }
            this.currentMaze = new Maze(Board, startingpoints, endpoint);
            myForm.showMaze(currentMaze);
        }
        private bool solvable(Maze i_maze)
        {
            if (i_maze.Coords == null || i_maze.Coords[0] == null) {
                return false;
            }
            else
            {
                List<int[]> currentFields=new List<int[]>();
                currentFields.AddRange(this.currentFields);
                bool solved = false;
                List<int[]> nextcurrentfields = new List<int[]>();
                while (!solved)
                {
                    Console.WriteLine(currentFields.Count + " currentfields");
                    if (currentFields.Count == 0)
                    {
                        solved = false;
                        break;
                        
                    }
                    foreach (int[] currentField in currentFields)//never happens because the ending is blocked, not null. if the ending should be null, it needs to lay inside of the maze, not on the edge
                    {
                        if (i_maze.Coords[currentField[0] + 1][currentField[1]] == -2)
                        {
                            solved = true;
                            break;

                        }
                        else
                        {
                            int nextVal = (int)i_maze.Coords[currentField[0]][currentField[1]] + 1;
                            if (i_maze.Coords[currentField[0] + 1][currentField[1]] == null)
                            {
                                i_maze.Coords[currentField[0] + 1][currentField[1]] = nextVal;
                                nextcurrentfields.Add(new int[] { currentField[0] + 1, currentField[1] });
                            }
                            if (i_maze.Coords[currentField[0] - 1][currentField[1]] == null)
                            {
                                i_maze.Coords[currentField[0] - 1][currentField[1]] = nextVal;
                                nextcurrentfields.Add(new int[] { currentField[0] - 1, currentField[1] });
                            }
                            if (i_maze.Coords[currentField[0]][currentField[1] - 1] == null)
                            {
                                i_maze.Coords[currentField[0]][currentField[1] - 1] = nextVal;
                                nextcurrentfields.Add(new int[] { currentField[0], currentField[1] - 1 });

                            }
                            if (i_maze.Coords[currentField[0]][currentField[1] + 1] == null)
                            {
                                i_maze.Coords[currentField[0]][currentField[1] + 1] = nextVal;
                                nextcurrentfields.Add(new int[] { currentField[0], currentField[1] + 1 });
                            }

                        }
                    }
                    currentFields.Clear();
                    currentFields.AddRange(nextcurrentfields);
                    nextcurrentfields.Clear();

                }//while !solved
                //erst alle zahlen rauslöschen, dann returnen
                i_maze.reset();

                        return true;
            }
           
        }

        public void solve(bool withAnimation, int delay)
        {
            bool solved = false;
            List<int[]> nextcurrentfields=new List<int[]>();
            while (!solved)
            {
                Console.WriteLine(currentFields.Count + " currentfields");
                if (currentFields.Count == 0)
                {
                    throw new ArgumentException("Unsolvable Maze");
                }
                foreach (int[] currentField in currentFields)//never happens because the ending is blocked, not null. if the ending should be null, it needs to lay inside of the maze, not on the edge
                {
                    if (currentMaze.Coords[currentField[0] + 1][currentField[1]]==-2)
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
                    myForm.refreshMaze(currentMaze, nextcurrentfields);
                }
                Thread.Sleep(delay);
                currentFields.Clear();
                currentFields.AddRange( nextcurrentfields);
                nextcurrentfields.Clear();

            }//while !solved
            solved = false;

            List<int[]>  t= retrackRoute(currentMaze.endpoint[0], currentMaze.endpoint[1]);
            myForm.showRoute(t);

            

            
        }
        private List<int[]> retrackRoute(int x, int y)
        {
            Console.WriteLine("retrack "+ currentMaze.Coords[x][y]);

            int smallestnum=999999999;
            int[] smallestidx=new int[] { 0,0};
            List<int[]> t = new List<int[]>();
            if(currentMaze.Coords[x][y] > 0)
            {
                t.Add(new int[2] { x, y });
            }
            
            if (currentMaze.Coords[x][y] ==0)
            {
                return t;
            }
            List<int[]> neighbours = new List<int[]>();
            if (x > 0)
            {
                if(currentMaze.Coords[x-1][y] >=0 && currentMaze.Coords[x - 1][y] < smallestnum)
                {
                    smallestidx[0] = x - 1;
                    smallestidx[1] = y;
                    smallestnum = (int)currentMaze.Coords[x - 1][y];
                }
            }
            if (x+1<currentMaze.Coords.Length)
            {
                if (currentMaze.Coords[x + 1][y] >= 0 && currentMaze.Coords[x + 1][y] < smallestnum)
                {
                    smallestidx[0] = x + 1;
                    smallestidx[1] = y;
                    smallestnum = (int)currentMaze.Coords[x + 1][y];
                }
            }
            if (y > 0)
            {
                if (currentMaze.Coords[x ][y - 1]>=0 &&currentMaze.Coords[x][y - 1] < smallestnum)
                {
                    smallestidx[0] = x ;
                    smallestidx[1] = y - 1;
                    smallestnum = (int)currentMaze.Coords[x ][y - 1];
                }
            }
            if (y + 1 < currentMaze.Coords[0].Length)
            {
                if (currentMaze.Coords[x ][y + 1] >=0 && currentMaze.Coords[x][y + 1]  < smallestnum)
                {
                    smallestidx[0] = x ;
                    smallestidx[1] = y + 1;
                    smallestnum = (int)currentMaze.Coords[x][y + 1];
                }
            }
            t.AddRange(retrackRoute(smallestidx[0], smallestidx[1]));
            return t;




        }
        
    }
}

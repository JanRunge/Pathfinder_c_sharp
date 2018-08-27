using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Pathfinder_c_sharp
{
    public partial class Form1 : Form
    {
        private Thread myThread;
        Solver mySolver;
        public delegate void del(Maze i_maze);
        public bool stopSolvingASAP=false;
        public delegate void del2(Maze i_maze, List<int[]> changedFields);


        public delegate void del3(List<int[]> fields);

        

        public Form1()
        {
            InitializeComponent();
            mySolver = new Solver(this);
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        
        Rectangle[][] allRects;
        public void OnResize(EventArgs e)
        {
            
            showMaze(mySolver.currentMaze);
            base.OnResize(e);
        }
        public void showMaze(Maze i_maze)
        {
            Console.WriteLine("trying to show");
           
            if (this.InvokeRequired)
            {
                Console.WriteLine("invoking");
                del d = new del(showMaze);
                this.Invoke(d, new object[] { i_maze });
            }
            else
            {
                Console.WriteLine("showing tablelayout");
                    int step = 20; //distance between the rows and columns has to be >max(width,height)
                    int width = 20; //the width of the rectangle
                    int height = 20; //the height of the rectangle
                    int?[][] Board = i_maze.Coords;
                    allRects = new Rectangle[Board.Length][];
                    using (Graphics g = this.CreateGraphics())
                    {
                        g.Clear(SystemColors.Control); //Clear the draw area
                        using (Pen pen = new Pen(Color.Black, 2))
                        {
                            for (int i = 0; i < Board.Length; i++)
                            {
                                allRects[i] = new Rectangle[Board[0].Length];
                                for (int k = 0; k < Board[i].Length; k++)
                                {
                                    Rectangle rect = new Rectangle(new Point(300 + step * k, 5 + step * i), new Size(width, height));
                                    g.DrawRectangle(pen, rect);
                                    if (i_maze.endpoint[0] == i && i_maze.endpoint[1] == k)
                                    {
                                        g.FillRectangle(System.Drawing.Brushes.Red, rect);
                                    }
                                    else if (i_maze.Coords[i][k] == null)
                                    {
                                        g.FillRectangle(System.Drawing.Brushes.White, rect);
                                    }
                                    else if (i_maze.Coords[i][k] == -1)
                                    {
                                        g.FillRectangle(System.Drawing.Brushes.Black, rect);
                                    }
                                    else if (i_maze.Coords[i][k] == 0)
                                    {
                                        g.FillRectangle(System.Drawing.Brushes.LightGreen, rect);
                                    }
                                    allRects[i][k] = rect;
                                    g.DrawString(i_maze.Coords[i][k] + "", new Font("Arial", 5), new SolidBrush(Color.Black), rect);
                                }
                            }

                        }
                    
                }
            }
        }

        public void refreshMaze(Maze i_maze, List<int[]> changedFields)
        {
            if (this.InvokeRequired)
            {
                Console.WriteLine("invoking");
                del2 f = new del2(refreshMaze);
                this.Invoke(f, new object[] { i_maze, changedFields });
            }
            else
            {
                using (Graphics g = this.CreateGraphics())
                {
                    //g.Clear(SystemColors.Control); //Clear the draw area
                    using (Pen pen = new Pen(Color.White, 2))
                    {
                        foreach (int[] field in changedFields)
                        {
                            g.DrawString(i_maze.Coords[field[0]][field[1]] + "", new Font("Arial", 7), new SolidBrush(Color.Black), allRects[field[0]][field[1]]);
                        }
                    }
                }
            }
        }
        
        public void showRoute(List<int[]> fields)
        {
            if (this.InvokeRequired)
            {
                Console.WriteLine("invoking");
                del3 f = new del3(showRoute);
                this.Invoke(f, new object[] { fields });
            }
            else
            {
                using (Graphics g = this.CreateGraphics())
                {
                    foreach (int[] field in fields)
                    {
                        g.FillRectangle(System.Drawing.Brushes.LightBlue, allRects[field[0]][field[1]]);
                        g.DrawString(mySolver.currentMaze.Coords[field[0]][field[1]] + "", new Font("Arial", 7), new SolidBrush(Color.Black), allRects[field[0]][field[1]]);

                    }
                }
            }
        }
        private void buttonDefault_Click(object sender, EventArgs e)
        {
            textBoxSizeX.Text = 20 + "";
            textBoxSizeY.Text = 20 + "";
            textBoxDensity.Text = 20 + "";

        }
        private void buttonGenerate_Click(object sender, EventArgs e)
        {

            int density;
            int sizex;
            int sizey;
            int cnt_startingpoints;
            Int32.TryParse(textBoxDensity.Text, out density);
            Int32.TryParse(textBoxSizeX.Text, out sizey);//x and y need to be switched, i cant be fucked to fix that
            Int32.TryParse(textBoxSizeY.Text, out sizex);
            Int32.TryParse(textBoxStartingpoints.Text, out cnt_startingpoints);
            new Thread(delegate () {
                mySolver.getBoard(sizex, sizey, density, cnt_startingpoints);
            }).Start();
            panelStart.Visible = true;
            //this.tableLayoutPanel1.
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            stopSolvingASAP = false;
            bool animation = true;
            if (textBoxDelay.Text == "")
            {
                textBoxDelay.Text = 0+"";
            }
            int delay;
            Int32.TryParse(textBoxDelay.Text, out delay);
            if (delay == 0)
            {
                animation = false;
            }
            new Thread(delegate () {
                mySolver.solve(animation, delay);
            }).Start();



        }

        private void buttonRedraw_Click(object sender, EventArgs e)
        {
            showMaze(mySolver.currentMaze);

        }

        private void button1_Click(object sender, EventArgs e)//reset
        {
            this.stopSolvingASAP = true;
            mySolver.currentMaze.reset();
            showMaze(mySolver.currentMaze);

            mySolver.currentFields.Clear();
            mySolver.currentFields.AddRange(mySolver.currentMaze.startingPoints);
            
        }

        private void buttonStopSolving_Click(object sender, EventArgs e)
        {
            this.stopSolvingASAP = true;
        }

        private void textBoxStartingpoints_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

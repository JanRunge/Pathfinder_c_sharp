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
        public del handler;
        public Form1()
        {
            InitializeComponent();
            mySolver = new Solver(this);
            handler = showMaze;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {

            new Thread(delegate () {
                mySolver.getBoard(20, 20, 20);
            }).Start();



            //this.tableLayoutPanel1.
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
                using (Graphics g = this.CreateGraphics())
                {
                    g.Clear(SystemColors.Control); //Clear the draw area
                    using (Pen pen = new Pen(Color.White, 2))
                    {
                        for (int i = 0; i < Board.Length; i++)
                        {
                            for (int k = 0; k < Board[i].Length; k++)
                            {
                                Rectangle rect = new Rectangle(new Point(300 + step * k, 5 + step * i), new Size(width, height));
                                g.DrawRectangle(pen, rect);
                                if (i_maze.endpoint[0]==i&& i_maze.endpoint[1] ==k)
                                {
                                    g.FillRectangle(System.Drawing.Brushes.Red, rect);
                                }
                                else if (i_maze.Coords[i][k] == null)
                                {
                                    g.FillRectangle(System.Drawing.Brushes.White, rect);
                                }
                                else if (i_maze.Coords[i][k] == 0)
                                {
                                    g.FillRectangle(System.Drawing.Brushes.Black, rect);
                                }
                                else if (i_maze.Coords[i][k] == 1)
                                {
                                    g.FillRectangle(System.Drawing.Brushes.LightGreen, rect);
                                }
                                else
                                {
                                    g.FillRectangle(System.Drawing.Brushes.White, rect);
                                    g.DrawString(i_maze.Coords[i][k] + "", new Font("Arial", 5), new SolidBrush(Color.Black), rect);
                                }





                            }



                        }

                    }
                }




            }
        }

        private void buttonDefault_Click(object sender, EventArgs e)
        {

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            new Thread(delegate () {
                mySolver.solve(true, 1000);
            }).Start();
            
        }
    }
}

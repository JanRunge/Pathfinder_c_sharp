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
        public del handler ;
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
                mySolver.getBoard(20,20,20);
            }).Start();
            


            //this.tableLayoutPanel1.
        }
        public void showMaze(Maze i_maze)
        {
            Console.WriteLine("trying to show");
            /*this.tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.Visible = true;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            int percentPerCol =100/ i_maze.Coords.Length;//percentage of the table that each col occupies
            int percentPerRow = 100 / i_maze.Coords.Length;
            this.tableLayoutPanel1.RowCount = 0;
            this.tableLayoutPanel1.ColumnCount = 0;


            //print the given Maze
            int?[][] Board = i_maze.Coords;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, percentPerRow));
            for (int i = 0; i < Board.Length; i++)
            {
                this.tableLayoutPanel1.RowCount = this.tableLayoutPanel1.RowCount + 1;
                this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, percentPerRow));
                //neue spalte erstellen
            }
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percentPerCol));
            for (int k = 0; k < Board[0].Length; k++)
            {
                this.tableLayoutPanel1.ColumnCount = this.tableLayoutPanel1.ColumnCount + 1;
                this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percentPerCol));
            }

            if (this.InvokeRequired)
            {
                Console.WriteLine("invoking");
                del d = new del(showMaze);
                this.Invoke(d, new object[] { i_maze });
            }
            else
            {
                Console.WriteLine("showing tablelayout");
                this.Controls.Add(this.tableLayoutPanel1);
            }*/
            if (this.InvokeRequired)
            {
                Console.WriteLine("invoking");
                del d = new del(showMaze);
                this.Invoke(d, new object[] { i_maze });
            }
            else
            {
                Console.WriteLine("showing tablelayout");
                int step = 10; //distance between the rows and columns
                int width = 30; //the width of the rectangle
                int height = 30; //the height of the rectangle
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
                                if (i_maze.Coords[i][k] == null)
                                {
                                    Rectangle rect = new Rectangle(new Point(300 + step * k, 5 + step * i), new Size(width, height));
                                    g.DrawRectangle(pen, rect);
                                    g.FillRectangle(System.Drawing.Brushes.Red, rect);
                                }
                                else
                                {
                                    Rectangle rect = new Rectangle(new Point(300 + step * k, 5 + step * i), new Size(width, height));
                                    g.DrawRectangle(pen, rect);
                                    g.FillRectangle(System.Drawing.Brushes.Blue, rect);
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
    }
}

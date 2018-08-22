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
        public delegate void my_delegate(Maze i_maze);
        public my_delegate DelegateBoard= showMaze;
        public Form1()
        {
            InitializeComponent();
            mySolver = new Solver(this);
            //DelegateBoard = new my_delegate ();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {

            new Thread(delegate () {
                mySolver.getBoard(20,20,20);
            }).Start();
            

            this.tableLayoutPanel1.RowCount = this.tableLayoutPanel1.RowCount + 1;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent,10F));


            //this.tableLayoutPanel1.
        }
        public void showMaze(Maze i_maze)
        {
            this.tableLayoutPanel1 = new TableLayoutPanel();
            int percentPerCol =100/ i_maze.Coords.Length;//percentage of the table that each col occupies
            int percentPerRow = 100 / i_maze.Coords.Length;
            this.tableLayoutPanel1.RowCount = 0;
            this.tableLayoutPanel1.ColumnCount = 0;


            //print the given Maze
            int?[][] Board = i_maze.Coords;
            for (int i = 0; i < Board.Length; i++)
            {
                this.tableLayoutPanel1.RowCount = this.tableLayoutPanel1.RowCount + 1;
                this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, percentPerRow));
                //neue spalte erstellen
            }
            for (int k = 0; k < Board[0].Length; k++)
            {
                this.tableLayoutPanel1.ColumnCount = this.tableLayoutPanel1.ColumnCount + 1;
                this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, percentPerCol));
            }
            DelegateBoard(i_maze);
            this.Invoke(DelegateBoard);

        }
        public void showPanel()
        {
            Console.WriteLine("showing panel");
            this.Controls.Add(this.tableLayoutPanel1);
        }
        public void showPanel(Maze i_Maze)
        {
            Console.WriteLine("showing panel");
            this.Controls.Add(this.tableLayoutPanel1);
        }
    }
}

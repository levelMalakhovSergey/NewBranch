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

namespace WindowsFormsApp2
{


    public partial class Form1 : Form
    {
        public static Graphics gr;
        public Form1()
        {
            InitializeComponent();
            gr = Graphics.FromHwnd(this.Handle);
        }

        public static int[,] Figure = new int[3, 3];
        public static int[,] Map = new int[16, 16];
        public static int[,] MapTemp = new int[16, 16];
        public static int[,] MapHistore = new int[16, 16];
        public static int[,] MiniMash = new int[3, 3];

        public static void DrawMap(PictureBox[] pb)
        {

        }
        public static void DrawFigure(string value)
        {
            Lifeless life = new Lifeless();
            Dead dead = new Dead();
            if (value == "Korabl")
            {
                Figure[0, 0] = life.Lifeless; Figure[0, 1] = life.Lifeless; Figure[0, 2] = dead.Dead;
                Figure[1, 0] = life.Lifeless; Figure[1, 1] = dead.Dead; Figure[1, 2] = life.Lifeless;
                Figure[2, 0] = dead.Dead; Figure[2, 1] = life.Lifeless; Figure[2, 2] = life.Lifeless;

            }
            if (value == "Lodka")
            {
                Figure[0, 0] = dead.Dead; Figure[0, 1] = life.Lifeless; Figure[0, 2] = dead.Dead;
                Figure[1, 0] = life.Lifeless; Figure[1, 1] = dead.Dead; Figure[1, 2] = life.Lifeless;
                Figure[2, 0] = dead.Dead; Figure[2, 1] = life.Lifeless; Figure[2, 2] = life.Lifeless;
            }
            if (value == "Plus")
            {
                Figure[0, 0] = dead.Dead; Figure[0, 1] = life.Lifeless; Figure[0, 2] = life.Lifeless;
                Figure[1, 0] = dead.Dead; Figure[1, 1] = life.Lifeless; Figure[1, 2] = life.Lifeless;
                Figure[2, 0] = dead.Dead; Figure[2, 1] = life.Lifeless; Figure[2, 2] = life.Lifeless;
            }

            Map[7, 7] = Figure[0, 0]; Map[7, 8] = Figure[0, 1]; Map[7, 9] = Figure[0, 2];
            Map[8, 7] = Figure[1, 0]; Map[8, 8] = Figure[1, 1]; Map[8, 9] = Figure[1, 2];
            Map[9, 7] = Figure[2, 0]; Map[9, 8] = Figure[2, 1]; Map[9, 9] = Figure[2, 2];


        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBox1.Items.Add("Korabl");
            comboBox1.Items.Add("Lodka");
            comboBox1.Items.Add("Plus");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Lifeless life = new Lifeless();
            Dead dead = new Dead();
            int x = 0, y = 0;
            int count = 0;
            

            //We maked our map all dead
            DrawFigure(comboBox1.AccessibilityObject.Value);

            int countOfDead = 0;

            y = 0;
            x = 0;
            while (countOfDead !=Map.Length ||count!=40)
            {
                for (int i = 0; i < Map.GetLength(0); i++)
                {
                    for (int j = 0; j < Map.GetLength(1); j++)
                    {
                        if (Map[i, j] == dead.Dead)
                        {
                            MapTemp[i, j] = Map[i, j];
                        }
                        if (Map[i, j] == life.Lifeless)
                        {

                            int IMin = i - 1;
                            if (IMin == -1)
                            {
                                IMin = 15;
                            }
                            int IMax = i + 1;
                            if (IMin == 16)
                            {
                                IMin = 0;
                            }

                            int JMin = j - 1;
                            if (JMin == -1)
                            {
                                JMin = 15;
                            }
                            int JMax = j + 1;
                            if (JMin == 16)
                            {
                                JMin = 0;
                            }//Maked world like Ellipse
                            MiniMash[0, 0] = Map[IMin, JMin]; MiniMash[0, 1] = Map[i, JMin]; MiniMash[0, 2] = Map[IMax, JMin];
                            MiniMash[1, 0] = Map[IMin, j]; MiniMash[1, 1] = Map[i, j]; MiniMash[1, 2] = Map[IMax, j];
                            MiniMash[2, 0] = Map[IMin, JMax]; MiniMash[2, 1] = Map[i, JMax]; MiniMash[2, 2] = Map[IMax, JMax];
                            RewriteToSeconsArr.Checkking(MiniMash, ref MapTemp, i, j);

                        }
                        if (Map[i, j] == 0)
                        {
                            gr.DrawRectangle(Pens.Black, x, y, 10, 10);
                            gr.FillRectangle(Brushes.Yellow, x, y, 10, 10);

                        }
                        if (Map[i, j] == 1)
                        {
                            gr.DrawRectangle(Pens.Black, x, y, 10, 10);
                            gr.FillRectangle(Brushes.Red, x, y, 10, 10);
                        }

                        x += 10;

                    }
                    x = 0;
                    y = y + 10;
                    Thread.Sleep(100);
                }
                Map = MapTemp;
                //for (int i = 0; i < Map.GetLength(0); i++)
                //{
                //    for (int j = 0; j < Map.GetLength(1); j++)
                //    {
                //        if (MapTemp[i, j] == 0)
                //        {
                //            gr.FillRectangle(Brushes.Yellow, x, y, 10, 10);
                //            countOfDead++;
                //        }
                //        else
                //        {
                //            gr.FillRectangle(Brushes.Red, x, y, 10, 10);
                //        }

                //        x += 10;

                //    }
                //    x = 0;
                //    y = y + 10;
                //}
                y = 0;
                x = 0;
                Thread.Sleep(500);
                //gr.Clear(Color.Gray);
                for (int i = 0; i < Map.GetLength(0); i++)
                {
                    for (int j = 0; j < Map.GetLength(1); j++) 
                     {
                        if (Map[i,j]==1)
                        {
                            countOfDead++;
                        }
                    }

                }

                count++;
            }


        }


    }
}



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic___Tac___Toe_Game.Properties;

namespace Tic___Tac___Toe_Game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        enum enGameChoice { Player=1,Computer=2}

        enGameChoice Choice = enGameChoice.Player;

        enum enWinner
        {
               
            Player=1,
            Computer=2,
            Draw=3,
            InProgress=4
        
        };

        struct stGameStatues
        {
          public  int Playcount;
          public  enWinner winner;
        }

         stGameStatues GameStatues;
     
        

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color White = Color.FromArgb(255, 255, 255, 255);

            Pen GridDrawer = new Pen(White);
            GridDrawer.Width = 10;

            GridDrawer.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            GridDrawer.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            e.Graphics.DrawLine(GridDrawer, 400, 300, 940, 300);
           
            e.Graphics.DrawLine(GridDrawer, 400, 480, 940, 480);
            
            e.Graphics.DrawLine(GridDrawer, 580, 120, 580, 660);
           
            e.Graphics.DrawLine(GridDrawer, 760, 120, 760, 660);


        }

        bool SendValue(PictureBox pb1,PictureBox pb2,PictureBox pb3)
        {

            if (pb1.Tag.ToString() != "?" && pb1.Tag.ToString() == pb2.Tag.ToString()&&pb1.Tag.ToString() ==pb3.Tag.ToString()) 
            {

                pb1.BackColor = Color.GreenYellow;
                pb2.BackColor = Color.GreenYellow;
                pb3.BackColor = Color.GreenYellow;

                if (pb1.Tag.ToString()=="X")
                {
                    GameStatues.winner = enWinner.Player;
                    lbWinner.Text = "Player";
                    MessageBox.Show("Game Over", "Message box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pb1.Tag = PB2.Tag = PB3.Tag = "Won";
                    return true;


                }
                else
                {
                    GameStatues.winner = enWinner.Computer;
                    lbWinner.Text = "Computer";
                    MessageBox.Show("Game Over", "Message box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pb1.Tag = PB2.Tag = PB3.Tag = "Won";

                    return false;
                }
            
            }
            if (GameStatues.Playcount==9)
            {

                lbWinner.Text = "Draw";
                MessageBox.Show("Draw Time", "Message box", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
         
            return false;


        }
        void CheckWinner()
        {
            //Rows
           if( SendValue(PB1,PB2,PB3))
            {
                return;
            }


            if (SendValue(PB4, PB5, PB6))
            {
                return;
            }


            if (SendValue(PB7, PB8, PB9))
            {
                return;
            }

            //Cols
            if (SendValue(PB1, PB4, PB7))
            {
                return;
            }


            if (SendValue(PB2, PB5, PB8))
            {
                return;
            }


            if (SendValue(PB3, PB6, PB9))
            {
                return;
            }

            //diagonals
            if (SendValue(PB1, PB5, PB9))
            {
                return;
            }


            if (SendValue(PB3, PB5, PB7))
            {
                return;
            }



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        
             PictureBox PB = (PictureBox)sender;


             if (PB.Tag == "?")

             {
                 if (Choice == enGameChoice.Player)
                 {

                     PB.Image = Resources.X;
                     PB.Tag = "X";
                     lbTurn.Text = "Computer";
                     Choice = enGameChoice.Computer;
                    GameStatues.Playcount++;
                    CheckWinner();
                 }
                 else
                 {


                     PB.Image = Resources.O;
                     PB.Tag = "O";
                     lbTurn.Text = "Player ";
                     Choice = enGameChoice.Player;
                    GameStatues.Playcount++;
                    CheckWinner();
                 }


             }
            else
            {

                MessageBox.Show("Error Message", "Message box", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        void BackToDefaulf(PictureBox pb)
        {


            pb.Image= Resources.question_mark_96;
            pb.Tag = "?";
            pb.BackColor=Color.Transparent;


        }
         void BTRestartGame_Click(object sender, EventArgs e)
         {
           BackToDefaulf(PB1);
           BackToDefaulf(PB2);
           BackToDefaulf(PB3);
           BackToDefaulf(PB4);
           BackToDefaulf(PB5);
           BackToDefaulf(PB6);
           BackToDefaulf(PB7);
           BackToDefaulf(PB8);
           BackToDefaulf(PB9);

            GameStatues.Playcount = 0;
            GameStatues.winner = enWinner.InProgress;
            Choice = enGameChoice.Player;
            lbTurn.Text = "Player ";
            lbWinner.Text = "In Progress";
            

         }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {

            PictureBox PB = (PictureBox)sender;
                if(PB.Tag.ToString()=="Won")
                {
                 PB.BackColor = Color.Black;
                }

        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            PictureBox PB = (PictureBox)sender;
            if(lbWinner.Text=="Player"||lbWinner.Text=="Computer" || PB.BackColor == Color.GreenYellow)

                if (PB.Tag.ToString() == "Won")
                {
                    PB.BackColor = Color.GreenYellow;

                }



        }


    }



























}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_Barbut
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //instance, creating a "copy" of the class Random (on the right) on the RAM
        
        Random rnd = new Random();

        int oyuncuZar1;
        int oyuncuZar2;

        decimal bakiyeOyuncu1 = 500;
        decimal bakiyeOyuncu2 = 500;

        decimal ortaPuan;
        
              
        
        //THE GAME
        private void Form1_Load(object sender, EventArgs e)
        {
            btnOyuncuZar2.Enabled = false;
        }

        private void btnOyuncuZar1_Click(object sender, EventArgs e)
        {
            oyuncuZar1 = rnd.Next(1, 7);
            lblOyuncuZar1.Text = oyuncuZar1.ToString();
            btnOyuncuZar2.Enabled = true;
            btnOyuncuZar1.Enabled = false;
        }

        private void btnOyuncuZar2_Click(object sender, EventArgs e)
        {
            oyuncuZar2 = rnd.Next(1, 7);
            lblOyuncuZar2.Text = oyuncuZar2.ToString();

            if (oyuncuZar1 == oyuncuZar2)
            {
                lblSonuc.Text = "Tie";
            }
            else if(oyuncuZar1 > oyuncuZar2)
            {
                lblSonuc.Text = "Player 1 wins";
                bakiyeOyuncu1 += ortaPuan;
                lblOyuncu1.Text = bakiyeOyuncu1.ToString();
                ortaPuan = 0;
                lblOrtaPuan.Text = ortaPuan.ToString();
                
            }
            else
            {
                lblSonuc.Text = "Player 2 wins";
                bakiyeOyuncu2 += ortaPuan;
                lblOyuncu2.Text = bakiyeOyuncu2.ToString();
                ortaPuan = 0;
                lblOrtaPuan.Text = ortaPuan.ToString();
            }
            btnOyuncuZar2.Enabled = false;
            listBox1.Items.Add(lblSonuc.Text);

            //Stores the "yes" or "no" value returned from the messageboxbutton dialogue
            DialogResult result =  MessageBox.Show("Play again?", "Game over", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                btnOyuncuZar1.Enabled = true;
            }
            else
            {
                Application.Exit();
            }
        }


        //PLAYER 1
        private void btnOyuncu1Cek_Click(object sender, EventArgs e)
        {
            bakiyeOyuncu1 = Convert.ToDecimal(lblOyuncu1.Text) - nudOyuncu1Cek.Value;
            lblOyuncu1.Text = bakiyeOyuncu1.ToString();

            //Logging
            rtbOyuncu1.Text = nudOyuncu1Cek.Value.ToString() + " çekildi";

            if (nudOyuncu1Cek.Value >= bakiyeOyuncu1)
            {
                MessageBox.Show("You don't have that much");
            }

        }

        private void btnOyuncu1Yatir_Click(object sender, EventArgs e)
        {
            bakiyeOyuncu1 = Convert.ToDecimal(lblOyuncu1.Text) + nudOyuncu1Yatir.Value;
            lblOyuncu1.Text = bakiyeOyuncu1.ToString();

            //Logging
            rtbOyuncu1.Text = nudOyuncu1Yatir.Value.ToString() + " yatırıldı";

        }
       
        private void btnOyuncu1OrtayaYatir_Click_1(object sender, EventArgs e)
        {
            bakiyeOyuncu1 = bakiyeOyuncu1 - nudOyuncu1OrtayaYatir.Value;
            lblOyuncu1.Text = bakiyeOyuncu1.ToString();

            //Value that goes in the pot
            ortaPuan += nudOyuncu1OrtayaYatir.Value;
            lblOrtaPuan.Text = ortaPuan.ToString();

            //Logging
            rtbOyuncu1.Text = nudOyuncu1OrtayaYatir.Value.ToString() + " ortaya konuldu";


            if (nudOyuncu1OrtayaYatir.Value >= bakiyeOyuncu1) 
            {
                MessageBox.Show("Limit exceeded");
            }

            
        }
        
        //PLAYER 2

        private void btnOyuncu2Cek_Click(object sender, EventArgs e)
        {
            bakiyeOyuncu2 = Convert.ToDecimal(lblOyuncu2.Text) - nudOyuncu2Cek.Value;
            lblOyuncu2.Text = bakiyeOyuncu2.ToString();

            //Logging
            rtbOyuncu2.Text = nudOyuncu2Cek.Value.ToString() + " çekildi";

            if (nudOyuncu2Cek.Value >= bakiyeOyuncu2)
            {
                MessageBox.Show("You don't have that much");
            }
        }

        private void btnOyuncu2Yatir_Click(object sender, EventArgs e)
        {
            bakiyeOyuncu2 = Convert.ToDecimal(lblOyuncu2.Text) + nudOyuncu2Yatir.Value;
            lblOyuncu2.Text = bakiyeOyuncu2.ToString();

            //Logging
            rtbOyuncu2.Text = nudOyuncu2Yatir.Value.ToString() + " yatırıldı";
        }

        private void btnOyuncu2OrtayaYatir_Click(object sender, EventArgs e)
        {
            bakiyeOyuncu2 = bakiyeOyuncu2 - nudOyuncu2OrtayaYatir.Value;
            lblOyuncu2.Text = bakiyeOyuncu2.ToString();

            //Value that goes in the pot
            ortaPuan += nudOyuncu2OrtayaYatir.Value;
            lblOrtaPuan.Text = ortaPuan.ToString();

            //Logging
            rtbOyuncu2.Text = nudOyuncu2OrtayaYatir.Value.ToString() + " ortaya konuldu";

            if (nudOyuncu2OrtayaYatir.Value >= bakiyeOyuncu2)
            {
                MessageBox.Show("Limit exceeded");
            }
        }
    }
}

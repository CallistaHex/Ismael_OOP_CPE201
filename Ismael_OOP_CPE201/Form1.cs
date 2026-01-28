using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ismael_OOP_CPE201
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
      
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Lunch meal a";
            priceTxtbox.Text = "121.30";
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Lunch meal b";
            priceTxtbox.Text = "130.30";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Lunch meal c";
            priceTxtbox.Text = "140.30";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Lunch meal d";
            priceTxtbox.Text = "125.30";
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Lunch meal e";
            priceTxtbox.Text = "200.30";
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Lunch meal f";
            priceTxtbox.Text = "199.30";
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Lunch meal g";
            priceTxtbox.Text = "80.30";
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Lunch meal h";
            priceTxtbox.Text = "95.30";
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Lunch meal i";
            priceTxtbox.Text = "180.30";
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Lunch meal j";
            priceTxtbox.Text = "250.30";
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Lunch meal k";
            priceTxtbox.Text = "128.30";
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Lunch meal l";
            priceTxtbox.Text = "161.30";
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Lunch meal m";
            priceTxtbox.Text = "300.30";
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Lunch meal m";
            priceTxtbox.Text = "640.30";
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Text = "Lunch meal o";
            priceTxtbox.Text = "126.30";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.Text = "";
            priceTxtbox.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            itemnameTxtbox.Clear();
            priceTxtbox.Clear();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

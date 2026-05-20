using Ismael_OOP_CPE201.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ismael_OOP_CPE201
{
    public partial class Lesson2Activity : Form
    {
        public Lesson2Activity()
        {
            InitializeComponent();
        }

        private void Lesson2Activity_Load(object sender, EventArgs e)
        {
            programscombobx.Items.Add("BS Computer Engineering");
            programscombobx.Items.Add("BS Information Technology");
            programscombobx.Items.Add("BS Computer Science");
            programscombobx.Items.Add("BS Civil Engineering");
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void Browsebut_Click(object sender, EventArgs e)
        {
            // Open file dialog for image upload
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Title = "Select Student Photo";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void programscombobx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            // ADD to course code to listBox2
            if (!string.IsNullOrWhiteSpace(coursecodetxtbox.Text))
            {
                listBox2.Items.Add(coursecodetxtbox.Text);
                listBox3.Items.Add(coursedesctxtbox.Text);
                listBox4.Items.Add(unitlecturetxtbox.Text);
                listBox5.Items.Add(unitlabtxtbox.Text);
                listBox6.Items.Add(creditunitstxtbox.Text);
                listBox7.Items.Add(timetxtbox.Text);
                listBox8.Items.Add(daytxtbox.Text);
                listBox1.Items.Add(coursenumtxtbox.Text);

                // Optional: Show message
                MessageBox.Show($"Course '{coursecodetxtbox.Text}' added to list!",
                    "Course Added", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear the textbox
                coursecodetxtbox.Clear();
                coursedesctxtbox.Clear();
                unitlecturetxtbox.Clear();
                unitlabtxtbox.Clear();
                creditunitstxtbox.Clear();
                timetxtbox.Clear();
                daytxtbox.Clear();
                coursenumtxtbox.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a course code",
                    "No Course Code", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            coursecodetxtbox.Clear();
            coursedesctxtbox.Clear();
            unitlecturetxtbox.Clear();
            unitlabtxtbox.Clear();
            creditunitstxtbox.Clear();
            timetxtbox.Clear();
            daytxtbox.Clear();
            coursenumtxtbox.Clear();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class Lesson7example6 : Form
    {
        public Lesson7example6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int InitialValue = 1;
            int numTimeDisplay;
            numTimeDisplay = Convert.ToInt32(numTimeDisplayTextbox.Text);
            do
            {
                displayListbox.Items.Add(countryCombobox.Text);
                InitialValue++;
            } while (InitialValue <= numTimeDisplay);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void countryCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Lesson7example6_Load(object sender, EventArgs e)
        {
            countryCombobox.Items.Add("Japan");
            countryCombobox.Items.Add("Philippines");
            countryCombobox.Items.Add("Taiwan");
            countryCombobox.Items.Add("Canada");
        }
    }
}

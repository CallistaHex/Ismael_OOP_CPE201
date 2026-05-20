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
    public partial class transac : Form
    {
        public transac()
        {
            InitializeComponent();
            reciept_list.Font = new Font("Arial", 12, FontStyle.Bold);
            reciept_list.HorizontalScrollbar = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

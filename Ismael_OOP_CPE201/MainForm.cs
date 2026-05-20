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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void activity1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activity1 activity1 = new Activity1();
            activity1.MdiParent = this;
            activity1.Show();
        }

        private void activity2ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void prelimsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void activity2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Activity2 activity2 = new Activity2();
            activity2.MdiParent = this;
            activity2.Show();
        }

        private void lesson7Example4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lesson7Example4 lesson7Example4 = new Lesson7Example4();
            lesson7Example4.MdiParent = this;
            lesson7Example4.Show();
        }

        private void lesson7Example5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lesson7Example5 lesson7Example5 = new Lesson7Example5();
            lesson7Example5.MdiParent = this;
            lesson7Example5.Show();
        }

        private void lesson7Example6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lesson7example6 lesson7example6 = new Lesson7example6();
            lesson7example6.MdiParent = this;
            lesson7example6.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void activity4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activity4_PrintFrm activity4printfrm = new Activity4_PrintFrm();
            activity4printfrm.MdiParent = this;
            activity4printfrm.Show();
        }

        private void lesson8Exampl4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lesson8Example4 activity4printfrm = new Lesson8Example4();
            activity4printfrm.MdiParent = this;
            activity4printfrm.Show();
        }

        private void finalsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lesson8Example5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lesson8Example5 activity4printfrm = new Lesson8Example5();
            activity4printfrm.MdiParent = this;
            activity4printfrm.Show();
        }

        private void lesson8Example7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lesson8Example7 activity4printfrm = new Lesson8Example7();
            activity4printfrm.MdiParent = this;
            activity4printfrm.Show();
        }

        private void lesson8Example8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lesson8Example8 activity4printfrm = new Lesson8Example8();
            activity4printfrm.MdiParent = this;
            activity4printfrm.Show();
        }

        private void lesson8Example9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lesson8Example9 activity4printfrm = new Lesson8Example9();
            activity4printfrm.MdiParent = this;
            activity4printfrm.Show();
        }
    }
}

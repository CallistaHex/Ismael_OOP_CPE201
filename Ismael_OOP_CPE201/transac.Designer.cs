namespace Ismael_OOP_CPE201
{
    partial class transac
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reciept_list = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // reciept_list
            // 
            this.reciept_list.FormattingEnabled = true;
            this.reciept_list.ItemHeight = 16;
            this.reciept_list.Location = new System.Drawing.Point(13, 13);
            this.reciept_list.Name = "reciept_list";
            this.reciept_list.Size = new System.Drawing.Size(760, 420);
            this.reciept_list.TabIndex = 0;
            this.reciept_list.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // transac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reciept_list);
            this.Name = "transac";
            this.Text = "transac";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox reciept_list;
    }
}
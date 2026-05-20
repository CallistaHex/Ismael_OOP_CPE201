namespace Ismael_OOP_CPE201
{
    partial class payslipprint
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
            this.Payslip = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // Payslip
            // 
            this.Payslip.FormattingEnabled = true;
            this.Payslip.ItemHeight = 16;
            this.Payslip.Location = new System.Drawing.Point(4, 13);
            this.Payslip.Name = "Payslip";
            this.Payslip.Size = new System.Drawing.Size(559, 772);
            this.Payslip.TabIndex = 0;
            // 
            // payslipprint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 743);
            this.Controls.Add(this.Payslip);
            this.Name = "payslipprint";
            this.Text = "payslipprint";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox Payslip;
    }
}
using System;
using System.Windows.Forms;

namespace PayrollApplication
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtBasicRate;
        private TextBox txtBasicHours;
        private TextBox txtHonorariumRate;
        private TextBox txtHonorariumHours;
        private TextBox txtOtherRate;
        private TextBox txtOtherHours;
        private TextBox txtBasicIncome;
        private TextBox txtHonorariumIncome;
        private TextBox txtOtherIncome;
        private TextBox txtGrossIncome;
        private TextBox txtSSS;
        private TextBox txtPhilHealth;
        private TextBox txtPagIbig;
        private TextBox txtIncomeTax;
        private TextBox txtOtherDeductions;
        private TextBox txtTotalDeductions;
        private TextBox txtNetIncome;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Button btnGrossIncome;
        private Button btnNetIncome;
        private Button btnNew;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtBasicRate = new TextBox();
            this.txtBasicHours = new TextBox();
            this.txtHonorariumRate = new TextBox();
            this.txtHonorariumHours = new TextBox();
            this.txtOtherRate = new TextBox();
            this.txtOtherHours = new TextBox();
            this.txtBasicIncome = new TextBox();
            this.txtHonorariumIncome = new TextBox();
            this.txtOtherIncome = new TextBox();
            this.txtGrossIncome = new TextBox();
            this.txtSSS = new TextBox();
            this.txtPhilHealth = new TextBox();
            this.txtPagIbig = new TextBox();
            this.txtIncomeTax = new TextBox();
            this.txtOtherDeductions = new TextBox();
            this.txtTotalDeductions = new TextBox();
            this.txtNetIncome = new TextBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.label5 = new Label();
            this.label6 = new Label();
            this.label7 = new Label();
            this.label8 = new Label();
            this.label9 = new Label();
            this.label10 = new Label();
            this.label11 = new Label();
            this.label12 = new Label();
            this.label13 = new Label();
            this.label14 = new Label();
            this.label15 = new Label();
            this.label16 = new Label();
            this.label17 = new Label();
            this.label18 = new Label();
            this.btnGrossIncome = new Button();
            this.btnNetIncome = new Button();
            this.btnNew = new Button();
            this.groupBox1 = new GroupBox();
            this.groupBox2 = new GroupBox();
            this.groupBox3 = new GroupBox();
            this.groupBox4 = new GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();

            // Form1
            this.Text = "Payroll Application";
            this.Size = new System.Drawing.Size(800, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            // GroupBox1 - Income Input
            this.groupBox1.Text = "Income Input";
            this.groupBox1.Location = new System.Drawing.Point(20, 20);
            this.groupBox1.Size = new System.Drawing.Size(350, 200);

            // Basic Rate
            this.label1.Text = "Basic Rate/Hour:";
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.txtBasicRate.Location = new System.Drawing.Point(130, 27);
            this.txtBasicRate.Size = new System.Drawing.Size(100, 23);

            // Basic Hours
            this.label2.Text = "Basic Hours:";
            this.label2.Location = new System.Drawing.Point(20, 60);
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.txtBasicHours.Location = new System.Drawing.Point(130, 57);
            this.txtBasicHours.Size = new System.Drawing.Size(100, 23);

            // Honorarium Rate
            this.label3.Text = "Honorarium Rate/Hour:";
            this.label3.Location = new System.Drawing.Point(20, 90);
            this.label3.Size = new System.Drawing.Size(110, 23);
            this.txtHonorariumRate.Location = new System.Drawing.Point(130, 87);
            this.txtHonorariumRate.Size = new System.Drawing.Size(100, 23);

            // Honorarium Hours
            this.label4.Text = "Honorarium Hours:";
            this.label4.Location = new System.Drawing.Point(20, 120);
            this.label4.Size = new System.Drawing.Size(110, 23);
            this.txtHonorariumHours.Location = new System.Drawing.Point(130, 117);
            this.txtHonorariumHours.Size = new System.Drawing.Size(100, 23);

            // Other Rate
            this.label5.Text = "Other Rate/Hour:";
            this.label5.Location = new System.Drawing.Point(20, 150);
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.txtOtherRate.Location = new System.Drawing.Point(130, 147);
            this.txtOtherRate.Size = new System.Drawing.Size(100, 23);

            // Other Hours
            this.label6.Text = "Other Hours:";
            this.label6.Location = new System.Drawing.Point(20, 180);
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.txtOtherHours.Location = new System.Drawing.Point(130, 177);
            this.txtOtherHours.Size = new System.Drawing.Size(100, 23);

            // GroupBox2 - Income Output
            this.groupBox2.Text = "Income Output";
            this.groupBox2.Location = new System.Drawing.Point(400, 20);
            this.groupBox2.Size = new System.Drawing.Size(350, 200);

            // Basic Income
            this.label7.Text = "Basic Income:";
            this.label7.Location = new System.Drawing.Point(20, 30);
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.txtBasicIncome.Location = new System.Drawing.Point(130, 27);
            this.txtBasicIncome.Size = new System.Drawing.Size(100, 23);
            this.txtBasicIncome.ReadOnly = true;

            // Honorarium Income
            this.label8.Text = "Honorarium Income:";
            this.label8.Location = new System.Drawing.Point(20, 60);
            this.label8.Size = new System.Drawing.Size(110, 23);
            this.txtHonorariumIncome.Location = new System.Drawing.Point(130, 57);
            this.txtHonorariumIncome.Size = new System.Drawing.Size(100, 23);
            this.txtHonorariumIncome.ReadOnly = true;

            // Other Income
            this.label9.Text = "Other Income:";
            this.label9.Location = new System.Drawing.Point(20, 90);
            this.label9.Size = new System.Drawing.Size(100, 23);
            this.txtOtherIncome.Location = new System.Drawing.Point(130, 87);
            this.txtOtherIncome.Size = new System.Drawing.Size(100, 23);
            this.txtOtherIncome.ReadOnly = true;

            // Gross Income
            this.label10.Text = "Gross Income:";
            this.label10.Location = new System.Drawing.Point(20, 120);
            this.label10.Size = new System.Drawing.Size(100, 23);
            this.txtGrossIncome.Location = new System.Drawing.Point(130, 117);
            this.txtGrossIncome.Size = new System.Drawing.Size(100, 23);
            this.txtGrossIncome.ReadOnly = true;

            // GroupBox3 - Deductions
            this.groupBox3.Text = "Deductions";
            this.groupBox3.Location = new System.Drawing.Point(20, 240);
            this.groupBox3.Size = new System.Drawing.Size(350, 250);

            // SSS
            this.label11.Text = "SSS:";
            this.label11.Location = new System.Drawing.Point(20, 30);
            this.label11.Size = new System.Drawing.Size(100, 23);
            this.txtSSS.Location = new System.Drawing.Point(130, 27);
            this.txtSSS.Size = new System.Drawing.Size(100, 23);

            // PhilHealth
            this.label12.Text = "PhilHealth:";
            this.label12.Location = new System.Drawing.Point(20, 60);
            this.label12.Size = new System.Drawing.Size(100, 23);
            this.txtPhilHealth.Location = new System.Drawing.Point(130, 57);
            this.txtPhilHealth.Size = new System.Drawing.Size(100, 23);

            // Pag-IBIG
            this.label13.Text = "Pag-IBIG:";
            this.label13.Location = new System.Drawing.Point(20, 90);
            this.label13.Size = new System.Drawing.Size(100, 23);
            this.txtPagIbig.Location = new System.Drawing.Point(130, 87);
            this.txtPagIbig.Size = new System.Drawing.Size(100, 23);

            // Income Tax
            this.label14.Text = "Income Tax:";
            this.label14.Location = new System.Drawing.Point(20, 120);
            this.label14.Size = new System.Drawing.Size(100, 23);
            this.txtIncomeTax.Location = new System.Drawing.Point(130, 117);
            this.txtIncomeTax.Size = new System.Drawing.Size(100, 23);

            // Other Deductions
            this.label15.Text = "Other Deductions:";
            this.label15.Location = new System.Drawing.Point(20, 150);
            this.label15.Size = new System.Drawing.Size(110, 23);
            this.txtOtherDeductions.Location = new System.Drawing.Point(130, 147);
            this.txtOtherDeductions.Size = new System.Drawing.Size(100, 23);

            // GroupBox4 - Net Income
            this.groupBox4.Text = "Net Income";
            this.groupBox4.Location = new System.Drawing.Point(400, 240);
            this.groupBox4.Size = new System.Drawing.Size(350, 200);

            // Total Deductions
            this.label16.Text = "Total Deductions:";
            this.label16.Location = new System.Drawing.Point(20, 30);
            this.label16.Size = new System.Drawing.Size(110, 23);
            this.txtTotalDeductions.Location = new System.Drawing.Point(130, 27);
            this.txtTotalDeductions.Size = new System.Drawing.Size(100, 23);
            this.txtTotalDeductions.ReadOnly = true;

            // Net Income
            this.label17.Text = "Net Income:";
            this.label17.Location = new System.Drawing.Point(20, 60);
            this.label17.Size = new System.Drawing.Size(100, 23);
            this.txtNetIncome.Location = new System.Drawing.Point(130, 57);
            this.txtNetIncome.Size = new System.Drawing.Size(100, 23);
            this.txtNetIncome.ReadOnly = true;

            // Buttons
            this.btnGrossIncome.Text = "GROSS INCOME";
            this.btnGrossIncome.Location = new System.Drawing.Point(100, 500);
            this.btnGrossIncome.Size = new System.Drawing.Size(120, 40);
            this.btnGrossIncome.Click += new EventHandler(this.btnGrossIncome_Click);

            this.btnNetIncome.Text = "NET INCOME";
            this.btnNetIncome.Location = new System.Drawing.Point(250, 500);
            this.btnNetIncome.Size = new System.Drawing.Size(120, 40);
            this.btnNetIncome.Click += new EventHandler(this.btnNetIncome_Click);

            this.btnNew.Text = "NEW";
            this.btnNew.Location = new System.Drawing.Point(400, 500);
            this.btnNew.Size = new System.Drawing.Size(120, 40);
            this.btnNew.Click += new EventHandler(this.btnNew_Click);

            // Add controls to group boxes
            this.groupBox1.Controls.AddRange(new Control[] {
                this.label1, this.txtBasicRate,
                this.label2, this.txtBasicHours,
                this.label3, this.txtHonorariumRate,
                this.label4, this.txtHonorariumHours,
                this.label5, this.txtOtherRate,
                this.label6, this.txtOtherHours
            });

            this.groupBox2.Controls.AddRange(new Control[] {
                this.label7, this.txtBasicIncome,
                this.label8, this.txtHonorariumIncome,
                this.label9, this.txtOtherIncome,
                this.label10, this.txtGrossIncome
            });

            this.groupBox3.Controls.AddRange(new Control[] {
                this.label11, this.txtSSS,
                this.label12, this.txtPhilHealth,
                this.label13, this.txtPagIbig,
                this.label14, this.txtIncomeTax,
                this.label15, this.txtOtherDeductions
            });

            this.groupBox4.Controls.AddRange(new Control[] {
                this.label16, this.txtTotalDeductions,
                this.label17, this.txtNetIncome
            });

            // Add all controls to form
            this.Controls.AddRange(new Control[] {
                this.groupBox1, this.groupBox2, this.groupBox3, this.groupBox4,
                this.btnGrossIncome, this.btnNetIncome, this.btnNew
            });

            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
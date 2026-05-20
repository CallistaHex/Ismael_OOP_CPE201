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
    public partial class Lesson7Example4 : Form
    {
        public Lesson7Example4()
        {
            InitializeComponent();
        }


        double basic_netincome = 0;
        double basic_numhrs = 0;
        double basic_rate = 0;
        double hono_netincome = 0;
        double hono_numhrs = 0;
        double hono_rate = 0;
        double other_netincome = 0;
        double other_numhrs = 0;
        double other_rate = 0;

        double grossincome = 0;
        double tax = 0;

        double sss_contrib = 0;
        double pagibig_contrib = 0;
        double philhealth_contrib = 0;
        double total_deduction = 0;
        double net_income = 0;
        private void BI_2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                basic_numhrs = Convert.ToDouble(BI_2.Text);
                basic_rate = Convert.ToDouble(BI_1.Text);
                basic_netincome = basic_numhrs * basic_rate;
                BI_3.Text = basic_netincome.ToString("n");
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area. Please contact your administator!");
            }
        }

        private void HI_2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                hono_numhrs = Convert.ToDouble(HI_2.Text);
                hono_rate = Convert.ToDouble(HI_1.Text);
                hono_netincome = hono_numhrs * hono_rate;
                HI_3.Text = hono_netincome.ToString("n");
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area. Please contact your administator!");
            }
        }

        private void OI_2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                other_numhrs = Convert.ToDouble(OI_2.Text);
                other_rate = Convert.ToDouble(OI_1.Text);
                other_netincome = other_numhrs * other_rate;
                OI_3.Text = other_netincome.ToString("n");

                grossincome = basic_netincome + hono_netincome + other_netincome;
                txtbox_GrossIncome.Text = grossincome.ToString("n");

              
                double philhealth_value = 0;
                if (grossincome < 10000)
                {
                    philhealth_value = 137.50;
                }
                else
                {
                    double philhealth_employshare = 137.50;

                    for (int x = 10000; x <= 40000; x += 1000)
                    {
                        if (grossincome >= x && grossincome < x + 1000 || grossincome > x + 1000)
                        {
                            philhealth_value = philhealth_employshare;
                        }
                        philhealth_employshare += 13.75;
                    }
                }
                RD_2.Text = philhealth_value.ToString("N");

                
                double sss_value = 0;
                if (grossincome <= 1000)
                {
                    sss_value = 36.30;
                }
                else
                {
                    double sss_employshare = 36.30;

                    for (int x = 1000; x <= 15750; x += 500)
                    {
                        if (grossincome >= x && grossincome < x + 500 || grossincome > x + 500)
                        {
                            sss_value = sss_employshare;
                        }
                        sss_employshare += 18.20;
                    }
                }
                RD_1.Text = sss_value.ToString("N");

     
                if (grossincome < (250000 / 24))
                {
                    RD_4.Text = "0.00";
                }
                else if (grossincome > 10416.67 && grossincome <= 16666.67)
                {
                    tax = ((((grossincome * 24) - 250000) * 0.20) / 24);
                    RD_4.Text = tax.ToString("N");
                }
                else if (grossincome > 16666.67 && grossincome <= 33333.33)
                {
                    tax = (((((grossincome * 24) - 400000) * 0.25) + 30000) / 24);
                    RD_4.Text = tax.ToString("N");
                }
                else if (grossincome > 33333.33 && grossincome <= 83333.33)
                {
                    tax = (((((grossincome * 24) - 800000) * 0.30) + 130000) / 24);
                    RD_4.Text = tax.ToString("N");
                }
                else if (grossincome > 83333.33 && grossincome <= 333333.33)
                {
                    tax = (((((grossincome * 24) - 2000000) * 0.32) + 490000) / 24);
                    RD_4.Text = tax.ToString("N");
                }
                else
                {
                    tax = (((((grossincome * 24) - 8000000) * 0.35) + 2410000) / 24);
                    RD_4.Text = tax.ToString("N");
                }

           
                RD_3.Text = "100";

            }
            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area. Please contact your administator!");
            }
        }

        private void btn_Calculate_Click(object sender, EventArgs e)
        {
            try
            {
                sss_contrib = Convert.ToDouble(RD_1.Text);
                pagibig_contrib = Convert.ToDouble(RD_2.Text);
                philhealth_contrib = Convert.ToDouble(RD_3.Text);
                tax = Convert.ToDouble(RD_4.Text);
                total_deduction = sss_contrib + pagibig_contrib + philhealth_contrib + tax;

                net_income = grossincome - total_deduction;

                txtbox_NetIncome.Text = net_income.ToString("C");
                txtbox_totaldeduction.Text = total_deduction.ToString("C");
                txtbox_GrossIncome.Text = grossincome.ToString("C");
            }
            catch (Exception)
            {
                MessageBox.Show("Error occurs in this area. Please contact your administator!");
            }

        }

        private void Lesson7_Example4_Load(object sender, EventArgs e)
        {
            HI_3.Enabled = false;
            BI_3.Enabled = false;
            OI_3.Enabled = false;

            RD_1.Enabled = false;
            RD_2.Enabled = false;
            RD_3.Enabled = false;
            RD_4.Enabled = false;

            txtbox_GrossIncome.Enabled = false;
            txtbox_NetIncome.Enabled = false;
            txtbox_totaldeduction.Enabled = false;
        }

        private void btn_NEW_Click(object sender, EventArgs e)
        {
            BI_1.Clear();
            BI_2.Clear();
            BI_3.Clear();

            HI_1.Clear();
            HI_2.Clear();
            HI_3.Clear();

            OI_1.Clear();
            OI_2.Clear();
            OI_3.Clear();

            // Clear deduction fields
            RD_1.Clear();
            RD_2.Clear();
            RD_3.Clear();
            RD_4.Clear();

            // Clear result fields
            txtbox_GrossIncome.Clear();
            txtbox_NetIncome.Clear();
            txtbox_totaldeduction.Clear();

            // Reset all variables to 0
            basic_netincome = 0;
            basic_numhrs = 0;
            basic_rate = 0;
            hono_netincome = 0;
            hono_numhrs = 0;
            hono_rate = 0;
            other_netincome = 0;
            other_numhrs = 0;
            other_rate = 0;
            grossincome = 0;
            tax = 0;
            sss_contrib = 0;
            pagibig_contrib = 0;
            philhealth_contrib = 0;
            total_deduction = 0;
            net_income = 0;

            // Set focus to first input field
            BI_1.Focus();
        }

        private void btn_EXIT_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


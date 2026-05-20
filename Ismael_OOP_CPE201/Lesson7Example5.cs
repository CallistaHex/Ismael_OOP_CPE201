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
    public partial class Lesson7Example5 : Form
    {
        private string picpath;
        private Double basic_netincome = 0.00,
            basic_numhrs = 0.00,
            basic_rate = 0.00,
            hono_netincome = 0.00,
            hono_numhrs = 0.00,
            hono_rate = 0.00,
            other_netincome = 0.00,
            other_numhrs = 0.00,
            other_rate = 0.00;

        private void button3_Click(object sender, EventArgs e)
        {
            sal_loanTxtbox.Clear();
            FS_loanTxtbox.Clear();
            FSD_depositTxtbox.Clear();
            emp_nuTxtbox.Clear();
            firstnameTxtbox.Clear();
            MNameTxtbox.Clear();
            surTxtbox.Clear();
            civil_statusTxtbox.Clear();
            desigTxtbox.Clear();
            numDependentTxtbox.Clear();
            empStatusTxtbox.Clear();
            DeptNameTxtbox.Clear();
            basic_netincomeTxtbox.Clear();
            basic_numhrsTxtbox.Clear();
            basic_rateTxtbox.Clear();
            hono_netincomeTxtbox.Clear();
            hono_numhrsTxtbox.Clear();
            hono_rateTxtbox.Clear();
            other_netincomeTxtbox.Clear();
            other_numhrsTxtbox.Clear();
            other_rateTxtbox.Clear();
            net_incomeTxtbox.Clear();
            gross_incomeTxtbox.Clear();
            sss_contribTxtbox.Clear();
            pagibig_contribTxtbox.Clear();
            philhealth_contribTxtbox.Clear();
            tax_contribTxtbox.Clear();
            sss_loanTxtbox.Clear();
            pagibig_loanTxtbox.Clear();
            total_deducTxtbox.Clear();
            otherLoanTxtbox.Clear();
            payslip_viewListBox.Items.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            emp_nuTxtbox.Clear();
            firstnameTxtbox.Clear();
            MNameTxtbox.Clear();
            surTxtbox.Clear();
            civil_statusTxtbox.Clear();
            desigTxtbox.Clear();
            numDependentTxtbox.Clear();
            empStatusTxtbox.Clear();
            DeptNameTxtbox.Clear();
            basic_netincomeTxtbox.Clear();
            basic_numhrsTxtbox.Clear();
            basic_rateTxtbox.Clear();
            hono_netincomeTxtbox.Clear();
            hono_numhrsTxtbox.Clear();
            hono_rateTxtbox.Clear();
            other_netincomeTxtbox.Clear();
            other_numhrsTxtbox.Clear();
            other_rateTxtbox.Clear();
            net_incomeTxtbox.Clear();
            gross_incomeTxtbox.Clear();
            sss_contribTxtbox.Clear();
            pagibig_contribTxtbox.Clear();
            philhealth_contribTxtbox.Clear();
            tax_contribTxtbox.Clear();
            sss_loanTxtbox.Clear();
            pagibig_loanTxtbox.Clear();
            total_deducTxtbox.Clear();
            otherLoanTxtbox.Clear();
            payslip_viewListBox.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Select Employee Picture";

                openFileDialog.ShowDialog();
                picpath = openFileDialog.FileName;
                picpathTxtbox.Text = picpath;
                pictureBox2.Image = Image.FromFile(picpath);
            }
            catch (Exception)
            {
                MessageBox.Show("No image selected.", "Image Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Method to update the payslip display
        private void UpdatePayslipDisplay()
        {
            payslip_viewListBox.Items.Clear();

            // Employee Information
            payslip_viewListBox.Items.Add("Employee Number: " + emp_nuTxtbox.Text);
            payslip_viewListBox.Items.Add("First Name: " + firstnameTxtbox.Text);
            payslip_viewListBox.Items.Add("Middlename: " + MNameTxtbox.Text);
            payslip_viewListBox.Items.Add("Surname: " + surTxtbox.Text);
            payslip_viewListBox.Items.Add("Designation: " + desigTxtbox.Text);
            payslip_viewListBox.Items.Add("Employee Status: " + empStatusTxtbox.Text);
            payslip_viewListBox.Items.Add("Department: " + DeptNameTxtbox.Text);
            payslip_viewListBox.Items.Add("Pay Date: " + paydateDatePicker.Text);
            payslip_viewListBox.Items.Add("--------------------------------------------------------------------------------------------------------------------------------------------------------");

            // Income Section
            payslip_viewListBox.Items.Add("BP Num. of Hrs.: " + basic_numhrsTxtbox.Text);
            payslip_viewListBox.Items.Add("BP Rate / Hr.: " + basic_rateTxtbox.Text);
            payslip_viewListBox.Items.Add("Basic Pay Income: " + basic_netincomeTxtbox.Text);
            payslip_viewListBox.Items.Add("");
            payslip_viewListBox.Items.Add("HNR Num. of Hrs.: " + hono_numhrsTxtbox.Text);
            payslip_viewListBox.Items.Add("HI Rate / Hr.: " + hono_rateTxtbox.Text);
            payslip_viewListBox.Items.Add("Honorarium Income: " + hono_netincomeTxtbox.Text);
            payslip_viewListBox.Items.Add("");
            payslip_viewListBox.Items.Add("OTI Num. of Hrs.: " + other_numhrsTxtbox.Text);
            payslip_viewListBox.Items.Add("OTI Rate / Hr.: " + other_rateTxtbox.Text);
            payslip_viewListBox.Items.Add("Other Income: " + other_netincomeTxtbox.Text);
            payslip_viewListBox.Items.Add("--------------------------------------------------------------------------------------------------------------------------------------------------------");

            // Gross Income
            payslip_viewListBox.Items.Add("Gross Income: " + gross_incomeTxtbox.Text);
            payslip_viewListBox.Items.Add("--------------------------------------------------------------------------------------------------------------------------------------------------------");

            // Deductions Section
            payslip_viewListBox.Items.Add("SSS Contribution: " + sss_contribTxtbox.Text);
            payslip_viewListBox.Items.Add("Pag-IBIG Contribution: " + pagibig_contribTxtbox.Text);
            payslip_viewListBox.Items.Add("PhilHealth Contribution: " + philhealth_contribTxtbox.Text);
            payslip_viewListBox.Items.Add("Tax Contribution: " + tax_contribTxtbox.Text);
            payslip_viewListBox.Items.Add("SSS Loan: " + sss_loanTxtbox.Text);
            payslip_viewListBox.Items.Add("Pag-IBIG Loan: " + pagibig_loanTxtbox.Text);
            payslip_viewListBox.Items.Add("Salary Loan: " + sal_loanTxtbox.Text);
            payslip_viewListBox.Items.Add("Faculty Savings Loan: " + FS_loanTxtbox.Text);
            payslip_viewListBox.Items.Add("FSD Deposit: " + FSD_depositTxtbox.Text);
            payslip_viewListBox.Items.Add("Other Loan: " + otherLoanTxtbox.Text);
            payslip_viewListBox.Items.Add("--------------------------------------------------------------------------------------------------------------------------------------------------------");

            // Totals
            payslip_viewListBox.Items.Add("Total Deduction: " + total_deducTxtbox.Text);
            payslip_viewListBox.Items.Add("Net Income: " + net_incomeTxtbox.Text);
        }

        // Auto-calculate Basic Pay when hours or rate changes
        private void basic_numhrsTxtbox_TextChanged(object sender, EventArgs e)
        {
            CalculateBasicPay();
            CalculateGrossIncome();
            CalculatePhilHealth();
            UpdatePayslipDisplay();
        }

        private void basic_rateTxtbox_TextChanged(object sender, EventArgs e)
        {
            CalculateBasicPay();
            CalculateGrossIncome();
            CalculatePhilHealth();
            UpdatePayslipDisplay();
        }

        // Auto-calculate Honorarium Pay when hours or rate changes
        private void hono_numhrsTxtbox_TextChanged(object sender, EventArgs e)
        {
            CalculateHonorariumPay();
            CalculateGrossIncome();
            CalculatePhilHealth();
            UpdatePayslipDisplay();
        }

        private void hono_rateTxtbox_TextChanged(object sender, EventArgs e)
        {
            CalculateHonorariumPay();
            CalculateGrossIncome();
            CalculatePhilHealth();
            UpdatePayslipDisplay();
        }

        // Auto-calculate Other Income when hours or rate changes
        private void other_numhrsTxtbox_TextChanged(object sender, EventArgs e)
        {
            CalculateOtherIncome();
            CalculateGrossIncome();
            CalculatePhilHealth();
            UpdatePayslipDisplay();
        }

        private void other_rateTxtbox_TextChanged(object sender, EventArgs e)
        {
            CalculateOtherIncome();
            CalculateGrossIncome();
            CalculatePhilHealth();
            UpdatePayslipDisplay();
        }

        // Method to calculate Basic Pay
        private void CalculateBasicPay()
        {
            try
            {
                if (!string.IsNullOrEmpty(basic_numhrsTxtbox.Text) && !string.IsNullOrEmpty(basic_rateTxtbox.Text))
                {
                    basic_numhrs = Convert.ToDouble(basic_numhrsTxtbox.Text);
                    basic_rate = Convert.ToDouble(basic_rateTxtbox.Text);
                    basic_netincome = basic_numhrs * basic_rate;
                    basic_netincomeTxtbox.Text = basic_netincome.ToString("N2");
                }
                else
                {
                    basic_netincomeTxtbox.Text = "0.00";
                }
            }
            catch (Exception)
            {
                basic_netincomeTxtbox.Text = "0.00";
            }
        }

        // Method to calculate Honorarium Pay
        private void CalculateHonorariumPay()
        {
            try
            {
                if (!string.IsNullOrEmpty(hono_numhrsTxtbox.Text) && !string.IsNullOrEmpty(hono_rateTxtbox.Text))
                {
                    hono_numhrs = Convert.ToDouble(hono_numhrsTxtbox.Text);
                    hono_rate = Convert.ToDouble(hono_rateTxtbox.Text);
                    hono_netincome = hono_numhrs * hono_rate;
                    hono_netincomeTxtbox.Text = hono_netincome.ToString("N2");
                }
                else
                {
                    hono_netincomeTxtbox.Text = "0.00";
                }
            }
            catch (Exception)
            {
                hono_netincomeTxtbox.Text = "0.00";
            }
        }

        // Method to calculate Other Income
        private void CalculateOtherIncome()
        {
            try
            {
                if (!string.IsNullOrEmpty(other_numhrsTxtbox.Text) && !string.IsNullOrEmpty(other_rateTxtbox.Text))
                {
                    other_numhrs = Convert.ToDouble(other_numhrsTxtbox.Text);
                    other_rate = Convert.ToDouble(other_rateTxtbox.Text);
                    other_netincome = other_numhrs * other_rate;
                    other_netincomeTxtbox.Text = other_netincome.ToString("N2");
                }
                else
                {
                    other_netincomeTxtbox.Text = "0.00";
                }
            }
            catch (Exception)
            {
                other_netincomeTxtbox.Text = "0.00";
            }
        }

        // Method to calculate Gross Income (Total of all incomes)
        private void CalculateGrossIncome()
        {
            try
            {
                double basic = string.IsNullOrEmpty(basic_netincomeTxtbox.Text) ? 0 : Convert.ToDouble(basic_netincomeTxtbox.Text);
                double honor = string.IsNullOrEmpty(hono_netincomeTxtbox.Text) ? 0 : Convert.ToDouble(hono_netincomeTxtbox.Text);
                double other = string.IsNullOrEmpty(other_netincomeTxtbox.Text) ? 0 : Convert.ToDouble(other_netincomeTxtbox.Text);

                grossincome = basic + honor + other;
                gross_incomeTxtbox.Text = grossincome.ToString("N2");
            }
            catch (Exception)
            {
                gross_incomeTxtbox.Text = "0.00";
            }
        }

        // Method to calculate PhilHealth Contribution using WHILE LOOP
        private void CalculatePhilHealth()
        {
            try
            {
                double gross = string.IsNullOrEmpty(gross_incomeTxtbox.Text) ? 0 : Convert.ToDouble(gross_incomeTxtbox.Text);
                double philhealthValue = 0;

                // PhilHealth computation using WHILE LOOP
                if (gross < 10000)
                {
                    philhealthValue = 137.50;
                }
                else
                {
                    double bracketStart = 10000;
                    double contribution = 137.50;

                    // WHILE LOOP to determine PhilHealth contribution
                    while (bracketStart <= 55000)
                    {
                        if (gross >= bracketStart && gross < bracketStart + 1000)
                        {
                            philhealthValue = contribution;
                            break;
                        }
                        bracketStart += 1000;
                        contribution += 12.50;

                        if (bracketStart > 55000)
                        {
                            philhealthValue = 687.50;
                        }
                    }
                }

                philhealth_contribTxtbox.Text = philhealthValue.ToString("N2");
            }
            catch (Exception)
            {
                philhealth_contribTxtbox.Text = "0.00";
            }
        }

        // Update display when textboxes change (for employee info and deductions)
        private void emp_nuTxtbox_TextChanged(object sender, EventArgs e)
        {
            UpdatePayslipDisplay();
        }

        private void firstnameTxtbox_TextChanged(object sender, EventArgs e)
        {
            UpdatePayslipDisplay();
        }

        private void MNameTxtbox_TextChanged(object sender, EventArgs e)
        {
            UpdatePayslipDisplay();
        }

        private void surTxtbox_TextChanged(object sender, EventArgs e)
        {
            UpdatePayslipDisplay();
        }

        private void desigTxtbox_TextChanged(object sender, EventArgs e)
        {
            UpdatePayslipDisplay();
        }

        private void empStatusTxtbox_TextChanged(object sender, EventArgs e)
        {
            UpdatePayslipDisplay();
        }

        private void DeptNameTxtbox_TextChanged(object sender, EventArgs e)
        {
            UpdatePayslipDisplay();
        }

        private void paydateDatePicker_ValueChanged(object sender, EventArgs e)
        {
            UpdatePayslipDisplay();
        }

        private void sss_contribTxtbox_TextChanged(object sender, EventArgs e)
        {
            UpdatePayslipDisplay();
        }

        private void pagibig_contribTxtbox_TextChanged(object sender, EventArgs e)
        {
            UpdatePayslipDisplay();
        }

        private void tax_contribTxtbox_TextChanged(object sender, EventArgs e)
        {
            UpdatePayslipDisplay();
        }

        private void sss_loanTxtbox_TextChanged(object sender, EventArgs e)
        {
            UpdatePayslipDisplay();
        }

        private void pagibig_loanTxtbox_TextChanged(object sender, EventArgs e)
        {
            UpdatePayslipDisplay();
        }

        private void sal_loanTxtbox_TextChanged(object sender, EventArgs e)
        {
            UpdatePayslipDisplay();
        }

        private void FS_loanTxtbox_TextChanged(object sender, EventArgs e)
        {
            UpdatePayslipDisplay();
        }

        private void FSD_depositTxtbox_TextChanged(object sender, EventArgs e)
        {
            UpdatePayslipDisplay();
        }

        private void otherLoanTxtbox_TextChanged(object sender, EventArgs e)
        {
            UpdatePayslipDisplay();
        }

        private void total_deducTxtbox_TextChanged(object sender, EventArgs e)
        {
            UpdatePayslipDisplay();
        }

        private void net_incomeTxtbox_TextChanged(object sender, EventArgs e)
        {
            UpdatePayslipDisplay();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Get all values from textboxes
                double sssLoan = string.IsNullOrEmpty(sss_loanTxtbox.Text) ? 0 : Convert.ToDouble(sss_loanTxtbox.Text);
                double pagibigLoan = string.IsNullOrEmpty(pagibig_loanTxtbox.Text) ? 0 : Convert.ToDouble(pagibig_loanTxtbox.Text);
                double salaryLoan = string.IsNullOrEmpty(sal_loanTxtbox.Text) ? 0 : Convert.ToDouble(sal_loanTxtbox.Text);
                double facultySavLoan = string.IsNullOrEmpty(FS_loanTxtbox.Text) ? 0 : Convert.ToDouble(FS_loanTxtbox.Text);
                double fsdDeposit = string.IsNullOrEmpty(FSD_depositTxtbox.Text) ? 0 : Convert.ToDouble(FSD_depositTxtbox.Text);
                double otherLoan = string.IsNullOrEmpty(otherLoanTxtbox.Text) ? 0 : Convert.ToDouble(otherLoanTxtbox.Text);
                double sssContrib = string.IsNullOrEmpty(sss_contribTxtbox.Text) ? 0 : Convert.ToDouble(sss_contribTxtbox.Text);
                double pagibigContrib = string.IsNullOrEmpty(pagibig_contribTxtbox.Text) ? 0 : Convert.ToDouble(pagibig_contribTxtbox.Text);
                double philhealthContrib = string.IsNullOrEmpty(philhealth_contribTxtbox.Text) ? 0 : Convert.ToDouble(philhealth_contribTxtbox.Text);
                double taxContrib = string.IsNullOrEmpty(tax_contribTxtbox.Text) ? 0 : Convert.ToDouble(tax_contribTxtbox.Text);

                // Calculate totals
                total_contrib = sssContrib + pagibigContrib + philhealthContrib + taxContrib;
                total_loan = sssLoan + pagibigLoan + salaryLoan + facultySavLoan + fsdDeposit + otherLoan;
                total_deduction = total_contrib + total_loan;

                // Display totals
                total_deducTxtbox.Text = total_deduction.ToString("N2");
                netincome = grossincome - total_deduction;
                net_incomeTxtbox.Text = netincome.ToString("N2");

                UpdatePayslipDisplay();
            }
            catch (Exception)
            {
                MessageBox.Show("Please input valid numeric values.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Manual refresh button - updates the display
            UpdatePayslipDisplay();
            MessageBox.Show("Payslip display updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Lesson7Example5Prnt printForm = new Lesson7Example5Prnt();
            printForm.priDisplayListBox.Items.AddRange(this.payslip_viewListBox.Items);
            printForm.Show();
        }

        private Double netincome = 0.00,
            grossincome = 0.00,
            sss_contrib = 0.00,
            pagibig_contrib = 0.00,
            philhealth_contrib = 0.00,
            tax_contrib = 0.00;
        private Double sss_loan = 0.00,
            pagibig_loan = 0.00,
            salay_loan = 0.00,
            salary_savings = 0.00,
            faculty_sav_loan = 0.00,
            other_deduction = 0.00,
            total_deduction = 0.00,
            total_contrib = 0.00,
            total_loan = 0.00;

        public Lesson7Example5()
        {
            InitializeComponent();
        }

        private void Lesson7Example5_Load(object sender, EventArgs e)
        {
            // Set default values
            basic_netincomeTxtbox.Enabled = false;
            hono_netincomeTxtbox.Enabled = false;
            other_netincomeTxtbox.Enabled = false;
            net_incomeTxtbox.Enabled = false;
            gross_incomeTxtbox.Enabled = false;
            total_deducTxtbox.Enabled = false;
            philhealth_contribTxtbox.Enabled = false;

            // Set initial values
            basic_netincomeTxtbox.Text = "0.00";
            hono_netincomeTxtbox.Text = "0.00";
            other_netincomeTxtbox.Text = "0.00";
            gross_incomeTxtbox.Text = "0.00";
            philhealth_contribTxtbox.Text = "0.00";

            sss_contribTxtbox.Text = "0.00";
            pagibig_contribTxtbox.Text = "0.00";
            tax_contribTxtbox.Text = "0.00";
            sss_loanTxtbox.Text = "0.00";
            pagibig_loanTxtbox.Text = "0.00";
            FSD_depositTxtbox.Text = "0.00";
            FS_loanTxtbox.Text = "0.00";
            sal_loanTxtbox.Text = "0.00";
            otherLoanTxtbox.Text = "0.00";

            others_loanCombo.Text = "Select other deduction";
            others_loanCombo.Items.Add("other 1");
            others_loanCombo.Items.Add("other 2");
            others_loanCombo.Items.Add("other 3");
            others_loanCombo.Items.Add("other 4");
            picpathTxtbox.Hide();

            // Initial display
            UpdatePayslipDisplay();
        }
    }
}
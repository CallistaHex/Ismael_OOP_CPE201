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
    public partial class Lesson5Activity : Form
    {
        public Lesson5Activity()
        {
            InitializeComponent();
            InitializeReadOnlyFields();
            InitializeNumericValidation();
            InitializeTextChangedEvents();
        }

        private void Lesson5Activity_Load(object sender, EventArgs e)
        {

        }

        private void InitializeReadOnlyFields()
        {
            // Set ReadOnly for computed fields and fields that shouldn't be edited
            tboxbasicincomepercutoff.ReadOnly = true;
            tboxhonorincompercutoff.ReadOnly = true;
            tboxotherincompercutoff.ReadOnly = true;
            tboxsummaryincgrossincome.ReadOnly = true;
            tboxsummaryincomNETincome.ReadOnly = true;
            tboxsssconti.ReadOnly = true;
            tboxphilhealthcontri.ReadOnly = true;
            tboxpagibigcontri.ReadOnly = true;
            tboxincometaxcontri.ReadOnly = true;
            tboxtotaldeductions.ReadOnly = true;

            // Set ReadOnly for employee info fields (make them read-only as specified)
            textBox9.ReadOnly = true; // First Name
            textBox8.ReadOnly = true; // Middle Name
            textBox7.ReadOnly = true; // Last Name
            textBox6.ReadOnly = true; // Civil Status
            textBox3.ReadOnly = true; // Employee Status
            textBox2.ReadOnly = true; // Designation
            tboxqualifieddependentsstatus.ReadOnly = true; // Qualified Dependents Status
            tboxpaydate.ReadOnly = true; // Pay Date

            // Set default value for Pag-IBIG contribution (fixed at 200.00)
            tboxpagibigcontri.Text = "200.00";
            this.ButtGrossInc.Click += new System.EventHandler(this.ButtGrossInc_Click);
            this.ButtSave.Click += new System.EventHandler(this.ButtSave_Click);
            this.ButtNetInc.Click += new System.EventHandler(this.ButtNetInc_Click);
            this.ButUpdate.Click += new System.EventHandler(this.ButUpdate_Click);
            this.ButtNew.Click += new System.EventHandler(this.ButtNew_Click);
        }

        private void InitializeNumericValidation()
        {
            // Add KeyPress events for numeric fields
            tboxbasicrateperhour.KeyPress += NumericOnly_KeyPress;
            tboxbasicnoofhourspercutoff.KeyPress += NumericOnly_KeyPress;
            tboxhonorrateperhour.KeyPress += NumericOnly_KeyPress;
            tboxhonornoofhourspercutoff.KeyPress += NumericOnly_KeyPress;
            tboxotherrateperhour.KeyPress += NumericOnly_KeyPress;
            tboxothernooofhourspercutoff.KeyPress += NumericOnly_KeyPress;
            tboxsssloan.KeyPress += NumericOnly_KeyPress;
            tboxpagibigloan.KeyPress += NumericOnly_KeyPress;
            tboxfacultysavingdepoit.KeyPress += NumericOnly_KeyPress;
            tboxfacultysavingsloan.KeyPress += NumericOnly_KeyPress;
            tboxsalaryloan.KeyPress += NumericOnly_KeyPress;
            tboxotherloan.KeyPress += NumericOnly_KeyPress;
        }

        private void InitializeTextChangedEvents()
        {
            // Add TextChanged events for automatic calculation
            tboxbasicrateperhour.TextChanged += IncomeInput_TextChanged;
            tboxbasicnoofhourspercutoff.TextChanged += IncomeInput_TextChanged;
            tboxhonorrateperhour.TextChanged += IncomeInput_TextChanged;
            tboxhonornoofhourspercutoff.TextChanged += IncomeInput_TextChanged;
            tboxotherrateperhour.TextChanged += IncomeInput_TextChanged;
            tboxothernooofhourspercutoff.TextChanged += IncomeInput_TextChanged;
        }

        private void NumericOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits, decimal point, and control characters
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains('.'))
            {
                e.Handled = true;
            }
        }

        private void IncomeInput_TextChanged(object sender, EventArgs e)
        {
            // Automatically calculate income per cutoff when inputs change
            CalculateBasicIncome();
            CalculateHonorariumIncome();
            CalculateOtherIncome();
            CalculateGrossIncome();
            CalculateRegularDeductions();
        }

        private void CalculateBasicIncome()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(tboxbasicrateperhour.Text) &&
                    !string.IsNullOrWhiteSpace(tboxbasicnoofhourspercutoff.Text))
                {
                    double rate = Convert.ToDouble(tboxbasicrateperhour.Text);
                    double hours = Convert.ToDouble(tboxbasicnoofhourspercutoff.Text);
                    double income = rate * hours;
                    tboxbasicincomepercutoff.Text = income.ToString("F2");
                }
                else
                {
                    tboxbasicincomepercutoff.Text = "0.00";
                }
            }
            catch
            {
                tboxbasicincomepercutoff.Text = "0.00";
            }
        }

        private void CalculateHonorariumIncome()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(tboxhonorrateperhour.Text) &&
                    !string.IsNullOrWhiteSpace(tboxhonornoofhourspercutoff.Text))
                {
                    double rate = Convert.ToDouble(tboxhonorrateperhour.Text);
                    double hours = Convert.ToDouble(tboxhonornoofhourspercutoff.Text);
                    double income = rate * hours;
                    tboxhonorincompercutoff.Text = income.ToString("F2");
                }
                else
                {
                    tboxhonorincompercutoff.Text = "0.00";
                }
            }
            catch
            {
                tboxhonorincompercutoff.Text = "0.00";
            }
        }

        private void CalculateOtherIncome()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(tboxotherrateperhour.Text) &&
                    !string.IsNullOrWhiteSpace(tboxothernooofhourspercutoff.Text))
                {
                    double rate = Convert.ToDouble(tboxotherrateperhour.Text);
                    double hours = Convert.ToDouble(tboxothernooofhourspercutoff.Text);
                    double income = rate * hours;
                    tboxotherincompercutoff.Text = income.ToString("F2");
                }
                else
                {
                    tboxotherincompercutoff.Text = "0.00";
                }
            }
            catch
            {
                tboxotherincompercutoff.Text = "0.00";
            }
        }

        private void CalculateGrossIncome()
        {
            try
            {
                double basicIncome = string.IsNullOrWhiteSpace(tboxbasicincomepercutoff.Text) ? 0 : Convert.ToDouble(tboxbasicincomepercutoff.Text);
                double honorIncome = string.IsNullOrWhiteSpace(tboxhonorincompercutoff.Text) ? 0 : Convert.ToDouble(tboxhonorincompercutoff.Text);
                double otherIncome = string.IsNullOrWhiteSpace(tboxotherincompercutoff.Text) ? 0 : Convert.ToDouble(tboxotherincompercutoff.Text);

                double grossIncome = basicIncome + honorIncome + otherIncome;
                tboxsummaryincgrossincome.Text = grossIncome.ToString("F2");
            }
            catch
            {
                tboxsummaryincgrossincome.Text = "0.00";
            }
        }

        private void CalculateRegularDeductions()
        {
            try
            {
                double grossIncome = string.IsNullOrWhiteSpace(tboxsummaryincgrossincome.Text) ? 0 : Convert.ToDouble(tboxsummaryincgrossincome.Text);

                // Calculate SSS Contribution
                double sssContribution = CalculateSSS(grossIncome);
                tboxsssconti.Text = sssContribution.ToString("F2");

                // Calculate PhilHealth Contribution
                double philHealthContribution = CalculatePhilHealth(grossIncome);
                tboxphilhealthcontri.Text = philHealthContribution.ToString("F2");

                // Pag-IBIG Contribution is fixed at 200.00 (already set)

                // Calculate Income Tax
                double incomeTax = CalculateIncomeTax(grossIncome);
                tboxincometaxcontri.Text = incomeTax.ToString("F2");
            }
            catch
            {
                tboxsssconti.Text = "0.00";
                tboxphilhealthcontri.Text = "0.00";
                tboxincometaxcontri.Text = "0.00";
            }
        }

        private double CalculateSSS(double grossIncome)
        {
            // SSS Contribution Table (based on actual government standards)
            if (grossIncome <= 3250) return 135.00;
            else if (grossIncome <= 3750) return 157.50;
            else if (grossIncome <= 4250) return 180.00;
            else if (grossIncome <= 4750) return 202.50;
            else if (grossIncome <= 5250) return 225.00;
            else if (grossIncome <= 5750) return 247.50;
            else if (grossIncome <= 6250) return 270.00;
            else if (grossIncome <= 6750) return 292.50;
            else if (grossIncome <= 7250) return 315.00;
            else if (grossIncome <= 7750) return 337.50;
            else if (grossIncome <= 8250) return 360.00;
            else if (grossIncome <= 8750) return 382.50;
            else if (grossIncome <= 9250) return 405.00;
            else if (grossIncome <= 9750) return 427.50;
            else if (grossIncome <= 10250) return 450.00;
            else if (grossIncome <= 10750) return 472.50;
            else if (grossIncome <= 11250) return 495.00;
            else if (grossIncome <= 11750) return 517.50;
            else if (grossIncome <= 12250) return 540.00;
            else if (grossIncome <= 12750) return 562.50;
            else if (grossIncome <= 13250) return 585.00;
            else if (grossIncome <= 13750) return 607.50;
            else if (grossIncome <= 14250) return 630.00;
            else if (grossIncome <= 14750) return 652.50;
            else if (grossIncome <= 15250) return 675.00;
            else if (grossIncome <= 15750) return 697.50;
            else if (grossIncome <= 16250) return 720.00;
            else if (grossIncome <= 16750) return 742.50;
            else if (grossIncome <= 17250) return 765.00;
            else if (grossIncome <= 17750) return 787.50;
            else if (grossIncome <= 18250) return 810.00;
            else if (grossIncome <= 18750) return 832.50;
            else if (grossIncome <= 19250) return 855.00;
            else if (grossIncome <= 19750) return 877.50;
            else if (grossIncome <= 20250) return 900.00;
            else if (grossIncome <= 20750) return 922.50;
            else if (grossIncome <= 21250) return 945.00;
            else if (grossIncome <= 21750) return 967.50;
            else if (grossIncome <= 22250) return 990.00;
            else if (grossIncome <= 22750) return 1012.50;
            else if (grossIncome <= 23250) return 1035.00;
            else if (grossIncome <= 23750) return 1057.50;
            else if (grossIncome <= 24250) return 1080.00;
            else if (grossIncome <= 24750) return 1102.50;
            else return 1125.00; // For income above 24750
        }

        private double CalculatePhilHealth(double grossIncome)
        {
            // PhilHealth Contribution: 3% of monthly basic salary, split between employer and employee
            // Employee share is 1.5% of monthly basic salary
            double philHealthShare = grossIncome * 0.015;

            // Minimum contribution
            if (philHealthShare < 225.00)
                return 225.00;
            // Maximum contribution
            else if (philHealthShare > 1125.00)
                return 1125.00;
            else
                return philHealthShare;
        }

        private double CalculateIncomeTax(double grossIncome)
        {
            // Income Tax based on TRAIN Law (simplified)
            double taxableIncome = grossIncome;

            if (taxableIncome <= 20833)
                return 0.00;
            else if (taxableIncome <= 33333)
                return (taxableIncome - 20833) * 0.15;
            else if (taxableIncome <= 66667)
                return 1875.00 + ((taxableIncome - 33333) * 0.20);
            else if (taxableIncome <= 166667)
                return 8541.80 + ((taxableIncome - 66667) * 0.25);
            else if (taxableIncome <= 666667)
                return 33541.80 + ((taxableIncome - 166667) * 0.30);
            else
                return 183541.80 + ((taxableIncome - 666667) * 0.35);
        }

        private void ButtGrossInc_Click(object sender, EventArgs e)
        {
            try
            {
                // Just refresh all calculations
                CalculateBasicIncome();
                CalculateHonorariumIncome();
                CalculateOtherIncome();
                CalculateGrossIncome();
                CalculateRegularDeductions();

                MessageBox.Show("Gross Income calculated successfully!", "Calculation Complete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Gross Income calculation: " + ex.Message, "Calculation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtNetInc_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if Gross Income has been calculated
                if (string.IsNullOrWhiteSpace(tboxsummaryincgrossincome.Text) ||
                    Convert.ToDouble(tboxsummaryincgrossincome.Text) == 0)
                {
                    MessageBox.Show("Please enter income data first. Gross Income will be calculated automatically.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double grossIncome = Convert.ToDouble(tboxsummaryincgrossincome.Text);

                // Get regular deductions
                double sss = Convert.ToDouble(tboxsssconti.Text);
                double philHealth = Convert.ToDouble(tboxphilhealthcontri.Text);
                double pagIbig = Convert.ToDouble(tboxpagibigcontri.Text);
                double incomeTax = Convert.ToDouble(tboxincometaxcontri.Text);

                // Get other deductions
                double otherDeductions = GetOtherDeductions();

                // Calculate total deductions
                double totalDeductions = sss + philHealth + pagIbig + incomeTax + otherDeductions;
                tboxtotaldeductions.Text = totalDeductions.ToString("F2");

                // Calculate Net Income
                double netIncome = grossIncome - totalDeductions;
                tboxsummaryincomNETincome.Text = netIncome.ToString("F2");

                MessageBox.Show($"Net Income calculated successfully!\n\nGross Income: ₱{grossIncome:F2}\nTotal Deductions: ₱{totalDeductions:F2}\nNet Income: ₱{netIncome:F2}",
                    "Calculation Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Net Income calculation: " + ex.Message, "Calculation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double GetOtherDeductions()
        {
            double total = 0;

            try
            {
                if (!string.IsNullOrWhiteSpace(tboxsssloan.Text))
                    total += Convert.ToDouble(tboxsssloan.Text);

                if (!string.IsNullOrWhiteSpace(tboxpagibigloan.Text))
                    total += Convert.ToDouble(tboxpagibigloan.Text);

                if (!string.IsNullOrWhiteSpace(tboxfacultysavingdepoit.Text))
                    total += Convert.ToDouble(tboxfacultysavingdepoit.Text);

                if (!string.IsNullOrWhiteSpace(tboxfacultysavingsloan.Text))
                    total += Convert.ToDouble(tboxfacultysavingsloan.Text);

                if (!string.IsNullOrWhiteSpace(tboxsalaryloan.Text))
                    total += Convert.ToDouble(tboxsalaryloan.Text);

                if (!string.IsNullOrWhiteSpace(tboxotherloan.Text))
                    total += Convert.ToDouble(tboxotherloan.Text);
            }
            catch
            {
                // Ignore conversion errors for empty fields
            }

            return total;
        }

        private void ButtNew_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear all input textboxes
                tboxempnum.Clear();
                tboxdepartment.Clear();
                tboxbasicrateperhour.Clear();
                tboxbasicnoofhourspercutoff.Clear();
                tboxhonorrateperhour.Clear();
                tboxhonornoofhourspercutoff.Clear();
                tboxotherrateperhour.Clear();
                tboxothernooofhourspercutoff.Clear();
                tboxsssloan.Clear();
                tboxpagibigloan.Clear();
                tboxfacultysavingdepoit.Clear();
                tboxfacultysavingsloan.Clear();
                tboxsalaryloan.Clear();
                tboxotherloan.Clear();

                // Reset computed fields
                tboxbasicincomepercutoff.Text = "0.00";
                tboxhonorincompercutoff.Text = "0.00";
                tboxotherincompercutoff.Text = "0.00";
                tboxsummaryincgrossincome.Text = "0.00";
                tboxsssconti.Text = "0.00";
                tboxphilhealthcontri.Text = "0.00";
                tboxpagibigcontri.Text = "200.00";
                tboxincometaxcontri.Text = "0.00";
                tboxtotaldeductions.Text = "0.00";
                tboxsummaryincomNETincome.Text = "0.00";

                MessageBox.Show("All fields have been cleared.", "New Entry",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error clearing fields: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate required fields
                if (string.IsNullOrWhiteSpace(tboxempnum.Text))
                {
                    MessageBox.Show("Please enter Employee Number.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(tboxdepartment.Text))
                {
                    MessageBox.Show("Please enter Department.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("Payroll data saved successfully!\n\n" +
                    $"Employee: {tboxempnum.Text}\n" +
                    $"Department: {tboxdepartment.Text}\n" +
                    $"Gross Income: ₱{tboxsummaryincgrossincome.Text}\n" +
                    $"Net Income: ₱{tboxsummaryincomNETincome.Text}",
                    "Save Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Update functionality would be implemented here with database connection.\n" +
                    "Current data can be modified and saved again.",
                    "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ButtNew_Click_1(object sender, EventArgs e)
        {

        }
    }
}
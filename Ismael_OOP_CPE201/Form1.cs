using System;
using System.Windows.Forms;

namespace PayrollApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ================= BUTTON EVENTS =================

        private void btnGrossIncome_Click(object sender, EventArgs e)
        {
            CalculateGrossIncome();
        }

        private void btnNetIncome_Click(object sender, EventArgs e)
        {
            CalculateNetIncome();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        // ================= GROSS INCOME =================

        private void CalculateGrossIncome()
        {
            bool isValid = true;
            string errorMessage = "";

            double basicRate = 0, basicHours = 0;
            double honorRate = 0, honorHours = 0;
            double otherRate = 0, otherHours = 0;

            // VALIDATION
            if (string.IsNullOrWhiteSpace(txtBasicRate.Text) ||
                string.IsNullOrWhiteSpace(txtBasicHours.Text) ||
                string.IsNullOrWhiteSpace(txtHonorariumRate.Text) ||
                string.IsNullOrWhiteSpace(txtHonorariumHours.Text) ||
                string.IsNullOrWhiteSpace(txtOtherRate.Text) ||
                string.IsNullOrWhiteSpace(txtOtherHours.Text))
            {
                isValid = false;
                errorMessage = "Please fill in all required fields.";
            }
            else
            {
                if (!double.TryParse(txtBasicRate.Text, out basicRate))
                {
                    isValid = false;
                    errorMessage = "Invalid Basic Rate.";
                }
                else if (!double.TryParse(txtBasicHours.Text, out basicHours))
                {
                    isValid = false;
                    errorMessage = "Invalid Basic Hours.";
                }
                else if (!double.TryParse(txtHonorariumRate.Text, out honorRate))
                {
                    isValid = false;
                    errorMessage = "Invalid Honorarium Rate.";
                }
                else if (!double.TryParse(txtHonorariumHours.Text, out honorHours))
                {
                    isValid = false;
                    errorMessage = "Invalid Honorarium Hours.";
                }
                else if (!double.TryParse(txtOtherRate.Text, out otherRate))
                {
                    isValid = false;
                    errorMessage = "Invalid Other Rate.";
                }
                else if (!double.TryParse(txtOtherHours.Text, out otherHours))
                {
                    isValid = false;
                    errorMessage = "Invalid Other Hours.";
                }
                else if (basicRate < 0 || basicHours < 0 ||
                         honorRate < 0 || honorHours < 0 ||
                         otherRate < 0 || otherHours < 0)
                {
                    isValid = false;
                    errorMessage = "Values must be positive.";
                }
            }

            // COMPUTATION
            if (isValid)
            {
                double basicIncome = basicRate * basicHours;
                double honorIncome = honorRate * honorHours;
                double otherIncome = otherRate * otherHours;

                double grossIncome = basicIncome + honorIncome + otherIncome;

                txtBasicIncome.Text = basicIncome.ToString("F2");
                txtHonorariumIncome.Text = honorIncome.ToString("F2");
                txtOtherIncome.Text = otherIncome.ToString("F2");
                txtGrossIncome.Text = grossIncome.ToString("F2");

                // DEFAULT DEDUCTIONS
                txtSSS.Text = "450.00";
                txtPhilHealth.Text = "375.00";
                txtPagIbig.Text = "200.00";
                txtIncomeTax.Text = "525.00";
            }
            else
            {
                MessageBox.Show(errorMessage, "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= NET INCOME =================

        private void CalculateNetIncome()
        {
            bool isValid = true;
            string errorMessage = "";

            double sss = 0, phil = 0, pagibig = 0, tax = 0, other = 0, gross = 0;

            // VALIDATION
            if (string.IsNullOrWhiteSpace(txtGrossIncome.Text))
            {
                isValid = false;
                errorMessage = "Please calculate Gross Income first.";
            }
            else if (!double.TryParse(txtGrossIncome.Text, out gross))
            {
                isValid = false;
                errorMessage = "Invalid Gross Income.";
            }
            else if (!double.TryParse(txtSSS.Text, out sss) ||
                     !double.TryParse(txtPhilHealth.Text, out phil) ||
                     !double.TryParse(txtPagIbig.Text, out pagibig) ||
                     !double.TryParse(txtIncomeTax.Text, out tax))
            {
                isValid = false;
                errorMessage = "Invalid deduction values.";
            }
            else if (sss < 0 || phil < 0 || pagibig < 0 || tax < 0)
            {
                isValid = false;
                errorMessage = "Deductions cannot be negative.";
            }
            else
            {
                // OPTIONAL OTHER DEDUCTIONS
                if (!string.IsNullOrWhiteSpace(txtOtherDeductions.Text))
                {
                    if (!double.TryParse(txtOtherDeductions.Text, out other))
                    {
                        isValid = false;
                        errorMessage = "Invalid Other Deductions.";
                    }
                    else if (other < 0)
                    {
                        isValid = false;
                        errorMessage = "Other Deductions cannot be negative.";
                    }
                }
            }

            // COMPUTATION
            if (isValid)
            {
                double totalDeductions = sss + phil + pagibig + tax + other;
                double netIncome = gross - totalDeductions;

                txtTotalDeductions.Text = totalDeductions.ToString("F2");
                txtNetIncome.Text = netIncome.ToString("F2");

                if (netIncome < 0)
                {
                    DialogResult result = MessageBox.Show(
                        "Net income is negative. Continue?",
                        "Warning",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.No)
                    {
                        txtTotalDeductions.Clear();
                        txtNetIncome.Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show(errorMessage, "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= CLEAR =================

        private void ClearAllFields()
        {
            txtBasicRate.Clear();
            txtBasicHours.Clear();
            txtHonorariumRate.Clear();
            txtHonorariumHours.Clear();
            txtOtherRate.Clear();
            txtOtherHours.Clear();

            txtBasicIncome.Clear();
            txtHonorariumIncome.Clear();
            txtOtherIncome.Clear();
            txtGrossIncome.Clear();

            txtSSS.Clear();
            txtPhilHealth.Clear();
            txtPagIbig.Clear();
            txtIncomeTax.Clear();
            txtOtherDeductions.Clear();

            txtTotalDeductions.Clear();
            txtNetIncome.Clear();
        }
    }
}
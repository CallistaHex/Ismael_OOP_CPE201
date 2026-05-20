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
    public partial class Lesson3Activity : Form
    {
        
        private const decimal LIBRARY_FEE = 1500.00m;
        private const decimal EXAM_BOOK_FEE = 4500.00m;
        private const decimal CISCO_LAB_FEE = 2500.00m;
        private const decimal TUITION_PER_UNIT = 8.00m;
        private const decimal COMPUTER_LAB_FEE = 3000.00m; 
        private const decimal SAP_FEE = 2000.00m; 
        private const decimal INSTALLMENT_CHARGE_RATE = 0.05m; 

        
        private List<CourseRow> courseRows;

        public Lesson3Activity()
        {
            InitializeComponent();
            InitializeCustomComponents();
            SetupEventHandlers();
            DisableCreditUnitTextBoxes();
        }

        private void InitializeCustomComponents()
        {
        
            courseRows = new List<CourseRow>();

        
            MapCourseRows();


            SetupComboBoxes();

          
            dateTimePicker1.Value = new DateTime(2025, 4, 4);

         
            MakeFeeTextBoxesReadOnly();

       
            modeofpay.ReadOnly = true;
            modeofpay.Text = "Installment";
        }

        private void MapCourseRows()
        {
            
            courseRows.Add(new CourseRow
            {
                CourseCode = corcode1,
                Section = section1,
                Description = coursedesc1,
                LecUnit = Leclab1,
                LabUnit = labun1,
                CredUnits = creduni1,
                Time = time1,
                Day = day1,
                Room = room1,
                RowNumber = rownum1
            });

            
            courseRows.Add(new CourseRow
            {
                CourseCode = corcode2,
                Section = section2,
                Description = coursedesc2,
                LecUnit = leclab2,
                LabUnit = labun2,
                CredUnits = creduni2,
                Time = time2,
                Day = day2,
                Room = room2,
                RowNumber = rownum2
            });

           
            courseRows.Add(new CourseRow
            {
                CourseCode = corcode3,
                Section = section3,
                Description = coursedesc3,
                LecUnit = leclab3,
                LabUnit = labun3,
                CredUnits = creduni3,
                Time = time3,
                Day = day3,
                Room = room3,
                RowNumber = rownum3
            });

           
            courseRows.Add(new CourseRow
            {
                CourseCode = corcode4,
                Section = section4,
                Description = coursedesc4,
                LecUnit = leclab4,
                LabUnit = labun4,
                CredUnits = creduni4,
                Time = time4,
                Day = day4,
                Room = room4,
                RowNumber = rownum4
            });

           
            courseRows.Add(new CourseRow
            {
                CourseCode = corcode5,
                Section = section5,
                Description = coursedesc5,
                LecUnit = leclab5,
                LabUnit = labun5,
                CredUnits = creduni5,
                Time = time5,
                Day = day5,
                Room = room5,
                RowNumber = rownum5
            });

            
            courseRows.Add(new CourseRow
            {
                CourseCode = corcode6,
                Section = section6,
                Description = coursedesc6,
                LecUnit = leclab6,
                LabUnit = labun6,
                CredUnits = creduni6,
                Time = time6,
                Day = day6,
                Room = room6,
                RowNumber = rownum6
            });

            
            courseRows.Add(new CourseRow
            {
                CourseCode = corcode7,
                Section = section7,
                Description = coursedesc7,
                LecUnit = leclab7,
                LabUnit = labun7,
                CredUnits = creduni7,
                Time = time7,
                Day = day7,
                Room = room7,
                RowNumber = rownum7
            });
        }

        private void SetupComboBoxes()
        {
            // Programs ComboBox
            programscombobx.Items.AddRange(new string[]
            {
                "BS Information Technology",
                "BS Computer Science",
                "BS Mechanical Engineering",
                "BS Computer Engineering",
                "BS Electrical Engineering",
                "BS Industrial Engineering"
            });

            // Year Level ComboBox
            comboyrlev.Items.AddRange(new string[]
            {
                "1st Year",
                "2nd Year",
                "3rd Year",
                "4th Year",
                "5th Year"
            });

            // Scholar ComboBox
            comboscholar.Items.AddRange(new string[]
            {
                "None",
                "Academic Scholar (20%)",
                "Presidential Scholar (50%)",
                "Athletic Scholar (30%)",
                "Dean's Lister (10%)"
            });

            // Mode ComboBox
            comboBox1.Items.AddRange(new string[]
            {
                "Installment",
                
            });

            // Set default values
            comboscholar.SelectedIndex = 0;
            comboyrlev.SelectedIndex = 0;
        }

        private void SetupEventHandlers()
        {
            // Attach event handlers for credit unit calculation
            foreach (var row in courseRows)
            {
                if (row.LecUnit != null)
                {
                    row.LecUnit.TextChanged += (s, e) => CalculateCredUnits(row);
                    row.LecUnit.Leave += (s, e) => ValidateNumericInput(row.LecUnit);
                }
                if (row.LabUnit != null)
                {
                    row.LabUnit.TextChanged += (s, e) => CalculateCredUnits(row);
                    row.LabUnit.Leave += (s, e) => ValidateNumericInput(row.LabUnit);
                }
            }
        }

        private void DisableCreditUnitTextBoxes()
        {
            foreach (var row in courseRows)
            {
                if (row.CredUnits != null)
                {
                    row.CredUnits.ReadOnly = true;
                    row.CredUnits.BackColor = Color.LightGray;
                    row.CredUnits.TabStop = false;
                }
            }
        }

        private void MakeFeeTextBoxesReadOnly()
        {
            // Make all fee display textboxes read-only
            Tottuitionfee.ReadOnly = true;
            MiscFee.ReadOnly = true;
            tot_oth_fee.ReadOnly = true;
            tottuitionandfees.ReadOnly = true;
            downpay.ReadOnly = true;
            installmentcharge.ReadOnly = true;
            firstinstall.ReadOnly = true;
            secinstall.ReadOnly = true;
            thirdinstall.ReadOnly = true;
            amount_due.ReadOnly = true;
            grandtot.ReadOnly = true;
            discount.ReadOnly = true;
            totalcreduni.ReadOnly = true;
            totalcreduni.BackColor = Color.LightGray;

            // Set background colors
            Tottuitionfee.BackColor = Color.White;
            MiscFee.BackColor = Color.White;
            tot_oth_fee.BackColor = Color.White;
            tottuitionandfees.BackColor = Color.White;
            downpay.BackColor = Color.White;
            installmentcharge.BackColor = Color.White;
            firstinstall.BackColor = Color.White;
            secinstall.BackColor = Color.White;
            thirdinstall.BackColor = Color.White;
            amount_due.BackColor = Color.White;
            grandtot.BackColor = Color.White;
            discount.BackColor = Color.White;

            // Set default values for other fees
            complabfee.Text = COMPUTER_LAB_FEE.ToString("F2");
            Sapfee.Text = SAP_FEE.ToString("F2");
            ciscolabfee.Text = CISCO_LAB_FEE.ToString("F2");
            exambookletfee.Text = EXAM_BOOK_FEE.ToString("F2");
            MiscFee.Text = LIBRARY_FEE.ToString("F2");

            // Make these fee textboxes read-only as they're fixed
            complabfee.ReadOnly = true;
            Sapfee.ReadOnly = true;
            ciscolabfee.ReadOnly = true;
            exambookletfee.ReadOnly = true;
            MiscFee.ReadOnly = true;

            complabfee.BackColor = Color.LightGray;
            Sapfee.BackColor = Color.LightGray;
            ciscolabfee.BackColor = Color.LightGray;
            exambookletfee.BackColor = Color.LightGray;
            MiscFee.BackColor = Color.LightGray;
        }

        private void ValidateNumericInput(TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
                return;

            if (!decimal.TryParse(textBox.Text, out _))
            {
                MessageBox.Show("Please enter a valid number.", "Invalid Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox.Text = "0";
            }
        }

        private void CalculateCredUnits(CourseRow row)
        {
            decimal lecUnit = 0;
            decimal labUnit = 0;

            decimal.TryParse(row.LecUnit?.Text ?? "0", out lecUnit);
            decimal.TryParse(row.LabUnit?.Text ?? "0", out labUnit);

            decimal credUnits = lecUnit + labUnit;

            if (row.CredUnits != null)
            {
                row.CredUnits.Text = credUnits.ToString("F1");
            }

            // Calculate and update total credit units
            UpdateTotalCreditUnits();
        }

        private void UpdateTotalCreditUnits()
        {
            decimal totalCredUnits = 0;

            foreach (var row in courseRows)
            {
                decimal credUnit = 0;
                decimal.TryParse(row.CredUnits?.Text ?? "0", out credUnit);
                totalCredUnits += credUnit;
            }

            totalcreduni.Text = totalCredUnits.ToString("F1");
        }

        private decimal CalculateTotalLectureUnits()
        {
            decimal totalLecUnits = 0;
            foreach (var row in courseRows)
            {
                decimal lecUnit = 0;
                decimal.TryParse(row.LecUnit?.Text ?? "0", out lecUnit);
                totalLecUnits += lecUnit;
            }
            return totalLecUnits;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ComputeAllFees();
        }

        private void ComputeAllFees()
        {
            try
            {
                // Get total credit units
                decimal totalCredUnits = 0;
                decimal.TryParse(totalcreduni.Text, out totalCredUnits);

                // Calculate Total Tuition Fee (Lecture Units * 8)
                decimal totalLecUnits = CalculateTotalLectureUnits();
                decimal totalTuition = totalLecUnits * TUITION_PER_UNIT;
                Tottuitionfee.Text = totalTuition.ToString("F2");

                // Get other fees
                decimal miscFee = LIBRARY_FEE;
                decimal compLabFee = decimal.Parse(complabfee.Text);
                decimal sapFee = decimal.Parse(Sapfee.Text);
                decimal ciscoFee = decimal.Parse(ciscolabfee.Text);
                decimal examFee = decimal.Parse(exambookletfee.Text);

                // Calculate Total Other Fees
                decimal totalOtherFees = miscFee + compLabFee + sapFee + ciscoFee + examFee;
                tot_oth_fee.Text = totalOtherFees.ToString("F2");

                // Calculate Total Tuition and Fees
                decimal totalTuitionAndFees = totalTuition + totalOtherFees;
                tottuitionandfees.Text = totalTuitionAndFees.ToString("F2");

                // Calculate Installment Charge (5% of Total Tuition and Fees)
                decimal installmentChargeAmount = totalTuitionAndFees * INSTALLMENT_CHARGE_RATE;
                installmentcharge.Text = installmentChargeAmount.ToString("F2");

                // Calculate Amount Due (Total Tuition and Fees + Installment Charge)
                decimal amountDue = totalTuitionAndFees + installmentChargeAmount;
                amount_due.Text = amountDue.ToString("F2");

              

                // Calculate Installments (remaining balance divided by 3)
                decimal remainingBalance = amountDue;
                decimal installmentAmount = remainingBalance / 3;
                firstinstall.Text = installmentAmount.ToString("F2");
                secinstall.Text = installmentAmount.ToString("F2");
                thirdinstall.Text = installmentAmount.ToString("F2");

                // Calculate Discount based on scholarship
                decimal discountAmount = CalculateDiscount(totalTuitionAndFees);
                discount.Text = discountAmount.ToString("F2");

                // Calculate Grand Total
                decimal grandTotal = totalTuitionAndFees - discountAmount;
                grandtot.Text = grandTotal.ToString("F2");

                // Update Grand Total in amount due if discount applied
                if (discountAmount > 0)
                {
                    amount_due.Text = grandTotal.ToString("F2");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error computing fees: {ex.Message}", "Computation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal CalculateDiscount(decimal totalTuitionAndFees)
        {
            string scholarType = comboscholar.SelectedItem?.ToString() ?? "None";

            switch (scholarType)
            {
                case "Academic Scholar (20%)":
                    return totalTuitionAndFees * 0.20m;
                case "Presidential Scholar (50%)":
                    return totalTuitionAndFees * 0.50m;
                case "Athletic Scholar (30%)":
                    return totalTuitionAndFees * 0.30m;
                case "Dean's Lister (10%)":
                    return totalTuitionAndFees * 0.10m;
                default:
                    return 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearStudentInformation();
        }

        private void ClearStudentInformation()
        {
            // Clear student information fields
            studentnametxtbox.Clear();
            studentnumbertxtbox.Clear();

            if (programscombobx.Items.Count > 0)
                programscombobx.SelectedIndex = -1;

            if (comboyrlev.Items.Count > 0)
                comboyrlev.SelectedIndex = 0;

            if (comboscholar.Items.Count > 0)
                comboscholar.SelectedIndex = 0;

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = -1;

            dateTimePicker1.Value = new DateTime(2025, 4, 4);

            MessageBox.Show("Student information cleared successfully.", "Clear Complete",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Exit application
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearScheduleOfCourses();
        }

        private void ClearScheduleOfCourses()
        {
            foreach (var row in courseRows)
            {
                row.CourseCode?.Clear();
                row.Section?.Clear();
                row.Description?.Clear();
                row.LecUnit?.Clear();
                row.LabUnit?.Clear();
                row.Time?.Clear();
                row.Day?.Clear();
                row.Room?.Clear();

                // CredUnits will be cleared automatically via calculation
                if (row.CredUnits != null)
                {
                    row.CredUnits.Clear();
                }
            }

            // Clear total credit units
            totalcreduni.Clear();

            // Clear all fee computations
            Tottuitionfee.Clear();
            tot_oth_fee.Clear();
            tottuitionandfees.Clear();
            installmentcharge.Clear();
            amount_due.Clear();
            downpay.Clear();
            firstinstall.Clear();
            secinstall.Clear();
            thirdinstall.Clear();
            discount.Clear();
            grandtot.Clear();

            MessageBox.Show("Schedule of courses cleared successfully.", "Clear Complete",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Lesson3Activity_Load(object sender, EventArgs e)
        {
            // Initialize form
            this.Text = "Student Assessment Fee Calculator - Quiz1";
        }

        // Event handlers that were in the designer
        private void studentnametxtbox_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void studentnumbertxtbox_TextChanged(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label21_Click(object sender, EventArgs e) { }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox144_TextChanged(object sender, EventArgs e)
        {

        }

        private void programscombobx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {

        }

        private void downpay_TextChanged(object sender, EventArgs e)
        {

        }
    }

    // Helper class to organize course row controls
    public class CourseRow
    {
        public TextBox CourseCode { get; set; }
        public TextBox Section { get; set; }
        public TextBox Description { get; set; }
        public TextBox LecUnit { get; set; }
        public TextBox LabUnit { get; set; }
        public TextBox CredUnits { get; set; }
        public TextBox Time { get; set; }
        public TextBox Day { get; set; }
        public TextBox Room { get; set; }
        public TextBox RowNumber { get; set; }
    }
}
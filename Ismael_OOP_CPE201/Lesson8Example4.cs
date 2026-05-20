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
    public partial class Lesson8Example4 : Form
    {
        // Accumulated totals for multiple transactions
        int totalQuantity = 0;
        double totalDiscount = 0;
        double totalDiscountedAmount = 0;
        
        // Current focused textbox for calculator input
        TextBox currentTextBox = null;

        public Lesson8Example4()
        {
            InitializeComponent();
            SetupForm();
        }
        // FORM SETUP FUNCTION (Lines 28-44) 
        // Purpose: Configures the form when it first loads

        private void SetupForm()
        {
            // Disable read-only textboxes so users can't type in them
            textbox_itemname.Enabled = false;
            textbox_price.Enabled = false;
            textbox_discountamount.Enabled = false;
            textbox_discountedamount.Enabled = false;
            textbox_totalquantity.Enabled = false;
            textbox_totaldiscountgiven.Enabled = false;
            textbox_totaldiscountedamount.Enabled = false;
            textbox_change.Enabled = false;

            // Make form start in center of screen and maximized
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;

            // Set default discount option to "No Discount"
            radiobutton_nodiscount.Checked = true;
        }

        // ==================== FORM LOAD EVENT (Lines 46-51) ====================
        // Purpose: Sets up which textboxes work with the calculator buttons
        private void Lesson8Example4_Load(object sender, EventArgs e)
        {
            // When user clicks into quantity or cashrendered, set currentTextBox to that box
            textbox_quantity.Enter += (s, ev) => currentTextBox = textbox_quantity;
            textbox_cashrendered.Enter += (s, ev) => currentTextBox = textbox_cashrendered;
        }

        #region Discount Calculation Functions (Lines 53-124)
        // ==================== DISCOUNT CALCULATION SECTION ====================

        /// <summary>
        /// Universal discount calculator - eliminates code redundancy
        /// Called by all discount radio buttons
        /// </summary>
        private void CalculateDiscount(double discountRate)
        {
            if (!ValidateQuantityAndPrice()) return;  // Exit if quantity/price missing

            int qty = Convert.ToInt32(textbox_quantity.Text);
            double price = Convert.ToDouble(textbox_price.Text);

            double subtotal = qty * price;
            double discountAmount = subtotal * discountRate;
            double discountedAmount = subtotal - discountAmount;

            textbox_discountamount.Text = discountAmount.ToString("N2");
            textbox_discountedamount.Text = discountedAmount.ToString("N2");
        }

        /// <summary>
        /// Removes discount when "No Discount" is selected
        /// </summary>
        private void RemoveDiscount()
        {
            if (!ValidateQuantityAndPrice()) return;

            int qty = Convert.ToInt32(textbox_quantity.Text);
            double price = Convert.ToDouble(textbox_price.Text);

            double subtotal = qty * price;

            textbox_discountamount.Text = "0.00";
            textbox_discountedamount.Text = subtotal.ToString("N2");
        }

        /// <summary>
        /// Validates that quantity and price fields are filled
        /// Returns true if both fields have valid numbers
        /// </summary>
        private bool ValidateQuantityAndPrice()
        {
            if (string.IsNullOrWhiteSpace(textbox_quantity.Text) ||
                string.IsNullOrWhiteSpace(textbox_price.Text))
                return false;

            return double.TryParse(textbox_quantity.Text, out _) &&
                   double.TryParse(textbox_price.Text, out _);
        }

        /// <summary>
        /// Updates the accumulated totals display
        /// Shows running totals of quantity, discount, and discounted amount
        /// </summary>
        private void UpdateTotalsDisplay()
        {
            textbox_totalquantity.Text = totalQuantity.ToString();
            textbox_totaldiscountgiven.Text = totalDiscount.ToString("N2");
            textbox_totaldiscountedamount.Text = totalDiscountedAmount.ToString("N2");
        }

        /// <summary>
        /// Clears only the current transaction fields (not the accumulated totals)
        /// Use this when starting a new transaction but keeping running totals
        /// </summary>
        private void ClearCurrentTransaction()
        {
            textbox_itemname.Clear();
            textbox_price.Clear();
            textbox_quantity.Clear();
            textbox_discountamount.Clear();
            textbox_discountedamount.Clear();
            textbox_cashrendered.Clear();
            textbox_change.Clear();
            radiobutton_nodiscount.Checked = true;
        }

        /// <summary>
        /// Clears everything including accumulated totals
        /// Use this to reset the entire POS system
        /// </summary>
        private void ClearAllTransactions()
        {
            ClearCurrentTransaction();

            totalQuantity = 0;
            totalDiscount = 0;
            totalDiscountedAmount = 0;

            UpdateTotalsDisplay();
        }

        /// <summary>
        /// Sets the item name and price when a product image is clicked
        /// </summary>
        private void SelectMenuItem(string itemName, double price)
        {
            textbox_itemname.Text = itemName;
            textbox_price.Text = price.ToString("N2");

            // Reset discount when new item is selected
            radiobutton_nodiscount.Checked = true;
        }
        #endregion

        #region Radio Button Events
        // ==================== DISCOUNT RADIO BUTTON SECTION ====================
        // These fire when user selects a discount option

        private void radiobutton_seniorcitizen_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobutton_seniorcitizen.Checked)
                CalculateDiscount(0.20); // 20% Senior Citizen discount
        }

        private void radiobutton_withdisccard_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobutton_withdisccard.Checked)
                CalculateDiscount(0.10); // 10% Discount Card
        }

        private void radiobutton_employeedisc_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobutton_employeedisc.Checked)
                CalculateDiscount(0.15); // 15% Employee Discount
        }

        private void radiobutton_nodiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobutton_nodiscount.Checked)
                RemoveDiscount(); // No discount applied
        }
        #endregion

        #region Button Events (Lines 163-215)
        // ==================== MAIN BUTTON SECTION ====================

        // CALCULATE BUTTON - Processes the transaction
        private void calcbutt_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate all required fields
                if (!ValidateAllFields())
                {
                    MessageBox.Show("Please complete all fields before calculating.",
                        "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get current transaction values
                int qty = Convert.ToInt32(textbox_quantity.Text);
                double discountAmount = Convert.ToDouble(textbox_discountamount.Text);
                double discountedAmount = Convert.ToDouble(textbox_discountedamount.Text);
                double cashRendered = Convert.ToDouble(textbox_cashrendered.Text);

                // Check if cash is sufficient
                if (cashRendered < discountedAmount)
                {
                    MessageBox.Show($"Insufficient cash! You need at least {discountedAmount:N2}",
                        "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Calculate change
                double change = cashRendered - discountedAmount;
                textbox_change.Text = change.ToString("N2");

                // Accumulate totals
                totalQuantity += qty;
                totalDiscount += discountAmount;
                totalDiscountedAmount += discountedAmount;

                // Update display
                UpdateTotalsDisplay();

                // Prepare for next transaction
                ClearCurrentTransaction();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing transaction: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // NEW BUTTON - Clears current transaction but keeps running totals
        private void newbut_Click(object sender, EventArgs e)
        {
            ClearCurrentTransaction();
        }

        // CANCEL BUTTON - Clears everything including totals
        private void cancelbut_Click(object sender, EventArgs e)
        {
            ClearAllTransactions();
        }

        // EXIT BUTTON - Closes the application
        private void exitbut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Calculator Button Events (Lines 217-291)
        // ==================== ON-SCREEN CALCULATOR SECTION ====================

        // Handles number buttons (0-9)
        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (currentTextBox != null)
            {
                currentTextBox.Text += button.Text;
                currentTextBox.Focus();
            }
        }

        // Handles operator buttons (+, -, *, /)
        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (currentTextBox != null)
            {
                currentTextBox.Text += button.Text;
                currentTextBox.Focus();
            }
        }

        // Handles decimal point button
        private void buttondot_Click(object sender, EventArgs e)
        {
            if (currentTextBox != null)
            {
                if (!currentTextBox.Text.Contains("."))
                {
                    currentTextBox.Text += ".";
                }
                currentTextBox.Focus();
            }
        }

        // ENTER button - Triggers the calculate function
        private void enterbut_Click(object sender, EventArgs e)
        {
            calcbutt_Click(sender, e);
        }

        // Individual operator button handlers
        private void dividebut_Click(object sender, EventArgs e) { OperatorButton_Click(sender, e); }
        private void multibut_Click(object sender, EventArgs e) { OperatorButton_Click(sender, e); }
        private void minusbut_Click(object sender, EventArgs e) { OperatorButton_Click(sender, e); }
        private void plusbut_Click(object sender, EventArgs e) { OperatorButton_Click(sender, e); }

        // Individual number button handlers
        private void button0_Click(object sender, EventArgs e) { NumberButton_Click(sender, e); }
        private void button1_Click(object sender, EventArgs e) { NumberButton_Click(sender, e); }
        private void button2_Click(object sender, EventArgs e) { NumberButton_Click(sender, e); }
        private void button3_Click(object sender, EventArgs e) { NumberButton_Click(sender, e); }
        private void button4_Click(object sender, EventArgs e) { NumberButton_Click(sender, e); }
        private void button5_Click(object sender, EventArgs e) { NumberButton_Click(sender, e); }
        private void button6_Click(object sender, EventArgs e) { NumberButton_Click(sender, e); }
        private void button7_Click(object sender, EventArgs e) { NumberButton_Click(sender, e); }
        private void button8_Click(object sender, EventArgs e) { NumberButton_Click(sender, e); }
        private void button19_Click(object sender, EventArgs e) { NumberButton_Click(sender, e); }
        #endregion

        #region Validation Functions (Lines 293-306)
        // ==================== VALIDATION SECTION ====================

        /// <summary>
        /// Validates all required fields are filled for calculation
        /// Returns true if all fields have valid data
        /// </summary>
        private bool ValidateAllFields()
        {
            return !string.IsNullOrWhiteSpace(textbox_itemname.Text) &&
                   !string.IsNullOrWhiteSpace(textbox_price.Text) &&
                   !string.IsNullOrWhiteSpace(textbox_quantity.Text) &&
                   !string.IsNullOrWhiteSpace(textbox_discountedamount.Text) &&
                   !string.IsNullOrWhiteSpace(textbox_cashrendered.Text) &&
                   int.TryParse(textbox_quantity.Text, out _) &&
                   double.TryParse(textbox_price.Text, out _) &&
                   double.TryParse(textbox_discountedamount.Text, out _) &&
                   double.TryParse(textbox_cashrendered.Text, out _);
        }
        #endregion

        #region PictureBox Click Events (Lines 308-405)
        // ==================== PRODUCT SELECTION SECTION ====================
        // These fire when user clicks on product images
        // Each sets a different item name and price

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SelectMenuItem("Combo Meal A", 200.00);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SelectMenuItem("Combo Meal B", 320.00);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SelectMenuItem("Breakfast Meal 1", 260.00);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            SelectMenuItem("Breakfast Meal 2", 670.00);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            SelectMenuItem("Chicken Meal A", 890.00);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            SelectMenuItem("Combo Meal A", 242.00);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            SelectMenuItem("Combo Meal B", 256.00);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            SelectMenuItem("Breakfast Meal 1", 180.00);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            SelectMenuItem("Breakfast Meal 2", 980.00);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            SelectMenuItem("Chicken Meal A", 199.00);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            SelectMenuItem("Combo Meal A", 209.00);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            SelectMenuItem("Combo Meal B", 189.00);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            SelectMenuItem("Breakfast Meal 1", 219.00);
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            SelectMenuItem("Breakfast Meal 2", 229.00);
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            SelectMenuItem("Chicken Meal A", 179.00);
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            SelectMenuItem("Combo Meal B", 229.00);
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            SelectMenuItem("Combo Meal A", 219.00);
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            SelectMenuItem("Breakfast Meal 1", 189.00);
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            SelectMenuItem("Breakfast Meal 2", 209.00);
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            SelectMenuItem("Chicken Meal A", 199.00);
        }
        #endregion

        #region Label Click Events (Lines 407-432)
        // ==================== EMPTY EVENT HANDLERS ====================
        // These are required by the designer but don't do anything
        // They exist because the form designer automatically creates click events for labels

        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }
        private void label11_Click(object sender, EventArgs e) { }
        private void label12_Click(object sender, EventArgs e) { }
        private void label13_Click(object sender, EventArgs e) { }
        private void label14_Click(object sender, EventArgs e) { }
        private void label15_Click(object sender, EventArgs e) { }
        private void label16_Click(object sender, EventArgs e) { }
        private void label17_Click(object sender, EventArgs e) { }
        private void label18_Click(object sender, EventArgs e) { }
        private void label19_Click(object sender, EventArgs e) { }
        private void label20_Click(object sender, EventArgs e) { }
        private void label21_Click(object sender, EventArgs e) { }
        private void label24_Click(object sender, EventArgs e) { }
        private void label25_Click(object sender, EventArgs e) { }
        private void label27_Click(object sender, EventArgs e) { }
        private void label31_Click(object sender, EventArgs e) { }
        #endregion

        #region TextBox Events (Lines 434-445)
        // ==================== EMPTY TEXTBOX EVENT HANDLERS ====================
        // These are required by the designer but don't do anything

        private void textbox_itemname_TextChanged(object sender, EventArgs e) { }
        private void textbox_discountamount_TextChanged(object sender, EventArgs e) { }
        private void textbox_discountedamount_TextChanged(object sender, EventArgs e) { }
        private void textbox_totalquantity_TextChanged(object sender, EventArgs e) { }
        private void textbox_totaldiscountgiven_TextChanged(object sender, EventArgs e) { }
        private void textbox_totaldiscountedamount_TextChanged(object sender, EventArgs e) { }
        private void textbox_change_TextChanged(object sender, EventArgs e) { }
        private void textbox_cashrendered_TextChanged(object sender, EventArgs e) { }
        private void groupBox2_Enter(object sender, EventArgs e) { }
        #endregion
    }
}
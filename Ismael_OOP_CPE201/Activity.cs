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
    public partial class Activity : Form
    {
        // Constants for bundle prices and discounts
        private const decimal BUNDLE_A_PRICE = 1000.00m;
        private const decimal BUNDLE_B_PRICE = 1299.00m;
        private const decimal BUNDLE_A_DISCOUNT_PERCENT = 20m;
        private const decimal BUNDLE_B_DISCOUNT_PERCENT = 15m;

        public Activity()
        {
            InitializeComponent();
            textbox_price.Enabled = false;
            textBox_discount.Enabled = false;
            textBox_discountedPrice.Enabled = false;
            textBox_change.Enabled = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobutton_foodbundleA.Checked)
            {
                this.BackColor = Color.LightCyan;

                pictureBox1.Image = Image.FromFile(@"C:\Users\Levi\source\repos\Ismael_OOP_CPE201\Ismael_OOP_CPE201\Resources\Screenshot 2026-01-30 175953.png");

                // Set Bundle A checkboxes
                SetCheckBoxes(true,
                    checkbox_A_friedchicken, checkbox_A_fries, checkbox_A_coke,
                    checkbox_A_sidedishes, checkbox_A_pizza);

                // Clear Bundle B checkboxes
                SetCheckBoxes(false,
                    checkbox_B_halohalo, checkbox_B_friedchicken, checkbox_B_carbonara,
                    checkbox_B_fries, checkbox_B_pizza);

                // Calculate and display prices
                CalculateAndDisplayPrices(BUNDLE_A_PRICE, BUNDLE_A_DISCOUNT_PERCENT);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Activity3_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGoldenrodYellow;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void checkbox_A_friedchicken_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobutton_foodbundleB.Checked)
            {
                this.BackColor = Color.LightBlue;

                pictureBox1.Image = Image.FromFile(@"C:\Users\Levi\source\repos\Ismael_OOP_CPE201\Ismael_OOP_CPE201\Resources\Screenshot 2026-01-28 1813231.png");

                // Clear Bundle A checkboxes
                SetCheckBoxes(false,
                    checkbox_A_friedchicken, checkbox_A_fries, checkbox_A_coke,
                    checkbox_A_sidedishes, checkbox_A_pizza);

                // Set Bundle B checkboxes
                SetCheckBoxes(true,
                    checkbox_B_halohalo, checkbox_B_friedchicken, checkbox_B_carbonara,
                    checkbox_B_fries, checkbox_B_pizza);

                // Calculate and display prices
                CalculateAndDisplayPrices(BUNDLE_B_PRICE, BUNDLE_B_DISCOUNT_PERCENT);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_payment_TextChanged(object sender, EventArgs e)
        {
            // Recalculate change when payment amount changes
            if (!string.IsNullOrEmpty(textBox_discountedPrice.Text))
            {
                string priceText = textBox_discountedPrice.Text.Replace("₱", "").Replace(",", "").Trim();
                if (decimal.TryParse(priceText, out decimal discountedPrice))
                {
                    CalculateChange(discountedPrice);
                }
            }
        }

        /// <summary>
        /// Sets multiple checkboxes to a specified state
        /// </summary>
        /// <param name="isChecked">The state to set (checked or unchecked)</param>
        /// <param name="checkBoxes">Array of checkboxes to modify</param>
        private void SetCheckBoxes(bool isChecked, params CheckBox[] checkBoxes)
        {
            foreach (var checkBox in checkBoxes)
            {
                checkBox.Checked = isChecked;
            }
        }

        /// <summary>
        /// Calculates and displays the price, discount, discounted price, and change
        /// </summary>
        /// <param name="price">Original price</param>
        /// <param name="discountPercent">Discount percentage</param>
        private void CalculateAndDisplayPrices(decimal price, decimal discountPercent)
        {
            // Calculate discount amount
            decimal discountAmount = price * (discountPercent / 100);
            
            // Calculate discounted price
            decimal discountedPrice = price - discountAmount;

            // Display original price
            textbox_price.Text = $"₱{price:N2}";

            // Display discount amount
            textBox_discount.Text = $"({discountPercent}%) ₱{discountAmount:N2}";

            // Display discounted price
            textBox_discountedPrice.Text = $"₱{discountedPrice:N2}";

            // Clear payment and change fields
            textBox_payment.Clear();
            textBox_change.Clear();
        }

        /// <summary>
        /// Calculates and displays the change based on payment amount
        /// </summary>
        /// <param name="discountedPrice">The discounted price to calculate change from</param>
        private void CalculateChange(decimal discountedPrice)
        {
            // Try to parse payment amount
            string paymentText = textBox_payment.Text.Replace("₱", "").Replace(",", "").Trim();
            
            if (decimal.TryParse(paymentText, out decimal paymentAmount) && paymentAmount > 0)
            {
                if (paymentAmount >= discountedPrice)
                {
                    decimal change = paymentAmount - discountedPrice;
                    textBox_change.Text = $"₱{change:N2}";
                }
                else
                {
                    textBox_change.Text = "Insufficient payment";
                }
            }
            else
            {
                textBox_change.Clear();
            }
        }

        /// <summary>
        /// Clears all selections and resets the form
        /// </summary>
        private void ClearAll()
        {
            this.BackColor = Color.White;

            // Uncheck radio buttons
            radiobutton_foodbundleA.Checked = false;
            radiobutton_foodbundleB.Checked = false;

            // Clear picture
            pictureBox1.Image = null;

            // Clear all checkboxes
            SetCheckBoxes(false,
                checkbox_A_friedchicken, checkbox_A_fries, checkbox_A_coke,
                checkbox_A_sidedishes, checkbox_A_pizza,
                checkbox_B_halohalo, checkbox_B_friedchicken, checkbox_B_carbonara,
                checkbox_B_fries, checkbox_B_pizza);

            // Clear all text boxes
            textbox_price.Clear();
            textBox_discount.Clear();
            textBox_discountedPrice.Clear();
            textBox_payment.Clear();
            textBox_change.Clear();
        }
    }
}
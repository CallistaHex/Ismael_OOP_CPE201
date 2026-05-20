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
    public partial class Lesson8Example5 : Form
    {
        // Constants for bundle prices and discounts
        private const decimal BUNDLE_A_PRICE = 1000.00m;
        private const decimal BUNDLE_B_PRICE = 1299.00m;
        private const decimal BUNDLE_A_DISCOUNT_PERCENT = 20m;
        private const decimal BUNDLE_B_DISCOUNT_PERCENT = 15m;

        private decimal total_amount = 0;
        private int total_qty = 0;
        private Dictionary<CheckBox, decimal> itemPrices = new Dictionary<CheckBox, decimal>();

        public Lesson8Example5()
        {
            InitializeComponent();
            InitializeForm();
            InitializeItemPrices();
        }

        private void InitializeItemPrices()
        {
            // Initialize all item prices
            itemPrices.Add(checkBox1, 280.00m);
            itemPrices.Add(checkBox2, 320.00m);
            itemPrices.Add(checkBox3, 350.00m);
            itemPrices.Add(checkBox4, 380.00m);
            itemPrices.Add(checkBox5, 420.00m);
            itemPrices.Add(checkBox6, 330.00m);
            itemPrices.Add(checkBox7, 400.00m);
            itemPrices.Add(checkBox8, 450.00m);
            itemPrices.Add(checkBox9, 390.00m);
            itemPrices.Add(checkBox10, 480.00m);
            itemPrices.Add(checkBox11, 370.00m);
            itemPrices.Add(checkBox12, 500.00m);
            itemPrices.Add(checkBox13, 360.00m);
            itemPrices.Add(checkBox14, 380.00m);
            itemPrices.Add(checkBox15, 340.00m);
            itemPrices.Add(checkBox16, 360.00m);
            itemPrices.Add(checkBox17, 450.00m);
            itemPrices.Add(checkBox18, 400.00m);
            itemPrices.Add(checkBox19, 300.00m);
            itemPrices.Add(checkBox20, 520.00m);
        }

        private void InitializeForm()
        {
            // Disable textboxes that shouldn't be editable
            textbox_price.Enabled = false;
            textbox_discountamount.Enabled = false;
            textbox_discountedamount.Enabled = false;
            textbox_change.Enabled = false;
            textbox_totalbills.Enabled = false;
            textbox_totalquantity.Enabled = false;
        }

        #region Radio Button Events

        // Food Bundle A RadioButton
        private void radiobutton_foodbundleA_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobutton_foodbundleA.Checked)
            {
                HandleBundleSelection(
                    Color.LightCyan,
                    Properties.Resources.Screenshot_2026_02_17_130532,
                    BUNDLE_A_PRICE,
                    BUNDLE_A_DISCOUNT_PERCENT,
                    true,  // isBundleA
                    false  // clearBundleB
                );
            }
        }

        // Food Bundle B RadioButton
        private void radiobutton_foodbundleB_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobutton_foodbundleB.Checked)
            {
                HandleBundleSelection(
                    Color.LightBlue,
                    Properties.Resources.Screenshot_2026_02_17_132402,
                    BUNDLE_B_PRICE,
                    BUNDLE_B_DISCOUNT_PERCENT,
                    false, // isBundleA
                    true   // clearBundleA
                );
            }
        }

        #endregion

        #region Bundle Helper Methods

        /// <summary>
        /// Handles bundle selection with all necessary UI updates
        /// </summary>
        private void HandleBundleSelection(Color backColor, Image bundleImage, decimal price, decimal discountPercent, bool isBundleA, bool isBundleB)
        {
            try
            {
                this.BackColor = backColor;

                // Set bundle image
                pictureBox21.Image = bundleImage;

                // Clear all individual item checkboxes
                ResetAllItemCheckboxes();

                // Set bundle checkboxes based on selection
                SetBundleCheckboxes(isBundleA, isBundleB);

                // Calculate and display prices
                CalculateAndDisplayPrices(price, discountPercent);

                // Add to listbox
                string bundleName = isBundleA ? "Food Bundle A" : "Food Bundle B";
                listbox_display.Items.Add($"{bundleName}          {textbox_price.Text}");
                listbox_display.Items.Add($"          Discount Amount:          {textbox_discountamount.Text}");

                textbox_quantity.Text = "0";
                textbox_quantity.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading bundle: " + ex.Message);
            }
        }

        /// <summary>
        /// Sets checkboxes for either Bundle A or Bundle B
        /// </summary>
        private void SetBundleCheckboxes(bool isBundleA, bool isBundleB)
        {
            // Set Bundle A checkboxes
            checkbox_A_friedchicken.Checked = isBundleA;
            checkbox_A_fries.Checked = isBundleA;
            checkbox_A_coke.Checked = isBundleA;
            checkbox_A_sidedishes.Checked = isBundleA;
            checkbox_A_pizza.Checked = isBundleA;

            // Set Bundle B checkboxes
            checkbox_B_halohalo.Checked = isBundleB;
            checkbox_B_friedchicken.Checked = isBundleB;
            checkbox_B_carbonara.Checked = isBundleB;
            checkbox_B_fries.Checked = isBundleB;
            checkbox_B_pizza.Checked = isBundleB;
        }

        /// <summary>
        /// Calculates and displays all price-related fields
        /// </summary>
        private void CalculateAndDisplayPrices(decimal price, decimal discountPercent)
        {
            // Calculate discount amount
            decimal discountAmount = price * (discountPercent / 100m);

            // Calculate discounted price per unit
            decimal discountedPricePerUnit = price - discountAmount;

            // Display original price
            textbox_price.Text = price.ToString("F2");

            // Display discount amount
            textbox_discountamount.Text = discountAmount.ToString("F2");

            // Calculate based on quantity
            int qty = 0;
            if (!string.IsNullOrWhiteSpace(textbox_quantity.Text))
            {
                int.TryParse(textbox_quantity.Text, out qty);
            }

            // Calculate total discounted amount
            decimal totalDiscountedAmount = discountedPricePerUnit * qty;
            textbox_discountedamount.Text = totalDiscountedAmount.ToString("F2");

            // Update totals
            total_qty = qty;
            textbox_totalquantity.Text = total_qty.ToString();
            total_amount = totalDiscountedAmount;
            textbox_totalbills.Text = total_amount.ToString("F2");
        }

        /// <summary>
        /// Calculates and displays change amount
        /// </summary>
        private void CalculateChange()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textbox_cashgiven.Text))
                {
                    textbox_change.Text = "";
                    return;
                }

                if (!decimal.TryParse(textbox_cashgiven.Text, out decimal cashGiven))
                {
                    MessageBox.Show("Please enter a valid cash amount.");
                    return;
                }

                if (!decimal.TryParse(textbox_totalbills.Text, out decimal totalBills))
                {
                    MessageBox.Show("Please select items first.");
                    return;
                }

                if (cashGiven < totalBills)
                {
                    MessageBox.Show("Insufficient cash amount!");
                    textbox_change.Text = "Insufficient";
                    return;
                }

                decimal change = cashGiven - totalBills;
                textbox_change.Text = change.ToString("F2");

                // Add transaction details to listbox
                listbox_display.Items.Add($"Total Bills:          {textbox_totalbills.Text}");
                listbox_display.Items.Add($"Cash Given:          {textbox_cashgiven.Text}");
                listbox_display.Items.Add($"Change:          {textbox_change.Text}");
                listbox_display.Items.Add($"Total No. of Items:          {textbox_totalquantity.Text}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating change: " + ex.Message);
            }
        }

        #endregion

        #region Checkbox Event Handlers

        private void checkBox1_CheckedChanged(object sender, EventArgs e) => HandleItemCheckbox(checkBox1);
        private void checkBox2_CheckedChanged(object sender, EventArgs e) => HandleItemCheckbox(checkBox2);
        private void checkBox3_CheckedChanged(object sender, EventArgs e) => HandleItemCheckbox(checkBox3);
        private void checkBox4_CheckedChanged(object sender, EventArgs e) => HandleItemCheckbox(checkBox4);
        private void checkBox5_CheckedChanged(object sender, EventArgs e) => HandleItemCheckbox(checkBox5);
        private void checkBox6_CheckedChanged(object sender, EventArgs e) => HandleItemCheckbox(checkBox6);
        private void checkBox7_CheckedChanged(object sender, EventArgs e) => HandleItemCheckbox(checkBox7);
        private void checkBox8_CheckedChanged(object sender, EventArgs e) => HandleItemCheckbox(checkBox8);
        private void checkBox9_CheckedChanged(object sender, EventArgs e) => HandleItemCheckbox(checkBox9);
        private void checkBox10_CheckedChanged(object sender, EventArgs e) => HandleItemCheckbox(checkBox10);
        private void checkBox11_CheckedChanged(object sender, EventArgs e) => HandleItemCheckbox(checkBox11);
        private void checkBox12_CheckedChanged(object sender, EventArgs e) => HandleItemCheckbox(checkBox12);
        private void checkBox13_CheckedChanged(object sender, EventArgs e) => HandleItemCheckbox(checkBox13);
        private void checkBox14_CheckedChanged(object sender, EventArgs e) => HandleItemCheckbox(checkBox14);
        private void checkBox15_CheckedChanged(object sender, EventArgs e) => HandleItemCheckbox(checkBox15);
        private void checkBox16_CheckedChanged(object sender, EventArgs e) => HandleItemCheckbox(checkBox16);
        private void checkBox17_CheckedChanged(object sender, EventArgs e) => HandleItemCheckbox(checkBox17);
        private void checkBox18_CheckedChanged(object sender, EventArgs e) => HandleItemCheckbox(checkBox18);
        private void checkBox19_CheckedChanged(object sender, EventArgs e) => HandleItemCheckbox(checkBox19);
        private void checkBox20_CheckedChanged(object sender, EventArgs e) => HandleItemCheckbox(checkBox20);

        // Bundle A checkbox events
        private void checkbox_A_friedchicken_CheckedChanged(object sender, EventArgs e) => HandleBundleCheckboxClick();
        private void checkbox_A_fries_CheckedChanged(object sender, EventArgs e) => HandleBundleCheckboxClick();
        private void checkbox_A_coke_CheckedChanged(object sender, EventArgs e) => HandleBundleCheckboxClick();
        private void checkbox_A_sidedishes_CheckedChanged(object sender, EventArgs e) => HandleBundleCheckboxClick();
        private void checkbox_A_pizza_CheckedChanged(object sender, EventArgs e) => HandleBundleCheckboxClick();

        // Bundle B checkbox events
        private void checkbox_B_halohalo_CheckedChanged(object sender, EventArgs e) => HandleBundleCheckboxClick();
        private void checkbox_B_friedchicken_CheckedChanged(object sender, EventArgs e) => HandleBundleCheckboxClick();
        private void checkbox_B_carbonara_CheckedChanged(object sender, EventArgs e) => HandleBundleCheckboxClick();
        private void checkbox_B_fries_CheckedChanged(object sender, EventArgs e) => HandleBundleCheckboxClick();
        private void checkbox_B_pizza_CheckedChanged(object sender, EventArgs e) => HandleBundleCheckboxClick();

        #endregion

        #region Helper Methods

        /// <summary>
        /// Handles when a bundle sub-item checkbox is clicked
        /// </summary>
        private void HandleBundleCheckboxClick()
        {
            radiobutton_foodbundleA.Checked = false;
            radiobutton_foodbundleB.Checked = false;
            ResetAllItemCheckboxes();
            ClearPriceFields();
        }

        /// <summary>
        /// Handles individual item checkbox selection
        /// </summary>
        private void HandleItemCheckbox(CheckBox checkBox)
        {
            if (checkBox.Checked)
            {
                try
                {
                    // Uncheck bundle selections
                    radiobutton_foodbundleA.Checked = false;
                    radiobutton_foodbundleB.Checked = false;

                    // Clear bundle checkboxes
                    SetBundleCheckboxes(false, false);

                    // Reset other individual checkboxes except the current one
                    ResetOtherItemCheckboxes(checkBox);

                    // Set price for the selected item
                    if (itemPrices.ContainsKey(checkBox))
                    {
                        decimal price = itemPrices[checkBox];
                        CalculateAndDisplayPrices(price, 0); // 0% discount for individual items

                        // Add to listbox
                        string itemName = string.IsNullOrWhiteSpace(checkBox.Text) ?
                            $"Item {GetCheckBoxNumber(checkBox)}" : checkBox.Text;

                        listbox_display.Items.Add($"{itemName}          {textbox_price.Text}");
                        listbox_display.Items.Add($"          Discount Amount:          {textbox_discountamount.Text}");

                        textbox_quantity.Text = "0";
                        textbox_quantity.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error selecting item: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Clears all price-related text fields
        /// </summary>
        private void ClearPriceFields()
        {
            textbox_price.Clear();
            textbox_discountamount.Clear();
            textbox_discountedamount.Clear();
            textbox_totalbills.Clear();
            textbox_totalquantity.Clear();
            textbox_change.Clear();
            textbox_cashgiven.Clear();
            textbox_quantity.Clear();
        }

        /// <summary>
        /// Resets all item checkboxes except the specified one
        /// </summary>
        private void ResetOtherItemCheckboxes(CheckBox excludeCheckBox)
        {
            var allCheckBoxes = new CheckBox[] {
                checkBox1, checkBox2, checkBox3, checkBox4, checkBox5,
                checkBox6, checkBox7, checkBox8, checkBox9, checkBox10,
                checkBox11, checkBox12, checkBox13, checkBox14, checkBox15,
                checkBox16, checkBox17, checkBox18, checkBox19, checkBox20
            };

            foreach (var cb in allCheckBoxes)
            {
                if (cb != excludeCheckBox)
                {
                    cb.Checked = false;
                }
            }
        }

        /// <summary>
        /// Resets all 20 item checkboxes
        /// </summary>
        private void ResetAllItemCheckboxes()
        {
            ResetOtherItemCheckboxes(null);
        }

        /// <summary>
        /// Gets the number of a checkbox based on its reference
        /// </summary>
        private int GetCheckBoxNumber(CheckBox checkBox)
        {
            var checkboxMap = new Dictionary<CheckBox, int>
            {
                { checkBox1, 1 }, { checkBox2, 2 }, { checkBox3, 3 }, { checkBox4, 4 }, { checkBox5, 5 },
                { checkBox6, 6 }, { checkBox7, 7 }, { checkBox8, 8 }, { checkBox9, 9 }, { checkBox10, 10 },
                { checkBox11, 11 }, { checkBox12, 12 }, { checkBox13, 13 }, { checkBox14, 14 }, { checkBox15, 15 },
                { checkBox16, 16 }, { checkBox17, 17 }, { checkBox18, 18 }, { checkBox19, 19 }, { checkBox20, 20 }
            };

            return checkboxMap.ContainsKey(checkBox) ? checkboxMap[checkBox] : 0;
        }

        #endregion

        #region Button Events

        // Quantity TextBox TextChanged
        private void textbox_quantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textbox_price.Text))
                    return;

                if (!decimal.TryParse(textbox_price.Text, out decimal price))
                    return;

                if (!int.TryParse(textbox_quantity.Text, out int qty) || qty < 0)
                {
                    if (qty < 0)
                    {
                        MessageBox.Show("Quantity cannot be negative!");
                        textbox_quantity.Text = "0";
                    }
                    return;
                }

                decimal discountAmount = 0;
                if (!string.IsNullOrWhiteSpace(textbox_discountamount.Text))
                {
                    decimal.TryParse(textbox_discountamount.Text, out discountAmount);
                }

                decimal discountedPricePerUnit = price - discountAmount;
                total_amount = discountedPricePerUnit * qty;
                total_qty = qty;

                textbox_totalquantity.Text = total_qty.ToString();
                textbox_totalbills.Text = total_amount.ToString("F2");
                textbox_discountedamount.Text = total_amount.ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating quantity: " + ex.Message);
            }
        }

        // CALCULATE BILLS Button
        private void button1_Click(object sender, EventArgs e)
        {
            CalculateChange();
        }

        // PRINT TRANSACTION Button
        private void button2_Click(object sender, EventArgs e)
        {
            if (listbox_display.Items.Count == 0)
            {
                MessageBox.Show("No transactions to print.");
                return;
            }

            transac printForm = new transac();
            printForm.reciept_list.Items.AddRange(this.listbox_display.Items);
            printForm.Show();
        }

        // REMOVE ORDER Button
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (listbox_display.SelectedIndex >= 0)
                {
                    listbox_display.Items.RemoveAt(listbox_display.SelectedIndex);
                }
                else
                {
                    MessageBox.Show("Please select an item to remove.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing item: " + ex.Message);
            }
        }

        // NEW Button
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Clear bundle selections
                radiobutton_foodbundleA.Checked = false;
                radiobutton_foodbundleB.Checked = false;

                // Clear all checkboxes
                SetBundleCheckboxes(false, false);
                ResetAllItemCheckboxes();

                // Clear all text fields
                ClearPriceFields();

                // Clear listbox
                listbox_display.Items.Clear();

                // Reset totals
                total_amount = 0;
                total_qty = 0;

                // Reset UI
                this.BackColor = Color.LightGoldenrodYellow;
                pictureBox21.Image = null;

                textbox_quantity.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error starting new order: " + ex.Message);
            }
        }

        // EXIT Button
        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?",
                "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        #endregion

        private void Activity4_PrintFrm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGoldenrodYellow;

            // Re-initialize form state
            textbox_price.Enabled = false;
            textbox_discountedamount.Enabled = false;
            textbox_change.Enabled = false;
            textbox_totalbills.Enabled = false;
            textbox_discountamount.Enabled = false;
            textbox_totalquantity.Enabled = false;

            SetBundleCheckboxes(false, false);
            ResetAllItemCheckboxes();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
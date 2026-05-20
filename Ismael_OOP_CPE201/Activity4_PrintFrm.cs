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
    public partial class Activity4_PrintFrm : Form
    {
        private double total_amount = 0;
        private int total_qty = 0;
        private Dictionary<CheckBox, double> itemPrices = new Dictionary<CheckBox, double>();   
        
        public Activity4_PrintFrm()
        {
            InitializeComponent();
            InitializeForm();
            InitializeItemPrices();
        }
        
        private void InitializeItemPrices()
        {
            // Initialize all item prices
            itemPrices.Add(checkBox1, 280.00);
            itemPrices.Add(checkBox2, 320.00);
            itemPrices.Add(checkBox3, 350.00);
            itemPrices.Add(checkBox4, 380.00);
            itemPrices.Add(checkBox5, 420.00);
            itemPrices.Add(checkBox6, 330.00);
            itemPrices.Add(checkBox7, 400.00);
            itemPrices.Add(checkBox8, 450.00);
            itemPrices.Add(checkBox9, 390.00);
            itemPrices.Add(checkBox10, 480.00);
            itemPrices.Add(checkBox11, 370.00);
            itemPrices.Add(checkBox12, 500.00);
            itemPrices.Add(checkBox13, 360.00);
            itemPrices.Add(checkBox14, 380.00);
            itemPrices.Add(checkBox15, 340.00);
            itemPrices.Add(checkBox16, 360.00);
            itemPrices.Add(checkBox17, 450.00);
            itemPrices.Add(checkBox18, 400.00);
            itemPrices.Add(checkBox19, 300.00);
            itemPrices.Add(checkBox20, 520.00);
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

        // Food Bundle A RadioButton
        private void radiobutton_foodbundleA_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobutton_foodbundleA.Checked)
            {
                try
                {
                    this.BackColor = Color.LightCyan;

                    // Use resource image instead of file path
                    pictureBox21.Image = Properties.Resources.Screenshot_2026_02_17_130532;

                    // Set bundle A checkboxes
                    checkbox_A_friedchicken.Checked = true;
                    checkbox_A_fries.Checked = true;
                    checkbox_A_coke.Checked = true;
                    checkbox_A_sidedishes.Checked = true;
                    checkbox_A_pizza.Checked = true;

                    // Clear bundle B checkboxes
                    checkbox_B_halohalo.Checked = false;
                    checkbox_B_friedchicken.Checked = false;
                    checkbox_B_carbonara.Checked = false;
                    checkbox_B_fries.Checked = false;
                    checkbox_B_pizza.Checked = false;

                    // Clear individual item checkboxes
                    ResetAllItemCheckboxes();

                    textbox_price.Text = "1000.00";
                    textbox_discountamount.Text = "200.00";

                    listbox_display.Items.Add(radiobutton_foodbundleA.Text + "          " + textbox_price.Text);
                    listbox_display.Items.Add("          Discount Amount: " + "         " + textbox_discountamount.Text);

                    textbox_quantity.Text = "0";
                    textbox_quantity.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading bundle: " + ex.Message);
                }
            }
        }

        // Food Bundle B RadioButton
        private void radiobutton_foodbundleB_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobutton_foodbundleB.Checked)
            {
                try
                {
                    this.BackColor = Color.LightBlue;

                    // Use resource image instead of file path
                    pictureBox21.Image = Properties.Resources.Screenshot_2026_02_17_132402;

                    // Clear bundle A checkboxes
                    checkbox_A_friedchicken.Checked = false;
                    checkbox_A_fries.Checked = false;
                    checkbox_A_coke.Checked = false;
                    checkbox_A_sidedishes.Checked = false;
                    checkbox_A_pizza.Checked = false;

                    // Set bundle B checkboxes
                    checkbox_B_halohalo.Checked = true;
                    checkbox_B_friedchicken.Checked = true;
                    checkbox_B_carbonara.Checked = true;
                    checkbox_B_fries.Checked = true;
                    checkbox_B_pizza.Checked = true;

                    // Clear individual item checkboxes
                    ResetAllItemCheckboxes();

                    textbox_price.Text = "1299.00";
                    textbox_discountamount.Text = "194.85";

                    listbox_display.Items.Add(radiobutton_foodbundleB.Text + "          " + textbox_price.Text);
                    listbox_display.Items.Add("          Discount Amount: " + "         " + textbox_discountamount.Text);

                    textbox_quantity.Text = "0";
                    textbox_quantity.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading bundle: " + ex.Message);
                }
            }
        }

        // Quantity TextBox TextChanged event
        private void textbox_quantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textbox_price.Text) ||
                    string.IsNullOrWhiteSpace(textbox_quantity.Text))
                {
                    return;
                }

                double price = Convert.ToDouble(textbox_price.Text);
                int qty = Convert.ToInt32(textbox_quantity.Text);

                if (qty < 0)
                {
                    MessageBox.Show("Quantity cannot be negative!");
                    textbox_quantity.Text = "0";
                    return;
                }

                double discount_amount = 0;
                if (!string.IsNullOrWhiteSpace(textbox_discountamount.Text))
                {
                    discount_amount = Convert.ToDouble(textbox_discountamount.Text);
                }

                double discounted_amount = (price - discount_amount) * qty;

                total_qty = qty;
                textbox_totalquantity.Text = total_qty.ToString();

                total_amount = discounted_amount;
                textbox_totalbills.Text = total_amount.ToString("n2");
                textbox_discountedamount.Text = discounted_amount.ToString("n2");
            }
            catch (FormatException)
            {
                // Ignore formatting errors while typing
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating quantity: " + ex.Message);
            }
        }

        // CALCULATE BILLS Button
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textbox_cashgiven.Text))
                {
                    MessageBox.Show("Please enter cash given amount.");
                    return;
                }

                double cash_given = Convert.ToDouble(textbox_cashgiven.Text);
                double total_amountPaid = Convert.ToDouble(textbox_totalbills.Text);

                if (cash_given < total_amountPaid)
                {
                    MessageBox.Show("Insufficient cash amount!");
                    return;
                }

                double change = cash_given - total_amountPaid;

                textbox_change.Text = change.ToString("n2");
                listbox_display.Items.Add("Total Bills: " + "          " + textbox_totalbills.Text);
                listbox_display.Items.Add("Cash Given: " + "          " + textbox_cashgiven.Text);
                listbox_display.Items.Add("Change: " + "          " + textbox_change.Text);
                listbox_display.Items.Add("Total No. of Items: " + "          " + textbox_totalquantity.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numbers in cash given field.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating bills: " + ex.Message);
            }
        }

        // PRINT TRANSACTION Button
        private void button2_Click(object sender, EventArgs e)
        {
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
                // Clear all selections
                radiobutton_foodbundleA.Checked = false;
                radiobutton_foodbundleB.Checked = false;
                
                // Clear bundle checkboxes
                checkbox_A_friedchicken.Checked = false;
                checkbox_A_fries.Checked = false;
                checkbox_A_coke.Checked = false;
                checkbox_A_sidedishes.Checked = false;
                checkbox_A_pizza.Checked = false;

                checkbox_B_halohalo.Checked = false;
                checkbox_B_friedchicken.Checked = false;
                checkbox_B_carbonara.Checked = false;
                checkbox_B_fries.Checked = false;
                checkbox_B_pizza.Checked = false;

                // Clear individual item checkboxes
                ResetAllItemCheckboxes();

                // Clear textboxes
                textbox_price.Text = "";
                textbox_discountamount.Text = "";
                textbox_discountedamount.Text = "";
                textbox_quantity.Text = "";
                textbox_cashgiven.Text = "";
                textbox_change.Text = "";
                textbox_totalbills.Text = "";
                textbox_totalquantity.Text = "";

                // Clear listbox
                listbox_display.Items.Clear();

                // Reset totals
                total_amount = 0;
                total_qty = 0;

                // Reset background color
                this.BackColor = Color.LightGoldenrodYellow;
                
                // Reset picture
                pictureBox21.Image = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error starting new order: " + ex.Message);
            }
        }

        // EXIT Button
        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void ResetAllItemCheckboxes()
        {
            // Reset checkboxes 1-20
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            checkBox10.Checked = false;
            checkBox11.Checked = false;
            checkBox12.Checked = false;
            checkBox13.Checked = false;
            checkBox14.Checked = false;
            checkBox15.Checked = false;
            checkBox16.Checked = false;
            checkBox17.Checked = false;
            checkBox18.Checked = false;
            checkBox19.Checked = false;
            checkBox20.Checked = false;
        }

        private void Activity4_PrintFrm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGoldenrodYellow;

            textbox_price.Enabled = false;
            textbox_discountedamount.Enabled = false;
            textbox_change.Enabled = false;
            textbox_totalbills.Enabled = false;
            textbox_discountamount.Enabled = false;
            textbox_totalquantity.Enabled = false;

            checkbox_A_friedchicken.Checked = false;
            checkbox_A_fries.Checked = false;
            checkbox_A_coke.Checked = false;
            checkbox_A_sidedishes.Checked = false;
            checkbox_A_pizza.Checked = false;

            checkbox_B_halohalo.Checked = false;
            checkbox_B_friedchicken.Checked = false;
            checkbox_B_carbonara.Checked = false;
            checkbox_B_fries.Checked = false;
            checkbox_B_pizza.Checked = false;
        }

        // COMPLETE CHECKBOX EVENT HANDLERS (1-20)

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            HandleItemCheckbox(checkBox1);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            HandleItemCheckbox(checkBox2);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            HandleItemCheckbox(checkBox3);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            HandleItemCheckbox(checkBox4);
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            HandleItemCheckbox(checkBox5);
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            HandleItemCheckbox(checkBox6);
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            HandleItemCheckbox(checkBox7);
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            HandleItemCheckbox(checkBox8);
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            HandleItemCheckbox(checkBox9);
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            HandleItemCheckbox(checkBox10);
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            HandleItemCheckbox(checkBox11);
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            HandleItemCheckbox(checkBox12);
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            HandleItemCheckbox(checkBox13);
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            HandleItemCheckbox(checkBox14);
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            HandleItemCheckbox(checkBox15);
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            HandleItemCheckbox(checkBox16);
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            HandleItemCheckbox(checkBox17);
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            HandleItemCheckbox(checkBox18);
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            HandleItemCheckbox(checkBox19);
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            HandleItemCheckbox(checkBox20);
        }

        // Bundle B checkboxes
        private void checkbox_B_halohalo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_B_halohalo.Checked)
            {
                radiobutton_foodbundleA.Checked = false;
                radiobutton_foodbundleB.Checked = false;
                ResetAllItemCheckboxes();
            }
        }

        private void checkbox_B_friedchicken_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_B_friedchicken.Checked)
            {
                radiobutton_foodbundleA.Checked = false;
                radiobutton_foodbundleB.Checked = false;
                ResetAllItemCheckboxes();
            }
        }

        private void checkbox_B_carbonara_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_B_carbonara.Checked)
            {
                radiobutton_foodbundleA.Checked = false;
                radiobutton_foodbundleB.Checked = false;
                ResetAllItemCheckboxes();
            }
        }

        private void checkbox_B_fries_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_B_fries.Checked)
            {
                radiobutton_foodbundleA.Checked = false;
                radiobutton_foodbundleB.Checked = false;
                ResetAllItemCheckboxes();
            }
        }

        private void checkbox_B_pizza_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_B_pizza.Checked)
            {
                radiobutton_foodbundleA.Checked = false;
                radiobutton_foodbundleB.Checked = false;
                ResetAllItemCheckboxes();
            }
        }

        // Bundle A checkboxes
        private void checkbox_A_friedchicken_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_A_friedchicken.Checked)
            {
                radiobutton_foodbundleA.Checked = false;
                radiobutton_foodbundleB.Checked = false;
                ResetAllItemCheckboxes();
            }
        }

        private void checkbox_A_fries_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_A_fries.Checked)
            {
                radiobutton_foodbundleA.Checked = false;
                radiobutton_foodbundleB.Checked = false;
                ResetAllItemCheckboxes();
            }
        }

        private void checkbox_A_coke_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_A_coke.Checked)
            {
                radiobutton_foodbundleA.Checked = false;
                radiobutton_foodbundleB.Checked = false;
                ResetAllItemCheckboxes();
            }
        }

        private void checkbox_A_sidedishes_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_A_sidedishes.Checked)
            {
                radiobutton_foodbundleA.Checked = false;
                radiobutton_foodbundleB.Checked = false;
                ResetAllItemCheckboxes();
            }
        }

        private void checkbox_A_pizza_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_A_pizza.Checked)
            {
                radiobutton_foodbundleA.Checked = false;
                radiobutton_foodbundleB.Checked = false;
                ResetAllItemCheckboxes();
            }
        }

        // Helper method to handle all item checkboxes
        private void HandleItemCheckbox(CheckBox checkBox)
        {
            if (checkBox.Checked)
            {
                try
                {
                    // Uncheck bundle radio buttons when selecting individual items
                    radiobutton_foodbundleA.Checked = false;
                    radiobutton_foodbundleB.Checked = false;

                    // Clear bundle checkboxes
                    checkbox_A_friedchicken.Checked = false;
                    checkbox_A_fries.Checked = false;
                    checkbox_A_coke.Checked = false;
                    checkbox_A_sidedishes.Checked = false;
                    checkbox_A_pizza.Checked = false;

                    checkbox_B_halohalo.Checked = false;
                    checkbox_B_friedchicken.Checked = false;
                    checkbox_B_carbonara.Checked = false;
                    checkbox_B_fries.Checked = false;
                    checkbox_B_pizza.Checked = false;

                    // Set price based on which checkbox was checked
                    if (itemPrices.ContainsKey(checkBox))
                    {
                        textbox_discountamount.Text = "0.00";
                        textbox_price.Text = itemPrices[checkBox].ToString("F2");

                        // Add to listbox with item name
                        string itemName = checkBox.Text;
                        if (string.IsNullOrEmpty(itemName))
                        {
                            itemName = "Item " + GetCheckBoxNumber(checkBox);
                        }

                        listbox_display.Items.Add(itemName + "          " + textbox_price.Text);

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

        // Helper method to get checkbox number if text is empty
        private int GetCheckBoxNumber(CheckBox checkBox)
        {
            if (checkBox == checkBox1) return 1;
            if (checkBox == checkBox2) return 2;
            if (checkBox == checkBox3) return 3;
            if (checkBox == checkBox4) return 4;
            if (checkBox == checkBox5) return 5;
            if (checkBox == checkBox6) return 6;
            if (checkBox == checkBox7) return 7;
            if (checkBox == checkBox8) return 8;
            if (checkBox == checkBox9) return 9;
            if (checkBox == checkBox10) return 10;
            if (checkBox == checkBox11) return 11;
            if (checkBox == checkBox12) return 12;
            if (checkBox == checkBox13) return 13;
            if (checkBox == checkBox14) return 14;
            if (checkBox == checkBox15) return 15;
            if (checkBox == checkBox16) return 16;
            if (checkBox == checkBox17) return 17;
            if (checkBox == checkBox18) return 18;
            if (checkBox == checkBox19) return 19;
            if (checkBox == checkBox20) return 20;
            return 0;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Optional: Add picture click functionality if needed
        }
    }
}
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
    public partial class Lesson8Example9 : Form
    {
        private double total_amount = 0;
        private int total_qty = 0;
        private Dictionary<CheckBox, double> itemPrices = new Dictionary<CheckBox, double>();

      
        Variables variables = new Variables();
        Price_Item_Values price_discountamount_value = new Price_Item_Values();

        public Lesson8Example9()
        {
            InitializeComponent();
            InitializeForm();
            InitializeItemPrices();
        }

        private void quantityTxtbox()
        {
            textbox_quantity.Text = "0";
            textbox_quantity.Focus();
        }

        private void foodradiobtn()
        {
            radiobutton_foodbundleA.Checked = false;
            radiobutton_foodbundleB.Checked = false;
        }

        private void item_priceValue(string discount_amt, string price_item)
        {
            price_discountamount_value.SetPriceDiscountAmountValue(discount_amt, price_item);
            textbox_price.Text = price_discountamount_value.GetPriceItem();
            textbox_discountamount.Text = price_discountamount_value.GetDiscountAmount();
            variables.price = Convert.ToDouble(textbox_price.Text);
        }

        private void InitializeItemPrices()
        {
          
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

                 
                    pictureBox21.Image = Properties.Resources.Screenshot_2026_02_17_130532;

                    checkbox_A_friedchicken.Checked = true;
                    checkbox_A_fries.Checked = true;
                    checkbox_A_coke.Checked = true;
                    checkbox_A_sidedishes.Checked = true;
                    checkbox_A_pizza.Checked = true;

                 
                    checkbox_B_halohalo.Checked = false;
                    checkbox_B_friedchicken.Checked = false;
                    checkbox_B_carbonara.Checked = false;
                    checkbox_B_fries.Checked = false;
                    checkbox_B_pizza.Checked = false;

                 
                    ResetAllItemCheckboxes();

            
                    price_discountamount_value.SetPriceDiscountAmountValue("200.00", "1000.00");
                    GetPriceDiscountAmount();

                    listbox_display.Items.Add(radiobutton_foodbundleA.Text + "          " + textbox_price.Text);
                    listbox_display.Items.Add("          Discount Amount: " + "         " + textbox_discountamount.Text);

                    quantityTxtbox();
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

                  
                    pictureBox21.Image = Properties.Resources.Screenshot_2026_02_17_132402;

                 
                    checkbox_A_friedchicken.Checked = false;
                    checkbox_A_fries.Checked = false;
                    checkbox_A_coke.Checked = false;
                    checkbox_A_sidedishes.Checked = false;
                    checkbox_A_pizza.Checked = false;

                 
                    checkbox_B_halohalo.Checked = true;
                    checkbox_B_friedchicken.Checked = true;
                    checkbox_B_carbonara.Checked = true;
                    checkbox_B_fries.Checked = true;
                    checkbox_B_pizza.Checked = true;

                 
                    ResetAllItemCheckboxes();

             
                    price_discountamount_value.SetPriceDiscountAmountValue("194.85", "1299.00");
                    GetPriceDiscountAmount();

                    listbox_display.Items.Add(radiobutton_foodbundleB.Text + "          " + textbox_price.Text);
                    listbox_display.Items.Add("          Discount Amount: " + "         " + textbox_discountamount.Text);

                    quantityTxtbox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading bundle: " + ex.Message);
                }
            }
        }

        private void GetPriceDiscountAmount()
        {
            textbox_price.Text = price_discountamount_value.GetPriceItem();
            textbox_discountamount.Text = price_discountamount_value.GetDiscountAmount();
            variables.price = Convert.ToDouble(textbox_price.Text);
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
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating quantity: " + ex.Message);
            }
        }

        // Calculate Button
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

        // Print transaction Button
        private void button2_Click(object sender, EventArgs e)
        {
            transac printForm = new transac();
            printForm.reciept_list.Items.AddRange(this.listbox_display.Items);
            printForm.Show();
        }

        // remove order Button
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

        // new Button
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
           
                radiobutton_foodbundleA.Checked = false;
                radiobutton_foodbundleB.Checked = false;

         
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

                ResetAllItemCheckboxes();

                
                textbox_price.Text = "";
                textbox_discountamount.Text = "";
                textbox_discountedamount.Text = "";
                textbox_quantity.Text = "";
                textbox_cashgiven.Text = "";
                textbox_change.Text = "";
                textbox_totalbills.Text = "";
                textbox_totalquantity.Text = "";

                listbox_display.Items.Clear();

                total_amount = 0;
                total_qty = 0;

                this.BackColor = Color.LightGoldenrodYellow;

                pictureBox21.Image = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error starting new order: " + ex.Message);
            }
        }

        // exit Button
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

     

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                foodradiobtn();
                item_priceValue("0.00", "500.99");
                listbox_display.Items.Add(checkBox1.Text + "          " + textbox_price.Text);
                quantityTxtbox();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                foodradiobtn();
                item_priceValue("0.00", "550.00");
                listbox_display.Items.Add(checkBox2.Text + "          " + textbox_price.Text);
                quantityTxtbox();
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                foodradiobtn();
                item_priceValue("0.00", "600.99");
                listbox_display.Items.Add(checkBox3.Text + "          " + textbox_price.Text);
                quantityTxtbox();
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                foodradiobtn();
                item_priceValue("0.00", "700.50");
                listbox_display.Items.Add(checkBox4.Text + "          " + textbox_price.Text);
                quantityTxtbox();
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                foodradiobtn();
                item_priceValue("0.00", "500.00");
                listbox_display.Items.Add(checkBox5.Text + "          " + textbox_price.Text);
                quantityTxtbox();
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                foodradiobtn();
                item_priceValue("0.00", "750.00");
                listbox_display.Items.Add(checkBox6.Text + "          " + textbox_price.Text);
                quantityTxtbox();
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                foodradiobtn();
                item_priceValue("0.00", "700.00");
                listbox_display.Items.Add(checkBox7.Text + "          " + textbox_price.Text);
                quantityTxtbox();
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            {
                foodradiobtn();
                item_priceValue("0.00", "850.00");
                listbox_display.Items.Add(checkBox8.Text + "          " + textbox_price.Text);
                quantityTxtbox();
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked)
            {
                foodradiobtn();
                item_priceValue("0.00", "450.00");
                listbox_display.Items.Add(checkBox9.Text + "          " + textbox_price.Text);
                quantityTxtbox();
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked)
            {
                foodradiobtn();
                item_priceValue("0.00", "650.00");
                listbox_display.Items.Add(checkBox10.Text + "          " + textbox_price.Text);
                quantityTxtbox();
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked)
            {
                foodradiobtn();
                item_priceValue("0.00", "575.00");
                listbox_display.Items.Add(checkBox11.Text + "          " + textbox_price.Text);
                quantityTxtbox();
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked)
            {
                foodradiobtn();
                item_priceValue("0.00", "575.00");
                listbox_display.Items.Add(checkBox12.Text + "          " + textbox_price.Text);
                quantityTxtbox();
            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked)
            {
                foodradiobtn();
                item_priceValue("0.00", "575.00");
                listbox_display.Items.Add(checkBox13.Text + "          " + textbox_price.Text);
                quantityTxtbox();
            }
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.Checked)
            {
                foodradiobtn();
                item_priceValue("0.00", "575.00");
                listbox_display.Items.Add(checkBox14.Text + "          " + textbox_price.Text);
                quantityTxtbox();
            }
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox15.Checked)
            {
                foodradiobtn();
                item_priceValue("0.00", "575.00");
                listbox_display.Items.Add(checkBox15.Text + "          " + textbox_price.Text);
                quantityTxtbox();
            }
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox16.Checked)
            {
                foodradiobtn();
                item_priceValue("0.00", "575.00");
                listbox_display.Items.Add(checkBox16.Text + "          " + textbox_price.Text);
                quantityTxtbox();
            }
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox17.Checked)
            {
                foodradiobtn();
                item_priceValue("0.00", "575.00");
                listbox_display.Items.Add(checkBox17.Text + "          " + textbox_price.Text);
                quantityTxtbox();
            }
        }

        private void checkBox18_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox18.Checked)
            {
                foodradiobtn();
                item_priceValue("0.00", "575.00");
                listbox_display.Items.Add(checkBox18.Text + "          " + textbox_price.Text);
                quantityTxtbox();
            }
        }

        private void checkBox19_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox19.Checked)
            {
                foodradiobtn();
                item_priceValue("0.00", "575.00");
                listbox_display.Items.Add(checkBox19.Text + "          " + textbox_price.Text);
                quantityTxtbox();
            }
        }

        private void checkBox20_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox20.Checked)
            {
                foodradiobtn();
                item_priceValue("0.00", "575.00");
                listbox_display.Items.Add(checkBox20.Text + "          " + textbox_price.Text);
                quantityTxtbox();
            }
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
   
        }
    }
}
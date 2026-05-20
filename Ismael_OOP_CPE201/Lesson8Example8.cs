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
    public partial class Lesson8Example8 : Form
    {
      
        Price_Item_Values price_item_value = new Price_Item_Values();
        Variables variables = new Variables();

        public Lesson8Example8()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
          
            textbox_itemname.Enabled = false;
            textbox_price.Enabled = false;
            textbox_discountamount.Enabled = false;
            textbox_discountedamount.Enabled = false;
            textbox_totalquantity.Enabled = false;
            textbox_totaldiscountgiven.Enabled = false;
            textbox_totaldiscountedamount.Enabled = false;
            textbox_change.Enabled = false;

            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;

           
            radiobutton_nodiscount.Checked = true;
        }

        private void Activity2_Load(object sender, EventArgs e)
        {
      
        }

        #region Discount Calculation Functions

        private void quantity_price_Convert()
        {
            if (!string.IsNullOrWhiteSpace(textbox_quantity.Text))
                variables.quantity = Convert.ToInt32(textbox_quantity.Text);

            if (!string.IsNullOrWhiteSpace(textbox_price.Text))
                variables.price = Convert.ToDouble(textbox_price.Text);
        }

       
        private void computation_Formula_and_DisplayData()
        {
            variables.discounted_amt = (variables.quantity * variables.price) - variables.discount_amt;
            textbox_discountamount.Text = variables.discount_amt.ToString("F2");
            textbox_discountedamount.Text = variables.discounted_amt.ToString("F2");
        }

        public void GetPriceItemValue()
        {
            textbox_itemname.Text = price_item_value.GetItemName();
            textbox_price.Text = price_item_value.GetPrice();
        }

   
        private bool ValidateQuantityAndPrice()
        {
            if (string.IsNullOrWhiteSpace(textbox_quantity.Text) ||
                string.IsNullOrWhiteSpace(textbox_price.Text))
                return false;

            return int.TryParse(textbox_quantity.Text, out _) &&
                   double.TryParse(textbox_price.Text, out _);
        }

    
        private void UpdateTotalsDisplay()
        {
            textbox_totalquantity.Text = variables.qty_total.ToString();
            textbox_totaldiscountgiven.Text = variables.discount_totalgiven.ToString("F2");
            textbox_totaldiscountedamount.Text = variables.discounted_total.ToString("F2");
        }

       
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

          
            variables.quantity = 0;
            variables.price = 0;
            variables.discount_amt = 0;
            variables.discounted_amt = 0;
            variables.cash_given = 0;
            variables.change = 0;
        }

        private void ClearAllTransactions()
        {
            ClearCurrentTransaction();

            variables.qty_total = 0;
            variables.discount_totalgiven = 0;
            variables.discounted_total = 0;

            UpdateTotalsDisplay();
        }

        #endregion

        #region Radio Button Events

        private void radiobutton_seniorcitizen_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobutton_seniorcitizen.Checked)
            {
                try
                {
                  
                    quantity_price_Convert();
                    variables.discount_amt = (variables.quantity * variables.price) * 0.20;
               
                    computation_Formula_and_DisplayData();
               
                    radiobutton_withdisccard.Checked = false;
                    radiobutton_employeedisc.Checked = false;
                    radiobutton_nodiscount.Checked = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void radiobutton_withdisccard_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobutton_withdisccard.Checked)
            {
                try
                {
                    quantity_price_Convert();
                    variables.discount_amt = (variables.quantity * variables.price) * 0.10;
                    computation_Formula_and_DisplayData();
                    radiobutton_seniorcitizen.Checked = false;
                    radiobutton_employeedisc.Checked = false;
                    radiobutton_nodiscount.Checked = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void radiobutton_employeedisc_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobutton_employeedisc.Checked)
            {
                try
                {
                    quantity_price_Convert();
                    variables.discount_amt = (variables.quantity * variables.price) * 0.15;
                    computation_Formula_and_DisplayData();
                    radiobutton_seniorcitizen.Checked = false;
                    radiobutton_withdisccard.Checked = false;
                    radiobutton_nodiscount.Checked = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void radiobutton_nodiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (radiobutton_nodiscount.Checked)
            {
                try
                {
                    quantity_price_Convert();
                    variables.discount_amt = 0;
                    computation_Formula_and_DisplayData();
                    radiobutton_seniorcitizen.Checked = false;
                    radiobutton_withdisccard.Checked = false;
                    radiobutton_employeedisc.Checked = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Button Events

        private void calcbutt_Click(object sender, EventArgs e)
        {
            try
            {
          
                if (!ValidateAllFields())
                {
                    MessageBox.Show("Please complete all fields before calculating.",
                        "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

        
                variables.quantity = Convert.ToInt32(textbox_quantity.Text);
                variables.discount_amt = Convert.ToDouble(textbox_discountamount.Text);
                variables.discounted_amt = Convert.ToDouble(textbox_discountedamount.Text);
                variables.cash_given = Convert.ToDouble(textbox_cashrendered.Text);

                
                if (variables.cash_given < variables.discounted_amt)
                {
                    MessageBox.Show($"Insufficient cash! You need at least {variables.discounted_amt:F2}",
                        "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

        
                variables.change = variables.cash_given - variables.discounted_amt;
                textbox_change.Text = variables.change.ToString("F2");

                
                variables.qty_total += variables.quantity;
                variables.discount_totalgiven += variables.discount_amt;
                variables.discounted_total += variables.discounted_amt;

                
                UpdateTotalsDisplay();

               
                ClearCurrentTransaction();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing transaction: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void newbut_Click(object sender, EventArgs e)
        {
            ClearCurrentTransaction(); 
        }

        private void cancelbut_Click(object sender, EventArgs e)
        {
            ClearAllTransactions(); 
        }

        private void exitbut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Validation

     
        private bool ValidateAllFields()
        {
            return !string.IsNullOrWhiteSpace(textbox_itemname.Text) &&
                   !string.IsNullOrWhiteSpace(textbox_price.Text) &&
                   !string.IsNullOrWhiteSpace(textbox_quantity.Text) &&
                   !string.IsNullOrWhiteSpace(textbox_discountedamount.Text) &&
                   !string.IsNullOrWhiteSpace(textbox_cashrendered.Text);
        }

        #endregion

        #region PictureBox Click Events (Product Selection)

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Combo Meal A", "200.00");
            GetPriceItemValue();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Combo Meal B", "320.00");
            GetPriceItemValue();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Breakfast Meal 1", "260.00");
            GetPriceItemValue();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Breakfast Meal 2", "670.00");
            GetPriceItemValue();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Chicken Meal A", "890.00");
            GetPriceItemValue();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Combo Meal A", "242.00");
            GetPriceItemValue();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Combo Meal B", "256.00");
            GetPriceItemValue();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Breakfast Meal 1", "180.00");
            GetPriceItemValue();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Breakfast Meal 2", "980.00");
            GetPriceItemValue();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Chicken Meal A", "199.00");
            GetPriceItemValue();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Combo Meal A", "209.00");
            GetPriceItemValue();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Combo Meal B", "189.00");
            GetPriceItemValue();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Breakfast Meal 1", "219.00");
            GetPriceItemValue();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Breakfast Meal 2", "229.00");
            GetPriceItemValue();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Chicken Meal A", "179.00");
            GetPriceItemValue();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Combo Meal B", "229.00");
            GetPriceItemValue();
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Combo Meal A", "219.00");
            GetPriceItemValue();
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Breakfast Meal 1", "189.00");
            GetPriceItemValue();
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Breakfast Meal 2", "209.00");
            GetPriceItemValue();
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Chicken Meal A", "199.00");
            GetPriceItemValue();
        }

        #endregion

        #region Unused Event Handlers (Required by Designer)

        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }
        private void label21_Click(object sender, EventArgs e) { }
        private void label24_Click(object sender, EventArgs e) { }
        private void label25_Click(object sender, EventArgs e) { }
        private void label27_Click(object sender, EventArgs e) { }
        private void label31_Click(object sender, EventArgs e) { }
        private void button16_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox4_TextChanged(object sender, EventArgs e) { }
        private void textbox_discountedamount_TextChanged(object sender, EventArgs e) { }
        private void textbox_totalquantity_TextChanged(object sender, EventArgs e) { }
        private void textbox_totaldiscountamount_TextChanged(object sender, EventArgs e) { }
        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void dividebut_Click(object sender, EventArgs e) { }

        #endregion

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}
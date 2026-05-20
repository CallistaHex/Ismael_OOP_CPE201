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
    public partial class Lesson8Example7 : Form
    {
        // CLASS-LEVEL VARIABLES (Fields)
        // Creating instances of custom classes to be used throughout this form
        Price_Item_Values price_item_value = new Price_Item_Values();  // CLASS INSTANCE
        Variables variables = new Variables();  // CLASS INSTANCE

        // CONSTRUCTOR FUNCTION - Called when form is created
        public Lesson8Example7()
        {
            InitializeComponent();  // CLASS FUNCTION (Windows Forms generated)
        }

        // CUSTOM CLASS FUNCTION - Gets item name and price from Price_Item_Values class
        private void GetPriceItemValue()
        {
            // Calling GETTER methods from Price_Item_Values class
            itemnameTxtbox.Text = price_item_value.GetItemName();  // CLASS FUNCTION CALL
            priceTxtbox.Text = price_item_value.GetPrice();        // CLASS FUNCTION CALL
        }

        // CUSTOM FUNCTION - Clears a textbox and sets focus to it
        private void ClearQuantityTxtbox(TextBox qtyTxtbox)
        {
            qtyTxtbox.Clear();   // BUILT-IN FUNCTION of TextBox class
            qtyTxtbox.Focus();   // BUILT-IN FUNCTION of TextBox class
        }

        // FORM EVENT FUNCTION - Triggers when form loads
        private void Form1_Load(object sender, EventArgs e)
        {
            // Empty - no functionality implemented
        }

        // PICTUREBOX EVENT FUNCTIONS - Each triggers when a meal picture is clicked
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Calling SETTER method from Price_Item_Values class
            price_item_value.SetPriceItemValue("Meal A", "90.50");  // CLASS FUNCTION CALL
            GetPriceItemValue();  // CUSTOM FUNCTION CALL
            ClearQuantityTxtbox(qtyTxtbox);  // CUSTOM FUNCTION CALL
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Meal B", "120.50");  // CLASS FUNCTION CALL
            GetPriceItemValue();  // CUSTOM FUNCTION CALL
            ClearQuantityTxtbox(qtyTxtbox);  // CUSTOM FUNCTION CALL
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Meal C", "88.50");  // CLASS FUNCTION CALL
            GetPriceItemValue();  // CUSTOM FUNCTION CALL
            ClearQuantityTxtbox(qtyTxtbox);  // CUSTOM FUNCTION CALL
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Meal D", "109.50");  // CLASS FUNCTION CALL
            GetPriceItemValue();  // CUSTOM FUNCTION CALL
            ClearQuantityTxtbox(qtyTxtbox);  // CUSTOM FUNCTION CALL
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Meal 1", "95.00");  // CLASS FUNCTION CALL
            GetPriceItemValue();  // CUSTOM FUNCTION CALL
            ClearQuantityTxtbox(qtyTxtbox);  // CUSTOM FUNCTION CALL
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Meal 2", "120.50");  // CLASS FUNCTION CALL
            GetPriceItemValue();  // CUSTOM FUNCTION CALL
            ClearQuantityTxtbox(qtyTxtbox);  // CUSTOM FUNCTION CALL
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Meal 3", "120.50");  // CLASS FUNCTION CALL
            GetPriceItemValue();  // CUSTOM FUNCTION CALL
            ClearQuantityTxtbox(qtyTxtbox);  // CUSTOM FUNCTION CALL
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Meal 4", "120.50");  // CLASS FUNCTION CALL
            GetPriceItemValue();  // CUSTOM FUNCTION CALL
            ClearQuantityTxtbox(qtyTxtbox);  // CUSTOM FUNCTION CALL
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Meal Combo A", "120.50");  // CLASS FUNCTION CALL
            GetPriceItemValue();  // CUSTOM FUNCTION CALL
            ClearQuantityTxtbox(qtyTxtbox);  // CUSTOM FUNCTION CALL
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Meal Budget A", "110");  // CLASS FUNCTION CALL
            GetPriceItemValue();  // CUSTOM FUNCTION CALL
            ClearQuantityTxtbox(qtyTxtbox);  // CUSTOM FUNCTION CALL
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Meal Solo A", "190.50");  // CLASS FUNCTION CALL
            GetPriceItemValue();  // CUSTOM FUNCTION CALL
            ClearQuantityTxtbox(qtyTxtbox);  // CUSTOM FUNCTION CALL
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Meal Double A", "220.50");  // CLASS FUNCTION CALL
            GetPriceItemValue();  // CUSTOM FUNCTION CALL
            ClearQuantityTxtbox(qtyTxtbox);  // CUSTOM FUNCTION CALL
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Meal Couple A", "100.99");  // CLASS FUNCTION CALL
            GetPriceItemValue();  // CUSTOM FUNCTION CALL
            ClearQuantityTxtbox(qtyTxtbox);  // CUSTOM FUNCTION CALL
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Meal Friend A", "129.70");  // CLASS FUNCTION CALL
            GetPriceItemValue();  // CUSTOM FUNCTION CALL
            ClearQuantityTxtbox(qtyTxtbox);  // CUSTOM FUNCTION CALL
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            price_item_value.SetPriceItemValue("Meal Combo D", "220.50");  // CLASS FUNCTION CALL
            GetPriceItemValue();  // CUSTOM FUNCTION CALL
            ClearQuantityTxtbox(qtyTxtbox);  // CUSTOM FUNCTION CALL
        }

        // TEXTBOX EVENT FUNCTION - Triggers when quantity text changes
        private void qtyTxtbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Accessing and modifying properties of Variables class
                variables.price = Convert.ToDouble(priceTxtbox.Text);  // CLASS PROPERTY ACCESS
                variables.quantity = Convert.ToInt32(qtyTxtbox.Text);  // CLASS PROPERTY ACCESS
                variables.amount_paid = variables.price * variables.quantity;  // CLASS PROPERTY ACCESS
                amount_PaidTxtbox.Text = variables.amount_paid.ToString("n");
                cash_givenTxtbox.Focus();  // BUILT-IN FUNCTION
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter valid numbers");  // BUILT-IN FUNCTION
            }
        }

        // BUTTON EVENT FUNCTION - Calculates change when Calculate button is clicked
        private void calculateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Accessing and manipulating Variables class properties
                variables.amount_paid = Convert.ToDouble(amount_PaidTxtbox.Text);  // CLASS PROPERTY ACCESS
                variables.cash_given = Convert.ToDouble(cash_givenTxtbox.Text);    // CLASS PROPERTY ACCESS
                variables.change = variables.cash_given - variables.amount_paid;    // CLASS PROPERTY ACCESS
                changeTxtbox.Text = variables.change.ToString("C");                 // CLASS PROPERTY ACCESS
                amount_PaidTxtbox.Text = variables.amount_paid.ToString("C");
                cash_givenTxtbox.Text = variables.cash_given.ToString("C");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter valid numbers");  // BUILT-IN FUNCTION
            }
        }

        // UNUSED EVENT FUNCTION
        private void label1_Click(object sender, EventArgs e)
        {
            // Empty
        }

        // UNUSED EVENT FUNCTION
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Empty
        }

        // BUTTON EVENT FUNCTION - Exits the application
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();  // BUILT-IN FUNCTION (Static method)
        }

        // BUTTON EVENT FUNCTION - Clears all form fields (New Order button)
        private void button1_Click(object sender, EventArgs e)
        {
            ClearForm();  // CUSTOM FUNCTION CALL
        }

        // CUSTOM FUNCTION - Clears all textboxes on the form
        private void ClearForm()
        {
            // BUILT-IN FUNCTIONS of TextBox class
            itemnameTxtbox.Clear();
            priceTxtbox.Clear();
            qtyTxtbox.Clear();
            amount_PaidTxtbox.Clear();
            cash_givenTxtbox.Clear();
            changeTxtbox.Clear();
            itemnameTxtbox.Focus();  // BUILT-IN FUNCTION
        }

        // TABLE LAYOUT EVENT FUNCTION
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Empty
        }
    }
}
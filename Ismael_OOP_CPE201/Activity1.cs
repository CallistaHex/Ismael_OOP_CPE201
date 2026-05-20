using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ismael_OOP_CPE201
{
    public partial class Activity1 : Form
    {
        private MenuManager menuManager;
        private FormProcessor formProcessor;

        public Activity1()
        {
            InitializeComponent();
            InitializeClasses();
        }

        Price_Item_Values priceItemValues = new Price_Item_Values();    

        private void InitializeClasses()
        {
            menuManager = new MenuManager(this);
            formProcessor = new FormProcessor(this);
        }

        public void DisplayMealInfo(Meal meal)
        {
            itemnameTxtbox.Text = meal.Name;
            priceTxtbox.Text = meal.GetFormattedPrice();
        }

        public void ClearFormFields()
        {
            itemnameTxtbox.Clear();
            priceTxtbox.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // PictureBox click handlers using the MenuManager class
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            menuManager.SelectMeal(1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            menuManager.SelectMeal(2);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            menuManager.SelectMeal(3);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            menuManager.SelectMeal(4);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            menuManager.SelectMeal(5);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            menuManager.SelectMeal(6);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            menuManager.SelectMeal(7);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            menuManager.SelectMeal(8);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            menuManager.SelectMeal(9);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            menuManager.SelectMeal(10);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            menuManager.SelectMeal(11);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            menuManager.SelectMeal(12);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            menuManager.SelectMeal(13);
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            menuManager.SelectMeal(14);
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            menuManager.SelectMeal(15);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // This method needs to be reviewed - currently clearing on text change
            // Consider removing this logic or implementing properly
            pictureBox1.Text = "";
            priceTxtbox.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formProcessor.CloseForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formProcessor.ResetForm();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    // Meal class to represent a meal item
    public class Meal
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Image MealImage { get; set; }
        public int Id { get; set; }

        public Meal(int id, string name, decimal price, Image image)
        {
            Id = id;
            Name = name;
            Price = price;
            MealImage = image;
        }

        public string GetFormattedPrice()
        {
            return Price.ToString("F2");
        }
    }

    // MenuManager class to handle menu operations
    public class MenuManager
    {
        private List<Meal> meals;
        private Activity1 form;

        public MenuManager(Activity1 form)
        {
            this.form = form;
            meals = new List<Meal>();
            InitializeMenu();
        }

        private void InitializeMenu()
        {
            // Initialize all meals with their respective images
            meals.Add(new Meal(1, "Lunch meal a", 121.30m, Properties.Resources.Screenshot_2026_01_28_180249));
            meals.Add(new Meal(2, "Lunch meal b", 130.30m, Properties.Resources.Screenshot_2026_01_28_180237));
            meals.Add(new Meal(3, "Lunch meal c", 140.30m, Properties.Resources.Screenshot_2026_01_28_180253));
            meals.Add(new Meal(4, "Lunch meal d", 125.30m, Properties.Resources.Screenshot_2026_01_28_180328));
            meals.Add(new Meal(5, "Lunch meal e", 200.30m, Properties.Resources.Screenshot_2026_01_28_180309));
            meals.Add(new Meal(6, "Lunch meal f", 199.30m, Properties.Resources.Screenshot_2026_01_28_180306));
            meals.Add(new Meal(7, "Lunch meal g", 80.30m, Properties.Resources.Screenshot_2026_01_28_180302));
            meals.Add(new Meal(8, "Lunch meal h", 95.30m, Properties.Resources.Screenshot_2026_01_28_180257));
            meals.Add(new Meal(9, "Lunch meal i", 180.30m, Properties.Resources.Screenshot_2026_01_28_181341));
            meals.Add(new Meal(10, "Lunch meal j", 250.30m, Properties.Resources.Screenshot_2026_01_28_181333));
            meals.Add(new Meal(11, "Lunch meal k", 128.30m, Properties.Resources.Screenshot_2026_01_28_181348));
            meals.Add(new Meal(12, "Lunch meal l", 161.30m, Properties.Resources.Screenshot_2026_01_28_181355));
            meals.Add(new Meal(13, "Lunch meal m", 300.30m, Properties.Resources.Screenshot_2026_01_28_1813231));
            meals.Add(new Meal(14, "Lunch meal n", 640.30m, Properties.Resources.Screenshot_2026_01_28_181311));
            meals.Add(new Meal(15, "Lunch meal o", 126.30m, Properties.Resources.Screenshot_2026_01_28_181316));
        }

        public Meal GetMealById(int id)
        {
            return meals.FirstOrDefault(m => m.Id == id);
        }

        public void SelectMeal(int mealId)
        {
            Meal selectedMeal = GetMealById(mealId);
            if (selectedMeal != null)
            {
                form.DisplayMealInfo(selectedMeal);
            }
        }

        public void ClearSelection()
        {
            form.ClearFormFields();
        }
    }

    // FormProcessor class to handle form operations
    public class FormProcessor
    {
        private Activity1 form;

        public FormProcessor(Activity1 form)
        {
            this.form = form;
        }

        public void CloseForm()
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                form.Close();
            }
        }

        public void ResetForm()
        {
            form.ClearFormFields();
        }
    }
}
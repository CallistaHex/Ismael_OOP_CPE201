using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ismael_OOP_CPE201
{
    class Price_Item_Values
    {
        // Code for declaring variables that are accessible in different areas of the application
        public String price, itemname, discount_amount;

        // Code for setting the value for item name and item price
        public void SetPriceItemValue(string item_name, string item_price)
        {
            this.itemname = item_name;
            this.price = item_price;
        }

        // Code for getting the value of an item and using it as needed in the application
        public String GetItemName()
        {
            return itemname;
        }

        // Codes for getting the value of the price and use it as needed in the application
        public String GetPrice()
        {
            return price;
        }

        // Codes for setting the values of the discount amount and item price
        public void SetPriceDiscountAmountValue(string discount_amt, string priceItem)
        {
            this.price = priceItem;
            this.discount_amount = discount_amt;
        }

        // Codes for getting the value of price and use it as needed in the application
        public String GetPriceItem()
        {
            return price;
        }

        // Codes for getting the value of discount amount and use it as needed in the application
        public String GetDiscountAmount()
        {
            return discount_amount;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Supermarket
    {
        private double totalAmount;
        private bool isDiscountApplied;

        public Supermarket()
        {
            totalAmount = 0;
            isDiscountApplied = false;
        }

        public void AddProduct(Product product)
        {
            totalAmount += product.Price;
        }

        public double CalculateTotal()
        {
            return isDiscountApplied ? totalAmount * 0.95 : totalAmount;
        }

        public void ApplyDiscount(DateTime purchaseTime)
        {
            if (purchaseTime.Hour >= 8 && purchaseTime.Hour < 12)
            {
                isDiscountApplied = true;
            }
            else
            {
                isDiscountApplied = false;
            }
        }
    }
}

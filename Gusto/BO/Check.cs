using Gusto.Entities;
using Gusto.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gusto.BO
{
    /// <summary>
    /// Check class
    /// </summary>
    public class Check
    {
        /// <summary>
        /// Not exposing checkitems to other classes because i want chekkc items to be updated with the discount price so use the GetUpdatedCheckItems() method to get the checkitems 
        /// </summary>
        private List<CheckItem> CheckItems { get; set; }
        public int CategoryDiscounted { get; set; }
        public decimal GrossTotalBeforeDiscount { get; set; }
        public decimal GrossDiscountAmount { get; set; }
        public decimal GrossTotalAfterDiscount { get; set; }

        public Check()
        {
            this.CheckItems = new List<CheckItem>();
        }

        /// <summary>
        /// Method to add an item
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="quantity"></param>
        public void AddItem(Menu menu, int quantity)
        {
            CheckItem item = new CheckItem();
            var menuRepository = new MenuRepository();

            item.Menu = menu;
            item.Quantity = quantity;

            this.CheckItems.Add(item);
        }

        /// <summary>
        /// method returns the updated check item list will all the discounts applied
        /// </summary>
        /// <returns></returns>
        public List<CheckItem> GetUpdatedCheckItems()
        {
            var categroyRepository = new CategoryRepository();
            var discountRepository = new DiscountRepository();

            foreach (var check in this.CheckItems)
            {
                check.DiscountApplied = false;
                check.DiscountPercentage = 0;

                if (check.Menu.Category == this.CategoryDiscounted)
                {
                    check.DiscountApplied = true;
                    check.DiscountPercentage = discountRepository.GetItemById(check.Menu.Category).Percentage;
                }

                check.GrossTotalBeforeDiscount = check.Quantity * check.Menu.Price;
                check.GrossDiscountAmount = check.Quantity * (check.Menu.Price * (check.DiscountPercentage / 100));
                check.GrossTotalAfterDiscount = check.GrossTotalBeforeDiscount - check.GrossDiscountAmount;
            }

            return this.CheckItems;
        }

        /// <summary>
        /// Get totals
        /// </summary>
        public void GetTotals()
        {
            this.GetUpdatedCheckItems();
            this.GrossTotalBeforeDiscount = this.CheckItems.Sum(x => x.GrossTotalBeforeDiscount);
            this.GrossDiscountAmount = this.CheckItems.Sum(x => x.GrossDiscountAmount);
            this.GrossTotalAfterDiscount = this.CheckItems.Sum(x => x.GrossTotalAfterDiscount);

        }
    }
}

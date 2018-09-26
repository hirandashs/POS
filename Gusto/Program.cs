using Gusto.BO;
using Gusto.Entities;
using Gusto.Repository;
using System;

namespace Gusto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Menu");
            var menuRepository = new MenuRepository();
            var categoryRepository = new CategoryRepository();
            var discountRepository = new DiscountRepository();

            /// shows the menu
            Console.WriteLine("Id".ToString().PadLeft(5, ' ') + " | " + "Category".PadRight(20, ' ') + " | " + "Price".PadLeft(20, ' ') + " | " + "Name");

            foreach (var item in menuRepository.GetAll())
            {
                Console.WriteLine(item.Id.ToString().PadLeft(5, ' ') + " | " + categoryRepository.GetItemById(item.Category).Name.ToString().PadLeft(20, ' ') + " | " + item.Price.ToString().PadLeft(20, ' ') + " | " + item.Name.ToString());
            }

            ///show the discount
            Console.WriteLine("Discount");

            Console.WriteLine("Id".ToString().PadLeft(5, ' ') + " | " + "Category".PadRight(20, ' ') + " | " + "Disc %".PadLeft(20, ' ') + " | " + "Name");
            foreach (var item in discountRepository.GetAll())
            {
                Console.WriteLine(item.Id.ToString().PadLeft(5, ' ') + " | " + categoryRepository.GetItemById(item.Category).Name.ToString().PadLeft(20, ' ') + " | " + item.Percentage.ToString().PadLeft(20, ' ') + " | " + item.Name.ToString());
            }
            bool continueOrder = true;
            bool discountApplied = false;

            Console.WriteLine("");
            Console.WriteLine("");
            Check check = new Check();

            /// get the order
            do
            {
                Console.Write("Choose an item from the menu : ");
                int item = Convert.ToInt32(Console.ReadLine());
                Menu menu = menuRepository.GetItemById(item);

                Console.Write("How many items do you want? : ");
                int qty = Convert.ToInt32(Console.ReadLine());
                //if (discountApplied == false)
                {
                    Console.Write("Apply discount(\"y\" for yes[You can have only one discount at a time])? : ");
                    discountApplied = Console.ReadLine() == "y" ? true : false;
                    if (discountApplied == true)
                        check.CategoryDiscounted = menu.Category;
                }

                check.AddItem(menu, qty);

                Console.WriteLine("Enter \"y\" to contiue with more order : ");
                continueOrder = Console.ReadLine() == "y" ? true : false;

            } while (continueOrder);


            Console.WriteLine("");


            // shows the check details
            Console.WriteLine("Item Name".PadRight(15, ' ') + " | " + "Qty".PadRight(3, ' ') + " | " + "Dsc".PadRight(5, ' ') + " | " + "Dis%".PadRight(5, ' ') + " | " + "Price".PadRight(5, ' ') + " | " + "DisAmt".PadRight(6, ' ') + " | " + "GrsPri".PadRight(10, ' '));

            foreach (CheckItem chk in check.GetUpdatedCheckItems())
            {
                Console.WriteLine(chk.Menu.Name.ToString().PadRight(15, ' ') + " | " + chk.Quantity.ToString().PadRight(3, ' ') + " | " + chk.DiscountApplied.ToString().PadRight(5, ' ') + " | " + chk.DiscountPercentage.ToString().PadRight(5, ' ') + " | " + chk.GrossTotalBeforeDiscount.ToString().PadRight(5, ' ') + " | " + chk.GrossDiscountAmount.ToString().PadRight(6, ' ') + " | " + chk.GrossTotalAfterDiscount.ToString().PadRight(10, ' '));
            }

            check.GetTotals();

            Console.WriteLine("");
            /// shows the price details
            Console.WriteLine("Gross Total Before Discount : " + check.GrossTotalBeforeDiscount.ToString("0.00"));
            Console.WriteLine("You Saved : " + check.GrossDiscountAmount.ToString("0.00"));
            Console.WriteLine("You Pay : " + check.GrossTotalAfterDiscount.ToString("0.00"));

            Console.Read();
        }
    }
}

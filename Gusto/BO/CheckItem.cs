using Gusto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gusto.BO
{
    /// <summary>
    /// Check item class
    /// </summary>
    public class CheckItem
    {
        public Menu Menu { get; set; }
        public int Quantity { get; set; }
        public bool DiscountApplied { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal GrossTotalBeforeDiscount { get; set; }
        public decimal GrossDiscountAmount { get; set; }
        public decimal GrossTotalAfterDiscount { get; set; }
    }
}

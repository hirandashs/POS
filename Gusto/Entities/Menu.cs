using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gusto.Entities
{
    public class Menu : Base
    {
        public decimal Price {get;set;}
        public int Category { get; set; }
    }
}

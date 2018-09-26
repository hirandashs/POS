using Gusto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gusto.Repository
{

    /// <summary>
    /// Repository class for discount related oprations
    /// </summary>

    public class DiscountRepository : GenericRepository<Discount>
    {
        IQueryable<Discount> categories;
        public DiscountRepository()
        {
            categories = GetAll();
        }

        /// <summary>
        /// get discount by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Discount GetItemById(int Id)
        {
            return categories.Where(x => x.Category == Id).FirstOrDefault<Discount>();
        }

    }
}

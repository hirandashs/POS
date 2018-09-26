using Gusto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gusto.Repository
{
    /// <summary>
    /// Repository class for cateagory related oprations
    /// </summary>
    public class CategoryRepository: GenericRepository<Category>
    {
        IQueryable<Category> categories;

        /// <summary>
        /// Create catagory table from the json
        /// </summary>
        public CategoryRepository()
        {
            categories = GetAll();
        }

        /// <summary>
        /// Get item by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Category GetItemById(int Id)
        {
            return categories.Where(x => x.Id == Id).FirstOrDefault<Category>();
        }

    }
}

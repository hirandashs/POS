using Gusto.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gusto.Repository
{
    /// <summary>
    /// Repository class for menu related oprations
    /// </summary
    public class MenuRepository : GenericRepository<Menu>
    {
        IQueryable<Menu> menus;

        public MenuRepository()
        {
            menus = GetAll();
        }

        /// <summary>
        /// get menu by id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Menu GetItemById(int Id)
        {
            return menus.Where(x => x.Id == Id).FirstOrDefault<Menu>();
        }
    }
}

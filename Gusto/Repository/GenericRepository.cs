using Gusto.Entities;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gusto.Repository
{
    /// <summary>
    /// Generica repository for common methods and also initiate the entities
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : Base
    {
        internal object Context;
        internal List<T> _entities;

        public GenericRepository()
        {
            Type typeParameterType = typeof(T);
            switch (typeParameterType.Name)
            {
                case "Menu":
                    using (StreamReader r = new StreamReader(@"Data\Menu.json"))
                    {
                        string json = r.ReadToEnd();
                        _entities = JsonConvert.DeserializeObject<List<T>>(json);
                    }
                    break;
                case "Discount":
                    using (StreamReader r = new StreamReader(@"Data\Discount.json"))
                    {
                        string json = r.ReadToEnd();
                        _entities = JsonConvert.DeserializeObject<List<T>>(json);
                    }
                    break;
                case "Category":
                    using (StreamReader r = new StreamReader(@"Data\Category.json"))
                    {
                        string json = r.ReadToEnd();
                        _entities = JsonConvert.DeserializeObject<List<T>>(json);
                    }
                    break;
                case "default":
                    using (StreamReader r = new StreamReader(@"Data\Menu.json"))
                    {
                        string json = r.ReadToEnd();
                        _entities = JsonConvert.DeserializeObject<List<T>>(json);
                    }
                    break;
            }
        }

        /// <summary>
        /// Get all method
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = _entities.AsQueryable<T>();
            return query;
        }
    }
}

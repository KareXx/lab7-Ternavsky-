using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7._1
{
    internal class Repository<T>
    {
        private List<T> items;

        public Repository()
        {
            items = new List<T>();
        }

        public void Add(T item)
        {
            items.Add(item);
        }

        public List<T> Find(Criteria<T> criteria)
        {
            List<T> results = new List<T>();

            foreach (var item in items)
            {
                if (criteria(item))
                {
                    results.Add(item);
                }
            }

            return results;
        }
    }

    public delegate bool Criteria<T>(T item);

}

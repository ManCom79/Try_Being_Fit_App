using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class DataTable<T> : IDataTable<T> where T : Base
    {
        public List<T> Items { get; set; }  = new List<T>();
        public void Add(T entity)
        {
            Items.Add(entity);
        }

        public void Delete(T entity)
        {
            Items.Remove(entity);
        }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            List<T> list = Items.ToList();
            return list;
        }

        public void GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

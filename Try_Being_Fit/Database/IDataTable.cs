using Models;

namespace Database
{
    public interface IDataTable<T>where T : Base
    {
        public void Add(T entity);
        public List<T> GetAll();
        public T GetById(int id);
        public void Update(T entity);
        public void Delete(T entity);
        public void DeleteById(int id);
    }
}

using Models;
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
            T item = Items.FirstOrDefault(x => x.ID == id);

            if (item != null)
            {
                Items.Remove(item);
            } else
            {
                throw new KeyNotFoundException($"The item with ID {id} does not exist");
            }
        }

        public List<T> GetAll()
        {
            return Items;
        }

        public T GetById(int id)
        {
            T item = Items.FirstOrDefault(x => x.ID == id);

            if(item == null)
            {
                throw new KeyNotFoundException($"Item with ID {id} does not exist!");
            } else
            {
                return item;
            }
        }

        public void Update(T entity)
        {
            T itemToUpdate = Items.FirstOrDefault(x => x.ID == entity.ID);

            if (itemToUpdate == null)
            {
                throw new KeyNotFoundException($"Item with ID {entity.ID} does not exist!");
            }
            else
            {
                int indexOfItemToUpdate = Items.IndexOf(itemToUpdate);
                Items[indexOfItemToUpdate] = entity;
            }
        }
    }
}

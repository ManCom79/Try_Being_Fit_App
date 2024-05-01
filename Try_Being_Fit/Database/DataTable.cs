using Models;
using Newtonsoft.Json;
namespace Database
{
    public class DataTable<T> : IDataTable<T> where T : Base
    {
        public void Add(T entity)
        {
            var items = ReadItems();
            items.Add(entity);
            SaveItems(items);
        }

        public void Delete(T entity)
        {
            var items = ReadItems();
            items.Remove(entity);
            SaveItems(items);
        }

        public void DeleteById(int id)
        {
            var items = ReadItems();

            T item = items.FirstOrDefault(x => x.ID == id);

            if (item != null)
            {
                items.Remove(item);
            } else
            {
                throw new KeyNotFoundException($"The item with ID {id} does not exist");
            }
            SaveItems(items);
        }

        public List<T> GetAll()
        {
            return ReadItems();
        }

        public T GetById(int id)
        {
            var items = ReadItems();

            T item = items.FirstOrDefault(x => x.ID == id);

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
            var items = ReadItems();

            T itemToUpdate = items.FirstOrDefault(x => x.ID == entity.ID);

            if (itemToUpdate == null)
            {
                throw new KeyNotFoundException($"Item with ID {entity.ID} does not exist!");
            }
            else
            {
                int indexOfItemToUpdate = items.IndexOf(itemToUpdate);
                items[indexOfItemToUpdate] = entity;
            }
            SaveItems(items);
        }

        public List<T> ReadItems()
        {
            string folderPath = @"..\..\..\Data";
            string filePath = $@"{folderPath}\{typeof(T).Name}s.json";
            var result = new List<T>();

            if(!Directory.Exists(folderPath)) {
                return result;
            }

            if(!File.Exists(filePath))
            {
                return result;
            }

            try
            {
                using(var stremReader = new StreamReader(filePath))
                {
                    string content = stremReader.ReadToEnd();
                    JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                    result = JsonConvert.DeserializeObject<List<T>>(content, settings) ?? new List<T>();
                }
            } catch (Exception ex)
            {
                return result;
            }
            return result;
        }

        public void SaveItems(List<T> items)
        {
            string folderPath = @"..\..\..\Data";
            string filePath = $@"{folderPath}\{typeof(T).Name}s.json";

            if(!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if(!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            string content = JsonConvert.SerializeObject(items, settings);

            using (var stremWriter = new StreamWriter(filePath))
            {
                stremWriter.WriteLine(content);
            }
        }
    }
}

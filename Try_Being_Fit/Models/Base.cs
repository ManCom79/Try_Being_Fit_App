using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace Models

{
    public abstract class Base
    {
        public int ID { get; set; }

        public Base() 
        {
            ID = GetUniqueId();
        }

        public int GetUniqueId() {
            Random number = new Random();
            int uniqueId = number.Next(1, 1000);
            return uniqueId;            
        }
    }
}
using System.Security.Cryptography.X509Certificates;

namespace Models
{
    public abstract class Base
    {
        public int ID { get; set; }

        public Base(int id) {
            ID = id;
        }
    }
}

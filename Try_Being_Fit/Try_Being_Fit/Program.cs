namespace Try_Being_Fit
{
    using Database;
    using Models;
    using Models.Enums;
    using System.Data;

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating customer user: test!!!");
            Person newCustomer1 = new Person("easr", "esadr", "Mereenko", "Mkmererkdmkd123", AccountTypeEnum.Premium);
            Person newCustomer2 = new Person("efdvdvr", "edfvdfr", "Mereenko", "Mkmererkdmkd123", AccountTypeEnum.Premium);

            DatabaseDefinition.People.Add(newCustomer1);
            DatabaseDefinition.People.Add(newCustomer2);

            List<Person> allUsers = DatabaseDefinition.People.GetAll();

            foreach (Person person in allUsers)
            {
                Console.WriteLine($"ID: {person.ID} {person.FirstName} {person.LastName}");
            }


            
        }
    }
}

namespace Try_Being_Fit
{
    using Database;
    using Models;
    using Models.Enums;
    using System.Data;

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating customer user: test!!!");
            Person newCustomer1 = new Person("easrasdf", "esadrasdf", "Mereenko", "Mkmererkdmkd123", AccountTypeEnum.Premium);
            Person newCustomer2 = new Person("dssdvsdv", "sdvsvvsdv", "sdvsdvvdsv", "svdsdvsvsdv123", AccountTypeEnum.Premium);
            Person trainer1 = new Person("rtytyytryt", "rtyrtytryr", "fdgfgdfdggfd", "dfgdfgfdgfdg1", AccountTypeEnum.Premium);
            Person trainer2 = new Person("sdsdfsdfsfsdf", "sdsdfsdfsfsdf", "sdsdfsdfsfsdf", "sdsdfsdfsfsdf123", AccountTypeEnum.Premium);

            DatabaseDefinition.People.Add(newCustomer1);
            DatabaseDefinition.People.Add(trainer1);

            List<Person> allUsers = DatabaseDefinition.People.GetAll();

            foreach (Person person in allUsers)
            {
                Console.WriteLine($"ID: {person.ID} {person.FirstName} {person.LastName}");
            }

            List<Person> liveTrainer = new List<Person> { trainer1 };
            List<Person> liveParticipant = new List<Person> { newCustomer1 };
            DateTime trainingDate = DateTime.Now.AddDays(7);

            LiveTraining live = new LiveTraining("Title", "Link", trainingDate, liveTrainer, liveParticipant);
            Console.WriteLine($"The LiveTraining title is {live.Title}, with live {live.Link} at {live.Schedule} with trainer {liveTrainer[0].FirstName} and participant {liveParticipant[0].FirstName}");

            VideoTraining video = new VideoTraining("Title", "Link", 5);
            Console.WriteLine($"The VideoTraining title is {video.Title}, with live {video.Link} with rating {video.Rating}");

            video.CalculateRating(8);

            Console.WriteLine($"The VideoTraining title is {video.Title}, with live {video.Link} with rating {video.Rating}");


        }
    }
}

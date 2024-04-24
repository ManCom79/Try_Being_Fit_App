namespace Try_Being_Fit
{
    using Database;
    using Models;
    using Models.Enums;
    using Services.Implamentations;
    using Services.Interfaces;
    using System.Data;

    public class Program
    {
        static void Main(string[] args)
        {
            Person trainer1 = new Person("John", "Johnson", "jjtrainer", "jjtrainer123", AccountTypeEnum.Trainer);
            Person trainer2 = new Person("Bob", "Bobsky", "bbtrainer", "bbtrainer123", AccountTypeEnum.Trainer);
            DatabaseDefinition.People.Add(trainer1);
            DatabaseDefinition.People.Add(trainer2);

            while (true) 
            {
                IUIService uiService = new UIService();
                uiService.ShowWelcomeMenu();
            }
            

            //Console.WriteLine("Creating customer user: test!!!");
            //Person newCustomer1 = new Person("es", "esadrasdf", "Mereenko", "Mkmererkdmkd123", AccountTypeEnum.Premium);
            //Person newCustomer2 = new Person("dssdvsdv", "sdvsvvsdv", "sdvsdvvdsv", "svdsdvsvsdv123", AccountTypeEnum.Premium);
            //Person trainer1 = new Person("rtytyytryt", "rtyrtytryr", "fdgfgdfdggfd", "dfgdfgfdgfdg1", AccountTypeEnum.Premium);
            //Person trainer2 = new Person("sdsdfsdfsfsdf", "sdsdfsdfsfsdf", "sdsdfsdfsfsdf", "sdsdfsdfsfsdf123", AccountTypeEnum.Premium);

            //DatabaseDefinition.People.Add(newCustomer1);
            //DatabaseDefinition.People.Add(trainer1);

            //List<Person> allUsers = DatabaseDefinition.People.GetAll();

            //foreach (Person person in allUsers)
            //{
            //    Console.WriteLine($"ID: {person.ID} {person.FirstName} {person.LastName}");
            //}

            //List<Person> liveTrainer = new List<Person> { trainer1 };
            //List<Person> liveParticipant = new List<Person> { newCustomer1 };
            //DateTime trainingDate = DateTime.Now.AddDays(7);

            //LiveTraining live = new LiveTraining("Title", "Link", trainingDate, liveTrainer, liveParticipant);
            //Console.WriteLine($"The LiveTraining title is {live.Title}, with live {live.Link} at {live.Schedule} with trainer {liveTrainer[0].FirstName} and participant {liveParticipant[0].FirstName}");

            //VideoTraining video = new VideoTraining("Title", "Link", 5);
            //VideoTraining video1 = new VideoTraining("Title", "Link", 5);
            //Console.WriteLine($"The VideoTraining title is {video.Title}, with live {video.Link} with rating {video.Rating}");

            //video.CalculateRating(8);
            //video1.CalculateRating(10);

            //Console.WriteLine($"The VideoTraining with id {video.ID} title is {video.Title}, with live {video.Link} with rating {video.Rating}");
            //Console.WriteLine($"The VideoTraining with id {video1.ID} title is {video1.Title}, with live {video1.Link} with rating {video1.Rating}");

            //DatabaseDefinition.LiveTrainings.Add(live);
            //DatabaseDefinition.VideoTrainings.Add(video);
            //DatabaseDefinition.VideoTrainings.Add(video1);


            //Console.WriteLine($"There are {DatabaseDefinition.LiveTrainings.Items.Count()} live trainings available");
            //Console.WriteLine($"The count of live is {DatabaseDefinition.LiveTrainings.GetAll().Count()}");

            //Console.WriteLine($"There are {DatabaseDefinition.VideoTrainings.Items.Count()} video trainings available");
            //Console.WriteLine($"The count of video is {DatabaseDefinition.VideoTrainings.GetAll().Count()}");

            //Console.WriteLine($"The id of the video to be deleted with delete by id is {video1.ID}.");
            //DatabaseDefinition.VideoTrainings.DeleteById(video1.ID);

            //Console.WriteLine($"There are {DatabaseDefinition.VideoTrainings.Items.Count()} video trainings available");
            //Console.WriteLine($"The count of video is {DatabaseDefinition.VideoTrainings.GetAll().Count()}");

            //DatabaseDefinition.VideoTrainings.Add(video1);

            //Console.WriteLine($"There are {DatabaseDefinition.VideoTrainings.Items.Count()} video trainings available");
            //Console.WriteLine($"The count of video is {DatabaseDefinition.VideoTrainings.GetAll().Count()}");

            //DatabaseDefinition.VideoTrainings.Delete(video1);

            //Console.WriteLine($"The video to be deleted with delete function is {video1.ID}.");
            //Console.WriteLine($"There are {DatabaseDefinition.VideoTrainings.Items.Count()} video trainings available");
            //Console.WriteLine($"The count of video is {DatabaseDefinition.VideoTrainings.GetAll().Count()}");

            //video.Link = "Linkilink";

            //DatabaseDefinition.VideoTrainings.Update(video);

            //Console.WriteLine($"The VideoTraining with id {video.ID} title is {video.Title}, with live {video.Link} with rating {video.Rating}");

        }
    }
}

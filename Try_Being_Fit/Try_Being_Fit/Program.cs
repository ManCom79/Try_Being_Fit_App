﻿namespace Try_Being_Fit
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
            Person testUser1 = new Person("Test", "StandardUser", "s", "s", AccountTypeEnum.Standard);
            Person testUser2 = new Person("Test", "PremiumUser", "p", "p", AccountTypeEnum.Premium);
            Person trainer1 = new Person("John", "Johnson", "jjtrainer", "jjtrainer123", AccountTypeEnum.Trainer);
            Person trainer2 = new Person("Bob", "Bobsky", "bbtrainer", "bbtrainer123", AccountTypeEnum.Trainer);
            DatabaseDefinition.People.Add(testUser1);
            DatabaseDefinition.People.Add(testUser2);
            DatabaseDefinition.People.Add(trainer1);
            DatabaseDefinition.People.Add(trainer2);

            VideoTraining videoTraining1 = new VideoTraining("Cardio Workout", "https://www.youtube.com/watch?v=yXHgcYpUVD4", 0);
            VideoTraining videoTraining2 = new VideoTraining("Fat Burning Workout", "https://www.youtube.com/watch?v=IT94xC35u6k", 0);
            DatabaseDefinition.VideoTrainings.Add(videoTraining1);
            DatabaseDefinition.VideoTrainings.Add(videoTraining2);

            List<Person> liveTrainer = new List<Person> { trainer1 };
            List<Person> liveParticipant = new List<Person> { testUser2 };
            DateTime trainingDate = DateTime.Now.AddDays(7);
            LiveTraining liveTraining1 = new LiveTraining("Cardio Workout", "https://www.microsoft.com/en-in/microsoft-teams/join-a-meeting", trainingDate, liveTrainer, liveParticipant);
            DatabaseDefinition.LiveTrainings.Add(liveTraining1);

            while (true) 
            {
                IUIService uiService = new UIService();
                uiService.ShowWelcomeMenu();
            }
            

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

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
            //Person testUser1 = new Person("Test", "StandardUser", "s", "s", AccountTypeEnum.Standard);
            //Person testUser2 = new Person("Test", "PremiumUser", "p", "p", AccountTypeEnum.Premium);
            //Person trainer1 = new Person("John", "Johnson", "t", "t", AccountTypeEnum.Trainer);
            //Person trainer2 = new Person("Bob", "Bobsky", "bbtrainer", "bbtrainer123", AccountTypeEnum.Trainer);
            //DatabaseDefinition.People.Add(testUser1);
            //DatabaseDefinition.People.Add(testUser2);
            //DatabaseDefinition.People.Add(trainer1);
            //DatabaseDefinition.People.Add(trainer2);

            //VideoTraining videoTraining1 = new VideoTraining("Cardio Workout", "https://www.youtube.com/watch?v=yXHgcYpUVD4", 0);
            //VideoTraining videoTraining2 = new VideoTraining("Fat Burning Workout", "https://www.youtube.com/watch?v=IT94xC35u6k", 0);
            //DatabaseDefinition.VideoTrainings.Add(videoTraining1);
            //DatabaseDefinition.VideoTrainings.Add(videoTraining2);

            //List<Person> liveTrainer = new List<Person> { trainer1 };
            //List<Person> liveParticipant = new List<Person> { testUser2 };
            //DateTime trainingDate = DateTime.Now.AddDays(7);   
            //LiveTraining liveTraining1 = new LiveTraining("Cardio Workout", "https://www.microsoft.com/en-in/microsoft-teams/join-a-meeting", trainingDate, liveTrainer, liveParticipant);
            //LiveTraining liveTraining2 = new LiveTraining("Fat Burning Workout", "https://www.microsoft.com/en-in/microsoft-teams/join-a-meeting", trainingDate, liveTrainer, liveParticipant);
            //DatabaseDefinition.LiveTrainings.Add(liveTraining1);
            //DatabaseDefinition.LiveTrainings.Add(liveTraining2);

            while (true) 
            {
                DatabaseDefinition databaseDefinition  = new DatabaseDefinition();
                IUIService uiService = new UIService();
                uiService.ShowWelcomeMenu();
            }
        }
    }
}

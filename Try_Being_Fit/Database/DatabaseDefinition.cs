using Models;
using Models.Enums;

namespace Database
{
    public class DatabaseDefinition
    {
        public DataTable<Person> People { get; set; }
        public DataTable<LiveTraining> LiveTrainings { get; set; }
        public DataTable<VideoTraining> VideoTrainings { get; set; }

        public DatabaseDefinition()
        { 
            People = new DataTable<Person>();
            LiveTrainings = new DataTable<LiveTraining>();
            VideoTrainings = new DataTable<VideoTraining>();

            if(People.GetAll().Where(x => x.AccountType == AccountTypeEnum.Trainer).Count() == 0) 
            {
                Person trainer1 = new Person("John", "Johnson", "t", "t", AccountTypeEnum.Trainer);
                People.Add(trainer1);
            }
            

            if (VideoTrainings.GetAll().Count() == 0)
            {
                VideoTraining videoTraining1 = new VideoTraining("Cardio Workout", "https://www.youtube.com/watch?v=yXHgcYpUVD4", 0);
                VideoTraining videoTraining2 = new VideoTraining("Fat Burning Workout", "https://www.youtube.com/watch?v=IT94xC35u6k", 0);
                VideoTrainings.Add(videoTraining1);
                VideoTrainings.Add(videoTraining2);
            }

            if(LiveTrainings.GetAll().Count() == 0)
            {
                List<Person> liveTrainer = People.GetAll().Where(x => x.AccountType == AccountTypeEnum.Trainer).ToList();
                List<Person> liveParticipant = new List<Person>();
                DateTime trainingDate = DateTime.Now.AddDays(7);
                LiveTraining liveTraining1 = new LiveTraining("Cardio Workout", "https://www.microsoft.com/en-in/microsoft-teams/join-a-meeting", trainingDate, liveTrainer, liveParticipant);
                LiveTraining liveTraining2 = new LiveTraining("Fat Burning Workout", "https://www.microsoft.com/en-in/microsoft-teams/join-a-meeting", trainingDate, liveTrainer, liveParticipant);
                LiveTrainings.Add(liveTraining1);
                LiveTrainings.Add(liveTraining2);
            }
        }
    }
}

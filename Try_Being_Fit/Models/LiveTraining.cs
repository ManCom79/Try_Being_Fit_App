namespace Models
{
    public class LiveTraining : Training
    {
        public DateTime Schedule {  get; set; }
        public List<Person> TrainingTrainers = new List<Person>();
        public List<Person> TrainingParticipants = new List<Person>();

        public LiveTraining(string title, string link, DateTime schedule, List<Person> trainingTrainers, List<Person> trainingParticipants) : base(title, link)
        {
            ID = GetUniqueId();
            Schedule = schedule;
            TrainingTrainers = trainingTrainers;
            TrainingParticipants = trainingParticipants;
        }
    }
}

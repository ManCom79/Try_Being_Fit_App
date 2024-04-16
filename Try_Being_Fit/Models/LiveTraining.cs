namespace Models
{
    public class LiveTraining : Training
    {
        public DateTime Schedule {  get; set; }
        public List<Person> trainingTrainers = new List<Person>();
        public List<Person> trainingParticipants = new List<Person>();

        public LiveTraining(int id, string title, string link, DateTime schedule, List<Person> trainingTrainers, List<Person> trainingParticipants) : base(id, title, link)
        {
            Schedule = schedule;
        }
    }
}

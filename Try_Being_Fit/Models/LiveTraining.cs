namespace Models
{
    public class LiveTraining : Training
    {
        public DateTime Schedule {  get; set; }
        public List<Person> trainingTrainers = new List<Person>();

        public LiveTraining(DateTime schedule, List<Person> trainingTrainers, int id, string title, string link) : base(id, title, link)
        {
            Schedule = schedule;
        }
    }
}

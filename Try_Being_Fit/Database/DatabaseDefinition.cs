using Models;

namespace Database
{
    public static class DatabaseDefinition
    {
        public static DataTable<Person> People { get; set; } = new DataTable<Person>();
        public static DataTable<LiveTraining> LiveTrainings { get; set; } = new DataTable<LiveTraining>();
        public static DataTable<VideoTraining> VideoTrainings { get; set; } = new DataTable<VideoTraining>();
    }
}

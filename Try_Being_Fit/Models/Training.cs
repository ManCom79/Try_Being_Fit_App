namespace Models
{
    public abstract class Training : Base
    {
        public string Title { get; set; }
        public string Link { get; set; }

        public Training(int id, string title, string link) : base()
        {
            Title = title;
            Link = link;
        }
    }
}

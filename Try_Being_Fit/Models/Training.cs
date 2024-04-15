namespace Models
{
    public class Training : Base
    {
        public string Title { get; set; }
        public string Link { get; set; }

        public Training(int id, string title, string link) : base(id)
        {
            Title = title;
            Link = link;
        }
    }
}

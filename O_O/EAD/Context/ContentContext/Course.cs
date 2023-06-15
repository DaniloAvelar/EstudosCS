using Context.ContentContext.Enums;

namespace Context.ContentContext
{
    public class Course : Content
    {
        //Inicializando a List Modules
        public Course(string title, string url)
        : base(title, url)
        {
            Modules = new List<Module>();
        }

        public string Tag { get; set; } //EX: 2802

        public IList<Module> Modules { get; set; }
        public int DurationInMinutes { get; set; }
        public EContentLevel Level { get; set; }
    }


}
using Context.ContentContext.Enums;
using Context.SharedContext;

namespace Context.ContentContext
{
    //Lecture = Aula
    public class Lecture : Base
    {
        public int Order { get; set; }
        public string Title { get; set; }
        public int DurationInMinutes { get; set; }
        public EContentLevel Level { get; set; }
    }
}
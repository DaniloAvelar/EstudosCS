using Context.SharedContext;

namespace Context.ContentContext
{
    public class Content : Base
    {
        //Gerando um RASH para cada novo ID
        public Content(string title, string url)
        {
            //Id = Guid.NewGuid(); //Migrado para Classe (Base)
            Title = title;
            Url = url;
        }

        public string? Title { get; set; }
        public string? Url { get; set; }
    }
}
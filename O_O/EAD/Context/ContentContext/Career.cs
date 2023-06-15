namespace Context.ContentContext
{
    public class Career : Content
    {
        public Career(string title, string url)
        : base(title, url)
        {
            Items = new List<CareerItem>();
        }
        public IList<CareerItem> Items { get; set; }

        //Retornando a contagem (Total) de cursos do IList<CareerItem>
        //Retirado SET pois nao vamos setar manualmente nenhum valor
        //Expression Body: ......................
        //public int TotalCOurses => Items.Count;
        public int TotalCourses
        {
            get
            {
                return Items.Count;
            }
        }

    }
}
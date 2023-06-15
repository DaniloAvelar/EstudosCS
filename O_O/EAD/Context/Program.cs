using Context.ContentContext;

public class Program
{
    static void Main(string[] args)
    {
        //Criando Novos Artigos
        var articles = new List<Article>();
        articles.Add(new Article("Artigo sobre OOP", "orientacao-objetos"));
        articles.Add(new Article("Artigo sobre C#", "artigo-cs"));
        articles.Add(new Article("Artigo sobre .NET", "artigo-dotnet"));

        // foreach (var i in articles)
        // {
        //     Console.WriteLine(i.Id);
        //     Console.WriteLine(i.Title);
        //     Console.WriteLine(i.Url);
        // }

        //Criando Novos Cursos
        var courses = new List<Course>();
        var courseOOP = new Course("Curso de OOP", "fundamentos-oop");
        var courseCsharp = new Course("Curso de C#", "fundamentos-csharp");
        var courseAspNet = new Course("Curso de ASP.Net", "fundamentos-aspnet");
        courses.Add(courseOOP);
        courses.Add(courseCsharp);
        courses.Add(courseAspNet);


        //Instanciando uma nova lista de Carreira <Career>
        var careers = new List<Career>();
        //Criando uma nova Carreira
        var careerDotNet = new Career("Especialista em .NET", "especialista-dotnet");

        //Criando um novos Itens (Items) da Carreira
        var careerItem3 = new CareerItem(3, "Aprenda .NET", "", courseAspNet);
        var careerItem1 = new CareerItem(1, "Comece por aqui", "", courseCsharp);
        var careerItem2 = new CareerItem(2, "Aprenda OOP", "", courseOOP);

        //Adicionando os Itens à Lista de Carreira 
        careerDotNet.Items.Add(careerItem3);
        careerDotNet.Items.Add(careerItem1);
        careerDotNet.Items.Add(careerItem2);

        //Adicionando a Carreira 
        careers.Add(careerDotNet);

        foreach (var i in careers)
        {
            Console.WriteLine(i.Title);

            //Percorrendo o Item da lista acima (i.Items) e Ordenando pelo (Order)
            foreach (var item in i.Items.OrderBy(x => x.Order))
            {
                Console.WriteLine($"{item.Order}, {item.Title}");
                Console.WriteLine(item.Course.Title);
            }
        }




    }
}
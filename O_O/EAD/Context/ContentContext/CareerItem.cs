using Context.NotificationContext;
using Context.SharedContext;

namespace Context.ContentContext
{
    public class CareerItem : Base
    {
        public CareerItem(int order, string title, string description, Course course)
        {
            //Criando regra para nao deixar criar um curso = NULL EX: new CareerItem(3, "Aprenda .NET", "", null);
            if (course == null)
                AddNotification(new Notification("Course", "Curso inválido"));

            Order = order;
            Title = title;
            Description = description;
            Course = course;
        }

        public int Order { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Course Course { get; set; }
    }
}
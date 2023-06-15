namespace Context.NotificationContext
{
    //Utilizando o Sealed para que essa classe não seja extendida ou seja ela é PADRÃO
    public sealed class Notification
    {
        public Notification()
        {

        }

        public Notification(string property, string message)
        {
            Property = property;
            Message = message;
        }

        public string Property { get; set; }
        public string Message { get; set; }

    }
}
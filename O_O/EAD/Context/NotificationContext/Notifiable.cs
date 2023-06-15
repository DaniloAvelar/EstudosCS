namespace Context.NotificationContext
{
    //Classe responsavel por executar as Notificação
    public abstract class Notifiable
    {
        //Propriedade
        public List<Notification> Notifications { get; set; }

        public Notifiable()
        {
            Notifications = new List<Notification>();
        }

        //Metodo Adicionar
        public void AddNotification(Notification notification)
        {
            Notifications.Add(notification);
        }

        //Metodo Adicionar Lista
        public void AddNotifications(IEnumerable<Notification> notifications)
        {
            Notifications.AddRange(notifications);
        }

        public bool IsValid => Notifications.Any();
    }

}

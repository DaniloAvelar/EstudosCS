using Context.NotificationContext;
using Context.SharedContext;

namespace Context.SubscriptionContext
{
    public class Student : Base
    {
        public Student()
        {
            Subscriptions = new List<Subscription>();
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public User User { get; set; }
        public IList<Subscription> Subscriptions { get; set; }

        public bool IsPremium => Subscriptions.Any(x => !x.IsInactive);

        //Metodo para validar se aluno ja possui assinatura
        public void CreateSubscription(Subscription subscription)
        {
            if (IsPremium)
            {
                AddNotification(new Notification("Premium", " O Aluno ja possui uma assinatura Premium."));
                return;
            }

            Subscriptions.Add(subscription);
        }
    }
}
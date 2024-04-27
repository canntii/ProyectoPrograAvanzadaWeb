using SistemaEducacion.WebEntities;

namespace SistemaEducacion.Services
{
    public interface ISubscription
    {
        Answer? AddSuscription(Subscription entity);
        Answer? UpdateSuscription(Subscription entity);
        SubscriptionAnswer? ListSubscriptions();
    }
}

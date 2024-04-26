using SistemaEducacion.Controllers;

namespace SistemaEducacion.WebEntities
{
    public class Subscription
    {
        public long SubscriptionID { get; set; }
        public string? SubscriptionType { get; set; }
        public decimal? SubscriptionPrice { get; set; }
        public bool? Estado { get; set; }
    }

    public class SubscriptionAnswer
    {
        public SubscriptionAnswer()
        {
            Code = "00";
            Message = string.Empty;
        }
        public string? Code { get; set; }
        public string? Message { get; set; }
        public Subscription? Datum { get; set; }
        public List<Subscription>? Data { get; set; }
    }
}

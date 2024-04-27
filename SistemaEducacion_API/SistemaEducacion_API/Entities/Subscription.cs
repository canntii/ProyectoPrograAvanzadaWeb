namespace SistemaEducacion_API.Entities
{
    public class Subscription
    {
        public long SubscriptionID { get; set; }
        public string? SubscriptionType { get; set; }
        public decimal SubscriptionPrice { get; set; }
        public bool? Estado { get; set; }
    }

    public class SubscriptionAnswer
    {
        public Subscription? info { get; set; }
        public List<Subscription>? data { get; set; }

        public string?  Code { get; set; }
        public string? Message { get; set; }
    }
}

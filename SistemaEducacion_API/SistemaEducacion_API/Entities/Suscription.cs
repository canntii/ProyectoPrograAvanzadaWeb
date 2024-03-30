namespace SistemaEducacion_API.Entities
{
    public class Suscription
    {
        public long SubscriptionID { get; set; }
        public string SubscriptionType { get; set; }
        public decimal SubscriptionPrice { get; set; }
        public bool? Estado { get; set; }
    }

    public class SuscriptionAnswer
    {
        public Suscription? info { get; set; }
        public List<Suscription>? data { get; set; }

        public string  Code { get; set; }
        public string Message { get; set; }
    }
}

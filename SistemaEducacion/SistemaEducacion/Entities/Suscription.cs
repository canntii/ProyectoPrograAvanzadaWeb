namespace SistemaEducacion.Entities
{
    public class Suscription
    {
        public long SuscriptionID { get; set; }
        public string SuscriptionType { get; set; }
        public decimal SubscriptionPrice { get; set; }
        public bool? Estado { get; set; }
    }

    public class SuscriptionAnswer
    {
        public Suscription info { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
    }
}

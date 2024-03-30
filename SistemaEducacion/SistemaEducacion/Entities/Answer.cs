namespace SistemaEducacion.Entities
{
    public class Answer
    {
        public Answer()
        {
            Code = "00";
            Message = string.Empty;
            consecutive = -1;
        }
        public string? Code { get; set; }
        public string? Message { get; set; }
        public long consecutive { get; set; }
    }
}

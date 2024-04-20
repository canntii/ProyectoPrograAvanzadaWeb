namespace SistemaEducacion_API.Entities
{
    public class Question
    {
        public int QuestionID { get; set; }
        public int AssesmentID { get; set; }
        public string? QuestionDesc { get; set; }
        public string? Correct { get; set; }
        public bool? Estado { get; set; }
        

    }
    public class QuestionAnswer
    {
        public QuestionAnswer()
        {
            Code = "00";
            Message = string.Empty;

        }
        public string? Code { get; set; }
        public string? Message { get; set; }
        public Question? Datum { get; set; }
        public List<Question>? Data { get; set; }
    }
}

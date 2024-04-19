using SistemaEducacion_API.Entity;

namespace SistemaEducacion_API.Entities
{
    public class Assesment
    {
        public int AssesmentID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal MinimumGrade { get; set; }
        public int CourseID { get; set; }
        public bool Estado { get; set; }
    }
    public class AssesmentAnswer
    {
        public AssesmentAnswer()
        {
            Code = "00";
            Message = string.Empty;

        }

        public string? Code { get; set; }
        public string? Message { get; set; }
        public Assesment? Datum { get; set; }
        public List<Assesment>? Data { get; set; }
    }
}

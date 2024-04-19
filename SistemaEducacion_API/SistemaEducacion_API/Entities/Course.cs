using SistemaEducacion_API.Entity;

namespace SistemaEducacion_API.Entities
{
    public class Course
    {
        public int CourseID { get; set; }
        public string? CourseTitle { get; set; }
        public string? CourseDescription { get; set; }
        public bool Estado { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class CourseAnswer
    {
        public CourseAnswer()
        {
            Code = "00";
            Message = string.Empty;
        }
        public Course? info { get; set; }
        public string? Code { get; set; }
        public string? Message { get; set; }
        public Course? Datum { get; set; }
        public List<Course>? Data { get; set; }

    }
}

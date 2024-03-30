namespace SistemaEducacion.Entities
{
    public class Course
    {
        public long CourseID { get; set; }
        public string CourseTittle { get; set; }
        public string CourseDescription { get; set; }
        public bool Estado { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class CourseAnswer
    {
        public Course info { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
    }
}

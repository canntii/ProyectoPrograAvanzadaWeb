namespace SistemaEducacion.WebEntities
{
    public class Lesson
    {
        public long LessonID { get; set; }
        public string? LessonTitle { get; set; }
        public string? LessonDescription { get; set; }
        public bool Estado { get; set; }
        public int CourseID { get; set; }

        public virtual Course? Course { get; set; }
    }

    public class LessonAnswer
    {
        public Lesson? info { get; set; }
        public string? Code { get; set; }
        public string? Message { get; set; }
    }
}

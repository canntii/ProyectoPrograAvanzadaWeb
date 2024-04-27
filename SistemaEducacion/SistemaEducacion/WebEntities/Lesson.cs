namespace SistemaEducacion.WebEntities
{
    public class Lesson
    {
        public long LessonID { get; set; }
        public string? LessonTitle { get; set; }
        public string? LessonDescription { get; set; }
        public bool Estado { get; set; }
        public int CourseID { get; set; }
        public string? VideoUrl { get; set; }
        public string? MiniPictureUrl { get; set; }
        public virtual Course? Course { get; set; }
    }

    public class LessonAnswer
    {
        public LessonAnswer()
        {
            Code = "00";
            Message = string.Empty;
        }
        public string? Code { get; set; }
        public string? Message { get; set; }
        public Lesson? Datum { get; set; }
        public List<Lesson>? Data { get; set; }

    }
}


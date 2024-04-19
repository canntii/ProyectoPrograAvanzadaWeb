

using SistemaEducacion_API.Entity;

namespace SistemaEducacion_API.Entities
{
    public class UserCourse
    {
        public int UserCourseID { get; set; }
        public bool? Estado { get; set; }
        public int CourseID { get; set; }
        public int UserID { get; set; }
        public string? CourseTitle {  get; set; }
        public string? CourseDescription { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public class UserCourseAnswer
        {
            public UserCourseAnswer()
            {
                Code = "00";
                Message = string.Empty;
            }
            public string Code { get; set; }
            public string Message { get; set; }
            public UserCourse? Datum { get; set; }
            public List<UserCourse>? Data { get; set; }
        }
    }
}

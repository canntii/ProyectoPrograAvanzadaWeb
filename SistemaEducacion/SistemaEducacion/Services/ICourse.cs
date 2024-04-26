using SistemaEducacion.WebEntities;

namespace SistemaEducacion.Services
{
    public interface ICourse
    {
        Answer? AddCourse(Course entity);
        CourseAnswer? ListCourses();
        CourseAnswer? SeeLessonCourse(int CourseID);
    }
}
 
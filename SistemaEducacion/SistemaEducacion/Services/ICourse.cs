using SistemaEducacion.WebEntities;

namespace SistemaEducacion.Services
{
    public interface ICourse
    {
        Answer? AddCourse(Course entity);
        CourseAnswer? ListCourses();
        CourseAnswer? ListMyCourses(int UserId);
        CourseAnswer? ListMySucriptionCourses(int UserId);
        CourseAnswer? SeeLessonCourse(int CourseID);
    }
}
 
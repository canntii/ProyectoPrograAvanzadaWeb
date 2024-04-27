using SistemaEducacion.WebEntities;

namespace SistemaEducacion.Services
{
    public interface ILesson
    {
        Answer? AddLesson(Lesson entity);
        LessonAnswer? LastInsert(int CourseID);
        LessonAnswer? SeeContentLesson(int LessonID);
    }
}

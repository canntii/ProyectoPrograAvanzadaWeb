using SistemaEducacion.WebEntities;

namespace SistemaEducacion.Services
{
    public interface ILesson
    {
        Answer? AddLesson(Lesson entity);
    }
}

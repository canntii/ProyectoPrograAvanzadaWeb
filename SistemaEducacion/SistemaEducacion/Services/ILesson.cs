using SistemaEducacion.Entities;

namespace SistemaEducacion.Services
{
    public interface ILesson
    {
        Answer AddLesson(Lesson entity);
    }
}

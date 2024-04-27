using Microsoft.AspNetCore.Mvc;
using SistemaEducacion.WebEntities;

namespace SistemaEducacion.Services
{
    public interface IUserModel
    {
        Answer? RegisterUser(User entity);
        Answer? UpdateUser(User entity);
        UserAnswer? Login(User entity);
        UserAnswer? RecoverAccess(User entity);
        UserAnswer? ChangePassword(User entity);
        UserAnswer? AcceptOrRejectProfessor(User entity);
        UserAnswer? BecomeProfessor(User entity);
        UserAnswer? ViewProfessorApplicants();
        UserAnswer? SeeProfesorCourse(int CourseID);
        UserAnswer? SearchUser(int UserId);
        public UserAnswer? ListProfessor();
    }
}

using Microsoft.AspNetCore.Http.HttpResults;
using SistemaEducacion.WebEntities;
using SistemaEducacion.Services;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;


namespace SistemaEducacion.Models
{
    public class UserModel(HttpClient _httpClient, IConfiguration _configuration, IHttpContextAccessor _context) : IUserModel
    {
        public Answer? RegisterUser(User entity)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/User/RegisterUser";
            JsonContent body = JsonContent.Create(entity);
            var resp = _httpClient.PostAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<Answer>().Result;
            return null;
        }

        public Answer? UpdateUser(User entity)
        {

            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/User/UpdateUser";
            JsonContent body = JsonContent.Create(entity);
            var resp = _httpClient.PutAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<Answer>().Result;
            return null;
        }

        public UserAnswer? Login(User entity)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/User/Login";
            JsonContent body = JsonContent.Create(entity);
            var resp = _httpClient.PostAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
            {
                return resp.Content.ReadFromJsonAsync<UserAnswer>().Result;
            }

            return resp.Content.ReadFromJsonAsync<UserAnswer>().Result; ;
        }

        public UserAnswer? PopularProfessors()
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/User/PopularProfessors";
            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
            {
                return resp.Content.ReadFromJsonAsync<UserAnswer>().Result;
            }

            return null;
        }

        public UserAnswer? RecoverAccess(User entity)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/User/RecoverAccess";
            JsonContent body = JsonContent.Create(entity);
            var resp = _httpClient.PostAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<UserAnswer>().Result;
            return null;
        }

        public UserAnswer? ChangePassword(User entity)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/User/ChangePassword";
            JsonContent body = JsonContent.Create(entity);
            var resp = _httpClient.PutAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<UserAnswer>().Result;
            return null;
        }

        public UserAnswer? BecomeProfessor(User entity)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/User/BecomeProfessor";

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            JsonContent body = JsonContent.Create(entity);
            var resp = _httpClient.PutAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<UserAnswer>().Result;
            return null;
        }

        public UserAnswer? AcceptOrRejectProfessor(User entity)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/User/AcceptOrRejectProfessor";
            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            JsonContent body = JsonContent.Create(entity);
            var resp = _httpClient.PutAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<UserAnswer>().Result;
            return null;
        }

        public UserAnswer? ViewProfessorApplicants()
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/User/ViewProfessorApplicants";

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<UserAnswer>().Result;

            return null;
        }

        public UserAnswer? SeeProfesorCourse(int CourseID)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/User/SeeProfesorCourse" + "/" + CourseID;

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<UserAnswer>().Result;

            return null;
        }

        public UserAnswer? SearchUser(int UserId)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/User/SearchUser/" + UserId;
            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
            {
                return resp.Content.ReadFromJsonAsync<UserAnswer>().Result;
            }

            return null;
        }

        public UserAnswer? ListProfessor()
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/User/ListProfessor";

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<UserAnswer>().Result;

            return null;
        }
    }
}

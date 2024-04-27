using Microsoft.EntityFrameworkCore;
using SistemaEducacion.Services;
using SistemaEducacion.WebEntities;
using System.Net.Http.Headers;

namespace SistemaEducacion.Models
{
    public class CourseModel(HttpClient _httpClient, IConfiguration _config, IHttpContextAccessor _context) : ICourse
    {
        public Answer? AddCourse(Course entity)
        {
            string url = _config.GetSection("settings:UrlWebApi").Value + "api/Course/AddCourse";

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            JsonContent body = JsonContent.Create(entity);
            var resp = _httpClient.PostAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<Answer>().Result;

            return null;
        }

        public CourseAnswer? ListCourses()
        {
            string url = _config.GetSection("settings:UrlWebApi").Value + "api/Course/ListCourses";

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<CourseAnswer>().Result;

            return null;
        }

        public CourseAnswer? PopularCourses()
        {
            string url = _config.GetSection("settings:UrlWebApi").Value + "api/Course/PopularCourses";

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<CourseAnswer>().Result;

            return null;
        }

        public CourseAnswer? ListMyCourses(int UserId)
        {
            string url = _config.GetSection("settings:UrlWebApi").Value + "api/Course/ListMyCourses/" + UserId;

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<CourseAnswer>().Result;

            return null;
        }

        public CourseAnswer? ListMySucriptionCourses(int UserId)
        {
            string url = _config.GetSection("settings:UrlWebApi").Value + "api/Course/ListMySuscriptionCourses/" + UserId;

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<CourseAnswer>().Result;

            return null;
        }


        public CourseAnswer? SeeLessonCourse(int CourseID)
        {
            string url = _config.GetSection("settings:UrlWebApi").Value + "api/Course/SeeLessonCourse" + "/" + CourseID;

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<CourseAnswer>().Result;

            return null;
        }

    }
}

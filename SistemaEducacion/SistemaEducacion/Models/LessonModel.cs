using Microsoft.EntityFrameworkCore;
using SistemaEducacion.Services;
using SistemaEducacion.WebEntities;
using System.Net.Http.Headers;

namespace SistemaEducacion.Models
{
    public class LessonModel(IConfiguration _config, HttpClient _httpClient, IHttpContextAccessor _context) : ILesson
    {
        public Answer? AddLesson(Lesson entity)
        {
            string url = _config.GetSection("settings:UrlWebApi").Value + "api/Lesson/RegisterLesson";
            JsonContent body = JsonContent.Create(entity);
            var resp = _httpClient.PostAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<Answer>().Result;      
            return null;
        }

        public LessonAnswer? LastInsert(int CourseID)
        {
            string url = _config.GetSection("settings:UrlWebApi").Value + "api/Lesson/LastInsert" + "/" + CourseID;

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<LessonAnswer>().Result;

            return null;
        }

        public LessonAnswer? SeeContentLesson(int LessonID)
        {
            string url = _config.GetSection("settings:UrlWebApi").Value + "api/Lesson/SeeContentLesson" + "/" + LessonID;

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<LessonAnswer>().Result;

            return null;
        }
    }
}

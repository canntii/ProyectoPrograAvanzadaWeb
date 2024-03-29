using Microsoft.AspNetCore.Http.HttpResults;
using SistemaEducacion.WebEntities;
using SistemaEducacion.Services;


namespace SistemaEducacion.Models
{
    public class UserModel(HttpClient _httpClient, IConfiguration _configuration) : IUserModel
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

        public UserAnswer? Login(User entity)
        {
            string url = _configuration.GetSection("settings:UrlWebApi").Value + "api/User/Login";
            JsonContent body = JsonContent.Create(entity);
            var resp = _httpClient.PostAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<UserAnswer>().Result;

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

        
    }
}

using Microsoft.EntityFrameworkCore;
using SistemaEducacion.Services;
using SistemaEducacion.WebEntities;
using System.Net.Http.Headers;

namespace SistemaEducacion.Models
{
    public class SuscriptionModel(IConfiguration _config, HttpClient _httpClient, IHttpContextAccessor _context) : ISubscription
    {
        public Answer? AddSuscription(Subscription entity)
        {
            string url = _config.GetSection("settings:UrlWebApi").Value + "api/Subscription/AddSuscription";
            JsonContent body = JsonContent.Create(entity);
            var resp = _httpClient.PostAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
            {
                return resp.Content.ReadFromJsonAsync<Answer>().Result;
            }

            return null;
        }

        public Answer? UpdateSuscription(Subscription entity)
        {
            string url = _config.GetSection("settings:UrlWebApi").Value + "api/Subscription/UpdateSubscription";
            JsonContent body = JsonContent.Create(entity);
            var resp = _httpClient.PutAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
            {
                return resp.Content.ReadFromJsonAsync<Answer>().Result;
            }

            return null;
        }

        public SubscriptionAnswer? ListSubscriptions()
        {
            string url = _config.GetSection("settings:UrlWebApi").Value + "api/Subscription/ListSubscriptions";

            string token = _context.HttpContext?.Session.GetString("Token")!;
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<SubscriptionAnswer>().Result;

            return null;
        }
    }
}

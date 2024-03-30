using SistemaEducacion.Entities;
using SistemaEducacion.Services;

namespace SistemaEducacion.Models
{
    public class SuscriptionModel(IConfiguration _config, HttpClient _httpClient) : ISuscription
    {
        public Answer AddSuscription(Suscription entity)
        {
            string url = _config.GetSection("settings:UrlWebApi").Value + "api/Suscription/AddSuscription";
            JsonContent body = JsonContent.Create(entity);
            var resp = _httpClient.PostAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
            {
                return resp.Content.ReadFromJsonAsync<Answer>().Result;
            }

            return null;
        }

        public Answer UpdateSuscription(Suscription entity)
        {
            string url = _config.GetSection("settings:UrlWebApi").Value + "api/Suscription/UpdateSubscription";
            JsonContent body = JsonContent.Create(entity);
            var resp = _httpClient.PutAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
            {
                return resp.Content.ReadFromJsonAsync<Answer>().Result;
            }

            return null;
        }
    }
}

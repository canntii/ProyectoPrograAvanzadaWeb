using Azure.Storage.Blobs;

namespace SistemaEducacion_API.Services
{
    public interface IUtilitariosModel
    {
        string GenerarToken(string userEmail);
        string Encrypt(string text);
        string GenerateNewPassword();
        void SendEmail(string Recipient, string Subject, string Message);
    }
}

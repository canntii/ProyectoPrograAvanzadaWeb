using Azure.Storage.Blobs;

namespace SistemaEducacion_API.Services
{
    public interface IUtilitariosModel
    {
        string GenerarToken(int UserID);
        string Encrypt(string text);
        string GenerateNewPassword();
        string Decrypt(string texto);
        void SendEmail(string Recipient, string Subject, string Message);
    }
}

using Azure.Storage.Blobs;
using SistemaEducacion_API.Entity;

namespace SistemaEducacion_API.Services
{
    public interface IUtilitariosModel
    {
        string GenerarToken(int UserID);
        string Encrypt(string text);
        string GenerateNewPassword();
        string Decrypt(string texto);
        void SendEmail(string Recipient, string Subject, string Message);
        UserAnswer BuscarUsuario(int UserId);
    }
}

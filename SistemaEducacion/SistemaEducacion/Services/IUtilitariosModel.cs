namespace SistemaEducacion.Services
{
    public interface IUtilitariosModel
    {
        public string Encrypt(string text);
        public string Decrypt(string text);
    }
}

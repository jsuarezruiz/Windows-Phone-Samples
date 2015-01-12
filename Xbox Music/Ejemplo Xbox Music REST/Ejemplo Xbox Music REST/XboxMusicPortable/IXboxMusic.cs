namespace Ejemplo_Xbox_Music.Services
{
    using Model;
    using System.Threading.Tasks;

    public interface IXboxMusic
    {
        string ClientId { get; set; }
        string ClientScecret { get; set; }
        Token Token { get; set; }
        string Country { get; set; }
        string Language { get; set; }

        Task<bool> Authenticate();
    }
}

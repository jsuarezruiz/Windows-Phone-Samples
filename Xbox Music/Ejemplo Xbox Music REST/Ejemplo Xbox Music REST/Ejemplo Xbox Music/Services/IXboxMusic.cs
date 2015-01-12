namespace Ejemplo_Xbox_Music.Services
{
    using Model;
    using System.Threading.Tasks;

    public interface IXboxMusic
    {
        string ClientId { get; set; }
        string ClientSecret { get; set; }

        Task<XboxMusicResult> Find(string query);
    }
}

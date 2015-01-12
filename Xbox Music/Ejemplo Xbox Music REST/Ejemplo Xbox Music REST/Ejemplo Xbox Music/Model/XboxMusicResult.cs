namespace Ejemplo_Xbox_Music.Model
{
    using Base;
    using System.Runtime.Serialization;

    [DataContract]
    public class XboxMusicResult
    {
        [DataMember]
        public PaginatedList<Artist> Artists { get; set; }

        [DataMember]
        public PaginatedList<Album> Albums { get; set; }

        [DataMember]
        public PaginatedList<Track> Tracks { get; set; }
    }
}

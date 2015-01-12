namespace Ejemplo_Xbox_Music.Model
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class ContentResponse
    {
        [DataMember]
        public IEnumerable<Artist> Artists { get; set; }

        [DataMember]
        public IEnumerable<Album> Albums { get; set; }

        [DataMember]
        public IEnumerable<Track> Tracks { get; set; }
    }
}

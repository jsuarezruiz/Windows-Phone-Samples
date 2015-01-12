using Ejemplo_Xbox_Music.Model.Base;

namespace Ejemplo_Xbox_Music.Model
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class Artist : XboxMusicBase
    {
        [DataMember]
        public List<string> Genres { get; set; }

        [DataMember]
        public List<Artist> RelatedArtists { get; set; }

        [DataMember]
        public List<Album> Albums { get; set; }

        [DataMember]
        public List<Track> TopTracks { get; set; }
    }
}
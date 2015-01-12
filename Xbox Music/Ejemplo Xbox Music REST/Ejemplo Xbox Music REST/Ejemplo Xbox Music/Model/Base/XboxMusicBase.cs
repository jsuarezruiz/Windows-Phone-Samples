using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Ejemplo_Xbox_Music.Model.Base
{
    [KnownType(typeof(Album))]
    [KnownType(typeof(Artist))]
    [KnownType(typeof(Track))]
    [DataContract]
    public class XboxMusicBase
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string ImageUrl { get; set; }

        [DataMember]
        public string Link { get; set; }

        [DataMember]
        public Dictionary<string, string> OtherIds { get; set; }

        [DataMember]
        public string Source { get; set; }
    }
}

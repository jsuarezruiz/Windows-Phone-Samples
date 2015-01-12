using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Ejemplo_Xbox_Music.Model.Base;

namespace Ejemplo_Xbox_Music.Model
{
    [DataContract]
    public class Track : XboxMusicBase
    {
        [DataMember]
        public TimeSpan? Duration { get; set; }

        [DataMember]
        public int? TrackNumber { get; set; }

        [DataMember]
        public bool? IsExplicit { get; set; }

        [DataMember]
        public List<string> Genres { get; set; }

        [DataMember]
        public List<string> Rights { get; set; }

        [DataMember]
        public Album Album { get; set; }
    }
}

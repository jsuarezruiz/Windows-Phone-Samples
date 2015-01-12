using Ejemplo_Xbox_Music.Model.Base;

namespace Ejemplo_Xbox_Music.Model
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class Album : XboxMusicBase
    {
        [DataMember]
        public DateTime? ReleaseDate { get; set; }

        [DataMember]
        public TimeSpan? Duration { get; set; }

        [DataMember]
        public int? TrackCount { get; set; }

        [DataMember]
        public bool? IsExplicit { get; set; }

        [DataMember]
        public string LabelName { get; set; }

        [DataMember]
        public List<string> Genres { get; set; }

        [DataMember]
        public string AlbumType { get; set; }

        [DataMember]
        public List<string> Rights { get; set; }
    }
}
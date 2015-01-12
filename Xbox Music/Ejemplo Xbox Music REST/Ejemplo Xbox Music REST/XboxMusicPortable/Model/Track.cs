﻿namespace Ejemplo_Xbox_Music.Model
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Track
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string ImageUrl { get; set; }
    }
}
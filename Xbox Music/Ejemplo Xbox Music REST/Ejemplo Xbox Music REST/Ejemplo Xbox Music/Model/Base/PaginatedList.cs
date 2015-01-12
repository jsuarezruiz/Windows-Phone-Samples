namespace Ejemplo_Xbox_Music.Model.Base
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class PaginatedList<T> where T: XboxMusicBase
    {
        [DataMember]
        public List<T> Items { get; set; } 

        [DataMember]
        public string ContinuationToken { get; set; }

    }
}

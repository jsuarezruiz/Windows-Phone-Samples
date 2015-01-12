using System;
using System.Runtime.Serialization;

namespace Ejemplo_Xbox_Music.Model
{
    [DataContract]
    public class TokenResult
    {
        [DataMember(Name = "access_token")]
        public string AccessToken { get; set; }

        [DataMember(Name = "token_type")]
        internal string TokenType { get; set; }

        [DataMember(Name = "expires_in")]
        internal int ExpiresInSeconds { get; set; }

        [DataMember(Name = "scope")]
        internal string Scope { get; set; }

        internal DateTime TimeStamp { get; set; }

        internal bool IsValid
        {
            get { return TimeStamp.AddSeconds(ExpiresInSeconds - 5) < DateTime.Now; }
        }

        internal bool NeedsRefresh
        {
            get { return TimeStamp.AddSeconds(ExpiresInSeconds - 30) < DateTime.Now; }
        }
    }
}

using System.Security.Cryptography;
using System.Text;

namespace SignalRDemos.Web.Hubs.SimpleChat
{
    internal static class GravatarHelpers
    {
        public static string GetImage(string email)
        {
            const string urlBase = "http://www.gravatar.com/avatar.php?gravatar_id={0}&size=20";
            if (email == null || !email.Contains("@"))
            {
                return string.Format(urlBase, "0");
            }
            byte[] hash = new MD5CryptoServiceProvider().ComputeHash(new UTF8Encoding().GetBytes(email.ToLower()));
            var str = new StringBuilder(hash.Length * 2);
            foreach (byte t in hash) 
                str.Append(t.ToString("X2"));
            return string.Format(urlBase, str.ToString().ToLower());
        }
    }
}
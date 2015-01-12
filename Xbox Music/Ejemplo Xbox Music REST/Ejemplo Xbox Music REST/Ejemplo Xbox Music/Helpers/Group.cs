using System.Collections.Generic;

namespace Ejemplo_Xbox_Music.Helpers
{
    public class Group<T> : List<T>
    {
        public Group(string type, IEnumerable<T> items)
            : base(items)
        {
            Type = type;
        }

        public string Type { get; set; }
    }
}
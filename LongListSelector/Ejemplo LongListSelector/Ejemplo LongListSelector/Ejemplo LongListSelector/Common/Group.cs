using System.Collections.Generic;

namespace Ejemplo_LongListSelector.Common
{
    public class Group<T> : List<T>
    {
        public Group(string name, IEnumerable<T> items)
            : base(items)
        {
            this.OS = name;
        }

        public string OS
        {
            get;
            set;
        }
    }
}

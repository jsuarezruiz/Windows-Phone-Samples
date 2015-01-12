using System.Collections.Generic;

namespace DoWapp.Services.Interfaces
{
    public interface ILocalDataService
    {
        IEnumerable<T> Load<T>(string file);
    }
}

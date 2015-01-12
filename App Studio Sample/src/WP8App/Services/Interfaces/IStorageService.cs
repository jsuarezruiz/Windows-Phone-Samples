using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPAppStudio.Services.Interfaces
{
    public interface IStorageService
    {
        T Load<T>(string fileName);
        bool Save<T>(string fileName, T data);
    }
}

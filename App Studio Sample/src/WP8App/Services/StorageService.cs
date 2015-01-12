using WPAppStudio.Services.Interfaces;
using System.IO;
using System.IO.IsolatedStorage;
using System.Xml.Serialization;

namespace WPAppStudio.Services
{
    public class StorageService : IStorageService
    {
        // Constructor
        public StorageService()
        {
        }

        // Deserializa un objeto de un fichero
        public T Load<T>(string fileName)
        {
            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!myIsolatedStorage.FileExists(fileName))
                    return default(T);
                
                using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile(fileName, FileMode.Open))
                {
                    var xml = new XmlSerializer(typeof(T));
                    T data = (T)xml.Deserialize(stream);
                    return data;
                }
            }
        }

        // Serializa un objeto a fichero
        public bool Save<T>(string fileName, T data)
        {
            try
            {
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream fileStream = myIsolatedStorage.CreateFile(fileName))
                    {
                        var xml = new XmlSerializer(typeof(T));
                        xml.Serialize(fileStream, data);
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

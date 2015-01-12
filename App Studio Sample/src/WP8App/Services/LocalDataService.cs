using DoWapp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;

namespace DoWapp.Services
{
    public class LocalDataService : ILocalDataService
    {
        public IEnumerable<T> Load<T>(string file)
        {
            var sri = App.GetResourceStream(new Uri(file, UriKind.Relative));
            var types = new List<Type> { typeof(T) };
            var deserializer = new DataContractJsonSerializer(typeof(IEnumerable<T>), types);

            return (IEnumerable<T>)deserializer.ReadObject(sri.Stream);
        }
    }
}

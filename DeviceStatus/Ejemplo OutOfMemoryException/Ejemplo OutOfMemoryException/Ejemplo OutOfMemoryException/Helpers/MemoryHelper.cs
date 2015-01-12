using Microsoft.Phone.Info;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace Ejemplo_OutOfMemoryException.Helpers
{
    public class MemoryHelper
    {
        private static Timer _timer;

        /// <summary>
        /// Obtiene la información de uso de memoria cada X segundos
        /// </summary>
        /// <param name="seconds">Tiempo marcado en segundos</param>
        public static void GetMemoryData(int seconds)
        {
            _timer = new Timer(state =>
            {
                string result = string.Empty;
                result += String.Format(@"
                            Fecha: {0}
                            Actual: {1}MB
                            Pico máximo: {2}MB
                            Límite de uso: {3}MB
                            Total dispositivo: {4}MB",
                            DateTime.Now.ToLongTimeString(),
                            (DeviceStatus.ApplicationCurrentMemoryUsage / 1000000).ToString(CultureInfo.InvariantCulture),
                            (DeviceStatus.ApplicationPeakMemoryUsage / 1000000).ToString(CultureInfo.InvariantCulture),
                            (DeviceStatus.ApplicationMemoryUsageLimit / 1000000).ToString(CultureInfo.InvariantCulture),
                            (DeviceStatus.DeviceTotalMemory / 1000000).ToString(CultureInfo.InvariantCulture));

                Deployment.Current.Dispatcher.BeginInvoke(() => Debug.WriteLine(result));
            },
                null,
                TimeSpan.FromSeconds(seconds),
                TimeSpan.FromSeconds(seconds));
        }
    }
}
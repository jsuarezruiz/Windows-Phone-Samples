using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Info;

namespace Ejemplo_OutOfMemoryException
{
    public partial class MainPage : PhoneApplicationPage
    {
        readonly List<Byte[]> _memoria;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            _memoria = new List<byte[]>();
        }

        private void AumentaMemoria_Click(object sender, RoutedEventArgs e)
        {
            _memoria.Add(new Byte[1024 * 1024 * 10]);

            ActualizarDatos();
        }

        private void LiberaMemoria_Click(object sender, RoutedEventArgs e)
        {
            _memoria.Clear();
            GC.Collect();

            ActualizarDatos();
        }

        private void ActualizarDatos()
        {
            Data.Text = String.Format(@"
                            Actual: {0}MB
                            Pico máximo: {1}MB
                            Límite de uso: {2}MB
                            Total dispositivo: {3}MB",
                (DeviceStatus.ApplicationCurrentMemoryUsage / 1000000).ToString(CultureInfo.InvariantCulture),
                (DeviceStatus.ApplicationPeakMemoryUsage / 1000000).ToString(CultureInfo.InvariantCulture),
                (DeviceStatus.ApplicationMemoryUsageLimit / 1000000).ToString(CultureInfo.InvariantCulture),
                (DeviceStatus.DeviceTotalMemory / 1000000).ToString(CultureInfo.InvariantCulture));
        }
    }
}
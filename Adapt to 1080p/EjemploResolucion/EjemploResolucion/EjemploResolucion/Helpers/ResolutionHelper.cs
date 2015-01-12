using System;
using System.Windows;
using Microsoft.Devices;
using Microsoft.Phone.Info;
using Environment = Microsoft.Devices.Environment;

namespace EjemploResolucion.Helpers
{
    public static class ResolutionHelper
    {
        private static double _screenSize = -1.0f;
        private static double _screenDpiX;
        private static double _screenDpiY;
        private static Size _size;

        public static bool Is1080P
        {
            get
            {
                if (Environment.DeviceType == DeviceType.Emulator)
                {
                    _screenSize = (Application.Current.Host.Content.ScaleFactor == 150) ? 6.0f : 0.0f;
                }

                if (_screenSize == -1.0f)
                {
                    try
                    {
                        _screenDpiX = (double) DeviceExtendedProperties.GetValue("RawDpiX");
                        _screenDpiY = (double) DeviceExtendedProperties.GetValue("RawDpiY");
                        _size = (Size) DeviceExtendedProperties.GetValue("PhysicalScreenResolution");

                        _screenSize =
                            Math.Sqrt(Math.Pow(_size.Width/_screenDpiX, 2) + Math.Pow(_size.Height/_screenDpiY, 2));
                    }
                    catch (Exception e)
                    {
                        _screenSize = 0;
                    }
                }

                return (_screenSize > 5.0f);
            }
        }
    }
}
using EjemploResolucion.Helpers;
using System;
using System.Windows;

namespace EjemploResolucion.Themes
{
    class ThemeSelector
    {
        public static void Set1080PTheme()
        {
            if (ResolutionHelper.Is1080P)
            {
                var the1080PTheme = new ResourceDictionary
                {
                    Source = new Uri("/EjemploResolucion;component/Themes/HDStyles.xaml", UriKind.RelativeOrAbsolute)
                };

                Application.Current.Resources.MergedDictionaries.Add(the1080PTheme);
            }
        }
    }
}

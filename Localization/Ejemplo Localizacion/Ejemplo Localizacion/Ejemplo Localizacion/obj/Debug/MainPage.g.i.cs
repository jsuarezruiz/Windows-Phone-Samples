﻿#pragma checksum "C:\Users\Javier\Documents\Visual Studio 2012\Projects\Ejemplo Localizacion\Ejemplo Localizacion\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "67A068050CFC3D16B4B21C8FA053AC24"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.18010
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Ejemplo_Localizacion {
    
    
    public partial class MainPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.StackPanel TitlePanel;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBlock tbLatitud;
        
        internal System.Windows.Controls.TextBlock tbLongitud;
        
        internal System.Windows.Controls.TextBlock tbVelocidad;
        
        internal System.Windows.Controls.TextBlock tbEstado;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Ejemplo%20Localizacion;component/MainPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.TitlePanel = ((System.Windows.Controls.StackPanel)(this.FindName("TitlePanel")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.tbLatitud = ((System.Windows.Controls.TextBlock)(this.FindName("tbLatitud")));
            this.tbLongitud = ((System.Windows.Controls.TextBlock)(this.FindName("tbLongitud")));
            this.tbVelocidad = ((System.Windows.Controls.TextBlock)(this.FindName("tbVelocidad")));
            this.tbEstado = ((System.Windows.Controls.TextBlock)(this.FindName("tbEstado")));
        }
    }
}


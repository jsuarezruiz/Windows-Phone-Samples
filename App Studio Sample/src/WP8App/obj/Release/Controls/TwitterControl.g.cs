﻿#pragma checksum "D:\DoWapp\Jobs\743.qrsaof\src\WP8App\Controls\TwitterControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7ED24182A1D78D80D96F2FE38B3ACFE0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18033
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
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


namespace DoWapp.Controls {
    
    
    public partial class TwitterControl : System.Windows.Controls.UserControl {
        
        internal Microsoft.Phone.Shell.ApplicationBarIconButton appbarTwitterRefresh;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock tbxSearchTerm;
        
        internal Microsoft.Phone.Controls.LongListSelector resultListBox;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/DoWapp;component/Controls/TwitterControl.xaml", System.UriKind.Relative));
            this.appbarTwitterRefresh = ((Microsoft.Phone.Shell.ApplicationBarIconButton)(this.FindName("appbarTwitterRefresh")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.tbxSearchTerm = ((System.Windows.Controls.TextBlock)(this.FindName("tbxSearchTerm")));
            this.resultListBox = ((Microsoft.Phone.Controls.LongListSelector)(this.FindName("resultListBox")));
        }
    }
}


﻿#pragma checksum "..\..\..\..\..\..\Views\User Control\UCGV\UCDeTaiGiangVien.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "25DB74C813992DAD0D14AF2A9F49B370A4DC5E71"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using EssayManagement.Views.User_Control;
using HandyControl.Controls;
using HandyControl.Data;
using HandyControl.Expression.Media;
using HandyControl.Expression.Shapes;
using HandyControl.Interactivity;
using HandyControl.Media.Animation;
using HandyControl.Media.Effects;
using HandyControl.Properties.Langs;
using HandyControl.Themes;
using HandyControl.Tools;
using HandyControl.Tools.Converter;
using HandyControl.Tools.Extension;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace EssayManagement.Views.User_Control {
    
    
    /// <summary>
    /// UCDeTaiGiangVien
    /// </summary>
    public partial class UCDeTaiGiangVien : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 17 "..\..\..\..\..\..\Views\User Control\UCGV\UCDeTaiGiangVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgvDeTai;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\..\..\Views\User Control\UCGV\UCDeTaiGiangVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLoad;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\..\..\Views\User Control\UCGV\UCDeTaiGiangVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HandyControl.Controls.CheckComboBox ccbLocGV;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\..\..\Views\User Control\UCGV\UCDeTaiGiangVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnThem;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/EssayManagement;component/views/user%20control/ucgv/ucdetaigiangvien.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Views\User Control\UCGV\UCDeTaiGiangVien.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.dgvDeTai = ((System.Windows.Controls.DataGrid)(target));
            
            #line 17 "..\..\..\..\..\..\Views\User Control\UCGV\UCDeTaiGiangVien.xaml"
            this.dgvDeTai.LoadingRow += new System.EventHandler<System.Windows.Controls.DataGridRowEventArgs>(this.DataGrid_LoadingRow);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnLoad = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\..\..\..\Views\User Control\UCGV\UCDeTaiGiangVien.xaml"
            this.btnLoad.Click += new System.Windows.RoutedEventHandler(this.btnLoad_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ccbLocGV = ((HandyControl.Controls.CheckComboBox)(target));
            
            #line 57 "..\..\..\..\..\..\Views\User Control\UCGV\UCDeTaiGiangVien.xaml"
            this.ccbLocGV.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ccbLocGV_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnThem = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\..\..\..\Views\User Control\UCGV\UCDeTaiGiangVien.xaml"
            this.btnThem.Click += new System.Windows.RoutedEventHandler(this.btnThem_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 3:
            
            #line 43 "..\..\..\..\..\..\Views\User Control\UCGV\UCDeTaiGiangVien.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnSua_Click);
            
            #line default
            #line hidden
            break;
            case 4:
            
            #line 46 "..\..\..\..\..\..\Views\User Control\UCGV\UCDeTaiGiangVien.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnXoa_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

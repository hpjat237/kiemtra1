﻿#pragma checksum "..\..\..\..\..\..\Views\User Control\UCSV\UCTaskSinhVien.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "78946D193E69331C520164C1DCDE16416A660E42"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using EssayManagement.Views.User_Control.UCSV;
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


namespace EssayManagement.Views.User_Control.UCSV {
    
    
    /// <summary>
    /// UCTaskSinhVien
    /// </summary>
    public partial class UCTaskSinhVien : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\..\..\Views\User Control\UCSV\UCTaskSinhVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgvNhom;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\..\..\Views\User Control\UCSV\UCTaskSinhVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLoad;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\..\..\Views\User Control\UCSV\UCTaskSinhVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button txtCapNhat;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\..\..\Views\User Control\UCSV\UCTaskSinhVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button txtThemTask;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\..\..\Views\User Control\UCSV\UCTaskSinhVien.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button txtBinhLuan;
        
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
            System.Uri resourceLocater = new System.Uri("/EssayManagement;component/views/user%20control/ucsv/uctasksinhvien.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Views\User Control\UCSV\UCTaskSinhVien.xaml"
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
            this.dgvNhom = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.btnLoad = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\..\..\Views\User Control\UCSV\UCTaskSinhVien.xaml"
            this.btnLoad.Click += new System.Windows.RoutedEventHandler(this.btnLoad_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txtCapNhat = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\..\..\..\Views\User Control\UCSV\UCTaskSinhVien.xaml"
            this.txtCapNhat.Click += new System.Windows.RoutedEventHandler(this.btnCapNhat_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtThemTask = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\..\..\..\Views\User Control\UCSV\UCTaskSinhVien.xaml"
            this.txtThemTask.Click += new System.Windows.RoutedEventHandler(this.btnThemTask_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtBinhLuan = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\..\..\..\Views\User Control\UCSV\UCTaskSinhVien.xaml"
            this.txtBinhLuan.Click += new System.Windows.RoutedEventHandler(this.btnBinhLuan_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


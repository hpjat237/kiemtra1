﻿#pragma checksum "..\..\..\..\..\Views\Windows\FDangNhap.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "BA0BBD3D61C324C399150F6E01D72F9E3BE92B9A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using EssayManagement;
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


namespace EssayManagement {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\..\..\Views\Windows\FDangNhap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal EssayManagement.MainWindow FDangNhap;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\..\Views\Windows\FDangNhap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExit;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\..\Views\Windows\FDangNhap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txbDangNhap;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\Views\Windows\FDangNhap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtTaiKhoan;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\..\Views\Windows\FDangNhap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox txtMatKhau;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\..\Views\Windows\FDangNhap.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDangNhap;
        
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
            System.Uri resourceLocater = new System.Uri("/EssayManagement;component/views/windows/fdangnhap.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Windows\FDangNhap.xaml"
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
            this.FDangNhap = ((EssayManagement.MainWindow)(target));
            return;
            case 2:
            this.btnExit = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\..\..\Views\Windows\FDangNhap.xaml"
            this.btnExit.MouseEnter += new System.Windows.Input.MouseEventHandler(this.btnExit_MouseEnter);
            
            #line default
            #line hidden
            
            #line 25 "..\..\..\..\..\Views\Windows\FDangNhap.xaml"
            this.btnExit.MouseLeave += new System.Windows.Input.MouseEventHandler(this.btnExit_MouseLeave);
            
            #line default
            #line hidden
            
            #line 25 "..\..\..\..\..\Views\Windows\FDangNhap.xaml"
            this.btnExit.Click += new System.Windows.RoutedEventHandler(this.btnExit_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.txbDangNhap = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.txtTaiKhoan = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.txtMatKhau = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 33 "..\..\..\..\..\Views\Windows\FDangNhap.xaml"
            this.txtMatKhau.KeyDown += new System.Windows.Input.KeyEventHandler(this.DangNhap_KeyDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnDangNhap = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\..\..\Views\Windows\FDangNhap.xaml"
            this.btnDangNhap.Click += new System.Windows.RoutedEventHandler(this.btnDangNhap_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


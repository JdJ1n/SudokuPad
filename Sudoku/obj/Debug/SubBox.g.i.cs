﻿#pragma checksum "..\..\SubBox.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "40EC27C81099E4D8D279F60A23B6A1500752CA7A4E0670C563EFD419FA7A901D"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Sudoku;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace Sudoku {
    
    
    /// <summary>
    /// SubBox
    /// </summary>
    public partial class SubBox : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\SubBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button textBox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\SubBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxLeftTop;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\SubBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxLeftBottom;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\SubBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxRightTop;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\SubBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxRightBottom;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\SubBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxCentre;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Sudoku;component/subbox.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\SubBox.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.textBox = ((System.Windows.Controls.Button)(target));
            return;
            case 2:
            this.textBoxLeftTop = ((System.Windows.Controls.TextBox)(target));
            
            #line 23 "..\..\SubBox.xaml"
            this.textBoxLeftTop.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextCornerChangedEventHandler);
            
            #line default
            #line hidden
            return;
            case 3:
            this.textBoxLeftBottom = ((System.Windows.Controls.TextBox)(target));
            
            #line 24 "..\..\SubBox.xaml"
            this.textBoxLeftBottom.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextCornerChangedEventHandler);
            
            #line default
            #line hidden
            return;
            case 4:
            this.textBoxRightTop = ((System.Windows.Controls.TextBox)(target));
            
            #line 25 "..\..\SubBox.xaml"
            this.textBoxRightTop.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextCornerChangedEventHandler);
            
            #line default
            #line hidden
            return;
            case 5:
            this.textBoxRightBottom = ((System.Windows.Controls.TextBox)(target));
            
            #line 26 "..\..\SubBox.xaml"
            this.textBoxRightBottom.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextCornerChangedEventHandler);
            
            #line default
            #line hidden
            return;
            case 6:
            this.textBoxCentre = ((System.Windows.Controls.TextBox)(target));
            
            #line 27 "..\..\SubBox.xaml"
            this.textBoxCentre.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextCentreChangedEventHandler);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

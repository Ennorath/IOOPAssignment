﻿#pragma checksum "..\..\Add Club.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "663269AE3829DD22639EADE7AF5D68A3489CA6A065ADCB590060ADA12A33E33C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using APUIOOPAssignment;
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


namespace APUIOOPAssignment {
    
    
    /// <summary>
    /// Add_Club
    /// </summary>
    public partial class Add_Club : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\Add Club.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image LogoClub;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Add Club.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtClubName;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Add Club.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbType;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\Add Club.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DateRegistered;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\Add Club.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPresident;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\Add Club.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtVicePresident;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\Add Club.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSecretary;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\Add Club.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RichTextBox txtDetails;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\Add Club.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddImage;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\Add Club.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TextBox1;
        
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
            System.Uri resourceLocater = new System.Uri("/APUIOOPAssignment;component/add%20club.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Add Club.xaml"
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
            this.LogoClub = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.txtClubName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.cmbType = ((System.Windows.Controls.ComboBox)(target));
            
            #line 21 "..\..\Add Club.xaml"
            this.cmbType.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbType_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DateRegistered = ((System.Windows.Controls.DatePicker)(target));
            
            #line 43 "..\..\Add Club.xaml"
            this.DateRegistered.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.DateClub_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtPresident = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtVicePresident = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtSecretary = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.txtDetails = ((System.Windows.Controls.RichTextBox)(target));
            return;
            case 9:
            
            #line 54 "..\..\Add Club.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnAddImage = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\Add Club.xaml"
            this.btnAddImage.Click += new System.Windows.RoutedEventHandler(this.btnAddImage_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.TextBox1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

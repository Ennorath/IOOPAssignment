﻿#pragma checksum "..\..\Admin Page.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "934A72AA3269E2A8216E872A2EE7B73977290A33945FBEDD8D0AEB1E0AF80F9C"
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
    /// Admin_Page
    /// </summary>
    public partial class Admin_Page : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\Admin Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClub;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Admin Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnViewMember;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Admin Page.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEditRepresentative;
        
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
            System.Uri resourceLocater = new System.Uri("/APUIOOPAssignment;component/admin%20page.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Admin Page.xaml"
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
            this.btnClub = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\Admin Page.xaml"
            this.btnClub.Click += new System.Windows.RoutedEventHandler(this.btnClub_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnViewMember = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\Admin Page.xaml"
            this.btnViewMember.Click += new System.Windows.RoutedEventHandler(this.btnViewMember_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnEditRepresentative = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\Admin Page.xaml"
            this.btnEditRepresentative.Click += new System.Windows.RoutedEventHandler(this.btnEditRepresentative_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


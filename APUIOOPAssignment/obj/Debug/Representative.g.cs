﻿#pragma checksum "..\..\Representative.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "6A4ED92B836A0E77DD88A227AB1463AAEAF2A6EA2F67F0B67C9058C1FD3154D0"
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
    /// Representative
    /// </summary>
    public partial class Representative : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\Representative.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnWeekly;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Representative.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClubInfo;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Representative.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnViewMember;
        
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
            System.Uri resourceLocater = new System.Uri("/APUIOOPAssignment;component/representative.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Representative.xaml"
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
            this.btnWeekly = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\Representative.xaml"
            this.btnWeekly.Click += new System.Windows.RoutedEventHandler(this.btnWeekly_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnClubInfo = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\Representative.xaml"
            this.btnClubInfo.Click += new System.Windows.RoutedEventHandler(this.ButtonClubInfo_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnViewMember = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\Representative.xaml"
            this.btnViewMember.Click += new System.Windows.RoutedEventHandler(this.btnViewMember_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


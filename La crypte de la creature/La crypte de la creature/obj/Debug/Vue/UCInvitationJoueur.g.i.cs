﻿#pragma checksum "..\..\..\Vue\UCInvitationJoueur.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8F5ED5F17243A3CED2A3261D6155E850"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.18444
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace La_crypte_de_la_creature.Vue {
    
    
    /// <summary>
    /// UCInvitationJoueur
    /// </summary>
    public partial class UCInvitationJoueur : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Vue\UCInvitationJoueur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbxDisponible;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Vue\UCInvitationJoueur.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbxInviter;
        
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
            System.Uri resourceLocater = new System.Uri("/La crypte de la creature;component/vue/ucinvitationjoueur.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Vue\UCInvitationJoueur.xaml"
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
            this.lbxDisponible = ((System.Windows.Controls.ListBox)(target));
            
            #line 11 "..\..\..\Vue\UCInvitationJoueur.xaml"
            this.lbxDisponible.GotFocus += new System.Windows.RoutedEventHandler(this.lbxDisponible_GotFocus);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 15 "..\..\..\Vue\UCInvitationJoueur.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnAjouterJoueur);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 16 "..\..\..\Vue\UCInvitationJoueur.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnEnleverJoueur);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lbxInviter = ((System.Windows.Controls.ListBox)(target));
            
            #line 18 "..\..\..\Vue\UCInvitationJoueur.xaml"
            this.lbxInviter.GotFocus += new System.Windows.RoutedEventHandler(this.lbxInviter_GotFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 22 "..\..\..\Vue\UCInvitationJoueur.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 23 "..\..\..\Vue\UCInvitationJoueur.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_Annuler);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


﻿#pragma checksum "..\..\..\Vue\UCPlateau.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "984099EFCF10FAC2F41FD05A8579135A"
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
    /// UCPlateau
    /// </summary>
    public partial class UCPlateau : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\Vue\UCPlateau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridJeu;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Vue\UCPlateau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgPion;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\Vue\UCPlateau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblNomUsager;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\Vue\UCPlateau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Coups;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\Vue\UCPlateau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblHistoriqueCourte;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\Vue\UCPlateau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblHistoriqueCourteMonstre;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\Vue\UCPlateau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Confirmer;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\Vue\UCPlateau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Annuler;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\Vue\UCPlateau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lboxPointage;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\Vue\UCPlateau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label JoueurCourant;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\Vue\UCPlateau.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChangeUser;
        
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
            System.Uri resourceLocater = new System.Uri("/La crypte de la creature;component/vue/ucplateau.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Vue\UCPlateau.xaml"
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
            this.GridJeu = ((System.Windows.Controls.Grid)(target));
            
            #line 19 "..\..\..\Vue\UCPlateau.xaml"
            this.GridJeu.KeyDown += new System.Windows.Input.KeyEventHandler(this.UserControl_KeyDown);
            
            #line default
            #line hidden
            
            #line 19 "..\..\..\Vue\UCPlateau.xaml"
            this.GridJeu.Loaded += new System.Windows.RoutedEventHandler(this.GridJeu_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.imgPion = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.lblNomUsager = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.Coups = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.lblHistoriqueCourte = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.lblHistoriqueCourteMonstre = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.Confirmer = ((System.Windows.Controls.Button)(target));
            
            #line 73 "..\..\..\Vue\UCPlateau.xaml"
            this.Confirmer.Click += new System.Windows.RoutedEventHandler(this.btnConfirme);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Annuler = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\..\Vue\UCPlateau.xaml"
            this.Annuler.Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 77 "..\..\..\Vue\UCPlateau.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.lboxPointage = ((System.Windows.Controls.ListBox)(target));
            return;
            case 11:
            this.JoueurCourant = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.ChangeUser = ((System.Windows.Controls.Button)(target));
            
            #line 93 "..\..\..\Vue\UCPlateau.xaml"
            this.ChangeUser.Click += new System.Windows.RoutedEventHandler(this.ChangeUser_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


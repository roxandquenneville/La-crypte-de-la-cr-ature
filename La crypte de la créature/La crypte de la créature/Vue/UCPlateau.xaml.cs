﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Cstj.MvvmToolkit.Services;
using Cstj.MvvmToolkit.Services.Definitions;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using La_crypte_de_la_creature.UI.VueModele;
using La_crypte_de_la_creature.VueModele;


namespace La_crypte_de_la_creature.Vue
{

    
    /// <summary>
    /// Logique d'interaction pour UCPlateau.xaml
    /// </summary>
    public partial class UCPlateau : System.Windows.Controls.UserControl
    {
        public int Pion = 0;
        public PartieViewModel PartieViewModel { get { return (PartieViewModel)DataContext; } }
        IApplicationService mainVM = ServiceFactory.Instance.GetService<IApplicationService>();

        public List<Deplacement> tmpList = new List<Deplacement>();
        public Position PositionAvantTour = new Position();
        public UCPlateau()
        {
            InitializeComponent();
            DataContext = new PartieViewModel();
            Loaded += WindowsLoaded;            

        }

        private void WindowsLoaded(Object o, RoutedEventArgs e)
        {
            lblNomUsager.Content = UtilisateurConnecte.nomUsager;
            afficherPointage();

        }


        private void afficherPointage()
        {
            int c = 1;
            foreach (Pointage p in PartieViewModel.Partie.Pointage)
            {
                StringBuilder Joueur = new StringBuilder().Append("Joueur ").Append(c).Append(" : ").Append(p.Point);
                lboxPointage.Items.Add(Joueur);
                c++;
            }
        }

        private void GridJeu_Loaded(object sender, RoutedEventArgs e)
        {
            GridJeu.Focus();
            AffichePlateau();
            SetPositionPion();
            lblHistoriqueCourte.Content = PartieViewModel.Historique.dernier_Mouvement();
            

        }


        private void SetPositionPion()
        {
            PositionAvantTour.X = PartieViewModel.Partie.Joueur[0].Pion[0].Position.X;
            PositionAvantTour.Y = PartieViewModel.Partie.Joueur[0].Pion[0].Position.Y; 
        }

        private void AffichePlateau()
        {
            GridJeu.Children.Clear();
            lblHistoriqueCourte.Content = PartieViewModel.Historique.dernier_Mouvement();
            foreach (Case c in PartieViewModel.Partie.Plateau.Cases)
            {
                String stringPath = c.Url;
                Uri imageUri = new Uri(stringPath, UriKind.RelativeOrAbsolute);
                BitmapImage imageBitmap = new BitmapImage(imageUri);
                Image myImage = new Image();
                myImage.Source = imageBitmap;

                GridJeu.Children.Add(myImage);
                Grid.SetColumn(myImage, c.Coordonnee.X);
                Grid.SetRow(myImage, c.Coordonnee.Y);
            }
            AfficherPiece();
        }

        private void AfficherPiece()
        {
            
            foreach (Piece c in PartieViewModel.Partie.Plateau.Pieces)
            {
                String stringPath = c.Url;
                if( stringPath !=null)
                {
                    if(c.Get_Type() == ConstanteGlobale.PION)
                    {                        
                        if(!((Pion)c).EstSortie || ((Pion)c).EstVivant)
                        {
                            AfficherPieceImage(stringPath, c);
                        } 
                    }
                    else
                    {
                        AfficherPieceImage(stringPath, c);
                    }
                }
            }
        }


        private void AfficherPieceImage(String url, Piece P )        
        {
            Uri imageUri = new Uri(url, UriKind.RelativeOrAbsolute);
            BitmapImage imageBitmap = new BitmapImage(imageUri);
            Image myImage = new Image();
            myImage.Source = imageBitmap;

            GridJeu.Children.Add(myImage);
            Grid.SetColumn(myImage, P.Position.X);
            Grid.SetRow(myImage, P.Position.Y);

            if (P.Get_Type() == ConstanteGlobale.PIERRE)
                GridJeu.Children[GridJeu.Children.Count - 1].SetValue(System.Windows.Controls.Panel.ZIndexProperty, 5);
        }

        public void UserControl_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            

            switch(e.Key)
            {
                case Key.Left:                    
                   
                    PartieViewModel.Partie.DeplacementDePion(tmpList, 0, Pion, ConstanteGlobale.GAUCHE);

                    Grid.SetColumn(imgPion, (PartieViewModel.Partie.Joueur[0].Pion[Pion].Position.X));
                    Grid.SetRow(imgPion, (PartieViewModel.Partie.Joueur[0].Pion[Pion].Position.Y));
                    AffichePlateau();
                    
                break;

                case Key.Right:
                   
                    PartieViewModel.Partie.DeplacementDePion(tmpList, 0, Pion, ConstanteGlobale.DROITE);

                    Grid.SetColumn(imgPion, (PartieViewModel.Partie.Joueur[0].Pion[Pion].Position.X));
                    Grid.SetRow(imgPion, (PartieViewModel.Partie.Joueur[0].Pion[Pion].Position.Y));
                    AffichePlateau();
                    
                break; 

                case Key.Up:
                   
                    PartieViewModel.Partie.DeplacementDePion(tmpList, 0, Pion, ConstanteGlobale.MONTE);

                    Grid.SetColumn(imgPion, (PartieViewModel.Partie.Joueur[0].Pion[Pion].Position.X));
                    Grid.SetRow(imgPion, (PartieViewModel.Partie.Joueur[0].Pion[Pion].Position.Y));
                    AffichePlateau();
                    
                break;
                case Key.Down:
                 
                    PartieViewModel.Partie.DeplacementDePion(tmpList, 0, Pion, ConstanteGlobale.DESCEND);

                    Grid.SetColumn(imgPion, (PartieViewModel.Partie.Joueur[0].Pion[Pion].Position.X));
                    Grid.SetRow(imgPion, (PartieViewModel.Partie.Joueur[0].Pion[Pion].Position.Y));
                    AffichePlateau();
                    
                break;
            }       
          
   
        }

        private void btnConfirme(object sender, RoutedEventArgs e)
        {
        //    PartieViewModel.SauvegarderCommand(); 
              if(Pion==0)
              Pion=1;
              else
              Pion=0;
              SetPositionPion();
              PartieViewModel.Partie.ConfirmerDeplacementPion(tmpList,1,Pion);
              lblHistoriqueCourte.Content = PartieViewModel.Historique.dernier_Mouvement();

               if (PartieViewModel.Partie.TourJoueur == (PartieViewModel.Partie.Joueur.Count() * PartieViewModel.Partie.Joueur[0].Pion.Count()))
               {
                    PartieViewModel.Partie.MouvementMonstre();
                    AffichePlateau();
                    PartieViewModel.Partie.TourJoueur =0;
               }
               tmpList.Clear();
                
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainVM.ChangeView<UCChoixPartie>(new UCChoixPartie());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PartieViewModel.Joueur.Pion[Pion].Position.X = PositionAvantTour.X;
            PartieViewModel.Joueur.Pion[Pion].Position.Y = PositionAvantTour.Y;
            AffichePlateau();
        }




    }
}

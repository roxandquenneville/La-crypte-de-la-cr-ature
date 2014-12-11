using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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
        public int Joueur =0;
        private int counter;
        private int nbTour=0;
        private int monstreJoue=0;
        Deplacement d = new Deplacement();
        Position ptmp = new Position();
        private static readonly object synchronizationObject = new object();
        public PartieViewModel PartieViewModel { get { return (PartieViewModel)DataContext; } }
        IApplicationService mainVM = ServiceFactory.Instance.GetService<IApplicationService>();
       

        public Historique tmpList = new Historique();
        public Position PositionAvantTour = new Position();
        public UCPlateau()
        {
            InitializeComponent();
            DataContext = new PartieViewModel();
            Loaded += WindowsLoaded; 
            Annuler.IsEnabled = false;
            Confirmer.IsEnabled = false;
       

        }
        public UCPlateau(string r)
        {
            InitializeComponent();
            DataContext = new PartieViewModel();
            Loaded += WindowsLoadedReprendre;


        }

        private void WindowsLoadedReprendre(Object o, RoutedEventArgs e)
        {
            PartieViewModel.reprendrePartieCommand();
            lblNomUsager.Content = UtilisateurConnecte.nomUsager;
            afficherPointage();

        }

        private void WindowsLoaded(Object o, RoutedEventArgs e)
        {
            PartieViewModel.CreerPartieCommand();
            lblNomUsager.Content = UtilisateurConnecte.nomUsager;
            afficherPointage();

        }


        private void afficherPointage()
        {
            lboxPointage.Items.Clear();
            int c = 0;
            foreach (Pointage p in PartieViewModel.Partie.Pointage)
            {
                String Joueur = new StringBuilder().Append(PartieViewModel.Partie.Joueur[c].Compte.NomUsager)
                                                         .Append(" : ").Append(p.Point).ToString();
              lboxPointage.Items.Add(Joueur);
              c++;
            }
        }

        private void GridJeu_Loaded(object sender, RoutedEventArgs e)
        {
            GridJeu.Focus();
            AffichePlateau();
            SetPositionPion();
            if (PartieViewModel.Historique.Deplacement.Count > 0)
            {
                lblHistoriqueCourte.Content = PartieViewModel.Historique.dernier_Mouvement();
            }
            NombreCoupAJouer();
            JoueurCourantAffichage();

        }


        private void SetPositionPion()
        {
            //PositionAvantTour.X = PartieViewModel.Partie.Joueur[0].Pion[0].Position.X;
            //PositionAvantTour.Y = PartieViewModel.Partie.Joueur[0].Pion[0].Position.Y; 
        }

        private void AffichePlateau()
        {
                afficherPointage();
                GridJeu.Children.Clear();
                //if (PartieViewModel.Historique.Deplacement.Count > 0)
                //{
                //    lblHistoriqueCourte.Content = PartieViewModel.Historique.dernier_Mouvement();
                //}
                foreach (Case c in PartieViewModel.Partie.Plateau.Case)
                {
                    c.DetermineImage();

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
            
            foreach (Piece c in PartieViewModel.Partie.Piece)
            {
                String stringPath = c.Url;
                if( stringPath !=null)
                {
                    if(c.Get_Type() == ConstanteGlobale.PION)
                    {                        
                        if(((Pion)c).EstSortie==false && ((Pion)c).EstVivant ==true)
                        {
                            AfficherPieceImage(stringPath, c);
                        } 
                    }
                    else if(c.Get_Type() == ConstanteGlobale.PIERRE)
                    {
                        if (((Pierre)c).EstSurPlateau)
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
    

            if (PartieViewModel.Partie.TourJoueur == (PartieViewModel.Partie.Joueur.Count() * PartieViewModel.Partie.Joueur[0].Pion.Count()))
            {
                
                System.Windows.Forms.MessageBox.Show("C'est au tour du monstre de jouer");
                if(monstreJoue ==0)
                {
                    Confirmer.IsEnabled = false;
                    InitializeTimer();
                }
            }
            else
            {
                GestionTour();
                if(PartieViewModel.Partie.Joueur[Joueur].Compte.NomUsager != UtilisateurConnecte.nomUsager)
                {
                    Confirmer.IsEnabled = false;
                    System.Windows.Forms.MessageBox.Show("Ce n'est pas à votre tour de joueur");
                }
                else
                {
                        Confirmer.IsEnabled = true;
                    switch(e.Key)
                    {
                        case Key.Left:


                            PartieViewModel.Partie.DeplacementDePion((List<Deplacement>)tmpList.Deplacement, Joueur, Pion, ConstanteGlobale.GAUCHE);

                            Grid.SetColumn(imgPion, (PartieViewModel.Partie.Joueur[Joueur].Pion[Pion].Position.X));
                            Grid.SetRow(imgPion, (PartieViewModel.Partie.Joueur[Joueur].Pion[Pion].Position.Y));
                            AffichePlateau();
                    
                        break;

                        case Key.Right:
                           
                            ptmp.X=PartieViewModel.Partie.Joueur[Joueur].Pion[Pion].Position.X;
                            ptmp.Y=PartieViewModel.Partie.Joueur[Joueur].Pion[Pion].Position.Y;

                            /* valide pour la fin d'un mouvement s'il est arrêter sur la case départ*/
 
                            ptmp.ChangePosition(ConstanteGlobale.DROITE);

                            if (ptmp.ValiderCaseDepart() == true && PartieViewModel.Partie.Joueur[Joueur].Pion[Pion].TmpDeplacement == 1)
                                break;

                            PartieViewModel.Partie.DeplacementDePion((List<Deplacement>)tmpList.Deplacement, Joueur, Pion, ConstanteGlobale.DROITE);

                            Grid.SetColumn(imgPion, (PartieViewModel.Partie.Joueur[Joueur].Pion[Pion].Position.X));
                            Grid.SetRow(imgPion, (PartieViewModel.Partie.Joueur[Joueur].Pion[Pion].Position.Y));
                            AffichePlateau();
                    
                        break; 

                        case Key.Up:

                        PartieViewModel.Partie.DeplacementDePion((List<Deplacement>)tmpList.Deplacement, Joueur, Pion, ConstanteGlobale.MONTE);

                        Grid.SetColumn(imgPion, (PartieViewModel.Partie.Joueur[Joueur].Pion[Pion].Position.X));
                        Grid.SetRow(imgPion, (PartieViewModel.Partie.Joueur[Joueur].Pion[Pion].Position.Y));
                            AffichePlateau();
                    
                        break;
                        case Key.Down:

                            ptmp.X=PartieViewModel.Partie.Joueur[Joueur].Pion[Pion].Position.X;
                            ptmp.Y=PartieViewModel.Partie.Joueur[Joueur].Pion[Pion].Position.Y;

                            ptmp.ChangePosition(ConstanteGlobale.DESCEND);

                            if (ptmp.ValiderCaseDepart() == true && PartieViewModel.Partie.Joueur[Joueur].Pion[Pion].TmpDeplacement == 1)
                                break;

                        PartieViewModel.Partie.DeplacementDePion((List<Deplacement>)tmpList.Deplacement, Joueur, Pion, ConstanteGlobale.DESCEND);

                            Grid.SetColumn(imgPion, (PartieViewModel.Partie.Joueur[Joueur].Pion[Pion].Position.X));
                            Grid.SetRow(imgPion, (PartieViewModel.Partie.Joueur[Joueur].Pion[Pion].Position.Y));
                            AffichePlateau();
                    
                        break;

                    }
                    if (PartieViewModel.Partie.Joueur[Joueur].Pion[Pion].Position.ValiderCaseDepart() == true)
                    Confirmer.IsEnabled = false;
                    else
                        Confirmer.IsEnabled = true;
                    if (tmpList.Deplacement.Count > 0)
                    {
                        lblHistoriqueCourte.Content = tmpList.dernier_Mouvement();
                    }
                    NombreCoupAJouer();
                }
            }

        }

        
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();

        private void InitializeTimer()
        {
            Confirmer.IsEnabled = false;
            monstreJoue=1;
            counter = 0;
            t.Interval = 1000;
           
            DoMything();
            if(nbTour==0)
            t.Tick += new EventHandler(timer1_Tick);
            nbTour++;
            t.Enabled = true;
            
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (counter >= 4 )
            {
                PartieViewModel.Partie.TourJoueur = 0;
                GestionTour();
                JoueurCourantAffichage();
                t.Enabled = false;     
            }
            else
            {
                //do something here 
                counter++;

                
                DoMything();
                lblHistoriqueCourteMonstre.Content = PartieViewModel.Partie.Historique.dernier_Mouvement();
            }
        }


        private void DoMything()
        {
               if(!(PartieViewModel.Partie.MouvementMonstre()))
               {
                    t.Enabled = false;
                    System.Windows.Forms.MessageBox.Show("Partie terminé","Fin de partie",MessageBoxButtons.OK);
                    mainVM.ChangeView<UCChoixPartie>(new UCChoixPartie());
               }
               else 
               {
                   AffichePlateau();
               }
                
          
        }

        private void NombreCoupAJouer()
        {
            Coups.Content = PartieViewModel.Partie.Joueur[Joueur].Pion[Pion].TmpDeplacement;
        }

        private void btnConfirme(object sender, RoutedEventArgs e)
        {
            if (PartieViewModel.Partie.TourJoueur == (PartieViewModel.Partie.Joueur.Count() * PartieViewModel.Partie.Joueur[0].Pion.Count()))
            {
                System.Windows.Forms.MessageBox.Show("C'est au tour du monstre de jouer");
            }
            else
            {
                GestionTour();
                if(PartieViewModel.Partie.Joueur[Joueur].Compte.NomUsager != UtilisateurConnecte.nomUsager)
                {
                    System.Windows.Forms.MessageBox.Show("Ce n'est pas à votre tour de joueur");
                }
                else
                {
                
                  PartieViewModel.SauvegarderCommand();

                  SetPositionPion();
              
                  PartieViewModel.Partie.ConfirmerDeplacementPion((List<Deplacement>)tmpList.Deplacement, Joueur, Pion);
                  
                  if (PartieViewModel.Historique.Deplacement.Count > 0 && tmpList.Deplacement.Count>0)
                  {
                      lblHistoriqueCourte.Content = PartieViewModel.Historique.dernier_Mouvement();
                  }
              
              
                      if (PartieViewModel.Partie.TourJoueur == (PartieViewModel.Partie.Joueur.Count() * PartieViewModel.Partie.Joueur[0].Pion.Count()))
                      {
                        JoueurCourantAffichage(" le Monstre");
                        InitializeTimer();
                      }
                      else
                      {
                          GestionTour();
                          JoueurCourantAffichage();
                      }

                  
                      NombreCoupAJouer();
                      PartieViewModel.SauvegarderCommand();
                      tmpList.Deplacement.Clear();
                    }     
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (PartieViewModel.Partie.TourJoueur != PartieViewModel.Partie.Joueur.Count * PartieViewModel.Partie.Joueur[0].Pion.Count)
            { 
                PartieViewModel.Partie = null;
                mainVM.ChangeView<UCChoixPartie>(new UCChoixPartie());
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PartieViewModel.Joueur.Pion[Pion].Position.X = PositionAvantTour.X;
            PartieViewModel.Joueur.Pion[Pion].Position.Y = PositionAvantTour.Y;
            AffichePlateau();
            
        }

        private void GestionTour()
        {
            double tmp =((double)(PartieViewModel.Partie.TourJoueur)/2);

            Joueur = (int)tmp;

            tmp = tmp - Joueur;

            Pion = (int)Math.Round(tmp, 0, MidpointRounding.AwayFromZero);
            Confirmer.IsEnabled = true;
            if (Joueur < PartieViewModel.Partie.Joueur.Count)
            { 

                if(PartieViewModel.Partie.Joueur[Joueur].Pion[Pion].EstVivant == false || PartieViewModel.Partie.Joueur[Joueur].Pion[Pion].EstSortie == true)
                {
                    PartieViewModel.Partie.TourJoueur++;
                    //tour du monstre
                    if (PartieViewModel.Partie.TourJoueur == (PartieViewModel.Partie.Joueur.Count() * PartieViewModel.Partie.Joueur[0].Pion.Count()))
                    {   
                        InitializeTimer();
                        Pion = 0;
                        Joueur = 0;
                    }
                    else
                    {
                        GestionTour();
                    }
                    NombreCoupAJouer();
                    PartieViewModel.SauvegarderCommand();
                    tmpList.Deplacement.Clear();
                }
            }
        }
        private void JoueurCourantAffichage(String tmp = "")
        {
            if (tmp == "")
            {
                tmp = PartieViewModel.Partie.Joueur[Joueur].Compte.NomUsager;
                JoueurCourant.Content = new StringBuilder().Append("C'est au ").Append(" Pion ")
                    .Append(Pion+1).Append(" de ").Append(tmp).Append(" à Jouer").ToString();
            }
            else
            {
                JoueurCourant.Content = new StringBuilder().Append("C'est au ").Append("Monstre")
                    .Append(" de Jouer").ToString();

            }      
        }

        private void ChangeUser_Click(object sender, RoutedEventArgs e)
        {
        
            Compte cTmp = new Compte();
            // met les donnée de L'utilisateur connecter dans un compte
            cTmp.NomUsager = UtilisateurConnecte.nomUsager;
            cTmp.idCompte = UtilisateurConnecte.idCompte;

            //Ajoute l'utilisateur connecter à la fin de la liste pour pouvoir le garder
            PartieViewModel.ListJoueurInvite.Add(cTmp);
            // Change L'utilisateur
            UtilisateurConnecte.nomUsager=PartieViewModel.ListJoueurInvite[0].NomUsager;
            UtilisateurConnecte.idCompte = PartieViewModel.ListJoueurInvite[0].idCompte;
            //Delete le premier joueur
            PartieViewModel.ListJoueurInvite.RemoveAt(0);

            lblNomUsager.Content = null;
            lblNomUsager.Content = UtilisateurConnecte.nomUsager;

        }

        private void Btn_Deconnexion(object sender, RoutedEventArgs e)
        {
            this.Content = new UCMainWindow();
        }

        private void Btn_Quitter(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }


        private void Btn_Guide(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Bouton :\n Changer d'utilisateur : permet de changer d'utilisateur sans confirmation de mot de passe.\n Confirmer tour: permet de confirmer la fin du mouvement d'un pion.\n Annuler tour: permet d'annuler le tour du pion\n Revenir: Permet de revenir à l'écran de choix de partie \n\nDéplacements: \nPour déplacer le pion il faut utiliser les touches de direction du clavier.\nLe pion seras déplacé d'une case à la fois.\nLe pion glisseras d'un bout à l'autre d'une marre de sang pour 1 point de déplacement \nLe pion peut pousser des pierres, temps que la case derrière est vide \n\nDéplacement du monstre: \nLe monstre regarde à sa gauche, à sa droite et devant lui. Il se dirigeras vers le pion le plus près qu'il voit. \nSi deux pions sont à la même distance dans son champs de vision le monstre continueras tout droit. \nLe monstre pourras aussi glisser sur les marres de sang \nLe monstre pousseras les pierres, peut importe se qu'il y a derrière. \nCe qui seras poussé au delà du mur par le monstre seras considéré comme détruit \n\nBut: \nLe but est de sortir de la crypte par la case sortie en haut à gauche du plateau sans se faire manger par le monstre. \nChaque pion qui sort vaut 1 point.");
        }

    } 
}

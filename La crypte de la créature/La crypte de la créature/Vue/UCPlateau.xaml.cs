using System;
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

        public PartieViewModel PartieViewModel { get { return (PartieViewModel)DataContext; } }
        IApplicationService mainVM = ServiceFactory.Instance.GetService<IApplicationService>();

        public List<Deplacement> tmpList = new List<Deplacement>();
        public Position PositionDeplacement = new Position();
        public UCPlateau()
        {
            InitializeComponent();
            DataContext = new PartieViewModel();
            Loaded += WindowsLoaded;



        }

        private void WindowsLoaded(Object o, RoutedEventArgs e)
        {
            lblNomUsager.Content = UtilisateurConnecte.nomUsager;

        }

        private void GridJeu_Loaded(object sender, RoutedEventArgs e)
        {
            GridJeu.Focus();


            foreach (Case c in PartieViewModel.Partie.Plateau.Case)
            {
                String stringPath = c.Url;
                Uri imageUri = new Uri(stringPath, UriKind.Relative);
                BitmapImage imageBitmap = new BitmapImage(imageUri);
                Image myImage = new Image();
                myImage.Source = imageBitmap;

                GridJeu.Children.Add(myImage);
                Grid.SetColumn(myImage, c.Coordonnee.X);
                Grid.SetRow(myImage, c.Coordonnee.Y);
            }
            foreach (Piece c in PartieViewModel.Partie.Plateau.Piece)
            {
                String stringPath = c.Url;
                Uri imageUri = new Uri(stringPath, UriKind.Relative);
                BitmapImage imageBitmap = new BitmapImage(imageUri);
                Image myImage = new Image();
                myImage.Source = imageBitmap;
                
                GridJeu.Children.Add(myImage);
                Grid.SetColumn(myImage, c.Position.X);
                Grid.SetRow(myImage, c.Position.Y);
            }

        }


        public void UserControl_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                PositionDeplacement.Y = Grid.GetRow(imgPion);
                PositionDeplacement.X = Grid.GetColumn(imgPion) - 1;
               Position p = PartieViewModel.Partie.Joueur[0].Pion[0].Position;
                PartieViewModel.Partie.DeplacementDePion(tmpList, 1, 1, PositionDeplacement);

                Grid.SetColumn(imgPion, (PartieViewModel.Partie.Joueur[0].Pion[0].Position.X));
                Grid.SetRow(imgPion, (PartieViewModel.Partie.Joueur[0].Pion[0].Position.Y));
            }
            if (e.Key == Key.Right)
            {

                PositionDeplacement.Y = Grid.GetRow(imgPion);
                PositionDeplacement.X = Grid.GetColumn(imgPion) + 1;
                PartieViewModel.Partie.DeplacementDePion(tmpList, 1, 1, PositionDeplacement);

                Grid.SetColumn(imgPion, (PartieViewModel.Partie.Joueur[0].Pion[0].Position.X));
                Grid.SetRow(imgPion, (PartieViewModel.Partie.Joueur[0].Pion[0].Position.Y));

            }
            if (e.Key == Key.Up)
            {
                PositionDeplacement.Y = Grid.GetRow(imgPion) - 1;
                PositionDeplacement.X = Grid.GetColumn(imgPion);
                PartieViewModel.Partie.DeplacementDePion(tmpList, 1, 1, PositionDeplacement);

                Grid.SetColumn(imgPion, (PartieViewModel.Partie.Joueur[0].Pion[0].Position.X));
                Grid.SetRow(imgPion, (PartieViewModel.Partie.Joueur[0].Pion[0].Position.Y));
            }
            if (e.Key == Key.Down)
            {
                PositionDeplacement.Y = Grid.GetRow(imgPion) + 1;
                PositionDeplacement.X = Grid.GetColumn(imgPion);
                PartieViewModel.Partie.DeplacementDePion(tmpList, 1, 1, PositionDeplacement);

                Grid.SetColumn(imgPion, (PartieViewModel.Partie.Joueur[0].Pion[0].Position.X));
                Grid.SetRow(imgPion, (PartieViewModel.Partie.Joueur[0].Pion[0].Position.Y));
            }
        }

        private void btnConfirme(object sender, RoutedEventArgs e)
        {
            PartieViewModel.SauvegarderCommand();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainVM.ChangeView<UCChoixPartie>(new UCChoixPartie());
        }


    }
}

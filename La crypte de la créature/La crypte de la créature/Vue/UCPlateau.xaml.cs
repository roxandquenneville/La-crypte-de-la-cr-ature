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

            for (int i = 0; i < 16; i++)
            {
                for (int y = 0; y < 12; y++)
                {
                    ImageBrush ImageFond = new ImageBrush();
                    ImageFond.ImageSource = (ImageSource)new ImageSourceConverter().ConvertFromString("D:/La-crypte-de-la-cr-ature/La crypte de la créature/La crypte de la créature/Images/CaseNormale.png");

                    Image img = new Image();
                    img.Source = ImageFond.ImageSource;
                    GridJeu.Children.Add(img);
                    Grid.SetColumn(img, i);
                    Grid.SetRow(img, y);

                    
                }
            }

        }

        
        public void UserControl_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                PositionDeplacement.Y = Grid.GetRow(imgPion);
                PositionDeplacement.X = Grid.GetColumn(imgPion) - 1;
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

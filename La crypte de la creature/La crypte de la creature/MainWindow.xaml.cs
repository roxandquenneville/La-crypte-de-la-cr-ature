using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using La_crypte_de_la_creature.Logic.Services.Interfaces;
using La_crypte_de_la_creature.Logic.Services.NHibernate;
using La_crypte_de_la_creature.UI.VueModele;
using La_crypte_de_la_creature.Vue;

namespace La_crypte_de_la_creature
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get { return (MainViewModel)DataContext; } }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            Configure();
            ViewModel.CurrentView = new UCPlateau();

        }

        private void Configure()
        {
            ServiceFactory.Instance.Register<ICompteService, NHibernateCompteService>(new NHibernateCompteService());
            ServiceFactory.Instance.Register<IDeplacementService, NHibernateDeplacementService>(new NHibernateDeplacementService());
            ServiceFactory.Instance.Register<IHistoriqueService, NHibernateHistoriqueService>(new NHibernateHistoriqueService());
            ServiceFactory.Instance.Register<IJoueurService, NHibernateJoueurService>(new NHibernateJoueurService());
            ServiceFactory.Instance.Register<IPositionService, NHibernatePositionService>(new NHibernatePositionService());
            ServiceFactory.Instance.Register<IPointageService, NHibernatePointageService>(new NHibernatePointageService());
            ServiceFactory.Instance.Register<IPartieService, NHibernatePartieService>(new NHibernatePartieService());
            ServiceFactory.Instance.Register<IPlateauService, NHibernatePlateauService>(new NHibernatePlateauService());
            ServiceFactory.Instance.Register<IApplicationService, MainViewModel>((MainViewModel)this.DataContext);

        }
    }
}

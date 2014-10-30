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
using La_crypte_de_la_creature.Logic.Modele.Classes;
using La_crypte_de_la_creature.VueModele;

namespace La_crypte_de_la_creature.Vue
{
    /// <summary>
    /// Logique d'interaction pour UCPlateau.xaml
    /// </summary>
    public partial class UCPlateau : System.Windows.Controls.UserControl
    {

        public PartieViewModel PartieViewModel { get { return (PartieViewModel)DataContext; } }

        public UCPlateau()
        {
            InitializeComponent();
            DataContext = new PartieViewModel();
            Loaded += WindowsLoaded;

        }

        private void WindowsLoaded(Object o ,RoutedEventArgs e)
        {
             lblNomUsager.Content = UtilisateurConnecte.nomUsager;
             this.Focusable  = true;
             //this.Focus;
            
        }
   
        private void Form_keyDown(Object sender, System.Windows.Forms.KeyEventArgs e, System.Windows.Forms.KeyEventHandler h)
        {

            if(e.KeyCode == Keys.Left)
            {               
               Grid.SetColumn(imgPion, (Grid.GetColumn(imgPion)-1));
            }
            if (e.KeyCode == Keys.Right)
            {
                Grid.SetColumn(imgPion, (Grid.GetColumn(imgPion) +1));
            }
            if (e.KeyCode == Keys.Up)
            {
                Grid.SetColumn(imgPion, (Grid.GetColumn(imgPion) - 1));
            }
            if (e.KeyCode == Keys.Down)
            {
                Grid.SetColumn(imgPion, (Grid.GetColumn(imgPion) + 1));
            } 
        }

       

    }
}

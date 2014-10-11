using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modele.Classes
{
    public class Partie
    {
        #region attribut
        private List<Joueur> listeDeJoueur;
        private Historique historiquePartie;
        private Plateau plateauPartie;
        private List<Pointage> listeDePointage;

        public virtual int? idPlateau { get; set; }
        public virtual int? idHistorique { get; set; }
        public virtual int? idPointage { get; set; }
        public virtual int? idPartie { get; set; }

        public virtual List<Joueur> ListeDeJoueur
        {
            get { return listeDeJoueur;}
            set 
            {   
                listeDeJoueur=value;
            }
        }

        public virtual Historique HistoriquePartie
        {
            get { return historiquePartie; }
            set
            {
                historiquePartie = value;
            }
        }
        public virtual Plateau PlateauPartie
        {
            get { return plateauPartie; }
            set
            {
                plateauPartie = value;
            }
        }


        public virtual List<Pointage> ListeDePointage
        {
            get { return listeDePointage; }
            set
            {
                listeDePointage = value;
            }
        }
        #endregion

        /// <summary>
        /// Constructeur de la classe Partie pour la bd
        /// </summary>
        public Partie()
        {
            ListeDeJoueur = new List<Joueur>();
            HistoriquePartie = new Historique();
            PlateauPartie = new Plateau();
            ListeDePointage = new List<Pointage>(); ;
        }



        /// <summary>
        /// Constructeur de la classe Partie
        /// </summary>
        /// <param name="historique">classe historique</param>
        /// <param name="plateau">classe plateau</param>
        /// <param name="pointage">classe plateau</param>
        /// <param name="listejoueur">liste de joueur</param>
        public Partie(Historique historique,Plateau plateau,List<Joueur> listejoueur)
        {
            ListeDeJoueur = listejoueur;
            HistoriquePartie = historique;
            PlateauPartie = plateau;
            ListeDePointage = new List<Pointage>(); ;
            
        }

        /// <summary>
        /// trouve c'est le tour à qui
        /// </summary>
        /// <returns>Retourne le id du joueur</returns>
        public int DetermineTour()
        {
            int NumJoueur=0;


            return NumJoueur;
        }
    }
}

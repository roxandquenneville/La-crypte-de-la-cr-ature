using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_créature.Logic.Modèle.Classes
{
    class Partie
    {
        #region attribut
        private Joueur[] tabJoueur;
        private Historique historiquePartie;
        private Plateau plateauPartie;
        private Pointage pointagePatie;

        public virtual int? idPlateau { get; set; }
        public virtual int? idHistorique { get; set; }
        public virtual int? idPointage { get; set; }

        public virtual Joueur[] TabJoueur
        {
            get { return tabJoueur;}
            set 
            {   
                tabJoueur=value;
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
        public virtual Pointage PointagePatie
        {
            get { return pointagePatie; }
            set
            {
                pointagePatie = value;
            }
        }
        #endregion

        /// <summary>
        /// Constructeur de la classe Partie
        /// </summary>
        /// <param name="nbrJoueur">Nombre de joueur dans la partie</param>
        public Partie(int nbrJoueur)
        {
            TabJoueur = new Joueur[nbrJoueur];
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modele.Classes
{
    class Partie
    {
        #region attribut
        private List<Joueur> listeDeJoueur;
        private Historique historiquePartie;
        private Plateau plateauPartie;
        private Pointage pointagePatie;

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
        /// <param name="historique">objet historique</param>
        /// <param name="plateau">objet plateau</param>
        /// <param name="pointage">objet plateau</param>
        public Partie(Historique historique,Plateau plateau,Pointage pointage)
        {
            ListeDeJoueur = new List<Joueur>();
            HistoriquePartie = historique;
            PlateauPartie = plateau;
            PointagePatie = pointage;
            
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

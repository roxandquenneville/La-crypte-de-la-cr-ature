using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_créature.Logic.Modèle.Classes
{
    class Partie
    {
        public Joueur[] TabJoueur;
        public Historique HistoriquePartie;
        public Plateau PlateauPartie;
        public Pointage PointagePatie;

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

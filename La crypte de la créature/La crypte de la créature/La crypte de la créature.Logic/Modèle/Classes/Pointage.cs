using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_créature.Logic.Modèle.Classes
{
    class Pointage
    {
        #region attribut
        public int[] Tabpoint;
        private int taille;
        #endregion

        /// <summary>
        /// Constructeur de la classe pointage
        /// Créer un tableau de la bonne taille et met toutes les cases a 0
        /// </summary>
        /// <param name="nbrJoueur">Le nombre de joueur de la partie</param>
        public Pointage(int nbrJoueur)
        {
            taille=nbrJoueur-1;

            Tabpoint = new int[taille];

            for (int i = 0; i < taille; i++)
            {
                Tabpoint[i] = 0;
            }

        }

        /// <summary>
        /// Lorsqu'on charge une partie déjà commencer
        /// </summary>
        /// <param name="nbrJoueur">Nombre de joueur</param>
        /// <param name="TabScore"> Tableau des scores</param>
        public Pointage(int nbrJoueur, int[] TabScore)
        {
            taille=(TabScore.Length)-1;

            Tabpoint = new int[taille];

            for (int i = 0; i < taille; i++)
            {
                Tabpoint[i] = TabScore[i];

            }

        }

        /// <summary>
        /// Permet de calculer le pointage modifie le tableau de point
        /// </summary>
       public void CalculerPointage()
       {
       
       }


        /// <summary>
        /// Retourne le pointage d'un joueur
        /// </summary>
        /// <param name="id">Numéro du joueur (1,2,3,4)</param>
        /// <returns>Si le nombre retourner est -1 le id n'existe pas</returns>
        public int Get_Point(int id)
        {
            if(id-1<=taille && id>1)
            {
                return Tabpoint[id-1];
            }
            else
            {
                return -1;
            }
        }


    }
}

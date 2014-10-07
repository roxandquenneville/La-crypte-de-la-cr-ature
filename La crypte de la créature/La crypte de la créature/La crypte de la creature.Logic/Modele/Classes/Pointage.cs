using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modele.Classes
{
    public class Pointage
    {
        #region attribut
        private List<int> listeDePoint;

        public virtual int? idPointage { get; set; }
        public virtual int? idTypeDePlateau { get; set; }

        public virtual List<int> ListeDePoint
        {
            get { return listeDePoint;}
            set 
            {
                listeDePoint = value;
            }

        }
       
        #endregion

        /// <summary>
        /// Constructeur de la classe pointage
        /// Créer un tableau de la bonne taille et met toutes les cases a 0
        /// </summary>
        public Pointage()
        {
            ListeDePoint = new List<int>();
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
            int longueur= (ListeDePoint.Count);

            if(id-1<=longueur && id>1)
            {
                return ListeDePoint[id-1];
            }
            else
            {
                return -1;
            }
        }


    }
}

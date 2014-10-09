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
        private int point;

        public virtual int? idPartie {get; set;}
        public virtual int? idPointage { get; set; }
        

        public virtual int Point
        {
            get { return point;}
            set 
            {
                point = value;
            }

        }
       
        #endregion

        /// <summary>
        /// Constructeur de la classe pointage
        /// Créer un tableau de la bonne taille et met toutes les cases a 0
        /// </summary>
        public Pointage(int score = 0)
        {
           Point= score;
        }


        /// <summary>
        /// Permet de calculer le pointage modifie le tableau de point
        /// </summary>
       public void CalculerPointage()
       {
       
       }




    }
}

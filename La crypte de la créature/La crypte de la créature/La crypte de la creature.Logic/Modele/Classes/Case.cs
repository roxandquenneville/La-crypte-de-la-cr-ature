using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modele.Classes
{
    public class Case
    {
        #region attribut
        private Position coordonnee;
        private bool interne;
        private string url;

        public virtual int? idCase { get; set; }
        public virtual int? idPlateau { get; set; }
        public virtual int? idPosition { get; set; }

        public virtual Position Coordonnee 
        { 
            get{return coordonnee;}
            set
            {
                coordonnee=value;
            }
        }
        #endregion

        /// <summary>
        /// Constructeur de la classe Case pour la bd
        /// </summary>
        public Case()
        {
            Coordonnee = new Position();
        }


        /// <summary>
        /// Constructeur de la classe Case
        /// Instancier une position et la passer dans le constructeur
        /// </summary>
        /// <param name="posXY">on passe une position</param>
        /// <param name="bExterne">faux si elle est en dehors du plateau sinon vrai</param>
        public Case(Position posXY,bool bInterne)
        {
            Coordonnee = posXY;
            interne=bInterne;
           
        }

        /// <summary>
        /// Determine si c'est une pierre,monstre,case,pion,case de sang à afficher. Rentre la valeur dans Url;
        /// </summary>
        public void DetermineImage()
        {
        }

    }
}

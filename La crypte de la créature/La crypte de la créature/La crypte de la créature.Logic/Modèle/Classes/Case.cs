using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_créature.Logic.Modèle.Classes
{
    class Case
    {
        #region attribut
        public Position Coordonnee { get;set;}
        private bool interne;
        private string url;

        public string Url
        {
            get { return url;}
            set
            {
                url=value;
            }

        }
        #endregion

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

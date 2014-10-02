using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_créature.Logic.Modèle.Classes
{
    class Plateau
    {
        #region attribut
        private List<Case> listeCase;

        public virtual int? idPlateau { get; set; }
        public virtual int? idTypeDePlateau { get; set; }

        public List<Case> ListeCase
        {
            get {return listeCase;}

            set 
            { 
               listeCase = value;
            }
        }
        #endregion

        /// <summary>
        /// Constructeur de la classe plateau
        /// </summary>
        public Plateau()
        {
          
       }

    }
}

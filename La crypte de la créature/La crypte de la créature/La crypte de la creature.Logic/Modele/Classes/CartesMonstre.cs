using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modele.Classes
{
    public class CartesMonstre
    {
         #region attribut
        private string url;
       

        public virtual int? idCarteMonstre { get; set; }
        public virtual Partie Partie { get; set;}
        public virtual int valeurDeplacement { get; set; }
        public virtual bool utilise { get; set; }
        public virtual List<int> ListeDeCarte {get;set; }
         #endregion
        /// <summary>
        /// constructeur vide de CartesMonstre
        /// </summary>
        public CartesMonstre()
        {
            ListeDeCarte = new List<int>();
        }

      



        

    }
}

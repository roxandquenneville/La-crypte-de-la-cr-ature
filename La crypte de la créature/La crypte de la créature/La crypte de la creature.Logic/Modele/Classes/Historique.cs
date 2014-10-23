using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modele.Classes
{
    public class Historique
    {
        #region attribut
        public virtual int? idHistorique { get; set; }
        public virtual List<Deplacement> Deplacement { get; set;}
        #endregion

        /// <summary>
        /// Constructeur de la classe Historique
        /// </summary>
        public Historique() 
        {
            Deplacement = new List<Deplacement>();
        }


    }
}

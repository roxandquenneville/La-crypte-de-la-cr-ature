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

        public virtual List<Deplacement> Deplacement {get; set; }
       
        #endregion

        /// <summary>
        /// Constructeur de la classe Historique
        /// </summary>
        public Historique() 
        {
            Deplacement = new List<Deplacement>();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Historique h = obj as Historique;

            if (h == null)
            {
                return false;
            }

            return this.idHistorique == h.idHistorique;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

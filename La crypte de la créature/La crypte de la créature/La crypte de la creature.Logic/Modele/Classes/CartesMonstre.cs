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
        public virtual int? idCarteMonstre { get; set; }
        public virtual string Url {get;set;}
        public virtual Partie Partie { get; set;}
        public virtual int ValeurDeplacement { get; set; }
        public virtual bool Utilise { get; set; }
         #endregion

        /// <summary>
        /// constructeur vide de CartesMonstre
        /// </summary>
        public CartesMonstre(){}



        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            CartesMonstre cm = obj as CartesMonstre;

            if (cm == null)
            {
                return false;
            }

            return this.idCarteMonstre == cm.idCarteMonstre;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        

    }
}

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


        public CartesMonstre(int deplacement) 
        { 
            ValeurDeplacement=deplacement;
            Utilise= false;
        }


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
       /* public static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }*/
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        

    }
}

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


        public virtual string  dernier_Mouvement()
        {
            
           int index = Deplacement.Count();
           string builder;
           if(index !=0)
                builder = "Depart : "+Deplacement[index-1].Depart.X.ToString()+ " , "+Deplacement[index-1].Depart.Y.ToString() + " / fin:"  +Deplacement[index-1].Fin.X.ToString()+Deplacement[index-1].Fin.Y.ToString();
           else
            return "";
           return builder;
        }

        public virtual List<string> liste_Dernier_Mouvement()
        {
               Deplacement.Reverse();
               List<string> lDeplacement=new List<string>();
            foreach(Deplacement item in Deplacement)
            {
               string builder = "Depart : " + item.Depart.X.ToString() + " , " + item.Depart.Y.ToString() + " / fin:" + item.Fin.X.ToString() + item.Fin.Y.ToString();
               lDeplacement.Add(builder);
            }
            Deplacement.Reverse();
            return lDeplacement;
            
        }

        
    }
}

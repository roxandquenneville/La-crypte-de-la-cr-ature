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

        public virtual IList<Deplacement> Deplacement {get; set; }
       
        #endregion

        /// <summary>
        /// Constructeur de la classe Historique
        /// </summary>
        public Historique() 
        {
            Deplacement = new List<Deplacement>();
        }

        public virtual string dernier_Mouvement()
        {

            int index = Deplacement.Count();
            string mouvement;
            if (index != 0)
                mouvement =new StringBuilder().Append("Depart : ").Append(Deplacement[index - 1].Depart.X.ToString()).Append(" , ")
                                              .Append(Deplacement[index - 1].Depart.Y.ToString()).Append(" / fin : ")
                                              .Append(Deplacement[index - 1].Fin.X.ToString()).Append(" , ")
                                              .Append(Deplacement[index - 1].Fin.Y.ToString())
                                              .ToString();
            else
                return "";
            return mouvement;
        }

        public virtual List<string> liste_Dernier_Mouvement()
        {
            Deplacement.Reverse();
            List<string> lDeplacement = new List<string>();
            foreach (Deplacement item in Deplacement)
            {
                string mouvement = new StringBuilder().Append("Depart : ").Append(item.Depart.X.ToString()).Append(" , ")
                                                     .Append(item.Depart.Y.ToString()).Append(" / fin : ").Append(item.Fin.X.ToString())
                                                     .Append(" , ").Append(item.Fin.Y.ToString()).ToString();
                lDeplacement.Add(mouvement);
            }
            Deplacement.Reverse();
            return lDeplacement;

        }

        public virtual string dernier_Mouvement_Monstre()
        {

            int index = Deplacement.Count();
            string mouvement;
            if (index != 0)
                mouvement = new StringBuilder().Append("Depart : ").Append(Deplacement[index - 1].Depart.X.ToString()).Append(" , ")
                                              .Append(Deplacement[index - 1].Depart.Y.ToString()).Append(" / fin:")
                                              .Append(Deplacement[index - 1].Fin.X.ToString()).Append(Deplacement[index - 1].Fin.Y.ToString())
                                              .ToString();
            else
                return "";
            return mouvement;
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

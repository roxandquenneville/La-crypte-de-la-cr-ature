using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modele.Classes
{
    public class Joueur
    {
        #region attribut
        public virtual int? idJoueur { get; set; }
        public virtual List<Pion> Pion { get; set;}
        public virtual Partie Partie { get; set;}
        public virtual Compte Compte { get; set;}
        #endregion
         
        /// <summary>
        /// constructeur de la classe Joueur
        /// </summary>
        public Joueur()
        {
            Pion = new List<Pion>();
        }

        /// <summary>
        /// Constructeur de la classe Joueur
        /// </summary>
        /// <param name="nbrPion">nombre de pion</param>
        public Joueur(int nbrPion)
        {
            Pion = new List<Pion>();
            if(nbrPion>0)
            {
                Random RdmDeplacement = new Random();
                int[] tabDeplacement = new int[nbrPion];

                for(int i=0;i<nbrPion;i++)
                {
                    tabDeplacement[i]=RdmDeplacement.Next(1,6);
                    Pion.Add(new Pion(tabDeplacement[i]));
                }
            }

        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Joueur j = obj as Joueur;

            if (j == null)
            {
                return false;
            }

            return this.idJoueur == j.idJoueur;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

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
        private List<Pion> listePion;

        public virtual int? idJoueur { get; set; }
        public virtual int? idPion { get; set; }
        public virtual int? idPartie { get; set; }
        public virtual int? idCompte { get; set; }

        public virtual List<Pion> ListePion
        {
            get {return listePion;}
            set 
            {
                listePion = value;
            }

        }
        #endregion
         
        /// <summary>
        /// constructeur de la classe Joueur
        /// </summary>
        public Joueur()
        {
            ListePion = new List<Pion>();
        }

        /// <summary>
        /// Constructeur de la classe Joueur
        /// </summary>
        /// <param name="nbrPion">nombre de pion</param>
        public Joueur(int nbrPion)
        {
            if(nbrPion>0)
            {
                Random RdmDeplacement = new Random();
                int[] tabDeplacement = new int[nbrPion];

                for(int i=0;i<nbrPion;i++)
                {
                    tabDeplacement[i]=RdmDeplacement.Next(1,6);
                    ListePion.Add(new Pion(tabDeplacement[i]));
                }
            }

        }
    }
}

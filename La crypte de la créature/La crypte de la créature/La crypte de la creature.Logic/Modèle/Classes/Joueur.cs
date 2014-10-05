using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modèle.Classes
{
    class Joueur
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
    }
}

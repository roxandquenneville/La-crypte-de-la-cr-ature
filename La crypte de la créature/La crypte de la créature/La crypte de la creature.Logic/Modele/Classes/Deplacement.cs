using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modele.Classes
{
    public class Deplacement
    {
        #region attribut
        private Position depart;
        private Position fin;

        public virtual int? idDeplacement { get; set; }
        public virtual int? idPartie { get; set; }
        public virtual int? idPiece { get; set; }
        public virtual int? idHistorique { get; set; }
        

        public virtual Position Depart
        {
            get {return depart;}
            set {depart=value;}
        }

        public virtual Position Fin
        {
            get { return fin; }
            set { fin = value; }
        }
        #endregion


        /// <summary>
        /// Constructeur de la classe Deplacement pour la bd
        /// </summary>
        public Deplacement()
        {
            Depart = new Position();
            Fin = new Position();
        }


        /// <summary>
        /// Constructeur de la classe deplacement
        /// Instancier deux positions et la passer dans le constructeur
        /// </summary>
        /// <param name="posDepart">Position de départ</param>
        /// <param name="posFin">Position de Fin</param>
        public Deplacement(Position posDepart,Position posFin)
        {
            Depart=posDepart;
            Fin=posFin;
        }

        /// <summary>
        /// Confirme le mouvement. 
        /// La fonction est Private ,car elle est appeler seulement dans la classe déplacement par une autre fonction
        /// </summary>
        /// <returns>Retourne vrai si le déplacement est valide sinon retourne faux</returns>
        public bool Confirmation(Plateau plateau)
        {
            bool Valide=true;

            return Valide;
        }

       

    }
}

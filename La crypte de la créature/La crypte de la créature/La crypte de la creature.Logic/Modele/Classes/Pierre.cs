using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modele.Classes
{
    public class Pierre : Piece
    {
        #region attribut

        //public virtual int? idPiece { get; set; }
        public virtual int? idPierre { get { return base.idPiece; } set { base.idPiece = value; } }

        public virtual bool EstSurPlateau { get; set; }
        #endregion


        /// <summary>
        /// constructeur de la classe Pierre
        /// </summary>
        public Pierre():base()
        {
        }


        /// <summary>
        /// Constructeur de la classe pierre
        /// </summary>
        /// <param name="posXY">position de la pierre</param>
        /// <param name="enJeu">Vrai si la pierre est en jeu sinon faux </param>
        public Pierre(Position posXY, bool enJeu):base(posXY)
        {
            EstSurPlateau=enJeu;
            DetermineImage();
        }

        /// <summary>
        /// Retourne le type
        /// </summary>
        /// <returns>Retourne la string "Pierre"</returns>
        public override string Get_Type() { return ConstanteGlobale.PIERRE; }


        /// <summary>
        /// Determine l'image de la pierre
        /// </summary>
        public override void DetermineImage()
        {
            Url = "../La crypte de la créature/Images/CasePillier.png";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Pierre p = obj as Pierre;

            if (p == null)
            {
                return false;
            }

            return this.idPierre == p.idPierre;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

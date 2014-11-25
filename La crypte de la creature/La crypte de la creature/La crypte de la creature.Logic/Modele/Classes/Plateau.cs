using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cstj.MvvmToolkit.Services;
using La_crypte_de_la_creature.Logic.Services.Interfaces;

namespace La_crypte_de_la_creature.Logic.Modele.Classes
{
    public class Plateau
    {
        #region attribut
        public virtual String type { get; set; }
        public virtual int? idPlateau { get; set; }
        public virtual IList<Case> Case { get;set;}
       
        
        #endregion

        /// <summary>
        /// Constructeur de la classe plateau
        /// </summary>
        public Plateau()
        {
          Case = new List<Case>();
          
        }
        public Plateau(IList<Case> cases)
        {


        }

        /// <summary>
        /// Constructeur de la classe plateau
        /// </summary>
        public Plateau(string nom)
        {
            Case = new List<Case>();

               for(int x=0;x<16;x++)
                {
                    for(int y=0;y<11;y++)
                    {
                        Case.Add(new Case(new Position(x, y)));
                    }
                }
        }


       
        /// <summary>
        /// Vérifie si la case n'est pas dans le plateau ou encore externe
        /// </summary>
        /// <param name="pos">Position à vérifier</param>
        /// <returns>retourne true si la case est présente et non externe sinon retourne false</returns>
        public virtual bool ConfirmationCase(Position pos)
        {
            bool Present = false;
            //vérifie si la case est dans la liste de case du plateau
            foreach (Case item in Case)
            {
                if (item.Coordonnee.X == pos.X && item.Coordonnee.Y == pos.Y)
                {
                    Present = true;
                    //vérifie que le case est interne
                    if (item.Interne == false)
                    {
                        return false;
                    }
                }

            }
            return Present;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Plateau p = obj as Plateau;

            if (p == null)
            {
                return false;
            }

            return this.idPlateau == p.idPlateau;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}

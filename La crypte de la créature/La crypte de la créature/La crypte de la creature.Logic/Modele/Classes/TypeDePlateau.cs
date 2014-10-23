using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modele.Classes
{
    public class TypePlateau
    {
        private string nomDePlateau;

        public virtual int? idTypePlateau { get; set; }

        public virtual string NomDePlateau
        {
            get { return nomDePlateau; }
            set
            {
                nomDePlateau = value;
            }
        }

        /// <summary>
        /// Constructeur de la classe Type de plateau
        /// </summary>
        /// <param name="plateau">on y passe le nom du type de plateau</param>
        public TypePlateau(string plateau="")
        {
            NomDePlateau = plateau;
        }
        // Constructeur vide
        public TypePlateau()
        {
         NomDePlateau = ""; 
        }

    }
}

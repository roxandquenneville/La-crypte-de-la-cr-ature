using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modele.Args
{
    public class RetrievePionArgs
    {
        public int idPion { get; set; }
        public int idPiece { get; set; }
        public int idJoueur { get; set; }
        public int valeurDeplacement { get; set; }
        public bool estVivant { get; set; }
        public bool estSortie { get; set; }
    }
}

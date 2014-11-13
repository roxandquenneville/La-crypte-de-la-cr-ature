using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using La_crypte_de_la_creature.Logic.Modele.Classes;

namespace La_crypte_de_la_creature.Logic.Modele.Args
{
    public class RetrieveDeplacementArgs
    {
        public int? idDeplacement { get; set; }
        public int idPartie { get; set; }
        public int idPiece { get; set; }
        public int idHistorique { get; set; }
        public Position Fin { get; set; }
        public Position Depart { get; set; }
    }
}

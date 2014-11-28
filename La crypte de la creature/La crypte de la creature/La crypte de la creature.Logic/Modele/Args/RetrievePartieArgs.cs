using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modele.Args
{
    public class RetrievePartieArgs
    {
        public int? idPartie { get; set; }
        public int? idPlateau { get; set; }
        public int? idHistorique { get; set; }
    }
}

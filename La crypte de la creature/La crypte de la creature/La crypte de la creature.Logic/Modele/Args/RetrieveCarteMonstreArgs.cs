using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modele.Args
{
    public class RetrieveCarteMonstreArgs
    {
        public int idCarteMonstre { get; set; }
        public int idPartie { get; set; }
        public int valeurDeplacement { get; set; }
        public bool utilise { get; set; }
    }
}

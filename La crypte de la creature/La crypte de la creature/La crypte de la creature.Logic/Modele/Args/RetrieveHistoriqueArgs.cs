using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using La_crypte_de_la_creature.Logic.Modele.Classes;

namespace La_crypte_de_la_creature.Logic.Modele.Args
{
    public class RetrieveHistoriqueArgs
    {
        public int idHistorique { get; set; }
        public IList<Deplacement> ListeDeplacement { get; set; }
    }
}

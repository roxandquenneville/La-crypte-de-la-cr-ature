using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using La_crypte_de_la_creature.Logic.Modele.Classes;

namespace La_crypte_de_la_creature.Logic.Modele.Args
{
    public class RetrieveJoueurArgs
    {
        public int idJoueur { get; set; }
        public int idPartie { get; set; }
        public int idCompte { get; set; }
        public IList<Pion> listePion { get; set;}
    }
}

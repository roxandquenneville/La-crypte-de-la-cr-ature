using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Modele.Args
{
    public class RetrieveCompteArgs
    {
        public int? idCompte { get; set; }
		public string nomUsager { get; set; }
		public string motDePasse { get; set; }
        public string email { get; set;}
    }
}
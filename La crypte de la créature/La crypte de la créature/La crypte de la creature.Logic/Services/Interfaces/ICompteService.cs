using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using La_crypte_de_la_creature.Logic.Modele.Args;

namespace La_crypte_de_la_creature.Services.Definitions
{
    public interface ICompteService
    {
        IList<Compte> RetrieveAll();
        Compte Retrieve(RetrieveCompteArgs args);
        void Create(Compte propriete);
        void Update(Compte propriete);
        void Delete(Compte propriete);
    }
}
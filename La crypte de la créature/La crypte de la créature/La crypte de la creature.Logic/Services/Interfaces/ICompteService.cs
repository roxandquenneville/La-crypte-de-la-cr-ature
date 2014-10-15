using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using La_crypte_de_la_creature.Logic.Modele.Args;

namespace La_crypte_de_la_creature.Logic.Services.Interfaces
{
    public interface ICompteService
    {
        IList<Compte> RetrieveAll();
        Compte Retrieve(RetrieveCompteArgs args);
        void Create(Compte c);
        void Update(Compte c);
        void Delete(Compte c);
    }
}
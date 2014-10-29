using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using La_crypte_de_la_creature.Logic.Modele.Args;

namespace La_crypte_de_la_creature.Logic.Services.Interfaces
{
    public interface ICaseService
    {
        IList<Case> RetrieveAll();
        Case Retrieve(RetrieveCaseArgs args);
        void Create(Case c);
        void Update(Case c);
        void Delete(Case c);
    }
}

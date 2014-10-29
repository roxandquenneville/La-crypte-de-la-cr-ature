using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using La_crypte_de_la_creature.Logic.Modele.Args;

namespace La_crypte_de_la_creature.Logic.Services.Interfaces
{
    public interface ICaseSangService
    {
        IList<CaseDeSang> RetrieveAll();
        CaseDeSang Retrieve(RetrieveCaseSangArgs args);
        void Create(CaseDeSang c);
        void Update(CaseDeSang c);
        void Delete(CaseDeSang c);
    }
}

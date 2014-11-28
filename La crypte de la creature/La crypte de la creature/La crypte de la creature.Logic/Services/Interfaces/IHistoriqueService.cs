using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using La_crypte_de_la_creature.Logic.Modele.Args;

namespace La_crypte_de_la_creature.Logic.Services.Interfaces
{
    public interface IHistoriqueService
    {
        IList<Historique> RetrieveAll();
        Historique Retrieve(RetrieveHistoriqueArgs args);
        Historique RetrieveLast(RetrieveHistoriqueArgs args);
        void Create(Historique h);
        void Update(Historique h);
        void Delete(Historique h);
    }
}

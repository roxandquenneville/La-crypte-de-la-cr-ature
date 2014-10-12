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
        void Create(Historique h);
        IList<Historique> RetrieveAll();
        Joueur Retrieve(RetrieveHistoriqueArgs args);
        void Update(Historique h);
        void Delete(Historique h);
    }
}

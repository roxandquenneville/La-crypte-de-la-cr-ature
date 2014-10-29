using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using La_crypte_de_la_creature.Logic.Modele.Args;

namespace La_crypte_de_la_creature.Logic.Services.Interfaces
{
    public interface IMarreSangService
    {
        IList<MarreDeSang> RetrieveAll();
        MarreDeSang Retrieve(RetrieveMarreSangArgs args);
        void Create(MarreDeSang c);
        void Update(MarreDeSang c);
        void Delete(MarreDeSang c);
    }
}

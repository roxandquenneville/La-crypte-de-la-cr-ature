using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using La_crypte_de_la_creature.Logic.Modele.Args;

namespace La_crypte_de_la_creature.Logic.Services.Interfaces
{
    public interface IMonstreService
    {
        IList<Monstre> RetrieveAll();
        Monstre Retrieve(RetrieveMonstreArgs args);
        void Create(Monstre c);
        void Update(Monstre c);
        void Delete(Monstre c);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using La_crypte_de_la_creature.Logic.Modele.Args;

namespace La_crypte_de_la_creature.Logic.Services.Interfaces
{
    public interface IPartieService
    {
        IList<Partie> RetrieveAll();
        Partie Retrieve(RetrievePartieArgs args);
        void Create(Partie p);
        void Update(Partie p);
        void Delete(Partie p);
    }
}

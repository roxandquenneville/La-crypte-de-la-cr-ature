using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using La_crypte_de_la_creature.Logic.Modele.Args;

namespace La_crypte_de_la_creature.Logic.Services.Interfaces
{
    public interface ICarteMonstreService
    {
        IList<CartesMonstre> RetrieveAll();
        CartesMonstre Retrieve(RetrieveCarteMonstreArgs args);
        void Create(CartesMonstre c);
        void Update(CartesMonstre c);
        void Delete(CartesMonstre c);
    }
}
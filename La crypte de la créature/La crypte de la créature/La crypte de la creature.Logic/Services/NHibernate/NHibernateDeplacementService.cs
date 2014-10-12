using La_crypte_de_la_creature.Logic.Modele.Args;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using La_crypte_de_la_creature.Logic.Services.NHibernate;
using La_crypte_de_la_creature.Services.Definitions;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Linq;
using System.Threading.Tasks;
using Immobilus.Logic.Services.Helpers;
using La_crypte_de_la_creature.Logic.Services.Interfaces;

namespace La_crypte_de_la_creature.Logic.Services.NHibernate
{
    public class NHibernateDeplacementService : IDeplacementService
    {
        private ISession session = NHibernateConnexion.OpenSession();

        #region ICompteService Membres
        public IList<Deplacement> RetrieveAll()
        {
            throw new NotImplementedException();
        }

        public Deplacement Retrieve(RetrieveDeplacementArgs args)
        {
            throw new NotImplementedException();
        }

        public void Create(Deplacement d)
        {
            throw new NotImplementedException();
        }

        public void Update(Deplacement d)
        {
            throw new NotImplementedException();
        }

        public void Delete(Deplacement d)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

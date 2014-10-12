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
    public class NHibernatePositionService : IPositionService 
    {
        private ISession session = NHibernateConnexion.OpenSession();


        #region IJoueurService Membres

        public IList<Position> RetrieveAll()
        {
            throw new NotImplementedException();
        }

        public Position Retrieve(RetrievePositionArgs args)
        {
            throw new NotImplementedException();
        }

        public void Create(Position p)
        {
            throw new NotImplementedException();
        }

        public void Update(Position p)
        {
            throw new NotImplementedException();
        }

        public void Delete(Position p)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

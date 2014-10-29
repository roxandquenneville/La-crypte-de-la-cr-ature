using La_crypte_de_la_creature.Logic.Modele.Args;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using La_crypte_de_la_creature.Logic.Services.NHibernate;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Linq;
using System.Threading.Tasks;
using La_crypte_de_la_creature.Logic.Services.Helpers;
using La_crypte_de_la_creature.Logic.Services.Interfaces;

namespace La_crypte_de_la_creature.Logic.Services.NHibernate
{
    public class NHibernatePierreService : IPierreService
    {
        private ISession session = NHibernateConnexion.OpenSession();
        #region IPierreService Members

        public IList<Pierre> RetrieveAll()
        {
            return session.Query<Pierre>().ToList();
        }

        public Pierre Retrieve(RetrievePierreArgs args)
        {
            var result = from p in session.Query<Pierre>()
                         where p.idPierre == args.idPierre
                         select p;

            return result.FirstOrDefault();

        }

        public void Create(Pierre p)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(p);
                transaction.Commit();
            }
        }

        public void Update(Pierre p)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(p);
                transaction.Commit();
            }
        }

        public void Delete(Pierre p)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(p);
                transaction.Commit();
            }
        }

        #endregion
    }
}


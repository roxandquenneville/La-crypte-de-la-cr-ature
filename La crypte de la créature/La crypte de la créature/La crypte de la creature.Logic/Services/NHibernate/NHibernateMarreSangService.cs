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
    public class NHibernateMarreDeSangService : IMarreSangService
    {
        private ISession session = NHibernateConnexion.OpenSession();
        #region IMarreDeSangService Members

        public IList<MarreDeSang> RetrieveAll()
        {
            return session.Query<MarreDeSang>().ToList();
        }

        public MarreDeSang Retrieve(RetrieveMarreSangArgs args)
        {
            var result = from p in session.Query<MarreDeSang>()
                         where p.idMarreDeSang == args.idMarre
                         select p;

            return result.FirstOrDefault();

        }

        public void Create(MarreDeSang p)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(p);
                transaction.Commit();
            }
        }

        public void Update(MarreDeSang p)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(p);
                transaction.Commit();
            }
        }

        public void Delete(MarreDeSang p)
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


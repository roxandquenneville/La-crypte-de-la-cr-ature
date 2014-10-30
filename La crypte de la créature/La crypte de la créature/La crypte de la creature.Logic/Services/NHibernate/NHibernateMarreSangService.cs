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
    public class NHibernateMareDeSangService : IMareSangService
    {
        private ISession session = NHibernateConnexion.OpenSession();
        #region IMareDeSangService Members

        public IList<MareDeSang> RetrieveAll()
        {
            return session.Query<MareDeSang>().ToList();
        }

        public MareDeSang Retrieve(RetrieveMareSangArgs args)
        {
            var result = from p in session.Query<MareDeSang>()
                         where p.idMareDeSang == args.idMare
                         select p;

            return result.FirstOrDefault();

        }

        public void Create(MareDeSang p)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(p);
                transaction.Commit();
            }
        }

        public void Update(MareDeSang p)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(p);
                transaction.Commit();
            }
        }

        public void Delete(MareDeSang p)
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


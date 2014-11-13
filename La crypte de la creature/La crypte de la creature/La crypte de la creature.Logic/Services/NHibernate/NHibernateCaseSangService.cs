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
    public class NHibernateCaseDeSangService : ICaseSangService
    {
        private ISession session = NHibernateConnexion.OpenSession();
        #region ICaseDeSangService Members

        public IList<CaseDeSang> RetrieveAll()
        {
            return session.Query<CaseDeSang>().ToList();
        }

        public CaseDeSang Retrieve(RetrieveCaseSangArgs args)
        {
            var result = from p in session.Query<CaseDeSang>()
                         where p.idCaseDeSang == args.idSang
                         select p;

            return result.FirstOrDefault();

        }

        public void Create(CaseDeSang p)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(p);
                transaction.Commit();
            }
        }

        public void Update(CaseDeSang p)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(p);
                transaction.Commit();
            }
        }

        public void Delete(CaseDeSang p)
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

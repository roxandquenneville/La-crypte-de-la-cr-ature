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
using La_crypte_de_la_creature.Logic.Services.Helpers;
using La_crypte_de_la_creature.Logic.Services.Interfaces;

namespace La_crypte_de_la_creature.Logic.Services.NHibernate
{
    public class NHibernateHistoriqueService : IHistoriqueService
    {
        private ISession session = NHibernateConnexion.OpenSession();


        #region IHistoriqueService Membres

        public void Create(Historique h)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(h);
                transaction.Commit();
            }
        }

        public IList<Historique> RetrieveAll()
        {
            return session.Query<Historique>().ToList();
        }

        public Historique Retrieve(RetrieveHistoriqueArgs args)
        {
            var result = from h in session.Query<Historique>()
                         where h.idHistorique == args.idHistorique
                         select h;

            return result.FirstOrDefault();
        }

        public void Update(Historique h)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(h);
                transaction.Commit();
            }
        }

        public void Delete(Historique h)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(h);
                transaction.Commit();
            }
        }
        #endregion
    }
}

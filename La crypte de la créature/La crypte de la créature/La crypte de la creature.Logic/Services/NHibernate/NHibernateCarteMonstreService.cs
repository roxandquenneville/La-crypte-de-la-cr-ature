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
    public class NHibernateCarteMonstreService : ICarteMonstreService
    {
        private ISession session = NHibernateConnexion.OpenSession();
        #region ICarteMonstreService Members

        public IList<CartesMonstre> RetrieveAll()
        {
            return session.Query<CartesMonstre>().ToList();
        }

        public CartesMonstre Retrieve(RetrieveCarteMonstreArgs args)
        {
            var result = from p in session.Query<CartesMonstre>()
                         where p.idCarteMonstre == args.idCarteMonstre
                         select p;

            return result.FirstOrDefault();

        }

        public void Create(CartesMonstre p)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(p);
                transaction.Commit();
            }
        }

        public void Update(CartesMonstre p)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(p);
                transaction.Commit();
            }
        }

        public void Delete(CartesMonstre p)
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

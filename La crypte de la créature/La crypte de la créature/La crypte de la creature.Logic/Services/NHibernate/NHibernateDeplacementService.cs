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
    public class NHibernateDeplacementService : IDeplacementService
    {
        private ISession session = NHibernateConnexion.OpenSession();

        #region IDeplacementService Membres
        public IList<Deplacement> RetrieveAll()
        {
            return session.Query<Deplacement>().ToList();
        }

        public Deplacement Retrieve(RetrieveDeplacementArgs args)
        {
            var result = from d in session.Query<Deplacement>()
                         where d.idDeplacement == args.idDeplacement
                         select d;
            return result.FirstOrDefault();
        }

        public void Create(Deplacement d)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(d);
                transaction.Commit();
            }
        }

        public void Update(Deplacement d)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(d);
                transaction.Commit();
            }
        }

        public void Delete(Deplacement d)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Delete(d);
                transaction.Commit();
            }
        }
        #endregion
    }
}

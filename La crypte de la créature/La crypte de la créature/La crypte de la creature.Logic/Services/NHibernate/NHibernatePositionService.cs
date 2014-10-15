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
    public class NHibernatePositionService : IPositionService 
    {
        private ISession session = NHibernateConnexion.OpenSession();


        #region IPositionService Membres

        public IList<Position> RetrieveAll()
        {
            return session.Query<Position>().ToList();
        }

        public Position Retrieve(RetrievePositionArgs args)
        {
            var result = from p in session.Query<Position>()
                         where p.idPosition == args.idPosition
                         select p;

            return result.FirstOrDefault();
        }

        public void Create(Position p)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(p);
                transaction.Commit();
            }
        }

        public void Update(Position p)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(p);
                transaction.Commit();
            }
        }

        public void Delete(Position p)
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

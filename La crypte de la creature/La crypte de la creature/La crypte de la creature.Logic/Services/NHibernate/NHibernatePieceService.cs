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
    public class NHibernatepieceService : IPieceService
    {
        
        private ISession session = NHibernateConnexion.OpenSession();

        #region IpieceService Members

        public IList<Piece> RetrieveAll()
        {
            return session.Query<Piece>().ToList();
        }

        public Piece Retrieve(RetrievePieceArgs args)
        {
            var result = from p in session.Query<Piece>()
                         where p.idPiece == args.idPiece
                         select p;

            return result.FirstOrDefault();

        }

        public void Create(Piece p)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Save(p);
                transaction.Commit();
            }
        }

        public void Update(Piece p)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(p);
                transaction.Commit();
            }
        }

        public void Delete(Piece p)
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

﻿using La_crypte_de_la_creature.Logic.Modele.Args;
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
    public class NHibernatePlateauService : IPlateauService
    {
        private ISession session = NHibernateConnexion.OpenSession();
        #region IPlateauService Members

        public IList<Plateau> RetrieveAll()
        {
            return session.Query<Plateau>().ToList();
        }

        public Plateau Retrieve(RetrievePlateauArgs args)
        {
            var result = from  p in session.Query<Plateau>()
                         where p.idPlateau == args.idPlateau
                         select p;
                         
            return result.FirstOrDefault();

        }

        public void Create(Plateau p)
        {
            using (var transaction = session.BeginTransaction())
            {                
                session.Save(p);
                transaction.Commit();
            }
        }

        public void Update(Plateau p)
        {
            using (var transaction = session.BeginTransaction())
            {
                session.Update(p);
                transaction.Commit();
            }
        }

        public void Delete(Plateau p)
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

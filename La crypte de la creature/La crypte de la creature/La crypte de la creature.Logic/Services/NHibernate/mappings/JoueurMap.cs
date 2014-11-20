using FluentNHibernate.Mapping;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Services.NHibernate.Mappings
{
    public class JoueurMap : ClassMap<Joueur>
    {
        public JoueurMap()
        {
              Table("joueurs");
              LazyLoad();
              Id(x => x.idJoueur)
                .Column("idJoueur")
                .CustomType("Int32")
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()                
                .GeneratedBy.Identity();
               References(x => x.Compte)
               .Column("idCompte")
               .Cascade.All();
               References(x => x.Partie)
               .Column("idPartie")
               .Cascade.All();
               HasMany(x => x.Pion).KeyColumn("idJoueur");
            //HasMany<Pion>(x => x.idJoueur)
            //    .Not.LazyLoad()
            //    .Access.Property()
            //    .Cascade.All()
            //    .Inverse()
            //    .KeyColumns.Add("idJoueur", map => map.Name("idJoueur")
            //                                        .SqlType("INTEGER")
            //                                        .Nullable());
        }
    }

}
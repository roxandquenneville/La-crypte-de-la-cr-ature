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
             .Class<Compte>()
             .Access.Property()
             .LazyLoad(Laziness.False)
             .Cascade.None()
             .Columns("idCompte");
               References(x => x.Partie)
              .Class<Partie>()
              .Access.Property()
              .LazyLoad(Laziness.False)
              .Cascade.None()
              .Columns("idPartie");
              
            HasMany(x => x.Pion)
               .KeyColumn("idJoueur")
               .Inverse()
               .Cascade.AllDeleteOrphan()
               .KeyColumns.Add("idJoueur", map => map.Name("idJoueur")
                                                   .SqlType("INTEGER")
                                                   .Not.Nullable());
        }
    }

}
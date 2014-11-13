using FluentNHibernate.Mapping;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Services.NHibernate.Mappings
{
    public class PartieMap : ClassMap<Partie>
    {
        public PartieMap()
        {
              Table("parties");
              LazyLoad();
              Id(x => x.idPartie)
                .Column("idPartie")
                .CustomType("Int32")
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()                
                .GeneratedBy.Identity();
              References(x => x.Historique)
               .Class<Historique>()
               .Access.Property()
               .LazyLoad(Laziness.False)
               .Cascade.None()
               .Columns("idHistorique");
              References(x => x.Plateau)
              .Class<Plateau>()
              .Access.Property()
              .LazyLoad(Laziness.False)
              .Cascade.None()
              .Columns("idPlateau");
			HasMany<Joueur>(x => x.idPartie)
                .Not.LazyLoad()
                .Access.Property()
                .Cascade.All()
                .Inverse()
                .KeyColumns.Add("idPartie", map => map.Name("idPartie")
                                                    .SqlType("INTEGER")
                                                    .Nullable());
            //HasMany<Pointage>(x => x.Pointage)
            //    .Not.LazyLoad()
            //    .Access.Property()
            //    .Cascade.All()
            //    .Inverse()
            //    .KeyColumns.Add("idPartie", map => map.Name("idPartie")
            //                                        .SqlType("INTEGER")
            //                                        .Nullable());
             //HasMany<CartesMonstre>(x => x.CartesMonstre)
             //   .Not.LazyLoad()
             //   .Access.Property()
             //   .Cascade.All()
             //   .Inverse()
             //   .KeyColumns.Add("idCarteMonstre", map => map.Name("idCarteMonstre")
             //                                   .SqlType("INTEGER")
             //                                   .Nullable());
        }
    }

}
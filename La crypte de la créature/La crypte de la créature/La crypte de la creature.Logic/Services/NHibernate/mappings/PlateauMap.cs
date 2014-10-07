using FluentNHibernate.Mapping;
using La_crypte_de_la_creature.Logic.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Services.NHibernate.Mappings
{
    public class PlateauMap : ClassMap<Plateau>
    {
        public PlateauMap()
        {
              Table("Plateaux");
              LazyLoad();
              Id(x => x.idPlateau)
                .Column("idPlateau")
                .CustomType("Int32")
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()                
                .GeneratedBy.Identity();
               HasOne(x => x.idTypePlateau)
                .Class<TypeDePlateau>()
                .Access.Property()
                .Cascade.None()
                .LazyLoad()
                .PropertyRef(p => p.Plateau);
			   HasMany<Case>(x => x.Cases)
                .Not.LazyLoad()
                .Access.Property()
                .Cascade.All()
                .Inverse()
                .KeyColumns.Add("idPlateau", map => map.Name("idPlateau")
                                                    .SqlType("INTEGER")
                                                    .Nullable());
        }
    }

}
using FluentNHibernate.Mapping;
using La_crypte_de_la_creature.Logic.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Services.NHibernate.Mappings
{
    public class CaseMap : ClassMap<Case>
    {
        public CaseMap()
        {
              Table("Cases");
              LazyLoad();
              Id(x => x.idCase)
                .Column("idCase")
                .CustomType("Int32")
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()                
                .GeneratedBy.Identity();
				References(x => x.idPlateau)
                .Class<Plateau>()
                .Access.Property()
                .LazyLoad(Laziness.False)
                .Cascade.None()
                .Columns("idPlateau");
				Map(x => x.X)
                .Column("X")
                .CustomType<int>()
                .Access.Property()
				.Generated.Never()
                .CustomSqlType("INTEGER");
				Map(x => x.Y)
                .Column("Y")
                .CustomType<int>()
                .Access.Property()
				.Generated.Never()
                .CustomSqlType("INTEGER");
                
        }
    }

}
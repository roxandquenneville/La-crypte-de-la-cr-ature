using FluentNHibernate.Mapping;
using La_crypte_de_la_creature.Logic.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Services.NHibernate.Mappings
{
    public class PierreMap : ClassMap<pierre>
    {
        public PierreMap()
        {
              Table("pieres");
              LazyLoad();
              Id(x => x.idPierre)
                .Column("idPierre")
                .CustomType("Int32")
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()                
                .GeneratedBy.Identity();
               References(x => x.idPiece)
                .Class<piece>()
                .Access.Property()
                .LazyLoad(Laziness.False)
                .Cascade.None()
                .Columns("idPiece");
				Map(x => x.estSurPlateau)
                .Column("estSurPlateau")
                .CustomType<bool>()
                .Access.Property()
				.Generated.Never()
                .CustomSqlType("BOOL");
        }
    }

}
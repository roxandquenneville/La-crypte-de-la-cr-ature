using FluentNHibernate.Mapping;
using La_crypte_de_la_creature.Logic.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Services.NHibernate.Mappings
{
    public class CaseDeSangMap : ClassMap<CaseDeSang>
    {
        public CaseDeSangMap()
        {
              Table("casesdesang");
              LazyLoad();
              Id(x => x.idSang)
                .Column("idSang")
                .CustomType("Int32")
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()                
                .GeneratedBy.Identity();
               References(x => x.idPiece)
                .Class<Piece>()
                .Access.Property()
                .LazyLoad(Laziness.False)
                .Cascade.None()
                .Columns("idPiece");
				References(x => x.idMarre)
                .Class<MarreDeSang>()
                .Access.Property()
                .LazyLoad(Laziness.False)
                .Cascade.None()
                .Columns("idMarre");
        }
    }

}
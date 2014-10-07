using FluentNHibernate.Mapping;
using La_crypte_de_la_creature.Logic.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Services.NHibernate.Mappings
{
    public class PionMap : ClassMap<pion>
    {
        public PionMap()
        {
              Table("pions");
              LazyLoad();
              Id(x => x.idPion)
                .Column("idPion")
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
			   Map(x => x.estVivant)
                .Column("estVivant")
                .CustomType<bool>()
                .Access.Property()
				.Generated.Never()
                .CustomSqlType("BOOL");
				Map(x => x.estSortie)
                .Column("estSortie")
                .CustomType<bool>()
                .Access.Property()
				.Generated.Never()
                .CustomSqlType("BOOL");
				
        }
    }

}
using FluentNHibernate.Mapping;
using La_crypte_de_la_creature.Logic.Modèle.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Services.NHibernate.Mappings
{
    public class PionMap : ClassMap<Pion>
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
			   Map(x => x.EstVivant)
                .Column("estVivant")
                .CustomType<bool>()
                .Access.Property()
				.Generated.Never()
                .CustomSqlType("BOOL");
				Map(x => x.EstSortie)
                .Column("estSortie")
                .CustomType<bool>()
                .Access.Property()
				.Generated.Never()
                .CustomSqlType("BOOL");
				
        }
    }

}
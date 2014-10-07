using FluentNHibernate.Mapping;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Services.NHibernate.Mappings
{
    public class TypePlateauMap : ClassMap<TypeDePlateau>
    {
        public TypePlateauMap()
        {
              Table("typesplateau");
              LazyLoad();
              Id(x => x.idTypeDePlateau)
                .Column("idTypePlateau")
                .CustomType("Int32")
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()                
                .GeneratedBy.Identity();
               Map(x => x.NomDePlateau)
                .Column("nom")
                .CustomType<string>()
                .Access.Property()
                .Generated.Never()
                .CustomSqlType("VARCHAR");
				
				
        }
    }

}
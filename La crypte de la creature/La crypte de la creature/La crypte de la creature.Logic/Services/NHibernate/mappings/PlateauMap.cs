using FluentNHibernate.Mapping;
using La_crypte_de_la_creature.Logic.Modele.Classes;
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
            Table("plateaux");
            LazyLoad();
            Id(x => x.idPlateau)
              .Column("idPlateau")
              .CustomType("Int32")
              .Access.Property()
              .CustomSqlType("INTEGER")
              .Not.Nullable()
              .GeneratedBy.Identity();

            Map(x => x.type)
                .Column("type")
                .CustomType<string>()
                .Access.Property()
                .Generated.Never()
                .CustomSqlType("VARCHAR");

            //HasMany(x => x.Case)
                 //.KeyColumn("idPlateau")
                 //.Inverse()
                 //.Cascade.AllDeleteOrphan()
                 //.KeyColumns.Add("idPlateau", map => map.Name("idPlateau")
                 //                                    .SqlType("INTEGER")
                 //                                    .Not.Nullable());

           

           
           
        }
    }

}
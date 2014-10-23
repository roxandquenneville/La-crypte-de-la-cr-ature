using FluentNHibernate.Mapping;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Services.NHibernate.Mappings
{
    public class PieceMap : ClassMap<Piece>
    {
        public PieceMap()
        {
              Table("pieces");
              LazyLoad();
              Id(x => x.idPiece)
                .Column("idPiece")
                .CustomType("Int32")
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()                
                .GeneratedBy.Identity();
              

               HasMany<Position>(x => x.idPosition)
               .Not.LazyLoad()
               .Access.Property()
               .Cascade.All()
               .Inverse()
               .KeyColumns.Add("idPosition", map => map.Name("idPosition")
                                                   .SqlType("INTEGER")
                                                   .Nullable());
				
        }
    }

}
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
              References(x => x.Position)
                .Class<Position>()
                .Access.Property()
                .LazyLoad(Laziness.False)
                .Cascade.None()
                .Columns("idPosition");
              References(x => x.Partie)
                .Class<Partie>()
                .Access.Property()
                .LazyLoad(Laziness.False)
                .Cascade.None()
                .Columns("idPartie");

           
				
        }
    }

}
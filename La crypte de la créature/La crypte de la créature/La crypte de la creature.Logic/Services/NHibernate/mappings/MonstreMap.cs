using FluentNHibernate.Mapping;
using La_crypte_de_la_creature.Logic.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Services.NHibernate.Mappings
{
    public class monstreMap : ClassMap<Monstre>
    {
        public monstreMap()
        {
              Table("monstres");
              LazyLoad();
              Id(x => x.idMonstre)
                .Column("idMonstre")
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
				Map(x => x.orientation)
                .Column("orientation")
                .CustomType<int>()
                .Access.Property()
				.Generated.Never()
                .CustomSqlType("INTEGER");
				
                
        }
    }

}
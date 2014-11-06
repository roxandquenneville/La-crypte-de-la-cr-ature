using FluentNHibernate.Mapping;
using La_crypte_de_la_creature.Logic.Modele.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_crypte_de_la_creature.Logic.Services.NHibernate.Mappings
{
    public class CompteMap : ClassMap<Compte>
    {
        public CompteMap()
        {
              Table("Comptes");
              LazyLoad();
              Id(x => x.idCompte)
                .Column("idCompte")
                .CustomType("Int32")
                .Access.Property()
                .CustomSqlType("INTEGER")
                .Not.Nullable()                
                .GeneratedBy.Identity();
               Map(x => x.NomUsager)
                .Column("nom")
                .CustomType<string>()
                .Access.Property()
                .Generated.Never()
                .CustomSqlType("VARCHAR");
				Map(x => x.MotDePasse)
                .Column("motDePasse")
                .CustomType<string>()
                .Access.Property()
                .Generated.Never()
                .CustomSqlType("VARCHAR");
                Map(x => x.Email)
                .Column("email")
                .CustomType<string>()
                .Access.Property()
                .Generated.Never()
                .CustomSqlType("VARCHAR");
        }
    }

}
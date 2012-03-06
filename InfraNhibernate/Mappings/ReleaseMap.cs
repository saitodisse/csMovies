using FluentNHibernate.Mapping;
using Dominio.Entidades;

namespace InfraNhibernate.Mappings
{
    public class ReleaseMap : ClassMap<Release>
    {
        public ReleaseMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.Native();

            Map(x => x.Nome);
            Map(x => x.LegendaSincronizada);
            Map(x => x.PossuiLegenda);
            Map(x => x.JaAssistido);
            Map(x => x.Nota);

            HasMany(x => x.Legendas);
            HasMany(x => x.UsuarioAssociados);
            
            References(x => x.Filme);


        }

    }
}

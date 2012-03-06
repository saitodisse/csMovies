using FluentNHibernate.Mapping;
using Dominio.Entidades;

namespace InfraNhibernate.Mappings
{
    public class ImdbInfoMap : ClassMap<ImdbInfo>
    {
        public ImdbInfoMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.Native();

            Map(x => x.Rating);
            Map(x => x.Overview);
            Map(x => x.ImdbLink);
            Map(x => x.HeaderYear);
            Map(x => x.HeaderTitle);
            Map(x => x.CaminhoImagem);

            References (x => x.Filme);

            //Map(x => x.Nome);
            //HasMany(x => x.Modelos);
            //References(x => x.ImdbInfo);
        }
    }
}

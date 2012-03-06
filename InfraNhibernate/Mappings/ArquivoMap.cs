using FluentNHibernate.Mapping;
using Dominio.Entidades;


namespace InfraNhibernate.Mappings
{
    public class ArquivoMap : ClassMap<Arquivo>
    {
        public  ArquivoMap()
        {
            Id(x => x.Id).Column("Id").GeneratedBy.Native();

            Map(x => x.Caminho);
            Map(x => x.Tamanho);

            References(x => x.Release);
        }
    }
}

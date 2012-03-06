using FluentNHibernate.Mapping;
using Dominio.Entidades;

namespace InfraNhibernate.Mappings
{
     public class ConfiguracoesGeraisMap : ClassMap<ConfiguracoesGerais>
     {
        public ConfiguracoesGeraisMap()
         {
            Id(x => x.Id).Column("Id").GeneratedBy.Native();

            Map(x => x.TamanhoMinimoArquivos);
            Map(x => x.TiposArquivosPadrao);

         }
    }
}

namespace Dominio.Entidades
{
    public class ConfiguracoesGerais
    {
        public virtual int Id { get; set; }
        public virtual long TamanhoMinimoArquivos { get; set; }
        public virtual string TiposArquivosPadrao { get; set; }

    }
}

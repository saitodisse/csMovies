namespace Dominio.Entidades
{
    public class PastaArquivos
    {
        public virtual int Id { get; set; }
        public virtual string Caminho { get; set; }
        public virtual string TipoArquivo { get; set; }
    }
}

namespace Dominio.Entidades
{
    public class Arquivo
    {
        public virtual int Id { get; set; }
        public virtual Release Release { get; set; }
        public virtual string Caminho { get; set; }
    }
}

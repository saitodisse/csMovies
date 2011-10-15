namespace Dominio.Entidades
{
    public class Legenda
    {
        public virtual int Id { get; private set; }
        public virtual Release Release { get; set; }
        public virtual string Linguagem { get; set; }
    }
}
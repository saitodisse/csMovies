namespace Dominio.Entidades
{
    public class ImdbInfo
    {
        public virtual int Id { get; private set; }
        public virtual Filme Filme { get; set; }
        public virtual string ImdbLink { get; set; }
        public virtual string HeaderTitle { get; set; }
        public virtual string HeaderYear { get; set; }
        public virtual string Rating { get; set; }
        public virtual string Overview { get; set; }
        public virtual string CaminhoImagem { get; set; }
    }
}
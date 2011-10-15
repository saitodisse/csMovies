namespace Dominio.Entidades
{
    public class DownloadLink
    {
        public virtual int Id { get; private set; }
        public virtual string Uri { get; set; }
        public virtual bool Downloaded { get; set; }
    }
}
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Filme
    {
        public virtual int Id { get; private set; }
        public virtual string Nome { get; set; }
        public virtual ImdbInfo ImdbInfo { get; set; }
        public virtual IList<Release> Releases { get; set; }

        public virtual void AdicionarRelease(Release release)
        {
            if (Releases == null)
            {
                Releases = new List<Release>();
            }
            release.Filme = this;
            Releases.Add(release);
        }
    }
}
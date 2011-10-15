using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Usuario
    {
        public virtual int Id { get; private set; }
        public virtual string Login { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual IList<Release> Releases { get; set; }

        public virtual void AdicionarRelease(Release release)
        {
            if (Releases == null)
            {
                Releases = new List<Release>();
            }

            //??? Objeto de valor?? DROGA!!
            if (release.UsuarioAssociados == null)
            {
                release.UsuarioAssociados = new List<Usuario>();
            }
            release.UsuarioAssociados.Add(this);

            
            Releases.Add(release);
        }
    }
}
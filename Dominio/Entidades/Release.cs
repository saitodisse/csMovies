using System.Collections.Generic;
using Dominio.Enums;

namespace Dominio.Entidades
{
    public class Release
    {
        public virtual int Id { get; private set; }
        public virtual string Nome { get; set; }
        public virtual Filme Filme { get; set; }
        //public virtual List<DownloadLink> DownloadLinks { get; set; }
        public virtual bool LegendaSincronizada { get; set; }
        public virtual bool PossuiLegenda { get; set; }
        public virtual bool JaAssistido { get; set; }
        public virtual Nota Nota { get; set; }

        public virtual IList<Legenda> Legendas { get; set; }
        public virtual IList<Usuario> UsuarioAssociados { get; set; }

        public virtual void AdicionarLegenda(Legenda legenda)
        {
            if(Legendas == null)
            {
                Legendas = new List<Legenda>();
            }

            legenda.Release = this;
            Legendas.Add(legenda);
        }
    }
}
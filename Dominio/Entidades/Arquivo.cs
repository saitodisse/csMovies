﻿using System.IO;
using Dominio.Helpers;

namespace Dominio.Entidades
{
    public class Arquivo
    {
        public virtual int Id { get; set; }
        public virtual Release Release { get; set; }
        public virtual string Caminho { get; set; }
        public virtual long Tamanho { get; set; }

        public virtual string Nome()
        {
            return Path.GetFileName(Caminho);
        }

        public virtual string TamanhoFormatado()
        {
            return string.Format(new FileSizeFormatProvider(), "{0:fs}", Tamanho);
        }

        public virtual bool PossuiLegenda()
        {
            return File.Exists(CaminhoLegenda());
        }

        public virtual string CaminhoLegenda()
        {
            var fi = new FileInfo(Caminho);
            string fullName = fi.FullName;
            string extension = fi.Extension;
            string nomeSemExtensao = fullName.Substring(0, fullName.Length - extension.Length);
            return nomeSemExtensao + ".srt";
        }
    }
}

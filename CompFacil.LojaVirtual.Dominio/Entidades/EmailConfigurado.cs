using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompFacil.LojaVirtual.Dominio.Entidades
{
    public class EmailConfigurado
    {
        public bool UsarSsl = false;
        public string ServidorSmtp = "smtp.live.com";
        public int ServidorPorta = 587;
        public string Usuario = "mailID@hotmail.com";
        public string Senha = "pwd";
        public bool EscreverArquivo = false;
        public string PastaArquivo = @"c:\envioemail";
        public string De = "mailID@hotmail.com";
        public string Para = "mailID@hotmail.com";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompFacil.LojaVirtual.Dominio.Entidades
{
    class EmailConfigurado
    {
        public bool UsarSsl = false;
        public string ServidorSmtp = "smtp.hotmail.com";
        public int ServidorPorta = 587;
        public string Usuario = "teste@hotmail.com";
        public bool EscreverArquivo = false;
        public string PastaArquivo = @"c:\envioemail";
        public string De = "teste@hotmail.com";
        public string Para = "teste@hotmail.com";
    }
}

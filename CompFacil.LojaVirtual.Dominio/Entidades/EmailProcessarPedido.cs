using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CompFacil.LojaVirtual.Dominio.Entidades
{
    public class EmailPedido
    {
        private readonly EmailConfigurado _emailConfigurado;

        public EmailPedido(EmailConfigurado emailConfigurado)
        {
            _emailConfigurado = emailConfigurado;
        }

        public void ProcessarPedido(Carrinho carrinho, Pedido pedido)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = _emailConfigurado.UsarSsl;
                smtpClient.Host = _emailConfigurado.ServidorSmtp;
                smtpClient.Port = _emailConfigurado.ServidorPorta;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new NetworkCredential(
                    _emailConfigurado.Usuario, _emailConfigurado.Senha, _emailConfigurado.ServidorSmtp);

                if (_emailConfigurado.EscreverArquivo)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = _emailConfigurado.PastaArquivo;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder()
                .AppendLine("Novo Pedido:")
                .AppendLine("-------")
                .AppendLine("Itens");

                foreach(var item in carrinho.ItensCarrinho)
                {
                    var subtotal = item.Produto.Preco * item.Quantidade;
                    body.AppendFormat("{0} x {1} (Subtotal: {2:c} )",
                        item.Quantidade, item.Produto.Nome, subtotal);
                }

                body.AppendFormat("Valor total do pedido: {0:c}", carrinho.ObterValorTotal())
                    .AppendLine("-------------------------")
                    .AppendLine("Enviar para:")
                    .AppendLine(pedido.NomeCliente)
                    .AppendLine(pedido.Email)
                    .AppendLine(pedido.Endereco ?? "")
                    .AppendLine(pedido.Cidade ?? "")
                    .AppendLine(pedido.Complemento ?? "")
                    .AppendLine("-------------------------")
                    .AppendFormat("Para presente: {0}", pedido.EmbrulhaPedido ? "Sim" : "Não");

                MailMessage mailMessage = new MailMessage(
                    _emailConfigurado.De,
                    _emailConfigurado.Para,
                    "Novo Pedido", body.ToString());

                if (_emailConfigurado.EscreverArquivo)
                    mailMessage.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

                smtpClient.Send(mailMessage);
            }
        }
    }
}
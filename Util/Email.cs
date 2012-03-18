using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace Util
{
    public class Email
    {
        public static void Enviar(string Email, string Assunto, string Mensagem)
        {
            Validar.Condicao(Validar.EMail(Email), "E-mail Inválido.");
            Validar.StringVazia(Mensagem, "Insira uma mensagem.");




            NetworkCredential loginInfo = new NetworkCredential("naoresponda@muambba.com.br", "muambba@tec_muambba");
            MailMessage msg = new MailMessage();
            
            
            msg.From = new MailAddress("naoresponda@muambba.com.br");
            msg.To.Add(new MailAddress(Email));

            msg.Subject = Assunto;


            


            msg.Body = Mensagem;




            msg.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = loginInfo;

            client.Send(msg);

        }

    }
}

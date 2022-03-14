using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Classes
{
    // https://pt.stackoverflow.com/questions/630/como-posso-enviar-um-e-mail-pelo-gmail
    public class Email
    {
        const string remetente = "sisguapabr@gmail.com";
        const string emailEmBranco = "Informe o e-mail utilizado no cadastro.";
        const string emailNaoValido = "Informe um e-mail válido.";
        const string emailNaoEnviado = "Falha ao enviar o e-mail.";
        const string senha = "Tot.1913";

        /// <summary>
        /// Envia um e-mail para o usuário.
        /// </summary>
        /// <param name="destinatario">E-mail de quem receberá a mensagem.</param>
        /// <param name="titulo">Título do e-mail</param>
        /// <param name="conteudo">Conteúdo do e-mail</param>
        /// <returns></returns>
        public static string EnviarEmailAsync(string destinatario, string titulo, string conteudo)
        {
            if (string.IsNullOrEmpty(destinatario))
                return emailEmBranco;

            else if(!FuncoesGerais.EmailEhValido(destinatario))
                return emailNaoValido;

            else
            {
                try
                {
                    //cria uma mensagem
                    var mail = new MailMessage();

                    //define os endereços
                    mail.From = new MailAddress(remetente);
                    mail.To.Add(destinatario);

                    //define o conteúdo
                    mail.Subject = titulo;
                    mail.Body = conteudo;

                    using (var smtp = new SmtpClient("smtp.gmail.com"))
                    {
                        smtp.UseDefaultCredentials = false; // vamos utilizar credencias especificas
                        smtp.EnableSsl = true; // GMail requer SSL
                        smtp.Port = 587;       // porta para SSL
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // modo de envio

                        // seu usuário e senha para autenticação
                        smtp.Credentials = new NetworkCredential(remetente, senha);
                        smtp.Send(mail);

                        smtp.SendCompleted += (s, e) =>
                        {
                            // após o envio pode chamar o Dispose
                            smtp.Dispose();
                        };

                        // envia assíncronamente
                        smtp.SendAsync(mail, null);
                    }
                }
                catch (Exception e)
                {
                    return emailNaoEnviado;
                }
                
                return string.Empty;
            }
        }
    }
}

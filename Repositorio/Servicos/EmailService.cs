using Repositorio.Interfaces;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Repositorio.Servicos
{
    // https://pt.stackoverflow.com/questions/630/como-posso-enviar-um-e-mail-pelo-gmail
    public class EmailService : IEmailService
    {
        const string remetente = "sisguapabr@gmail.com";
        const string emailEmBranco = "Informe o e-mail utilizado no cadastro.";
        const string emailNaoValido = "Informe um e-mail válido.";
        const string emailNaoEnviado = "Falha ao enviar o e-mail.";
        const string senha = "Adicionar senha em arquivo de configuracao";

        /// <summary>
        /// Envia um e-mail para o usuário.
        /// </summary>
        /// <param name="destinatario">E-mail de quem receberá a mensagem.</param>
        /// <param name="titulo">Título do e-mail</param>
        /// <param name="conteudo">Conteúdo do e-mail</param>
        /// <returns></returns>
        public async Task<string> EnviarEmailAsync(string destinatario, string titulo, string conteudo)
        {
            if (string.IsNullOrEmpty(destinatario))
                return emailEmBranco;

            else if (!EmailEhValido(destinatario))
                return emailNaoValido;

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

        /// <summary>
        /// Validação da própria System para e-mail válido.
        /// </summary>
        /// <param name="emailaddress"></param>
        /// <returns></returns>
        public bool EmailEhValido(string emailaddress)
        {
            try
            {
                var email = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}

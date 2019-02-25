using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

/// <summary>
/// Descrição resumida de Email
/// </summary>
public class Email
{
    public static string EnviarEmail(string emailDestinatario, string assunto, string corpomsg)
    {
        try
        {
            //Cria o endereço de email do remetente
            MailAddress de = new MailAddress("garimpowebshop@gmail.com");
            //Cria o endereço de email do destinatário -->
            MailAddress para = new MailAddress(emailDestinatario);
            MailMessage mensagem = new MailMessage(de, para);
            mensagem.IsBodyHtml = true;
            //Assunto do email
            mensagem.Subject = assunto;
            //Conteúdo do email
            mensagem.Body = corpomsg;
            //Prioridade E-mail
            mensagem.Priority = MailPriority.Normal;
            //Cria o objeto que envia o e-mail
            SmtpClient cliente = new SmtpClient();
            //Envia o email
            cliente.Send(mensagem);
            return "E-mail enviado com sucesso";
        }
        catch
        {
            return "Erro ao enviar e-mail";
        }
    }

    //verificar se email existe
    public static bool EmailExiste(string email)
    {
        try
        {
            MailAddress de = new MailAddress("garimpowebshop@gmail.com");
            MailAddress para = new MailAddress(email);
            SmtpClient cliente = new SmtpClient();
            cliente.Send(email,"","","");

            return true;
        }
        catch
        {
            return false;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace TccNovoGrupo.Controllers
{
    public class EnviarEmailController : Controller
    {
        // GET: EnviarEmail

        [HttpGet]
        public ActionResult EnviarEmail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EnviarEmail(String para, String assunto, String message)
        {
            try
            {
                MailMessage email = new MailMessage();
                email.From = new MailAddress("cabeleireirosalao31@gmail.com");
                email.To.Add(para);
                email.Subject = assunto;
                email.Body = message;
                email.IsBodyHtml = true;
                email.Priority = MailPriority.Normal;



                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 25;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                string sContaEmail = "cabeleireirosalao31@gmail.com";
                string sPasswordEmail = "salao1234";
                smtp.Credentials = new System.Net.NetworkCredential(sContaEmail, sPasswordEmail);

                smtp.Send(email);
                ViewBag.Message = "Mensagem enviada com sucesso, agradecemos o seu contato, entraremos em contato com você muito em breve, fique no aguardo, obrigado!  :)";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Falha ao enviar o email, verifique a estabilidade da sua conexão, " +
                      "ou se todos os campos do formulário foram preenchidos corretamente";
        
    }

            return View();
        }
    }
}
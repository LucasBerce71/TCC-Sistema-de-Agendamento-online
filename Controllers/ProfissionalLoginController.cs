using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TccNovoGrupo.Models;

namespace TccNovoGrupo.Controllers
{
    public class ProfissionalLoginController : Controller
    {
        // GET: ProfissionalLogin
        public ActionResult ObterLogins()
        {
            using (LoginProfissionalDbContext db = new LoginProfissionalDbContext())
            {
                return View(db.loginP.ToList());
            }
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(LoginProfissional login_profissional)
        {
            if (ModelState.IsValid)
            {
                using (LoginProfissionalDbContext db = new LoginProfissionalDbContext())
                {
                    db.loginP.Add(login_profissional);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = login_profissional.NomeProfissional + " " + login_profissional.SobrenomeProfissional + " foi cadastrado com sucesso.";

            }
            return View();
        }

        //Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginProfissional userProfissional)
        {
            using (LoginProfissionalDbContext db = new LoginProfissionalDbContext())
            {
                var usrProfissional = db.loginP.Single(u => u.ProfissionalUsuario == userProfissional.ProfissionalUsuario && u.ProfissionalPassword == userProfissional.ProfissionalPassword);
                if (usrProfissional != null)
                {
                    Session["LoginProfissionalID"] = usrProfissional.LoginProfissionalID.ToString();
                    Session["ProfissionalUsuario"] = usrProfissional.ProfissionalUsuario.ToString();
                    return RedirectToAction("ObterAgendamento");
                }
                else
                {
                    ModelState.AddModelError("","Nome de Usuário ou senha incorretos");
                }
            }
            return View();
        }

        public ActionResult ObterAgendamentoTeste()
        {
            if(Session["LoginProfissionalID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
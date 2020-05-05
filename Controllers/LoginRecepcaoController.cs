using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TccNovoGrupo.Models;

namespace TccNovoGrupo.Controllers
{
    public class LoginRecepcaoController : Controller
    {
        // GET: ProfissionalLogin
        public ActionResult ObterLogins()
        {
            using (LoginRecepcaoDbContext db = new LoginRecepcaoDbContext())
            {
                return View(db.loginR.ToList());
            }
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(LoginRecepcao login_recepcao)
        {
            if (ModelState.IsValid)
            {
                using (LoginRecepcaoDbContext db = new LoginRecepcaoDbContext())
                {
                    db.loginR.Add(login_recepcao);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = login_recepcao.NomeRecepcionista + " " + login_recepcao.SobrenomeRecepcionista + " foi cadastrado com sucesso.";

            }
            return View();
        }

        //Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginRecepcao userRecepcao)
        {
            using (LoginRecepcaoDbContext db = new LoginRecepcaoDbContext())
            {
                var usrRecepcao = db.loginR.Single(u => u.RecepcionistaUsuario == userRecepcao.RecepcionistaUsuario && u.RecepcionistaPassword == userRecepcao.RecepcionistaPassword);
                if (usrRecepcao != null)
                {
                    Session["LoginRecepcaoID"] = usrRecepcao.LoginRecepcaoID.ToString();
                    Session["RecepcionistaUsuario"] = usrRecepcao.RecepcionistaUsuario.ToString();
                    return RedirectToAction("RealizarAgendamento");
                }
                else
                {
                    ModelState.AddModelError("", "Nome de Usuário ou senha incorretos");
                }
            }
            return View();
        }

        public ActionResult RealizarAgendamento()
        {
            if (Session["LoginRecepcaoID"] != null)
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
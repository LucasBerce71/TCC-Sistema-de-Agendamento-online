using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TccNovoGrupo.Models;

namespace TccNovoGrupo.Controllers
{
    public class LoginAdmController : Controller
    {
        // GET: ProfissionalLogin
        public ActionResult ObterLogins()
        {
            using (LoginAdmDbContext db = new LoginAdmDbContext())
            {
                return View(db.loginAdmin.ToList());
            }
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(AdmLogin login_adm)
        {
            if (ModelState.IsValid)
            {
                using (LoginAdmDbContext db = new LoginAdmDbContext())
                {
                    db.loginAdmin.Add(login_adm);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = login_adm.NomeAdm + " " + login_adm.SobrenomeAdm + " foi cadastrado com sucesso.";

            }
            else
            {
                ViewBag.ErrCad = "Erro ao cadastrar usuário";
            }
            return View();
        }

        //Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AdmLogin userAdm)
        {
            using (LoginAdmDbContext db = new LoginAdmDbContext())
            {
                var usrAdm = db.loginAdmin.Single(u => u.AdmUsuario == userAdm.AdmUsuario && u.AdmPassword == userAdm.AdmPassword);
                if (usrAdm != null)
                {
                    Session["LoginAdmID"] = usrAdm.LoginAdmID.ToString();
                    Session["AdmUsuario"] = usrAdm.AdmUsuario.ToString();
                    return RedirectToAction("ObterServicosADM");
                }
                else
                {
                    ViewBag.Erro = "Login ou senha inválidos";
                }
                
            }
            return View();
        }

        public ActionResult ObterServicosADM()
        {
            if (Session["LoginAdmID"] != null)
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TccNovoGrupo.Models;
using TccNovoGrupo.Repositorio;

namespace TccNovoGrupo.Controllers
{
    public class ProfissionalController : Controller
    {
        // GET: Profissional

        private ProfissionalRepositorio _repositorio;

        [HttpGet]
        public ActionResult ObterProfissional()
        {
            _repositorio = new ProfissionalRepositorio();

            _repositorio.ObterProfissional();
            ModelState.Clear();
            return View(_repositorio.ObterProfissional());
        }

        [HttpGet]
        public ActionResult IncluirProfissional()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IncluirProfissional(Profissionals profissionalObj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositorio = new ProfissionalRepositorio();

                    if (_repositorio.AdicionarProfissional(profissionalObj))
                    {
                        ViewBag.Mensagem = "O profissional foi cadastrado com sucesso!";
                    }
                }

                return RedirectToAction("ObterProfissional");
            }
            catch (Exception)
            {

                return View("ObterProfissional");
            }
        }

        [HttpGet]
        public ActionResult AtualizarProfissional(int id)
        {
            _repositorio = new ProfissionalRepositorio();
            return View(_repositorio.ObterProfissional().Find(t => t.ProfissionalId == id));
        }

        [HttpPost]
        public ActionResult AtualizarProfissional(int id, Profissionals profissionalObj)
        {
            try
            {
                _repositorio = new ProfissionalRepositorio();
                _repositorio.AtualizarProfissional(profissionalObj);

                return RedirectToAction("ObterProfissional");
            }
            catch (Exception e)
            {
                var ja = e.Message;
                return View("ObterProfissional");
            }
        }

        public ActionResult ExcluirProfissional(int id)
        {
            try
            {
                _repositorio = new ProfissionalRepositorio();
                if (_repositorio.ExcluirProfissional(id))
                {
                    ViewBag.Mensagem = "O profissional retirado do sistema com sucesso";
                }

                return RedirectToAction("ObterProfissional");
            }
            catch (Exception)
            {

                return View("ObterProfissional");
            }
        }
    }
}
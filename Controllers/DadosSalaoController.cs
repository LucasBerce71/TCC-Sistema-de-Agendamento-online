using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TccNovoGrupo.Models;
using TccNovoGrupo.Repositorio;

namespace TccNovoGrupo.Controllers
{
    public class DadosSalaoController : Controller
    {
        // GET: Servico

        private SalaoDadosRepositorio _repositorio;

        [HttpGet]
        public ActionResult ObterSalao()
        {
            _repositorio = new SalaoDadosRepositorio();

            ViewBag.dadosServico = _repositorio.ObterSalao();
            ModelState.Clear();
            return View(_repositorio.ObterSalao());
        }

        [HttpGet]
        public ActionResult IncluirSalao()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IncluirSalao(DadosSalao salaoObj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositorio = new SalaoDadosRepositorio();

                    if (_repositorio.AdicionarSalao(salaoObj))
                    {
                        ViewBag.Mensagem = "O salão foi cadastrado com sucesso!";
                    }
                }

                return RedirectToAction("ObterSalao");
            }
            catch (Exception)
            {

                return View("ObterSalao");
            }
        }

        [HttpGet]
        public ActionResult EditarSalao(int id)
        {
            _repositorio = new SalaoDadosRepositorio();
            return View(_repositorio.ObterSalao().Find(t => t.SalaoId == id));
        }

        [HttpPost]
        public ActionResult EditarSalao(int id, DadosSalao salaoObj)
        {
            try
            {
                _repositorio = new SalaoDadosRepositorio();
                _repositorio.AtualizarSalao(salaoObj);

                return RedirectToAction("ObterSalao");
            }
            catch (Exception e)
            {
                var ja = e.Message;
                return View("ObterSalao");
            }
        }

        public ActionResult ExcluirSalao(int id)
        {
            try
            {
                _repositorio = new SalaoDadosRepositorio();
                if (_repositorio.ExcluirSalao(id))
                {
                    ViewBag.Mensagem = "O salão foi excluido com sucesso";
                }

                return RedirectToAction("ObterSalao");
            }
            catch (Exception)
            {

                return View("ObterSalao");
            }
        }
    }
}
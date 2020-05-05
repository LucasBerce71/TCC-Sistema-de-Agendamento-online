using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TccNovoGrupo.Models;
using TccNovoGrupo.Repositorio;

namespace TccNovoGrupo.Controllers
{
    public class ServicoController : Controller
    {
        // GET: Servico

        private ServicoRepositorio _repositorio;

        [HttpGet]
        public ActionResult ObterServicos()
        {
            _repositorio = new ServicoRepositorio();

           ViewBag.dadosServico = _repositorio.ObterServicos();
            ModelState.Clear();
            return View(_repositorio.ObterServicos());
        }

        [HttpGet]
        public ActionResult IncluirServico()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IncluirServico(Servicos servicoObj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositorio = new ServicoRepositorio();

                    if (_repositorio.AdicionarServico(servicoObj))
                    {
                        ViewBag.Mensagem = "O serviço foi cadastrado com sucesso!";
                    }
                }
               

                ViewBag.dadosServico = _repositorio.ObterServicos();
                ModelState.Clear();
                return RedirectToAction("ObterServicos", _repositorio.ObterServicos());
            }
            catch (Exception e)
            {
                var ja = e.Message;
                return View("ObterServicos");
            }
        }

        [HttpGet]
        public ActionResult EditarServico(int id)
        {
            _repositorio = new ServicoRepositorio();
            return View(_repositorio.ObterServicos().Find(t => t.ServicoId == id));
        }

        [HttpPost]
        public ActionResult EditarServico(int id, Servicos servicoObj)
        {
            try
            {
                _repositorio = new ServicoRepositorio();
                _repositorio.AtualizarServico(servicoObj);

                return RedirectToAction("ObterServicos", _repositorio.ObterServicos());
            }
            catch (Exception e)
            {
                var ja = e.Message;
                return View("ObterServicos", _repositorio.ObterServicos());
            }
        }

        public ActionResult ExcluirServico(int id)
        {
            try
            {
                _repositorio = new ServicoRepositorio();
                if (_repositorio.ExcluirServico(id))
                {
                    ViewBag.Mensagem = "O serviço foi excluido com sucesso";
                }

                return RedirectToAction("ObterServicos");
            }
            catch (Exception)
            {

                return View("ObterServicos");
            }
        }
    }
}
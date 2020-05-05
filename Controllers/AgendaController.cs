using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TccNovoGrupo.Models;
using TccNovoGrupo.Repositorio;

namespace TccNovoGrupo.Controllers
{
    public class AgendaController : Controller
    {
        // GET: Servico

        private AgendamentoRepositorio _repositorio;

        [HttpGet]
        public ActionResult ObterAgendamento()
        {
            _repositorio = new AgendamentoRepositorio();

            _repositorio.ObterAgendamentos();
            ModelState.Clear();
            return View(_repositorio.ObterAgendamentos());
        }

        [HttpGet]
        public ActionResult IncluirAgendamento()
        {
            return View();
        }

        [HttpPost]
        public ActionResult IncluirAgendamento(Agenda agendaObj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repositorio = new AgendamentoRepositorio();

                    if (_repositorio.AdicionarAgendamento(agendaObj))
                    {
                        ViewBag.Mensagem = "Seu agendamento foi realizado com sucesso!";
                    }
                }

                _repositorio.ObterAgendamentos();
                ModelState.Clear();

                return RedirectToAction("IncluirAgendamento");
            }
            catch (Exception)
            {

                return View("IncluirAgendamento");
            }
        }

        [HttpGet]
        public ActionResult AtualizarAgendamento(int id)
        {
            _repositorio = new AgendamentoRepositorio();
            return View(_repositorio.ObterAgendamentos().Find(t => t.cod_agendamento == id));
        }

        [HttpPost]
        public ActionResult AtualizarAgendamento(Agenda agendaObj)
        {
            try
            {
                _repositorio = new AgendamentoRepositorio();
                _repositorio.AtualizarAgendamento(agendaObj);

                _repositorio = new AgendamentoRepositorio();

               _repositorio.ObterAgendamentos();
                ModelState.Clear();


                //return View();
                return RedirectToAction("ObterAgendamento", "Agenda", _repositorio.ObterAgendamentos());
            }
            catch (Exception e)
            {               
                return View();
                //return View("ObterAgendamento");
            }
        }

        public ActionResult ExcluirAgendamento(int id)
        {
            try
            {
                _repositorio = new AgendamentoRepositorio();
                if (_repositorio.ExcluirAgendamento(id))
                {
                    ViewBag.Mensagem = "Seu agendamento foi excluido com sucesso";
                }

                return RedirectToAction("ObterAgendamento");
            }
            catch (Exception)
            {

                return View("ObterAgendamento");
            }
        }
    }
}
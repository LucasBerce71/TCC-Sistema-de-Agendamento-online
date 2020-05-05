using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TccNovoGrupo.Models;
using TccNovoGrupo.Repositorio;

namespace TccNovoGrupo.Controllers
{
    public class ConsultarHorariosController : Controller
    {
        // GET: ConsultarHorarios
        private ConsultarHorariosRepositorio _repositorio;

        [HttpGet]
        public ActionResult ConsultarHorarios()
        {
            _repositorio = new ConsultarHorariosRepositorio();

            ViewBag.dadosServico = _repositorio.ObterHorarios();
            ModelState.Clear();
            return View(_repositorio.ObterHorarios());
        }
    }
}
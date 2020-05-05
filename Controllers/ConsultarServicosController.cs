using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TccNovoGrupo.Models;
using TccNovoGrupo.Repositorio;

namespace TccNovoGrupo.Controllers
{
    public class ConsultarServicosController : Controller
    {
        // GET: ConsultarServicos
        private ServicoRepositorio _repositorio;
        public ActionResult ConsultarServicos()
        {
            _repositorio = new ServicoRepositorio();

            ViewBag.dadosServico = _repositorio.ObterServicos();
            ModelState.Clear();
            return View(_repositorio.ObterServicos());
        }
    }
}
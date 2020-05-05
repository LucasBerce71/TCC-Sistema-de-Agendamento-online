using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TccNovoGrupo.Models;
using TccNovoGrupo.Repositorio;

namespace TccNovoGrupo.Controllers
{
    public class ConsultarClientesController : Controller
    {
        // GET: ConsultarClientes

        private ClienteRepositorio _repositorio;

        [HttpGet]
        public ActionResult ObterClientes()
        {
            _repositorio = new ClienteRepositorio();

            _repositorio.ObterClientes();
            ModelState.Clear();
            return View(_repositorio.ObterClientes());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TccNovoGrupo.Models;
using TccNovoGrupo.Repositorio;

namespace TccNovoGrupo.Controllers
{
    public class ConsultarProfissionaisController : Controller
    {
        // GET: ConsultarProfissionais


        private ProfissionalRepositorio _repositorio;

        [HttpGet]
        public ActionResult ConsultarProfissionais()
        {
            _repositorio = new ProfissionalRepositorio();

            _repositorio.ObterProfissional();
            ModelState.Clear();
            return View(_repositorio.ObterProfissional());
        }
    }
    }

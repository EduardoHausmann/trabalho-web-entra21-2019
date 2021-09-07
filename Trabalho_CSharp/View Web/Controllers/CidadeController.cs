using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View_Web.Controllers
{
    public class CidadeController : Controller
    {
        private CidadeRepository repository;
        private EstadoRepository estadoRepository;

        public CidadeController()
        {
            repository = new CidadeRepository();
            estadoRepository = new EstadoRepository();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
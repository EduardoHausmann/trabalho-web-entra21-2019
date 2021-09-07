using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View_Web.Controllers
{
    public class ProjetoController : Controller
    {
        private ProjetoRepository repository;
        private ClienteRepository clienteRepository;

        public ProjetoController()
        {
            repository = new ProjetoRepository();
            clienteRepository = new ClienteRepository();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
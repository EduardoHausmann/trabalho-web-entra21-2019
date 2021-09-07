using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View_Web.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteRepository repository;
        private CidadeRepository cidadeRepository;

        public ClienteController()
        {
            repository = new ClienteRepository();
            cidadeRepository = new CidadeRepository();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
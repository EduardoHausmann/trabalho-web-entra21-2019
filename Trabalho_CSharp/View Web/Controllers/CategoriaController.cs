using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View_Web.Controllers
{
    public class CategoriaController : Controller
    {
        private CategoriaRepository repository;

        public CategoriaController()
        {
            repository = new CategoriaRepository();
        }

        public ActionResult Index()
        {
            List<Categoria> categorias = repository.ObterTodos();

            ViewBag.Categorias = categorias;

            return View();
        }
    }
}
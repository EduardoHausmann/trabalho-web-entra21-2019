using Model;
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
            List<Cidade> cidades = repository.ObterTodos();

            ViewBag.Cidades = cidades;

            return View();
        }

        public ActionResult Cadastro()
        {
            List<Estado> estados = estadoRepository.ObterTodos();

            ViewBag.Estados = estados;

            return View();
        }

        public ActionResult Store(string nome, int estado, int habitantes)
        {
            Cidade cidade = new Cidade();
            cidade.Nome = nome;
            cidade.NumeroHabitante = habitantes;
            cidade.IdEstado = estado;

            repository.Inserir(cidade);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            Cidade cidade = repository.ObterPeloId(id);
            ViewBag.Cidade = cidade;

            List<Estado> estados = estadoRepository.ObterTodos();
            ViewBag.Estados = estados;

            return View();
        }

        public ActionResult Update(int id, string nome, int estado, int habitantes)
        {
            Cidade cidade = new Cidade();
            cidade.Id = id;
            cidade.Nome = nome;
            cidade.NumeroHabitante = habitantes;
            cidade.IdEstado = estado;

            repository.Alterar(cidade);
            return RedirectToAction("Index");
        }

        public ActionResult Apagar(int id)
        {
            repository.Apagar(id);
            return RedirectToAction("Index");
        }
    }
}
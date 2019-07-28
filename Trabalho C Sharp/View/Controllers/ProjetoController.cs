using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class ProjetoController : Controller
    {
        private ProjetoRepository repository;

        public ProjetoController()
        {
            repository = new ProjetoRepository();
        }
        public ActionResult Index()
        {
            List<Projeto> projetos = repository.ObterTodos();
            ViewBag.Projetos = projetos;
            return View();
        }

        public ActionResult Cadastro()
        {
            ClienteRepository clienterepository = new ClienteRepository();
            List<Cliente> clientes = clienterepository.ObterTodos();
            ViewBag.Clientes = clientes;

            return View();
        }

        public ActionResult Store(int cliente, string nome, DateTime dataCriacao, DateTime dataFinalizacao)
        {
            Projeto projeto = new Projeto();
            projeto.Id_Cliente = cliente;
            projeto.Nome = nome;
            projeto.Data_Criacao = dataCriacao;
            projeto.Data_Finalizacao = dataFinalizacao;

            repository.Inserir(projeto);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            Projeto projeto = new Projeto();
            projeto = repository.ObterPeloId(id);

            ClienteRepository clienteRepository = new ClienteRepository();
            List<Cliente> clientes = clienteRepository.ObterTodos();
            ViewBag.Clientes = clientes;

            return View();
        }

        public ActionResult Update(int id, int cliente, string nome, DateTime dataCriacao, DateTime dataFinalizacao)
        {
            Projeto projeto = new Projeto();
            projeto.Id = id;
            projeto.Id_Cliente = cliente;
            projeto.Nome = nome;
            projeto.Data_Criacao = dataCriacao;
            projeto.Data_Finalizacao = dataFinalizacao;
            repository.Inserir(projeto);

            repository.Alterar(projeto);
            return RedirectToAction("Index");
        }

        public ActionResult Apagar(int id)
        {
            repository.Apagar(id);
            return RedirectToAction("Index");
        }
    }
}
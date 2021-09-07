﻿using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View_Web.Controllers
{
    public class EstadoController : Controller
    {
        private EstadoRepository repository;

        public EstadoController()
        {
            repository = new EstadoRepository();
        }

        public ActionResult Index()
        {
            List<Estado> estados = repository.ObterTodos();

            ViewBag.Estados = estados;

            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Store(string nome, string sigla)
        {
            Estado estado = new Estado();
            estado.Nome = nome;
            estado.Sigla = sigla;
            repository.Interir(estado);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            Estado estado = repository.ObterPeloId(id);

            ViewBag.Estado = estado;

            return View();
        }

        public ActionResult Update(int id, string nome, string sigla)
        {
            Estado estado = new Estado();
            estado.Id = id;
            estado.Nome = nome;
            estado.Sigla = sigla;
            repository.Alterar(estado);
            return RedirectToAction("Index");
        }

        public ActionResult Apagar(int id)
        {
            repository.Apagar(id);
            return RedirectToAction("Index");
        }
    }
}
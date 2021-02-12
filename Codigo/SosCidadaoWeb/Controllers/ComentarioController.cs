﻿using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using SosCidadaoWeb.Models;
using System;
using System.Collections.Generic;

namespace SosCidadaoWeb.Controllers
{
    public class ComentarioController : Controller
    {
        private readonly IComentarioService _comentarioService;
        private readonly IMapper _mapper;

        public ComentarioController(IComentarioService comentario, IMapper mapper)
        {
            _comentarioService = comentario;
            _mapper = mapper;
        }

        // GET: ComentarioController
        public ActionResult Index()
        {
            ViewBag.title_page = "Comentario";
            ViewBag.path = "Início / Comentario";

            var listaComentarios = _comentarioService.ObterTodos();
            var listaComentariosModel = _mapper.Map<List<ComentarioModel>>(listaComentarios);
            return View(listaComentariosModel);
        }

        // GET: ComentarioController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.title_page = "Comentario";
            ViewBag.path = "Início / Comentario / Detalhes";

            Comentario comentario = _comentarioService.Obter(id);
            ComentarioModel comentarioModel = _mapper.Map<ComentarioModel>(comentario);
            return View(comentarioModel);
        }

        // GET: ComentarioController/Create
        public ActionResult Create()
        {
            ViewBag.title_page = "Comentario";
            ViewBag.path = "Início / Comentario / Criar";

            return View();
        }

        // POST: ComentarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComentarioModel comentarioModel)
        {
            if (ModelState.IsValid)
            {
                var comentario = _mapper.Map<Comentario>(comentarioModel);

                comentario.DataCadastro = DateTime.Now;
                _comentarioService.Inserir(comentario);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ComentarioController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.title_page = "Comentario";
            ViewBag.path = "Início / Comentario / Editar";

            Comentario comentario = _comentarioService.Obter(id);
            ComentarioModel comentarioModel = _mapper.Map<ComentarioModel>(comentario);
            return View(comentarioModel);
        }

        // POST: ComentarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ComentarioModel comentarioModel)
        {
            if (ModelState.IsValid)
            {
                var comentario = _mapper.Map<Comentario>(comentarioModel);

                comentario.IdComentario = id;
                comentario.DataCadastro = DateTime.Now;
                _comentarioService.Atualizar(comentario);

            }
            return RedirectToAction(nameof(Index));
        }

        // GET: ComentarioController/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.title_page = "Comentario";
            ViewBag.path = "Início / Comentario / Remover";

            Comentario comentario = _comentarioService.Obter(id);
            ComentarioModel comentarioModel = _mapper.Map<ComentarioModel>(comentario);
            return View(comentarioModel);
        }

        // POST: ComentarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ComentarioModel comentario)
        {
            _comentarioService.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

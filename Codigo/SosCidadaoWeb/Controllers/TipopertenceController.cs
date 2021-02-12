﻿using AutoMapper;
using Core;
using Core.Service;
using Microsoft.AspNetCore.Mvc;
using SosCidadaoWeb.Models;
using System.Collections.Generic;

namespace SosCidadaoWeb.Controllers
{
    public class TipopertenceController : Controller
    {
        private readonly ITipopertenceService _tipopertenceService;
        private readonly IMapper _mapper;

        public TipopertenceController(ITipopertenceService tipopertenceService, IMapper mapper)
        {
            _tipopertenceService = tipopertenceService;
            _mapper = mapper;
        }
        // GET: Tipopertence
        public ActionResult Index()
        {
            ViewBag.title_page = "Tipo Pertence";
            ViewBag.path = "Início / Tipo Pertence";

            var listaTipopertence = _tipopertenceService.ObterTodos();
            var listaTipopertenceModel = _mapper.Map<List<TipopertenceModel>>(listaTipopertence);
            return View(listaTipopertenceModel);
        }

        // GET: Tipopertence/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.title_page = "Tipo Pertence";
            ViewBag.path = "Início / Tipo Pertence / Detalhes";

            Tipopertence tipopertence = _tipopertenceService.Obter(id);
            TipopertenceModel tipopertenceModel = _mapper.Map<TipopertenceModel>(tipopertence);
            return View(tipopertenceModel);
        }

        // GET: Tipopertence/Create
        public ActionResult Create()
        {
            ViewBag.title_page = "Tipo Pertence";
            ViewBag.path = "Início / Tipo Pertence / Criar";

            return View();
        }

        // POST: Tipopertence/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipopertenceModel tipopertenceModel)
        {
            if (ModelState.IsValid)
            {
                var tipopertence = _mapper.Map<Tipopertence>(tipopertenceModel);

                tipopertence.IdOrganizacao = 1;
                _tipopertenceService.Inserir(tipopertence);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Tipopertence/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.title_page = "Tipo Pertence";
            ViewBag.path = "Início / Tipo Pertence / Editar";

            Tipopertence tipopertence = _tipopertenceService.Obter(id);
            TipopertenceModel tipopertenceModel = _mapper.Map<TipopertenceModel>(tipopertence);
            return View(tipopertenceModel);
        }

        // POST: Tipopertence/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TipopertenceModel tipopertenceModel)
        {
            if (ModelState.IsValid)
            {
                var tipopertence = _mapper.Map<Tipopertence>(tipopertenceModel);
                tipopertence.IdTipoPertence = id;
                _tipopertenceService.Atualizar(tipopertence);
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: Tipopertence/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.title_page = "Tipo Pertence";
            ViewBag.path = "Início / Tipo Pertence / Remover";

            Tipopertence tipopertence = _tipopertenceService.Obter(id);
            TipopertenceModel tipopertenceModel = _mapper.Map<TipopertenceModel>(tipopertence);
            return View(tipopertenceModel);
        }

        // POST: Tipopertence/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, TipopertenceModel tipopertenceModel)
        {
            _tipopertenceService.Remover(id);
            return RedirectToAction(nameof(Index));

        }
    }
}

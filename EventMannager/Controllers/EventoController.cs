using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EventManager.Models;

namespace EventManager.Controllers
{
    public class EventoController : Controller
    {
        private static List<Evento> eventos = new List<Evento>();

        public ActionResult ListaEventos()
        {
            return View(eventos);
        }

        public ActionResult CrearEvento()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearEvento(Evento evento)
        {
            if (ModelState.IsValid)
            {
                evento.ID = eventos.Count + 1;
                eventos.Add(evento);
                return RedirectToAction("ListaEventos");
            }
            return View(evento);
        }

        public ActionResult EditarEvento(int id)
        {
            var evento = eventos.FirstOrDefault(e => e.ID == id);
            if (evento == null) return HttpNotFound();
            return View(evento);
        }

        [HttpPost]
        public ActionResult EditarEvento(Evento evento)
        {
            var existingEvento = eventos.FirstOrDefault(e => e.ID == evento.ID);
            if (existingEvento != null)
            {
                existingEvento.Titulo = evento.Titulo;
                existingEvento.Descripcion = evento.Descripcion;
                existingEvento.Lugar = evento.Lugar;
                existingEvento.Fecha = evento.Fecha;
                return RedirectToAction("ListaEventos");
            }
            return View(evento);
        }

        public ActionResult EliminarEvento(int id)
        {
            var evento = eventos.FirstOrDefault(e => e.ID == id);
            if (evento != null) eventos.Remove(evento);
            return RedirectToAction("ListaEventos");
        }
    }
}

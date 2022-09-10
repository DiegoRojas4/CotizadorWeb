using Cotizador.ExamenWeb.Models;
using Cotizador.Herramientas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Cotizador.ExamenWeb.Models.Cotizacion;

namespace Cotizador.ExamenWeb.Controllers
{
    public class CotizadorController : Controller
    {
        private ClienteRest _clienteRest;

        // GET: CotizadorController
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ObtenerCotización(string descripcionid)
        {
            Root cotizacionResponse = new Root();
            string resultResponse = string.Empty;
            try
            {
                _clienteRest = new ClienteRest("https://api-test.aarco.com.mx/api-examen/api/examen/crear-peticion");

                var request = new RequestCotizador();
                request.DescripcionId = descripcionid;

                resultResponse = _clienteRest.SimplePost<RequestCotizador, string>(request).Result;

                if (!string.IsNullOrEmpty(resultResponse))
                {
                    _clienteRest = new ClienteRest(string.Concat("https://api-test.aarco.com.mx/api-examen/api/examen/peticion/", resultResponse));

                    cotizacionResponse = _clienteRest.SimpleGet<Root>().Result;
                }
                return Json(cotizacionResponse);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: CotizadorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CotizadorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CotizadorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CotizadorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CotizadorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CotizadorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CotizadorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

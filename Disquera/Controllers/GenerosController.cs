using Disquera.AccesoDatos.Data.Repository.Irepository;
using Disquera.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Disquera.Controllers
{
    public class GenerosController : Controller
    {
        private readonly IContenedorTrabajo contenedor;

        public GenerosController(IContenedorTrabajo contex)
        {
            contenedor = contex;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Genero genero)
        {

            if (ModelState.IsValid)
            {
                contenedor.GetGenero.Add(genero);
                contenedor.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var datos = contenedor.GetGenero.GetID((int)id);
            if (datos == null)
            {
                return NotFound();
            }
            return View(datos);
        }

        [HttpPost]
        public IActionResult Edit(Genero genero)
        {
            if (ModelState.IsValid)
            {
                contenedor.GetGenero.UPdate(genero);
                contenedor.Save();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Json(new { success = false, messge = "borrado Incorrecto" });
            }
            var datos = contenedor.GetGenero.GetID((int)id);
            if (datos == null)
            {
                return NotFound();
            }
            contenedor.GetGenero.Remove(datos);
            contenedor.Save();
            return Json(new { success = true, messge = "borrado Correcto" });


        }

        #region

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = contenedor.GetGenero.GetAll() });
        }
        #endregion

    }
}

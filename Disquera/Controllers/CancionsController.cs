using Disquera.AccesoDatos.Data.Repository.Irepository;
using Disquera.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Disquera.Controllers
{
    public class CancionsController : Controller
    {
        private readonly IContenedorTrabajo contenedor;

        public CancionsController(IContenedorTrabajo contex)
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
            CancionVM cancionVM = new CancionVM()
            {
                Cancion = new Cancion(),
                ListaAlbum = contenedor.GetAlbum.ListaAlbum()
            };
            return View(cancionVM);
        }

        [HttpPost]
        public IActionResult Create(CancionVM cancionVM)
        {

            if (ModelState.IsValid)
            {
                contenedor.GetCancion.Add(cancionVM.Cancion);
                contenedor.Save();
                return RedirectToAction(nameof(Index));
            }
            cancionVM.ListaAlbum = contenedor.GetAlbum.ListaAlbum();

            return View(cancionVM);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var datos = contenedor.GetCancion.GetID((int)id);
            if (datos == null)
            {
                return NotFound();
            }
            return View(datos);
        }
        [HttpPost]
        public IActionResult Edit(CancionVM cancionVM)
        {
            if (ModelState.IsValid)
            {
                contenedor.GetCancion.Add(cancionVM.Cancion);
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
            var datos = contenedor.GetCancion.GetID((int)id);
            if (datos == null)
            {
                return NotFound();
            }
            contenedor.GetCancion.Remove(datos);
            contenedor.Save();
            return Json(new { success = true, messge = "borrado Correcto" });


        }

        #region

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = contenedor.GetCancion.GetAll(Includepropidad: "Album") });
        }
        #endregion

    }
}

using Disquera.AccesoDatos.Data.Repository.Irepository;
using Disquera.Models;
using Disquera.Models.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Linq;

namespace Disquera.Controllers
{
    public class ArtistasController : Controller
    {
        private readonly IContenedorTrabajo contenedor;
        private readonly IWebHostEnvironment webHost;
        public ArtistasController(IContenedorTrabajo contex, IWebHostEnvironment _webHost)
        {
            contenedor = contex;
            webHost = _webHost;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ArtistaVM artistaVM = new ArtistaVM()
            {
                Artista = new Artista(),
                ListaGenero = contenedor.GetGenero.ListaGenero()

            };
            return View(artistaVM);
        }

        [HttpPost]
        public IActionResult Create(ArtistaVM artistaVM)
        {
            if (ModelState.IsValid)
            {
                var rutaPrincipal = webHost.WebRootPath;
                var archivo = HttpContext.Request.Form.Files;

                var nombreArchivo = Guid.NewGuid().ToString();
                var subida = Path.Combine(rutaPrincipal, @"imagenes\fotos");
                var extesion = Path.GetExtension(archivo[0].FileName);

                using (var filiStreams = new FileStream(Path.Combine(subida, nombreArchivo + extesion), FileMode.Create))
                {
                    archivo[0].CopyTo(filiStreams);
                }
                artistaVM.Artista.UrlImagen = @"\imagenes\fotos\" + nombreArchivo + extesion;

                contenedor.GetArtista.Add(artistaVM.Artista);
                contenedor.Save();
                return RedirectToAction(nameof(Index));
            }
            artistaVM.ListaGenero = contenedor.GetGenero.ListaGenero();
            return View(artistaVM);

        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ArtistaVM artistaVM = new ArtistaVM()
            {

                Artista = new Artista(),
                ListaGenero = contenedor.GetGenero.GetAll().Select(g => new SelectListItem()
                {
                    Text = g.Nombre,
                    Value = g.GeneroID.ToString()

                })

            };
            if (id == 0)
            {
                return NotFound();
            }


            if (id != null)
            {
                artistaVM.Artista = contenedor.GetArtista.GetID(id.GetValueOrDefault());

            }
            return View(artistaVM);
        }
        [HttpPost]
        public IActionResult Edit(ArtistaVM artistaVM)
        {

            var rutaImagenprincipal = webHost.WebRootPath;
            var archivo = HttpContext.Request.Form.Files;
            var ImagenDB = contenedor.GetArtista.GetID(artistaVM.Artista.ArtistaID);


            if (archivo.Count() > 0)
            {
                var nombreArchivo = Guid.NewGuid().ToString();
                var subida = Path.Combine(rutaImagenprincipal, @"imagenes\fotos");
                var extension = Path.GetExtension(archivo[0].FileName);
                var Nuevaextension = Path.GetExtension(archivo[0].FileName);

                var rutaImagen = Path.Combine(Nuevaextension, ImagenDB.UrlImagen.TrimStart('\\'));

                if (System.IO.File.Exists(rutaImagen))
                {
                    System.IO.File.Delete(rutaImagen);
                }

                using (var Filestreams = new FileStream(Path.Combine(subida, nombreArchivo + extension), FileMode.Create))
                {
                    archivo[0].CopyTo(Filestreams);
                }
                artistaVM.Artista.UrlImagen = @"\imagenes\fotos\" + nombreArchivo + extension;
            }
            else
            {
                artistaVM.Artista.UrlImagen = ImagenDB.UrlImagen;
            }
            contenedor.GetArtista.Update(artistaVM.Artista);
            contenedor.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var datos = contenedor.GetArtista.GetID(id);
            var rutaDirectorio = webHost.WebRootPath;//string
            var rutaImagen = Path.Combine(rutaDirectorio, datos.UrlImagen.TrimStart('\\'));

            if (System.IO.File.Exists(rutaImagen))
            {
                System.IO.File.Delete(rutaImagen);
            }

            if (datos == null)
            {
                return Json(new { success = false, message = "Error al borrar" });
            }

            contenedor.GetArtista.Remove(datos);
            contenedor.Save();
            return Json(new { success = true, message = " borrado Correcto" });


        }

        #region

        [HttpGet]
        public IActionResult GeAll()
        {
            return Json(new { data = contenedor.GetArtista.GetAll(Includepropidad: "Genero") });
        }
        #endregion

    }

}

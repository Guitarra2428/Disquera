using Disquera.AccesoDatos.Data.Repository.Irepository;
using Disquera.Models;
using Disquera.Models.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace Disquera.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IContenedorTrabajo contenedor;
        private readonly IWebHostEnvironment webHost;

        public AlbumsController(IContenedorTrabajo contex, IWebHostEnvironment _webHost)
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
            AlbumVM album = new AlbumVM()
            {
                Album = new Album(),
                ListaArtista = contenedor.GetArtista.ListaArtista(),

                //ListaCancion = contenedor.GetCancion.ListaCancion()

            };
            return View(album);
        }

        [HttpPost]
        public IActionResult Create(AlbumVM albumVM)
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
                albumVM.Album.UrlImagen = @"\imagenes\fotos\" + nombreArchivo + extesion;

                contenedor.GetAlbum.Add(albumVM.Album);
                contenedor.Save();
                return RedirectToAction(nameof(Index));
            }
            albumVM.ListaArtista = contenedor.GetArtista.ListaArtista();
            return View(albumVM);

        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            AlbumVM albumVM = new AlbumVM()
            {

                Album = new Album(),
                ListaArtista = contenedor.GetArtista.ListaArtista(),

            };
            if (id == 0)
            {
                return NotFound();
            }

            if (id != null)
            {
                albumVM.Album = contenedor.GetAlbum.GetID(id.GetValueOrDefault());

            }
            return View(albumVM);
        }


        [HttpPost]
        public IActionResult Edit(AlbumVM albumVM)
        {

            var rutaImagenprincipal = webHost.WebRootPath;
            var archivo = HttpContext.Request.Form.Files;
            var ImagenDB = contenedor.GetAlbum.GetID(albumVM.Album.AlbumID);


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
                albumVM.Album.UrlImagen = @"\imagenes\fotos\" + nombreArchivo + extension;
            }
            else
            {
                albumVM.Album.UrlImagen = ImagenDB.UrlImagen;
            }
            contenedor.GetAlbum.Update(albumVM.Album);
            contenedor.Save();
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var datosDb = contenedor.GetAlbum.GetID(id);
            string rutadirectorio = webHost.WebRootPath;
            var rutaImagen = Path.Combine(rutadirectorio, datosDb.UrlImagen.TrimStart('\\'));

            if (System.IO.File.Exists(rutaImagen))
            {
                System.IO.File.Delete(rutaImagen);
            }

            if (datosDb == null)
            {
                return Json(new { success = false, message = "borrado Incorrecto" });
            }

            contenedor.GetAlbum.Remove(datosDb);
            contenedor.Save();
            return Json(new { success = true, message = "borrado Correcto" });


        }

        #region

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = contenedor.GetAlbum.GetAll(Includepropidad: "Artista") });
        }
        #endregion

    }
}

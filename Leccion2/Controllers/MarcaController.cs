using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Leccion2.Models;

namespace Leccion2.Controllers
{
    public class MarcaController : Controller
    {
        List<MarcaModel> listaMarca = null;
        // GET: Marca
        public ActionResult Index()
        {
            using (var bd = new BDPasajeEntities())
            {
                listaMarca = (from marca in bd.Marca
                              where marca.BHABILITADO == 1
                              select new MarcaModel
                              {
                                  IIDMARCA = marca.IIDMARCA,
                                  NOMBRE = marca.NOMBRE,
                                  DESCRIPCION = marca.DESCRIPCION
                              }).ToList();
            }
            return View(listaMarca);
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(MarcaModel marcaEntrante)
        {
            if (!ModelState.IsValid)
            {
                return View(marcaEntrante);
            }
            else
            {
                using (var bd = new BDPasajeEntities())
                {
                    Marca oMarca = new Marca();
                    oMarca.NOMBRE = marcaEntrante.NOMBRE;
                    oMarca.DESCRIPCION = marcaEntrante.DESCRIPCION;
                    oMarca.BHABILITADO = 1;
                    bd.Marca.Add(oMarca);
                    bd.SaveChanges();
                }
                return RedirectToAction("Index");
            }           
        }
    }
}
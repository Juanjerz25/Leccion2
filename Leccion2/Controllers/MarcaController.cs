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

        public ActionResult Editar(int id)
        {
            MarcaModel marcaModel = new MarcaModel();

            using(var bd= new BDPasajeEntities())
            {
                Marca marca = bd.Marca.Where(x => x.IIDMARCA.Equals(id)).FirstOrDefault();
                marcaModel.IIDMARCA = marca.IIDMARCA;
                marcaModel.NOMBRE = marca.NOMBRE;
                marcaModel.DESCRIPCION = marca.DESCRIPCION;
                marcaModel.BHABILITADO = marca.BHABILITADO;
            }
            return View(marcaModel);
        }

        [HttpPost]
        public ActionResult Editar(MarcaModel marcaModel)
        {
            if (!ModelState.IsValid)
            {
                return View(marcaModel);
            }
            else
            {
                using (var bd = new BDPasajeEntities())
                {
                    Marca oMarca = bd.Marca.Where(x=>x.IIDMARCA.Equals(marcaModel.IIDMARCA)).FirstOrDefault();
                    oMarca.NOMBRE = marcaModel.NOMBRE;
                    oMarca.DESCRIPCION = marcaModel.DESCRIPCION;
                    oMarca.BHABILITADO = 1;
                    bd.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
}
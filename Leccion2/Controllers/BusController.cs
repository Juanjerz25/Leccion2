using Leccion2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Leccion2.Controllers
{
    public class BusController : Controller
    {
        // GET: Bus
        public ActionResult Index()
        {
            List<BusModel> listaBuses = new List<BusModel>();
            using (var bd = new BDPasajeEntities())
            {
                listaBuses = (from bus in bd.Bus
                              join sucursal in bd.Sucursal
                              on bus.IIDSUCURSAL equals sucursal.IIDSUCURSAL
                              join tipoBus in bd.TipoBus
                              on bus.IIDBUS equals tipoBus.IIDTIPOBUS
                              join tipoModelo in bd.Modelo
                              on bus.IIDMODELO equals tipoModelo.IIDMODELO
                              join marca in bd.Marca
                              on bus.IIDMARCA equals marca.IIDMARCA
                              where bus.BHABILITADO == 1
                              select new BusModel
                              {
                                  IIDBUS = bus.IIDBUS,
                                  IIDSUCURSAL = bus.IIDSUCURSAL,
                                  IIDTIPOBUS = bus.IIDTIPOBUS,
                                  PLACA = bus.PLACA,
                                  FECHACOMPRA = bus.FECHACOMPRA,
                                  IIDMODELO = bus.IIDMODELO,
                                  NUMEROFILAS = bus.NUMEROFILAS,
                                  NUMEROCOLUMNAS = bus.NUMEROCOLUMNAS,
                                  BHABILITADO = bus.BHABILITADO,
                                  DESCRIPCION = bus.DESCRIPCION,
                                  OBSERVACION = bus.OBSERVACION,
                                  IIDMARCA = bus.IIDMARCA,
                                  nombreSucursal = sucursal.NOMBRE,
                                  nombreTipoBus = tipoBus.NOMBRE,
                                  nombreTipoModelo = tipoModelo.NOMBRE,
                                  nombreMarca = marca.NOMBRE
                              }).ToList();
            }
            return View(listaBuses);
        }

        List<SelectListItem> listaSucursal;
        public void llenarSucursal()
        {
            using (var bd = new BDPasajeEntities())
            {
                listaSucursal = (from sucursal in bd.Sucursal
                                 where sucursal.BHABILITADO == 1
                                 select new SelectListItem
                                 {
                                     Text = sucursal.NOMBRE,
                                     Value = sucursal.IIDSUCURSAL.ToString()
                                 }).ToList();
                listaSucursal.Insert(0, new SelectListItem { Text = "--Seleccione", Value = "" });
                ViewBag.listaSucursal = listaSucursal;
            }
        }

        List<SelectListItem> listaTipoModelo;
        public void llenarTipoModelo()
        {
            using (var bd = new BDPasajeEntities())
            {
                listaTipoModelo = (from item in bd.Modelo
                                   where item.BHABILITADO == 1
                                   select new SelectListItem
                                   {
                                       Text = item.NOMBRE,
                                       Value = item.IIDMODELO.ToString()
                                   }).ToList();
                listaTipoModelo.Insert(0, new SelectListItem { Text = "--Seleccione", Value = "" });
                ViewBag.listaTipoModelo = listaTipoModelo;
            }
        }

        List<SelectListItem> listaTipoBus;
        public void llenarTipoBus()
        {
            using (var bd = new BDPasajeEntities())
            {
                listaTipoBus = (from item in bd.TipoBus
                                where item.BHABILITADO == 1
                                select new SelectListItem
                                {
                                    Text = item.NOMBRE,
                                    Value = item.IIDTIPOBUS.ToString()
                                }).ToList();
                listaTipoBus.Insert(0, new SelectListItem { Text = "--Seleccione", Value = "" });
                ViewBag.listaTipoBus = listaTipoBus;
            }
        }

        List<SelectListItem> listaMarca;
        public void llenarlistaMarca()
        {
            using (var bd = new BDPasajeEntities())
            {
                listaMarca = (from item in bd.Marca
                              where item.BHABILITADO == 1
                              select new SelectListItem
                              {
                                  Text = item.NOMBRE,
                                  Value = item.IIDMARCA.ToString()
                              }).ToList();
                listaMarca.Insert(0, new SelectListItem { Text = "--Seleccione", Value = "" });
                ViewBag.listaMarca = listaMarca;
            }
        }

        public void llenarCombos()
        {
            llenarSucursal();
            llenarTipoBus();
            llenarTipoModelo();
            llenarlistaMarca();
        }

        public ActionResult Agregar()
        {
            llenarCombos();

            return View();
        }
        [HttpPost]
        public ActionResult Agregar(BusModel busModel)
        {
            if (!ModelState.IsValid)
            {
                llenarCombos();
                return View(busModel);
            }
            using (var bd = new BDPasajeEntities())
            {
                Bus bus = new Bus();
                bus.IIDSUCURSAL = busModel.IIDSUCURSAL;
                bus.IIDTIPOBUS = busModel.IIDTIPOBUS;
                bus.PLACA = busModel.PLACA;
                bus.FECHACOMPRA = busModel.FECHACOMPRA;
                bus.IIDMODELO = busModel.IIDMODELO;
                bus.NUMEROFILAS = busModel.NUMEROFILAS;
                bus.NUMEROCOLUMNAS = busModel.NUMEROCOLUMNAS;
                bus.BHABILITADO = 1;
                bus.DESCRIPCION = busModel.DESCRIPCION;
                bus.OBSERVACION = busModel.OBSERVACION;
                bus.IIDMARCA = busModel.IIDMARCA;
                bd.Bus.Add(bus);
                bd.SaveChanges();
            }


            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            BusModel busModel = new BusModel();
            llenarCombos();
            using (var bd = new BDPasajeEntities())
            {
                Bus bus = bd.Bus.Where(x => x.IIDBUS.Equals(id)).FirstOrDefault();
                busModel.IIDBUS = bus.IIDBUS;
                busModel.IIDSUCURSAL = bus.IIDSUCURSAL;
                busModel.IIDTIPOBUS = bus.IIDTIPOBUS;
                busModel.PLACA = bus.PLACA;
                busModel.FECHACOMPRA = bus.FECHACOMPRA;
                busModel.IIDMODELO = bus.IIDMODELO;
                busModel.NUMEROFILAS = bus.NUMEROFILAS;
                busModel.NUMEROCOLUMNAS = bus.NUMEROCOLUMNAS;
                busModel.BHABILITADO = bus.BHABILITADO;
                busModel.DESCRIPCION = bus.DESCRIPCION;
                busModel.OBSERVACION = bus.OBSERVACION;
                busModel.IIDMARCA = bus.IIDMARCA;

            }
            return View(busModel);
        }

        [HttpPost]
        public ActionResult Editar(BusModel busModel)
        {
            if (!ModelState.IsValid)
            {
                llenarCombos();
                return View(busModel);
            }


            using (var bd = new BDPasajeEntities())
            {
                Bus bus = bd.Bus.Where(x => x.IIDBUS.Equals(busModel.IIDBUS)).FirstOrDefault();
                bus.IIDSUCURSAL = busModel.IIDSUCURSAL;
                bus.IIDTIPOBUS = busModel.IIDTIPOBUS;
                bus.PLACA = busModel.PLACA;
                bus.FECHACOMPRA = busModel.FECHACOMPRA;
                bus.IIDMODELO = busModel.IIDMODELO;
                bus.NUMEROFILAS = busModel.NUMEROFILAS;
                bus.NUMEROCOLUMNAS = busModel.NUMEROCOLUMNAS;
                bus.DESCRIPCION = busModel.DESCRIPCION;
                bus.OBSERVACION = busModel.OBSERVACION;
                bus.IIDMARCA = busModel.IIDMARCA;
                bd.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
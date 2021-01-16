using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Leccion2.Models;

namespace Leccion2.Controllers
{
    public class ViajeController : Controller
    {
        // GET: Viaje
        public ActionResult Index()
        {

            List<ViajeModel> listaViajes = new List<ViajeModel>();
            using (var bd = new BDPasajeEntities())
            {
                listaViajes = (from viaje in bd.Viaje
                               join lugarOrigen in bd.Lugar
                               on viaje.IIDLUGARORIGEN equals lugarOrigen.IIDLUGAR
                               join lugarDestino in bd.Lugar
                               on viaje.IIDLUGARDESTINO equals lugarDestino.IIDLUGAR
                               join Bus in bd.Bus
                               on viaje.IIDBUS equals Bus.IIDBUS
                               where viaje.BHABILITADO == 1
                               select new ViajeModel
                               {
                                   IIDVIAJE = viaje.IIDVIAJE,
                                   IIDLUGARORIGEN = viaje.IIDLUGARORIGEN,
                                   IIDLUGARDESTINO = viaje.IIDLUGARDESTINO,
                                   PRECIO = viaje.PRECIO,
                                   FECHAVIAJE = viaje.FECHAVIAJE,
                                   IIDBUS = viaje.IIDBUS,
                                   NUMEROASIENTOSDISPONIBLES = viaje.NUMEROASIENTOSDISPONIBLES,
                                   BHABILITADO = viaje.BHABILITADO,
                                   FOTO = viaje.FOTO,
                                   nombrefoto = viaje.nombrefoto,
                                   nombreLugarOrigen = lugarOrigen.NOMBRE,
                                   nombreLugarDestino = lugarDestino.NOMBRE,
                                   nombreBus = Bus.PLACA
                               }).ToList();
            }

            return View(listaViajes);
        }

        List<SelectListItem> listaLugares;
        private void llenarLugar()
        {
            using (var bd = new BDPasajeEntities())
            {
                listaLugares = (from item in bd.Lugar
                                where item.BHABILITADO == 1
                                select new SelectListItem
                                {
                                    Text = item.NOMBRE,
                                    Value = item.IIDLUGAR.ToString()
                                }).ToList();
                listaLugares.Insert(0, new SelectListItem { Text = "--Seleccione", Value = "" });
                ViewBag.listaLugares = listaLugares;
            }
        }

        List<SelectListItem> listaBuses;
        private void llenarBus()
        {
            using (var bd = new BDPasajeEntities())
            {
                listaBuses = (from item in bd.Bus
                              where item.BHABILITADO == 1
                              select new SelectListItem
                              {
                                  Text = item.PLACA,
                                  Value = item.IIDBUS.ToString()
                              }).ToList();
                listaBuses.Insert(0, new SelectListItem { Text = "--Seleccione", Value = "" });
                ViewBag.listaBuses = listaBuses;
            }
        }

        public void listarCombos()
        {
            llenarBus();
            llenarLugar();
        }

        public ActionResult Agregar()
        {
            listarCombos();
            return View();
        }
        [HttpPost]
        public ActionResult Agregar(ViajeModel viajeModel)
        {

            if (!ModelState.IsValid)
            {
                return View(viajeModel);
            }


            using (var bd = new BDPasajeEntities())
            {
                Viaje oViaje = new Viaje();
                oViaje.IIDLUGARORIGEN = viajeModel.IIDLUGARORIGEN;
                oViaje.IIDLUGARDESTINO = viajeModel.IIDLUGARDESTINO;
                oViaje.PRECIO = viajeModel.PRECIO;
                oViaje.FECHAVIAJE = viajeModel.FECHAVIAJE;
                oViaje.IIDBUS = viajeModel.IIDBUS;
                oViaje.NUMEROASIENTOSDISPONIBLES = viajeModel.NUMEROASIENTOSDISPONIBLES;
                oViaje.BHABILITADO = 1;
                oViaje.FOTO = viajeModel.FOTO;
                oViaje.nombrefoto = viajeModel.nombrefoto;

                bd.Viaje.Add(oViaje);
                bd.SaveChanges();
            }
            return View();
        }
    }
}
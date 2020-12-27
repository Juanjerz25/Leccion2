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
    }
}
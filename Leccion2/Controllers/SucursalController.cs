﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Leccion2.Models;
namespace Leccion2.Controllers
{
    public class SucursalController : Controller
    {
        // GET: Sucursal
        public ActionResult Index()
        {
            List<SucursalModel> listaSucursal = null;
            using (var bd = new BDPasajeEntities())
            {
                listaSucursal = (from sucursal in bd.Sucursal
                                 where sucursal.BHABILITADO == 1
                                 select new SucursalModel
                                 {
                                     IIDSUCURSAL = sucursal.IIDSUCURSAL,
                                     NOMBRE = sucursal.NOMBRE,
                                     TELEFONO = sucursal.TELEFONO,
                                     EMAIL = sucursal.EMAIL
                                 }).ToList();
            }
            return View(listaSucursal);
        }

        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Agregar(SucursalModel sucursalEntrante)
        {
            if (!ModelState.IsValid)
            {
                return View(sucursalEntrante);
            }
            else
            {
                using (var bd = new BDPasajeEntities())
                {
                    Sucursal oSucursal = new Sucursal();
                    oSucursal.NOMBRE = sucursalEntrante.NOMBRE;
                    oSucursal.DIRECCION = sucursalEntrante.DIRECCION;
                    oSucursal.TELEFONO = sucursalEntrante.TELEFONO;
                    oSucursal.EMAIL = sucursalEntrante.EMAIL;
                    oSucursal.FECHAAPERTURA = sucursalEntrante.FECHAAPERTURA;
                    oSucursal.BHABILITADO = 1;
                    bd.Sucursal.Add(oSucursal);
                    bd.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
    }
}
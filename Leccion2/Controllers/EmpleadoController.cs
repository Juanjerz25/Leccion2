using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Leccion2.Models;

namespace Leccion2.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            List<EmpleadoModel> listaEmpleado = new List<EmpleadoModel>();
            using (var bd = new BDPasajeEntities())
            {
                listaEmpleado = (from empleado in bd.Empleado
                                 join tipoUsuario in bd.TipoUsuario
                                 on empleado.IIDTIPOUSUARIO equals tipoUsuario.IIDTIPOUSUARIO
                                 join tipoContrato in bd.TipoContrato
                                 on empleado.IIDTIPOCONTRATO equals tipoContrato.IIDTIPOCONTRATO
                                 join tipoSexo in bd.Sexo
                                 on empleado.IIDSEXO equals tipoSexo.IIDSEXO where empleado.BHABILITADO ==1
                                 select new EmpleadoModel
                                 {
                                     IIDEMPLEADO = empleado.IIDEMPLEADO,
                                     NOMBRE = empleado.NOMBRE,
                                     APPATERNO = empleado.APPATERNO,
                                     APMATERNO = empleado.APMATERNO,
                                     FECHACONTRATO = empleado.FECHACONTRATO,
                                     SUELDO = empleado.SUELDO,
                                     NombreTipoContrato = tipoContrato.NOMBRE,
                                     NombreTipoUsuario = tipoUsuario.NOMBRE,
                                     NombreTipoSexo = tipoSexo.NOMBRE
                                 }).ToList();


            }
            return View(listaEmpleado);
        }

        List<SelectListItem> listaSexo;
        private void llenarSexo()
        {
            using (var bd = new BDPasajeEntities())
            {
                listaSexo = (from sexo in bd.Sexo
                             where sexo.BHABILITADO == 1
                             select new SelectListItem
                             {
                                 Text = sexo.NOMBRE,
                                 Value = sexo.IIDSEXO.ToString()
                             }).ToList();
                listaSexo.Insert(0, new SelectListItem { Text = "--Seleccione", Value = "" });
                ViewBag.listaSexo = listaSexo;
            }
        }

        List<SelectListItem> listaTipoContrato;
        public void llenarTipoContrato()
        {
            using (var bd = new BDPasajeEntities())
            {
                listaTipoContrato = (from tipoContrato in bd.TipoContrato
                             where tipoContrato.BHABILITADO == 1
                             select new SelectListItem
                             {
                                 Text = tipoContrato.NOMBRE,
                                 Value = tipoContrato.IIDTIPOCONTRATO.ToString()
                             }).ToList();
                listaTipoContrato.Insert(0, new SelectListItem { Text = "--Seleccione", Value = "" });
                ViewBag.listaTipoContrato = listaTipoContrato;
            }
        }

        List<SelectListItem> listaTipoUsuario;
        public void llenarTipoUsuario()
        {
            using (var bd = new BDPasajeEntities())
            {
                listaTipoUsuario = (from tipoUsuario in bd.TipoUsuario
                                     where tipoUsuario.BHABILITADO == 1
                                     select new SelectListItem
                                     {
                                         Text = tipoUsuario.NOMBRE,
                                         Value = tipoUsuario.IIDTIPOUSUARIO.ToString()
                                     }).ToList();
                listaTipoUsuario.Insert(0, new SelectListItem { Text = "--Seleccione", Value = "" });
                ViewBag.listaTipoUsuario = listaTipoUsuario;
            }
        }

        public void listarCombos()
        {
            llenarSexo();
            llenarTipoContrato();
            llenarTipoUsuario();

        }

        public ActionResult Agregar()
        {

            listarCombos();
            return View();
        }
        [HttpPost]
        public ActionResult Agregar(EmpleadoModel empleadoNuevo)
        {
            if (!ModelState.IsValid)
            {
                listarCombos();
                return View(empleadoNuevo);
            }

            using (var bd = new BDPasajeEntities())
            {
                Empleado empleado = new Empleado();
                empleado.NOMBRE = empleadoNuevo.NOMBRE;
                empleado.APMATERNO = empleadoNuevo.APMATERNO;
                empleado.APPATERNO = empleadoNuevo.APPATERNO;
                empleado.FECHACONTRATO = empleadoNuevo.FECHACONTRATO;
                empleado.SUELDO = empleadoNuevo.SUELDO;
                empleado.IIDTIPOUSUARIO = empleadoNuevo.IIDTIPOUSUARIO;
                empleado.IIDTIPOCONTRATO = empleadoNuevo.IIDTIPOCONTRATO;
                empleado.IIDSEXO = empleadoNuevo.IIDSEXO;
                empleado.BHABILITADO = 1;
                bd.Empleado.Add(empleado);
                bd.SaveChanges();
            }




            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            EmpleadoModel empleadoModel = new EmpleadoModel();
            listarCombos();
            using(var bd = new BDPasajeEntities())
            {
                Empleado empleado = bd.Empleado.Where(x => x.IIDEMPLEADO.Equals(id)).FirstOrDefault();
                empleadoModel.IIDEMPLEADO = empleado.IIDEMPLEADO;
                empleadoModel.NOMBRE = empleado.NOMBRE;
                empleadoModel.APPATERNO = empleado.APPATERNO;
                empleadoModel.APMATERNO = empleado.APMATERNO;
                empleadoModel.FECHACONTRATO = empleado.FECHACONTRATO;
                empleadoModel.SUELDO = empleado.SUELDO;
                empleadoModel.IIDTIPOUSUARIO = empleado.IIDTIPOUSUARIO;
                empleadoModel.IIDTIPOCONTRATO = empleado.IIDTIPOCONTRATO;
                empleadoModel.IIDSEXO = empleado.IIDSEXO;
                empleadoModel.BHABILITADO = empleado.BHABILITADO;
                empleadoModel.bTieneUsuario = empleado.bTieneUsuario;
                empleadoModel.TIPOUSUARIO = empleado.TIPOUSUARIO;            }
            return View(empleadoModel);
        }


    }
}
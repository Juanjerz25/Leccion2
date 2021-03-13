using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Leccion2.Models;

namespace Leccion2.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        //hola
        public ActionResult Index()
        {
            List<ClienteModel> listaCliente = null;
            using (var bd = new BDPasajeEntities())
            {
                listaCliente = (from cliente in bd.Cliente
                                where cliente.BHABILITADO == 1
                                select new ClienteModel
                                {
                                    IIDCLIENTE = cliente.IIDCLIENTE,
                                    NOMBRE = cliente.NOMBRE,
                                    APPATERNO = cliente.APPATERNO,
                                    APMATERNO = cliente.APMATERNO,
                                    EMAIL = cliente.EMAIL,
                                    DIRECCION = cliente.DIRECCION,
                                    IIDSEXO = cliente.IIDSEXO,
                                    TELEFONOFIJO = cliente.TELEFONOFIJO,
                                    TELEFONOCELULAR = cliente.TELEFONOCELULAR,
                                    BHABILITADO = cliente.BHABILITADO,
                                    bTieneUsuario = cliente.bTieneUsuario,
                                    TIPOUSUARIO = cliente.TIPOUSUARIO
                                }).ToList();
            }
            return View(listaCliente);
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
            }
        }
        public ActionResult Agregar()
        {
            llenarSexo();
            ViewBag.lista = listaSexo;
            return View();
        }

        [HttpPost]
        public ActionResult Agregar(ClienteModel clienteEntrante)
        {
            if (!ModelState.IsValid)
            {
                llenarSexo();
                ViewBag.lista = listaSexo;
                return View(clienteEntrante);
            }
            else
            {
                using (var bd = new BDPasajeEntities())
                {
                    Cliente cliente = new Cliente();
                    cliente.IIDCLIENTE = clienteEntrante.IIDCLIENTE;
                    cliente.NOMBRE = clienteEntrante.NOMBRE;
                    cliente.APPATERNO = clienteEntrante.APPATERNO;
                    cliente.APMATERNO = clienteEntrante.APMATERNO;
                    cliente.EMAIL = clienteEntrante.EMAIL;
                    cliente.DIRECCION = clienteEntrante.DIRECCION;
                    cliente.IIDSEXO = clienteEntrante.IIDSEXO;
                    cliente.TELEFONOFIJO = clienteEntrante.TELEFONOFIJO;
                    cliente.TELEFONOCELULAR = clienteEntrante.TELEFONOCELULAR;
                    cliente.BHABILITADO = 1;

                    bd.Cliente.Add(cliente);
                    bd.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }

        public ActionResult Editar(int id)
        {
            ClienteModel clienteModel = new ClienteModel();
            using (var bd = new BDPasajeEntities())
            {
                Cliente cliente = bd.Cliente.Where(x => x.IIDCLIENTE.Equals(id)).FirstOrDefault();
                clienteModel.IIDCLIENTE = cliente.IIDCLIENTE;
                clienteModel.NOMBRE = cliente.NOMBRE;
                clienteModel.APPATERNO = cliente.APPATERNO;
                clienteModel.APMATERNO = cliente.APMATERNO;
                clienteModel.EMAIL = cliente.EMAIL;
                clienteModel.DIRECCION = cliente.DIRECCION;
                clienteModel.IIDSEXO = cliente.IIDSEXO;
                clienteModel.TELEFONOFIJO = cliente.TELEFONOFIJO;
                clienteModel.TELEFONOCELULAR = cliente.TELEFONOCELULAR;
                clienteModel.BHABILITADO = cliente.BHABILITADO;
                clienteModel.bTieneUsuario = cliente.bTieneUsuario;
                clienteModel.TIPOUSUARIO = cliente.TIPOUSUARIO;
                llenarSexo();
                ViewBag.lista = listaSexo;
            }

            return View(clienteModel);
        }

        [HttpPost]
        public ActionResult Editar(ClienteModel clienteModel)
        {
            if (!ModelState.IsValid)
            {
                llenarSexo();
                ViewBag.lista = listaSexo;
                return View(clienteModel);
            }

            using (var bd = new BDPasajeEntities())
            {
                Cliente cliente = bd.Cliente.Where(x => x.IIDCLIENTE.Equals(clienteModel.IIDCLIENTE)).FirstOrDefault();
                cliente.IIDCLIENTE = clienteModel.IIDCLIENTE;
                cliente.NOMBRE = clienteModel.NOMBRE;
                cliente.APPATERNO = clienteModel.APPATERNO;
                cliente.APMATERNO = clienteModel.APMATERNO;
                cliente.EMAIL = clienteModel.EMAIL;
                cliente.DIRECCION = clienteModel.DIRECCION;
                cliente.IIDSEXO = clienteModel.IIDSEXO;
                cliente.TELEFONOFIJO = clienteModel.TELEFONOFIJO;
                cliente.TELEFONOCELULAR = clienteModel.TELEFONOCELULAR;
                bd.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
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
    }
}
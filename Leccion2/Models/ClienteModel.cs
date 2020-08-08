using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Leccion2.Models
{
    public class ClienteModel
    {
        [Display(Name ="Id Cliente")]
        public int IIDCLIENTE { get; set; }
        [Display(Name = "Nombre Cliente")]
        public string NOMBRE { get; set; }
        [Display(Name = "Primer Apellido Cliente")]
        public string APPATERNO { get; set; }
        [Display(Name = "Segundo Apellido Cliente")]
        public string APMATERNO { get; set; }
        public string EMAIL { get; set; }
        public string DIRECCION { get; set; }
        public int? IIDSEXO { get; set; }
        [Display(Name = "Telefono Fijo")]
        public string TELEFONOFIJO { get; set; }
        public string TELEFONOCELULAR { get; set; }
        public int? BHABILITADO { get; set; }
        public int? bTieneUsuario { get; set; }
        public string TIPOUSUARIO { get; set; }
    }
}
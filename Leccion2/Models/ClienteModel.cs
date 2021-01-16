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
        [Required]
        [StringLength(100,ErrorMessage = "Longiutd máxima 100")]
        public string NOMBRE { get; set; }
        [Display(Name = "Primer Apellido Cliente")]
        [Required]
        [StringLength(150, ErrorMessage = "Longiutd máxima 150")]
        public string APPATERNO { get; set; }
        [Display(Name = "Segundo Apellido Cliente")]
        [Required]
        [StringLength(150, ErrorMessage = "Longiutd máxima 150")]
        public string APMATERNO { get; set; }
        [Display(Name = "Correo electrónico")]
        [Required]
        [StringLength(200, ErrorMessage = "Longiutd máxima 200")]
        [EmailAddress(ErrorMessage ="Ingrese un email válido")]
        public string EMAIL { get; set; }
        [Display(Name = "Dirección")]
        [DataType(DataType.MultilineText)]
        [Required]
        [StringLength(200, ErrorMessage = "Longiutd máxima 200")]
        public string DIRECCION { get; set; }
        [Display(Name = "Sexo")]
        [Required]
        public int? IIDSEXO { get; set; }
        [Display(Name = "Telefono Fijo")]
        [Required]
        [StringLength(10, ErrorMessage = "Longiutd máxima 10")]
        public string TELEFONOFIJO { get; set; }
        [StringLength(10, ErrorMessage = "Longiutd máxima 10")]
        [Display(Name = "Celular")]
        [Required]
        public string TELEFONOCELULAR { get; set; }
        public int? BHABILITADO { get; set; }
        public int? bTieneUsuario { get; set; }
        public string TIPOUSUARIO { get; set; }
    }
}
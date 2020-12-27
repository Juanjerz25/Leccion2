using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Leccion2.Models
{
    public class SucursalModel
    {
        [Display(Name = "Id Sucursal")]
        public int IIDSUCURSAL { get; set; }
        [Display(Name = "Nombre Sucursal")]
        [StringLength(100, ErrorMessage = "Longitud máxima 100")]
        [Required]
        public string NOMBRE { get; set; }
        [Display(Name ="Dirección")]
        [StringLength(200,ErrorMessage ="Longitud máxima 200")]
        [Required]
        public string DIRECCION { get; set; }
        [Display(Name = "Telefono Sucursal")]
        [StringLength(10, ErrorMessage = "Longitud máxima 10")]
        [Required]
        public string TELEFONO { get; set; }

        [Display(Name = "Email Sucursal")]
        [Required]
        [StringLength(100, ErrorMessage = "Longitud máxima 100")]
        [EmailAddress(ErrorMessage = "Ingrese un email válido")]
        public string EMAIL { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha Apertura")]
        public DateTime? FECHAAPERTURA { get; set; }
        public int? BHABILITADO { get; set; }
    }
}
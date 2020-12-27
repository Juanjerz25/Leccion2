using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Leccion2.Models
{
    public class EmpleadoModel
    {
        [Display(Name = "Id Empleado")]
        public int IIDEMPLEADO { get; set; }
        [Display(Name = "Nombre Empleado")]
        [Required]
        [StringLength(100, ErrorMessage = "Longiutd máxima 100")]
        public string NOMBRE { get; set; }
        [Display(Name = "Primer Apellido")]
        [Required]
        [StringLength(200, ErrorMessage = "Longiutd máxima 200")]
        public string APPATERNO { get; set; }
        [Display(Name = "Segundo Apellido")]
        [Required]
        [StringLength(200, ErrorMessage = "Longiutd máxima 200")]
        public string APMATERNO { get; set; }
        [Display(Name = "Fecha Contrato")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime? FECHACONTRATO { get; set; }
        [Display(Name = "Sueldo")]
        [Range(0,100000,ErrorMessage ="Fuera de Ragon")]
        [Required]
        public decimal? SUELDO { get; set; }
        [Display(Name = "Tipo de Usuario")]
        [Required]
        public int? IIDTIPOUSUARIO { get; set; }
        [Display(Name = "Tipo de Contrato")]
        [Required]
        public int? IIDTIPOCONTRATO { get; set; }
        [Display(Name = "Sexo")]
        [Required]
        public int? IIDSEXO { get; set; }
        public int? BHABILITADO { get; set; }
        public int? bTieneUsuario { get; set; }
        public string TIPOUSUARIO { get; set; }

        //propiedades Complementarias
        public string  NombreTipoContrato { get; set; }
        public string NombreTipoUsuario { get; set; }
        public string NombreTipoSexo { get; set; }


    }
}
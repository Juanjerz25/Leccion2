using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Leccion2.Models
{
    public class BusModel
    {
        [Display(Name = "Id Bus")]
        public int IIDBUS { get; set; }
        [Display(Name = "Sucursal")]
        [Required]
        public int? IIDSUCURSAL { get; set; }
        [Display(Name = "Tipo Bus")]
        [Required]
        public int? IIDTIPOBUS { get; set; }
        [Display(Name = "Placa")]
        [Required]
        [StringLength(100, ErrorMessage = "Longiutd máxima 100")]
        public string PLACA { get; set; }
        [Display(Name = "Fecha de Compra")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime? FECHACOMPRA { get; set; }
        [Display(Name = "Tipo de Modelo")]
        [Required]
        public int? IIDMODELO { get; set; }
        [Display(Name = "Numero de Filas")]
        [Required]
        public int? NUMEROFILAS { get; set; }
        [Display(Name = "Número de Columnas")]
        [Required]
        public int? NUMEROCOLUMNAS { get; set; }
        public int? BHABILITADO { get; set; }
        [Display(Name = "Descripción")]
        [Required]
        [StringLength(200, ErrorMessage = "Longiutd máxima 200")]
        public string DESCRIPCION { get; set; }
        [Display(Name = "Observación")]
        [StringLength(200, ErrorMessage = "Longiutd máxima 200")]
        public string OBSERVACION { get; set; }
        [Display(Name = "Marca")]
        [Required]
        public int? IIDMARCA { get; set; }

        //complementarias
        public string nombreSucursal { get; set; }
        public string nombreTipoBus { get; set; }
        public string nombreTipoModelo { get; set; }
        public string nombreMarca { get; set; }

    }
}
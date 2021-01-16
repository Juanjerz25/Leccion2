using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Leccion2.Models
{
    public class ViajeModel
    {
        [Display(Name = "Id Viaje")]
        public int IIDVIAJE { get; set; }
        [Display(Name = "Lugar de Origen")]
        [Required]
        public int? IIDLUGARORIGEN { get; set; }
        [Display(Name = "Lugar de Destino")]
        [Required]
        public int? IIDLUGARDESTINO { get; set; }
        [Display(Name = "Precio")] 
        [Range(0,100000,ErrorMessage ="Rango fuera de indices")]
        [Required]
        public decimal? PRECIO { get; set; }
        [Display(Name = "Fecha de Viaje")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        [DataType(DataType.Date)]
        public DateTime? FECHAVIAJE { get; set; }
        [Display(Name = "Bus")]
        [Required]
        public int? IIDBUS { get; set; }
        [Display(Name = "Número de Asientos Disponibles")]
        [Required]
        public int? NUMEROASIENTOSDISPONIBLES { get; set; }
        public int? BHABILITADO { get; set; }
        public byte[] FOTO { get; set; }
        [Display(Name = "Foto Nombre")]
        [Required]
        [StringLength(100, ErrorMessage = "Longiutd máxima 100")]
        public string nombrefoto { get; set; }
        public string nombreLugarOrigen { get; set; }
        public string nombreLugarDestino { get; set; }
        public string nombreBus { get; set; }

    }
}
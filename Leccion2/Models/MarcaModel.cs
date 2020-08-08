using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Leccion2.Models
{
    public class MarcaModel
    {
        [Display(Name ="Id Marca")]
        public int IIDMARCA { get; set; }
        [Display(Name = "Nombre Marca")]
        [Required]
        [StringLength(100,ErrorMessage ="La longitud máxima es 100")]
        public string NOMBRE { get; set; }
        [Display(Name = "Descripción Marca")]
        [Required]
        [StringLength(200, ErrorMessage = "La longitud máxima es 200")]
        public string DESCRIPCION { get; set; }
        public int? BHABILITADO { get; set; }
    }
}
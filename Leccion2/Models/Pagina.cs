//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Leccion2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pagina
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pagina()
        {
            this.RolPagina = new HashSet<RolPagina>();
        }
    
        public int IIDPAGINA { get; set; }
        public string MENSAJE { get; set; }
        public string ACCION { get; set; }
        public string CONTROLADOR { get; set; }
        public Nullable<int> BHABILITADO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RolPagina> RolPagina { get; set; }
    }
}

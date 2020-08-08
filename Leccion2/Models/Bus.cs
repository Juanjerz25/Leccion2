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
    
    public partial class Bus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bus()
        {
            this.DETALLEVENTA = new HashSet<DETALLEVENTA>();
            this.Viaje = new HashSet<Viaje>();
        }
    
        public int IIDBUS { get; set; }
        public Nullable<int> IIDSUCURSAL { get; set; }
        public Nullable<int> IIDTIPOBUS { get; set; }
        public string PLACA { get; set; }
        public Nullable<System.DateTime> FECHACOMPRA { get; set; }
        public Nullable<int> IIDMODELO { get; set; }
        public Nullable<int> NUMEROFILAS { get; set; }
        public Nullable<int> NUMEROCOLUMNAS { get; set; }
        public Nullable<int> BHABILITADO { get; set; }
        public string DESCRIPCION { get; set; }
        public string OBSERVACION { get; set; }
        public Nullable<int> IIDMARCA { get; set; }
    
        public virtual Marca Marca { get; set; }
        public virtual Modelo Modelo { get; set; }
        public virtual Sucursal Sucursal { get; set; }
        public virtual TipoBus TipoBus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETALLEVENTA> DETALLEVENTA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Viaje> Viaje { get; set; }
    }
}

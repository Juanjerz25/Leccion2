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
    
    public partial class Usuario
    {
        public int IIDUSUARIO { get; set; }
        public string NOMBREUSUARIO { get; set; }
        public string CONTRA { get; set; }
        public string TIPOUSUARIO { get; set; }
        public Nullable<int> IID { get; set; }
        public Nullable<int> IIDROL { get; set; }
        public Nullable<int> bhabilitado { get; set; }
    
        public virtual Rol Rol { get; set; }
        public virtual TIPOUSUARIOREGISTRO TIPOUSUARIOREGISTRO { get; set; }
    }
}

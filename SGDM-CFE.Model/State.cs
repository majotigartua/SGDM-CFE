//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SGDM_CFE.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class State
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public State()
        {
            this.Assignments = new HashSet<Assignment>();
            this.Assignments1 = new HashSet<Assignment>();
        }
    
        public int IdState { get; set; }
        public bool HasFailures { get; set; }
        public string FailuresDescription { get; set; }
        public bool RequiresMaintenance { get; set; }
        public bool IsFunctional { get; set; }
        public string ReviewNotes { get; set; }
        public int IdDevice { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Assignment> Assignments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Assignment> Assignments1 { get; set; }
        public virtual Device Device { get; set; }
    }
}

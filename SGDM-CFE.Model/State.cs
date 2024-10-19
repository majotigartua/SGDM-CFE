using System.ComponentModel.DataAnnotations.Schema;

namespace SGDM_CFE.Model
{    
    public partial class State
    {
        [Column("IdState")]
        public int Id { get; set; }
        public bool HasFailures { get; set; }
        public string FailuresDescription { get; set; }
        public bool RequiresMaintenance { get; set; }
        public bool IsFunctional { get; set; }
        public string ReviewNotes { get; set; }
        public int IdDevice { get; set; }
    
        public virtual Device Device { get; set; }
    }
}
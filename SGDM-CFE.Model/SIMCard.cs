using System.ComponentModel.DataAnnotations.Schema;

namespace SGDM_CFE.Model
{    
    public partial class SIMCard
    {
        [Column("IdSIMCard")]
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public bool IsDeleted { get; set; }
    }
}
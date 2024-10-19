using System.ComponentModel.DataAnnotations.Schema;

namespace SGDM_CFE.Model
{
    public partial class MobileDevice
    {
        [Column("IdMobileDevice")]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int IdType { get; set; }
        public int IdDevice { get; set; }
        public int? IdSIMCard { get; set; }
    
        public virtual Device Device { get; set; }
        public virtual SIMCard SIMCard { get; set; }
        public virtual Type Type { get; set; }
    }
}
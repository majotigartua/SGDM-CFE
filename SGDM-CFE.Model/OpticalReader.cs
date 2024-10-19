using System.ComponentModel.DataAnnotations.Schema;

namespace SGDM_CFE.Model
{
    public partial class OpticalReader
    {
        [Column("IdOpticalReader")]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int IdDevice { get; set; }
    
        public virtual Device Device { get; set; }
    }
}
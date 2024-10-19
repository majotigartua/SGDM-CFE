using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGDM_CFE.Model
{
    public partial class Type
    {
        [Column("IdType")]
        public int IdType { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<MobileDevice> MobileDevices { get; set; }

        public Type()
        {
            MobileDevices = new HashSet<MobileDevice>();
        }
    }
}
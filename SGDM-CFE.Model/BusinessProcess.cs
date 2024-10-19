using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGDM_CFE.Model
{
    public partial class BusinessProcess
    {
        [Column("IdBusinessProcess")]
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Device> Devices { get; set; }

        public BusinessProcess()
        {
            Devices = new HashSet<Device>();
        }
    }
}
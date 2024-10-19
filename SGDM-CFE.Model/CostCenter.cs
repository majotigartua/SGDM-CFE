using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGDM_CFE.Model
{   
    public partial class CostCenter
    {
        [Column("IdCostCenter")]
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Device> Devices { get; set; }

        public CostCenter()
        {
            this.Devices = new HashSet<Device>();
        }
    }
}
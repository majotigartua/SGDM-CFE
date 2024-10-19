using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGDM_CFE.Model
{ 
    public partial class WorkCenter
    {
        [Column("IdWorkCenter")]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public int IdArea { get; set; }
    
        public virtual Area Area { get; set; }
        public virtual ICollection<Device> Devices { get; set; }

        public WorkCenter()
        {
            Devices = new HashSet<Device>();
        }
    }
}
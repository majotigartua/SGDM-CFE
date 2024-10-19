using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGDM_CFE.Model
{
    public partial class Area
    {
        [Column("IdArea")]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<WorkCenter> WorkCenters { get; set; }

        public Area()
        {
            WorkCenters = new HashSet<WorkCenter>();
        }
    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace SGDM_CFE.Model
{
    public partial class WorkCenter_CostCenter
    {
        [Column("IdWorkCenter_CostCenter")]
        public int Id { get; set; }
        public int IdWorkCenter { get; set; }
        public int IdCostCenter { get; set; }
    
        public virtual CostCenter CostCenter { get; set; }
        public virtual WorkCenter WorkCenter { get; set; }
    }
}
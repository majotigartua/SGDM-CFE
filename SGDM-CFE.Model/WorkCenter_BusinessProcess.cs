using System.ComponentModel.DataAnnotations.Schema;

namespace SGDM_CFE.Model
{
    public partial class WorkCenter_BusinessProcess
    {
        [Column("IdWorkCenter_BusinessProcess")]
        public int Id { get; set; }
        public int IdWorkCenter { get; set; }
        public int IdBusinessProcess { get; set; }
    
        public virtual BusinessProcess BusinessProcess { get; set; }
        public virtual WorkCenter WorkCenter { get; set; }
    }
}
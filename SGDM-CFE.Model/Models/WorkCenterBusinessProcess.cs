namespace SGDM_CFE.Model.Models
{
    public partial class WorkCenterBusinessProcess
    {
        public int Id { get; set; }
        public int WorkCenterId { get; set; }
        public int BusinessProcessId { get; set; }

        public virtual BusinessProcess BusinessProcess { get; set; } = null!;
        public virtual WorkCenter WorkCenter{ get; set; } = null!;

        public virtual ICollection<State> States { get; set; } = [];
    }
}
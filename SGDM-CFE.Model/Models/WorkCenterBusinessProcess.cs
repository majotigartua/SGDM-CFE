namespace SGDM_CFE.Model.Models
{
    public partial class WorkCenterBusinessProcess
    {
        public int Id { get; set; }
        public int IdWorkCenter { get; set; }
        public int IdBusinessProcess { get; set; }

        public virtual BusinessProcess BusinessProcess { get; set; } = null!;
        public virtual WorkCenter WorkCenter{ get; set; } = null!;

        public virtual ICollection<State> States { get; set; } = new List<State>();
    }
}
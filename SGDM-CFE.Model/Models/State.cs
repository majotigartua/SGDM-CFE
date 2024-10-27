namespace SGDM_CFE.Model.Models
{
    public partial class State
    {
        public int Id { get; set; }
        public bool HasFailures { get; set; }
        public string? FailuresDescription { get; set; }
        public bool RequiresMaintenance { get; set; }
        public bool IsFunctional { get; set; }
        public string? ReviewNotes { get; set; }
        public int DeviceId { get; set; }
        public int WorkCenterBusinessProcessId { get; set; }
        public int WorkCenterCostCenterId { get; set; }

        public virtual Device Device { get; set; } = null!;
        public virtual WorkCenterBusinessProcess WorkCenterBusinessProcess { get; set; } = null!;
        public virtual WorkCenterCostCenter WorkCenterCostCenter { get; set; } = null!;

        public virtual ICollection<Assignment> AssignmentStateAssignments { get; set; } = [];
        public virtual ICollection<Assignment> ReturnStateAssignments { get; set; } = [];
    }
}
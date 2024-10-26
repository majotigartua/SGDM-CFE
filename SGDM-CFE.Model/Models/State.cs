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
        public int IdDevice { get; set; }
        public int IdWorkCenterBusinessProcess { get; set; }
        public int IdWorkCenterCostCenter { get; set; }

        public virtual Device Device { get; set; } = null!;
        public virtual WorkCenterBusinessProcess WorkCenterBusinessProcess { get; set; } = null!;
        public virtual WorkCenterCostCenter WorkCenterCostCenter { get; set; } = null!;

        public virtual ICollection<Assignment> AssignmentStateAssignments { get; set; } = new List<Assignment>();
        public virtual ICollection<Assignment> ReturnStateAssignments { get; set; } = new List<Assignment>();
    }
}
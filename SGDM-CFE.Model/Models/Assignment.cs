namespace SGDM_CFE.Model.Models
{
    public partial class Assignment
    {
        public int Id { get; set; }
        public DateTime AssignmentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int EmployeeId { get; set; }
        public int AssignmentStateId { get; set; }
        public int? ReturnStateId { get; set; }

        public virtual State AssignmentState { get; set; } = null!;
        public virtual Employee Employee { get; set; } = null!;
        public virtual State? ReturnState { get; set; }
    }
}
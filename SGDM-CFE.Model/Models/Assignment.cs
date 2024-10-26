namespace SGDM_CFE.Model.Models
{
    public partial class Assignment
    {
        public int Id { get; set; }
        public DateTime AssignmentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int IdEmployee { get; set; }
        public int IdAssignmentState { get; set; }
        public int? IdReturnState { get; set; }

        public virtual State AssignmentState { get; set; } = null!;
        public virtual Employee Employee { get; set; } = null!;
        public virtual State? ReturnState { get; set; }
    }
}
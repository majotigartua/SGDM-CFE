namespace SGDM_CFE.Entities.Models
{
    public class Assignment
    {
        public int IdAssignment { get; set; }
        public DateTime AssignmentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int IdEmployee { get; set; }
        public int IdState { get; set; }

        public Assignment() { }

        public Assignment(int idAssignment, DateTime assignmentDate, DateTime? returnDate, int idEmployee, int idState)
        {
            IdAssignment = idAssignment;
            AssignmentDate = assignmentDate;
            ReturnDate = returnDate;
            IdEmployee = idEmployee;
            IdState = idState;
        }
    }
}
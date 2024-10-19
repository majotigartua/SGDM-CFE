using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGDM_CFE.Model
{
    public partial class Assignment
    {
        [Column("IdAssignment")]
        public int Id { get; set; }
        public DateTime AssignmentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int IdEmployee { get; set; }
        public int IdAssignmentState { get; set; }
        public int? IdReturnState { get; set; }
    
        public virtual State AssignmentState { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual State ReturnState { get; set; }
    }
}
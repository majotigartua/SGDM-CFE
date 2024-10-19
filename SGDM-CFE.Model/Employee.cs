using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGDM_CFE.Model
{
    public partial class Employee
    {
        [Column("IdEmployee")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PaternalSurname { get; set; }
        public string MaternalSurname { get; set; }
        public string RPE { get; set; }
        public bool IsDeleted { get; set; }
        public int? IdUser { get; set; }
    
        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual User User { get; set; }

        public Employee()
        {
            Assignments = new HashSet<Assignment>();
        }
    }
}
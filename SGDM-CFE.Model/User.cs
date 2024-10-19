using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGDM_CFE.Model
{   
    public partial class User
    {
        [Column("IdUser")]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        public int IdRole { get; set; }
    
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual Role Role { get; set; }

        public User()
        {
            Employees = new HashSet<Employee>();
        }
    }
}
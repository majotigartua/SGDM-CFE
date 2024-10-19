using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGDM_CFE.Model
{
    public partial class Role
    {
        [Column("IdRole")]
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<User> Users { get; set; }

        public Role()
        {
            Users = new HashSet<User>();
        }
    }
}
﻿namespace SGDM_CFE.Model.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool IsDeleted { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; } = [];
    }
}
﻿namespace SGDM_CFE.Model.Models
{
    public partial class Role
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<User> Users { get; set; } = [];

        public override string? ToString()
        {
            return Name;
        }
    }
}
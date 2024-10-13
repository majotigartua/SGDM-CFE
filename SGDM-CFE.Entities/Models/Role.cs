namespace SGDM_CFE.Entities.Models
{
    public class Role
    {
        public int IdRole { get; set; }
        public string? Name { get; set; }

        public Role() { }

        public Role(int idRole, string? name)
        {
            IdRole = idRole;
            Name = name;
        }
    }
}
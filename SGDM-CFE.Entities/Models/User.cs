using System.ComponentModel.DataAnnotations.Schema;

namespace SGDM_CFE.Entities.Models
{
    public class User
    {
        public int IdUser { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }

        public User() { }

        public User(int idUser, string? email, string? name)
        {
            IdUser = idUser;
            Email = email;
            Name = name;
        }
    }
}
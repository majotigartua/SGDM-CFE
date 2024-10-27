namespace SGDM_CFE.Model.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PaternalSurname { get; set; }
        public string? MaternalSurname { get; set; }
        public string? RPE { get; set; }
        public bool IsDeleted { get; set; }
        public int? UserId { get; set; }

        public virtual User? User { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; } = [];
    }
}
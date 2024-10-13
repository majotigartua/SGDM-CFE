namespace SGDM_CFE.Entities.Models
{
    public class Employee
    {
        public int IdEmployee { get; set; }
        public string? Name { get; set; }
        public string? PaternalSurname { get; set; }
        public string? MaternalSurname { get; set; }
        public string? RPE { get; set; }
        public int? IdUser { get; set; }

        public Employee() { }

        public Employee(int idEmployee, string? name, string? paternalSurname, string? maternalSurname, string? rpe, int? idUser)
        {
            IdEmployee = idEmployee;
            Name = name;
            PaternalSurname = paternalSurname;
            MaternalSurname = maternalSurname;
            RPE = rpe;
            IdUser = idUser;
        }
    }
}
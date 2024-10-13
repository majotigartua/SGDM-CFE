namespace SGDM_CFE.Entities.Models
{
    public class Area
    {
        public int IdArea { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }

        public Area() { }

        public Area(int idArea, string? code, string? name)
        {
            IdArea = idArea;
            Code = code;
            Name = name;
        }
    }
}
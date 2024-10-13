namespace SGDM_CFE.Entities.Models
{
    public class Type
    {
        public int IdType { get; set; }
        public string? Name { get; set; }

        public Type() { }

        public Type(int idType, string name)
        {
            IdType = idType;
            Name = name;
        }
    }
}
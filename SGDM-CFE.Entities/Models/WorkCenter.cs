using System.ComponentModel.DataAnnotations.Schema;

namespace SGDM_CFE.Entities.Models
{
    public class WorkCenter
    {
        public int IdWorkCenter { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public int IdArea { get; set; }

        public WorkCenter() { }

        public WorkCenter(int idWorkCenter, string? code, string? name, int idArea)
        {
            IdWorkCenter = idWorkCenter;
            Code = code;
            Name = name;
            IdArea = idArea;
        }
    }
}
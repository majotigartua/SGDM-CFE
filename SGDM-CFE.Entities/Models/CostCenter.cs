namespace SGDM_CFE.Entities.Models
{
    public class CostCenter
    {
        public int IdCostCenter { get; set; }
        public string? Name { get; set; }

        public CostCenter() { }

        public CostCenter(int idCostCenter, string? name)
        {
            IdCostCenter = idCostCenter;
            Name = name;
        }   
    }
}
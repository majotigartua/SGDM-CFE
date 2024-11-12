namespace SGDM_CFE.Model.Models
{
    public partial class CostCenter
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<WorkCenterCostCenter> WorkCenterCostCenters { get; set; } = [];

        public override string? ToString()
        {
            return Name;
        }
    }
}
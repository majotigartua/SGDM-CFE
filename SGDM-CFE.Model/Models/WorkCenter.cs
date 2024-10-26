namespace SGDM_CFE.Model.Models
{
    public partial class WorkCenter
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public bool IsDeleted { get; set; }

        public int IdArea { get; set; }

        public virtual Area Area { get; set; } = null!;

        public virtual ICollection<Device> Devices { get; set; } = new List<Device>();
        public virtual ICollection<WorkCenterBusinessProcess> WorkCenterBusinessProcesses { get; set; } = new List<WorkCenterBusinessProcess>();
        public virtual ICollection<WorkCenterCostCenter> WorkCenterCostCenters { get; set; } = new List<WorkCenterCostCenter>();
    }
}
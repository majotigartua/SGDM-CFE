namespace SGDM_CFE.Model.Models
{
    public partial class WorkCenter
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public bool IsDeleted { get; set; }

        public int AreaId { get; set; }

        public virtual Area Area { get; set; } = null!;

        public virtual ICollection<Device> Devices { get; set; } = [];
        public virtual ICollection<WorkCenterBusinessProcess> WorkCenterBusinessProcesses { get; set; } = [];
        public virtual ICollection<WorkCenterCostCenter> WorkCenterCostCenters { get; set; } = [];
    }
}
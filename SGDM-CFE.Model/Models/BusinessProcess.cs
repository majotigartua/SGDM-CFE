namespace SGDM_CFE.Model.Models
{
    public partial class BusinessProcess
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<WorkCenterBusinessProcess> WorkCenterBusinessProcesses { get; set; } = [];

        public override string? ToString()
        {
            return Name;
        }
    }
}
namespace SGDM_CFE.Model.Models
{
    public partial class Area
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<WorkCenter> WorkCenters { get; set; } = new List<WorkCenter>();
    }
}
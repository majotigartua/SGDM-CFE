namespace SGDM_CFE.Model.Models
{
    public partial class OpticalReader
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int DeviceId { get; set; }

        public virtual Device Device { get; set; } = null!;
    }
}
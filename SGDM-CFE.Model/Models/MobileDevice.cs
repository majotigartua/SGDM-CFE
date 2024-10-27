namespace SGDM_CFE.Model.Models
{
    public partial class MobileDevice
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int TypeId { get; set; }
        public int DeviceId { get; set; }
        public int? SIMCardId { get; set; }

        public virtual Device Device { get; set; } = null!;
        public virtual SIMCard? SIMCard { get; set; }
        public virtual Type Type { get; set; } = null!;
    }
}
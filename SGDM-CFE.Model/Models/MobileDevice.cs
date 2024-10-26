namespace SGDM_CFE.Model.Models
{
    public partial class MobileDevice
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int IdType { get; set; }
        public int IdDevice { get; set; }
        public int? IdSIMCard { get; set; }

        public virtual Device Device { get; set; } = null!;
        public virtual SIMCard? SIMCard { get; set; }
        public virtual Type Type { get; set; } = null!;
    }
}
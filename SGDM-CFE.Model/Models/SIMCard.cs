namespace SGDM_CFE.Model.Models
{
    public partial class SIMCard
    {
        public int Id { get; set; }
        public string? SerialNumber { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<MobileDevice> MobileDevices { get; set; } = [];

        public override string? ToString()
        {
            return SerialNumber;
        }
    }
}
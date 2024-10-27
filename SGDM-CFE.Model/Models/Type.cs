namespace SGDM_CFE.Model.Models
{
    public partial class Type
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<MobileDevice> MobileDevices { get; set; } = [];
    }
}
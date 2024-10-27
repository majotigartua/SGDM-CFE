namespace SGDM_CFE.Model.Models
{
    public partial class Device
    {
        public int Id{ get; set; }
        public string? InventoryNumber { get; set; }
        public string? SerialNumber { get; set; }
        public bool IsCriticalMission { get; set; }
        public string? Notes { get; set; }
        public bool IsDeleted { get; set; }
        public int WorkCenterId { get; set; }

        public virtual WorkCenter WorkCenter { get; set; } = null!;

        public virtual ICollection<MobileDevice> MobileDevices { get; set; } = [];
        public virtual ICollection<OpticalReader> OpticalReaders { get; set; } = [];
        public virtual ICollection<State> States { get; set; } = [];
    }
}
namespace SGDM_CFE.Entities.Models
{
    public class Device
    {
        public int IdDevice { get; set; }
        public string? InventoryNumber { get; set; }
        public string? SerialNumber { get; set; }
        public bool IsCriticalMission { get; set; }
        public string? Notes { get; set; }
        public int IdBusinessProcess { get; set; }
        public int IdCostCenter { get; set; }
        public int IdWorkCenter { get; set; }

        public Device() { }

        public Device(int idDevice, string? inventoryNumber, string? serialNumber, bool isCriticalMission, string? notes, int idBusinessProcess, int idCostCenter, int idWorkCenter)
        {
            IdDevice = idDevice;
            InventoryNumber = inventoryNumber;
            SerialNumber = serialNumber;
            IsCriticalMission = isCriticalMission;
            Notes = notes;
            IdBusinessProcess = idBusinessProcess;
            IdCostCenter = idCostCenter;
            IdWorkCenter = idWorkCenter;
        }
    }
}
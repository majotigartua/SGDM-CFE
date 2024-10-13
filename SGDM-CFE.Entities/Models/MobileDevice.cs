namespace SGDM_CFE.Entities.Models
{
    public class MobileDevice
    {
        public int IdMobileDevice {  get; set; }
        public int IdType { get; set; }
        public int IdDevice { get; set; }
        public int? IdSIMCard { get; set; }

        public MobileDevice() { }
        public MobileDevice(int idMobileDevice, int idType, int idDevice, int? idSIMCard)
        {
            IdMobileDevice = idMobileDevice;
            IdType = idType;
            IdDevice = idDevice;
            IdSIMCard = idSIMCard;
        }
    }
}
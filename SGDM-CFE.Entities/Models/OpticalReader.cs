namespace SGDM_CFE.Entities.Models
{
    public class OpticalReader
    {
        public int IdOpticalReader { get; set; }
        public int IdDevice { get; set; }

        public OpticalReader() { }

        public OpticalReader(int idOpticalReader, int idDevice)
        {
            IdOpticalReader = idOpticalReader;
            IdDevice = idDevice;
        }
    }
}
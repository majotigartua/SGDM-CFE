namespace SGDM_CFE.Entities.Models
{
    public class SIMCard
    {
        public int IdSIMCard { get; set; }
        public string? SerialNumber { get; set; }

        public SIMCard() { }

        public SIMCard(int idSIMCard, string? serialNumber)
        {
            IdSIMCard = idSIMCard;
            SerialNumber = serialNumber;
        }
    }
}
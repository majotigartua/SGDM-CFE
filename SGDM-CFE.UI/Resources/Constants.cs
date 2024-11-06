namespace SGDM_CFE.UI.Resources
{
    public class Constants
    {

        public enum DeviceType
        {
            OpticalReader,
            PortableTerminal,
            Tablet
        }

        public enum ViewType
        {
            StartPanel,
            Employees,
            OpticalReaders,
            PortableTerminals,
            SIMCards,
            Tablets,
            WorkCenters
        }

        public static class Roles
        {
            public const int Administrator = 1;
            public const int Operator = 2;
        }
    }
}
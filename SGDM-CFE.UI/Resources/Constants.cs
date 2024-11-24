namespace SGDM_CFE.UI.Resources
{
    public class Constants
    {
        public const int InvalidId = 0;

        public enum DeviceType
        {
            OpticalReader = 0,
            PortableTerminal = 1,
            Tablet = 2
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
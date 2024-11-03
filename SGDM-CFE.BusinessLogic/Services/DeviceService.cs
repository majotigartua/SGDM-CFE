using SGDM_CFE.BusinessLogic.Interfaces;
using SGDM_CFE.DataAccess.Repositories;
using SGDM_CFE.Model;

namespace SGDM_CFE.BusinessLogic.Services
{
    public class DeviceService(Context context) : IDeviceService
    {
        private readonly AssignmentRepository _assignmentRepository = new(context);
        private readonly DeviceRepository _deviceRepository = new(context);
        private readonly MobileDeviceRepository _mobileDeviceRepository = new(context);
        private readonly OpticalReaderRepository _opticalReaderRepository = new(context);
        private readonly SIMCardRepository _simCardRepository = new(context);
        private readonly StateRepository _stateRepository = new(context);
        private readonly TypeRepository _typeRepository = new(context);
    }
}
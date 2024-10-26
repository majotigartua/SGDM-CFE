using SGDM_CFE.BusinessLogic.Interfaces;
using SGDM_CFE.DataAccess.Repositories;
using SGDM_CFE.Model;

namespace SGDM_CFE.BusinessLogic.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly AssignmentRepository _assignmentRepository;
        private readonly DeviceRepository _deviceRepository;
        private readonly MobileDeviceRepository _mobileDeviceRepository;
        private readonly OpticalReaderRepository _opticalReaderRepository;
        private readonly SIMCardRepository _simCardRepository;
        private readonly StateRepository _stateRepository;
        private readonly TypeRepository _typeRepository;

        public DeviceService(Entities context)
        {
            _assignmentRepository = new AssignmentRepository(context);
            _deviceRepository = new DeviceRepository(context);
            _mobileDeviceRepository = new MobileDeviceRepository(context);
            _opticalReaderRepository = new OpticalReaderRepository(context);
            _simCardRepository = new SIMCardRepository(context);
            _stateRepository = new StateRepository(context);
            _typeRepository = new TypeRepository(context);
        }
    }
}
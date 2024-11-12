using SGDM_CFE.BusinessLogic.Interfaces;
using SGDM_CFE.DataAccess.Repositories;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;

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

        public Assignment? GetAssignmentByState(int stateId)
        {
            var assignment = _assignmentRepository.GetByState(stateId);
            return assignment;
        }

        public List<MobileDevice> GetMobileDevicesByType(int typeId)
        {
            var mobileDevices = _mobileDeviceRepository.GetByType(typeId);
            return mobileDevices;
        }

        public List<OpticalReader> GetOpticalReaders()
        {
            var opticalReaders = _opticalReaderRepository.GetAll();
            return opticalReaders;
        }

        public List<SIMCard> GetSIMCards()
        {
            var simCards = _simCardRepository.GetAll();
            return simCards;
        }

        public List<State> GetStatesByDevice(int deviceId)
        {
            var states = _stateRepository.GetByDevice(deviceId);
            return states;
        }
    }
}
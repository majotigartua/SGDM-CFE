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

        public bool CreateAssignment(Assignment assignment)
        {
            return _assignmentRepository.Add(assignment);
        }

        public bool CreateMobileDevice(MobileDevice mobileDevice)
        {
            return _mobileDeviceRepository.Add(mobileDevice);
        }

        public bool CreateOpticalReader(OpticalReader opticalReader)
        {
            return _opticalReaderRepository.Add(opticalReader);
        }

        public bool CreateSIMCard(SIMCard simCard)
        {
            return _simCardRepository.Add(simCard);
        }

        public bool DeleteMobileDevice(MobileDevice mobileDevice)
        {
            return _mobileDeviceRepository.Delete(mobileDevice);
        }

        public bool DeleteOpticalReader(OpticalReader opticalReader)
        {
            return _opticalReaderRepository.Delete(opticalReader);
        }

        public bool DeleteSIMCard(SIMCard simCard)
        {
            return _simCardRepository.Delete(simCard);
        }

        public bool EditAssignment(Assignment assignment)
        {
            return _assignmentRepository.Update(assignment);
        }

        public bool EditMobileDevice(MobileDevice mobileDevice)
        {
            return _mobileDeviceRepository.Update(mobileDevice);
        }

        public bool EditOpticalReader(OpticalReader opticalReader)
        {
            return _opticalReaderRepository.Update(opticalReader);
        }

        public bool EditSIMCard(SIMCard simCard)
        {
            return _simCardRepository.Update(simCard);
        }

        public Assignment? GetAssignmentByState(int stateId)
        {
            return _assignmentRepository.GetByState(stateId);
        }

        public List<Assignment> GetAssignmentsByDevice(int deviceId)
        {
            return _assignmentRepository.GetByDevice(deviceId);
        }

        public List<Assignment> GetAssignmentsByEmployee(int employeeId)
        {
            return _assignmentRepository.GetByEmployee(employeeId);
        }

        public List<Device> GetDevicesByWorkCenter(int workCenterId)
        {
            return _deviceRepository.GetByWorkCenter(workCenterId);
        }

        public MobileDevice? GetMobileDeviceBySIMCard(int simCardId)
        {
            return _mobileDeviceRepository.GetBySIMCard(simCardId);
        }

        public List<MobileDevice> GetMobileDevicesByType(int typeId)
        {
            return _mobileDeviceRepository.GetByType(typeId);
        }

        public List<OpticalReader> GetOpticalReaders()
        {
            return _opticalReaderRepository.GetAll();
        }

        public List<SIMCard> GetSIMCards()
        {
            return _simCardRepository.GetAll();
        }

        public State? GetStateByDevice(int deviceId)
        {
            return _stateRepository.GetByDevice(deviceId);
        }
    }
}
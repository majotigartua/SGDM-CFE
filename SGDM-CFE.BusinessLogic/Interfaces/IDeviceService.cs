using SGDM_CFE.Model.Models;

namespace SGDM_CFE.BusinessLogic.Interfaces
{
    public interface IDeviceService
    {
        bool CreateSIMCard(SIMCard simCard);
        bool EditSIMCard(SIMCard simCard);
        List<Assignment> GetAssignmentsByDevice(int deviceId);
        List<Assignment> GetAssignmentsByEmployee(int employeeId);
        Assignment? GetAssignmentByState(int stateId);
        List<Device> GetDevicesByWorkCenter(int workCenterId);
        List<OpticalReader> GetOpticalReaders();
        MobileDevice? GetMobileDeviceBySIMCard(int simCardId);
        List<MobileDevice> GetMobileDevicesByType(int typeId);
        List<SIMCard> GetSIMCards();
        State? GetStateByDevice(int deviceId);
    }
}
using SGDM_CFE.Model.Models;

namespace SGDM_CFE.BusinessLogic.Interfaces
{
    public interface IDeviceService
    {
        bool CreateAssignment(Assignment assignment);
        bool CreateMobileDevice(MobileDevice mobileDevice);
        bool CreateOpticalReader(OpticalReader opticalReader);
        bool CreateSIMCard(SIMCard simCard);
        bool DeleteMobileDevice(MobileDevice mobileDevice);
        bool DeleteOpticalReader(OpticalReader opticalReader);
        bool DeleteSIMCard(SIMCard simCard);
        bool EditAssignment(Assignment assignment);
        bool EditOpticalReader(OpticalReader opticalReader);
        bool EditMobileDevice(MobileDevice mobileDevice);
        bool EditSIMCard(SIMCard simCard);
        List<Assignment> GetAssignmentsByDevice(int deviceId);
        List<Assignment> GetAssignmentsByEmployee(int employeeId);
        Assignment? GetAssignmentByState(int stateId);
        List<Device> GetDevicesByWorkCenter(int workCenterId);
        List<OpticalReader> GetOpticalReaders();
        MobileDevice? GetMobileDeviceBySIMCard(int simCardId);
        List<MobileDevice> GetMobileDevicesByType(int typeId);
        SIMCard? GetSIMCardByMobileDevice(int mobileDeviceId);
        List<SIMCard> GetSIMCards();
        State? GetStateByDevice(int deviceId);
    }
}
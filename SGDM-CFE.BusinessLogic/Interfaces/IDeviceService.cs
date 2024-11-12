using SGDM_CFE.Model.Models;

namespace SGDM_CFE.BusinessLogic.Interfaces
{
    public interface IDeviceService
    {
        Assignment? GetAssignmentByState(int stateId);
        List<OpticalReader> GetOpticalReaders();
        List<MobileDevice> GetMobileDevicesByType(int typeId);
        List<SIMCard> GetSIMCards();
        List<State> GetStatesByDevice(int deviceId);
    }
}
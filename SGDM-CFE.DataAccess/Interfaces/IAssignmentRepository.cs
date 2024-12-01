using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IAssignmentRepository
    {
        bool Add(Assignment assignment);
        List<Assignment> GetByDevice(int deviceId);
        List<Assignment> GetByEmployee(int employeeId);
        Assignment? GetByState(int stateId);
        bool Update(Assignment assignment);
    }
}
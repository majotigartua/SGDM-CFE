using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IAssignmentRepository
    {
        bool Add(Assignment assignment);    
        List<Assignment> GetByEmployee(int employeeId);
        List<Assignment> GetByDevice(int deviceId);
        Assignment? GetByState(int stateId);
        bool Update(Assignment assignment);
    }
}
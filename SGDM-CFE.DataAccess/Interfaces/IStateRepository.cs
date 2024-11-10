using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IStateRepository
    {
        bool Add(State state);
        List<State> GetAll();
        List<State> GetByAssignment(int assigmentId);
        List<State> GetByBusinessProcess(int workCenterBusinessProcessId);
        List<State> GetByCostCenter(int workCenterCostCenterId);
        List<State> GetByDevice(int deviceId);
        State? GetById(int id);
        bool Update(State state);
    }
}
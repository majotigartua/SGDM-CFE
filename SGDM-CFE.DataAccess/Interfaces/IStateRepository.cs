using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IStateRepository
    {
        bool Add(State state);
        List<State> GetAll();
        List<State> GetByAssignment(Assignment assignment);
        List<State> GetByBusinessProcess(WorkCenterBusinessProcess workCenterBusinessProcess);
        List<State> GetByCostCenter(WorkCenterCostCenter workCenterCostCenter);
        List<State> GetByDevice(Device device);
        State GetById(int id);
        bool Update(State state);
    }
}
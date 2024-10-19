using SGDM_CFE.Model;
using System.Collections.Generic;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IStateRepository
    {
        void Add(State state);
        IEnumerable<State> GetAll();
        State GetByAssignment(Assignment assignment);
        IEnumerable<State> GetByDevice(Device device);
        State GetById(int id);
        void Update(State state);
    }
}
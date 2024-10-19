using SGDM_CFE.DataAccess.Interfaces;
using SGDM_CFE.Model;
using System.Collections.Generic;

namespace SGDM_CFE.DataAccess.Repositories
{
    public class StateRepository : IStateRepository
    {
        public void Add(State state)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<State> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public State GetByAssignment(Assignment assignment)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<State> GetByDevice(Device device)
        {
            throw new System.NotImplementedException();
        }

        public State GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(State state)
        {
            throw new System.NotImplementedException();
        }
    }
}
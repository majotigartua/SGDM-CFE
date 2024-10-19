using SGDM_CFE.DataAccess.Interfaces;
using SGDM_CFE.Model;
using System;
using System.Collections.Generic;

namespace SGDM_CFE.DataAccess.Repositories
{
    public class AssignmentRepository : IAssignmentRepository
    {
        public void Add(Assignment assignment)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Assignment> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Assignment> GetByEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Assignment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Assignment GetByState(State state)
        {
            throw new NotImplementedException();
        }

        public void Update(Assignment assignment)
        {
            throw new NotImplementedException();
        }
    }
}
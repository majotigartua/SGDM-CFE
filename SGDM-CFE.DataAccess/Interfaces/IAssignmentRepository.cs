using SGDM_CFE.Model;
using System.Collections.Generic;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IAssignmentRepository
    {
        void Add(Assignment assignment);
        IEnumerable<Assignment> GetAll();
        IEnumerable<Assignment> GetByEmployee(Employee employee);
        Assignment GetById(int id);
        Assignment GetByState(State state);
        void Update(Assignment assignment);
    }
}
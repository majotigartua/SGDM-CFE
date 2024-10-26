using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IAssignmentRepository
    {
        bool Add(Assignment assignment);    
        List<Assignment> GetAll();
        List<Assignment> GetByEmployee(Employee employee);
        Assignment GetById(int id);
        Assignment GetByState(State state);
        bool Update(Assignment assignment);
    }
}
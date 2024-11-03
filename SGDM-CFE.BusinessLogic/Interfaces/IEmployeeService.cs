using SGDM_CFE.Model.Models;

namespace SGDM_CFE.BusinessLogic.Interfaces
{
    public interface IEmployeeService
    {
        Employee? Login(string rpe, string password);
    }
}
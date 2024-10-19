using SGDM_CFE.Model;
using System.Collections.Generic;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAll();
        Role GetById(int id);
        Role GetByUser(User user);
    }
}
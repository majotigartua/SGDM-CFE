using SGDM_CFE.DataAccess.Interfaces;
using SGDM_CFE.Model;
using System.Collections.Generic;

namespace SGDM_CFE.DataAccess.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public IEnumerable<Role> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Role GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Role GetByUser(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
using SGDM_CFE.DataAccess.Interfaces;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Repositories
{
    public class RoleRepository(Context context) : IRoleRepository
    {
        private readonly Context _context = context;

        public List<Role> GetAll()
        {
            try
            {
                return [.. _context.Roles];
            }
            catch (Exception)
            {
                return [];
            }
        }
    }
}
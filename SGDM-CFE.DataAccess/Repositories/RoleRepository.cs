using Microsoft.EntityFrameworkCore;
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
                var roles = _context.Roles.ToList();
                return roles;
            }
            catch (Exception)
            {
                return [];
            }
        }

        public Role? GetById(int id)
        {
            try
            {
                var role = _context.Roles.Find(id);
                return role;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Role? GetByUser(int userId)
        {
            try
            {
                var role = _context.Roles
                    .Include(r => r.Users)
                    .FirstOrDefault(r => r.Users.Any(u => u.Id == userId));
                return role;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
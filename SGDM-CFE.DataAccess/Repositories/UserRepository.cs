using Microsoft.EntityFrameworkCore;
using SGDM_CFE.DataAccess.Interfaces;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Repositories
{
    public class UserRepository(Context context) : IUserRepository
    {
        private readonly Context _context = context;

        public bool Add(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int userId)
        {
            try
            {
                var existingUser = _context.Users.Find(userId);
                if (existingUser != null)
                {
                    existingUser.IsDeleted = true;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<User> GetAll()
        {
            try
            {
                var users = _context.Users.ToList();
                return users;
            }
            catch (Exception)
            {
                return [];
            }
        }

        public User? GetByEmployee(int employeeId)
        {
            try
            {
                var user = _context.Users
                    .Include(u => u.Role)
                    .Include(u => u.Employees)
                    .FirstOrDefault(u => u.Employees.Any(e => e.Id == employeeId));
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public User? GetById(int id)
        {
            try
            {
                var user = _context.Users.Find(id);
                return user;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<User> GetByRole(int roleId)
        {
            try
            {
                var users = _context.Users
                    .Include(u => u.Role)
                    .Where(u => u.Role.Id == roleId)
                    .ToList();
                return users;
            }
            catch (Exception)
            {
                return [];
            }
        }

        public bool Update(User user)
        {
            try
            {
                int userId = user.Id;
                var existingUser = _context.Users.Find(userId);
                if (existingUser != null)
                {
                    existingUser.Email = user.Email;
                    existingUser.Password = user.Password;
                    existingUser.RoleId = user.RoleId;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
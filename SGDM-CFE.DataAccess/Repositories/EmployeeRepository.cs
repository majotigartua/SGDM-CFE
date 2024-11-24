using Microsoft.EntityFrameworkCore;
using SGDM_CFE.DataAccess.Interfaces;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Repositories
{
    public class EmployeeRepository(Context context) : IEmployeeRepository
    {
        private readonly Context _context = context;

        public bool Add(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Employee employee)
        {
            try
            {
                _context.Attach(employee);
                employee.IsDeleted = true;
                _context.Entry(employee).Property(e => e.IsDeleted).IsModified = true;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Employee> GetAll()
        {
            try
            {
                return [.. _context.Employees.Include(e => e.User).Where(e => !e.IsDeleted)];
            }
            catch (Exception)
            {
                return [];
            }
        }

        public Employee? GetByRPE(string rpe)
        {
            try
            {
                return _context.Employees
                    .Include(e => e.User)
                    .ThenInclude(u => u!.Role)
                    .FirstOrDefault(e => !e.IsDeleted && e.RPE == rpe);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(Employee employee)
        {
            try
            {
                _context.Employees.Update(employee);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
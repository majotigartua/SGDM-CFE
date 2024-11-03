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
                int employeeId = employee.Id;
                var existingEmployee = _context.Employees.Find(employeeId);
                if (existingEmployee != null)
                {
                    existingEmployee.IsDeleted = true;
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

        public List<Employee> GetAll()
        {
            try
            {
                var employees = _context.Employees.ToList();
                return employees;
            }
            catch (Exception)
            {
                return [];
            }
        } 

        public Employee? GetByAssignment(Assignment assignment)
        {
            try
            {
                int assignmentId = assignment.Id;
                var employee = _context.Employees
                    .Include(e => e.Assignments)
                    .FirstOrDefault(e => e.Assignments.Any(a => a.Id == assignmentId));
                return employee;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Employee? GetById(int id)
        {
            try
            {
                var employee = _context.Employees.Find(id);
                return employee;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Employee? GetByRPE(string rpe)
        {
            try
            {
                var employee = _context.Employees.FirstOrDefault(e => e.RPE == rpe);
                return employee;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Employee? GetByUser(User user)
        {
            try
            {
                int userId = user.Id;
                var employee = _context.Employees
                    .Include(e => e.User)
                    .FirstOrDefault(e => e.User != null && e.User.Id == userId);
                return employee;
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
                int employeeId = employee.Id;
                var existingEmployee = _context.Employees.Find(employeeId);
                if (existingEmployee != null)
                {
                    existingEmployee.Name = employee.Name;
                    existingEmployee.PaternalSurname = employee.PaternalSurname;
                    existingEmployee.MaternalSurname = employee.MaternalSurname;
                    existingEmployee.RPE = employee.RPE;
                    existingEmployee.UserId = employee.UserId;
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
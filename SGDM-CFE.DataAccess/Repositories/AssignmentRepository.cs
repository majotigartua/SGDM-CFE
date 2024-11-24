using Microsoft.EntityFrameworkCore;
using SGDM_CFE.DataAccess.Interfaces;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Repositories
{
    public class AssignmentRepository(Context context) : IAssignmentRepository
    {
        private readonly Context _context = context;

        public bool Add(Assignment assignment)
        {
            try
            {
                _context.Add(assignment);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Assignment> GetByDevice(int deviceId)
        {
            try
            {
                return [.. _context.Assignments
                    .Include(a => a.AssignmentState)
                    .ThenInclude(s => s.Device)
                    .Include(a => a.Employee)
                    .Where(a => a.AssignmentState.Device.Id == deviceId)];
            }
            catch (Exception)
            {
                return [];
            }
        }

        public List<Assignment> GetByEmployee(int employeeId)
        {
            try
            {
                return [.. _context.Assignments
                    .Include(a => a.Employee)
                    .Include(a => a.AssignmentState)
                    .ThenInclude(a => a.Device)
                    .ThenInclude(a => a.WorkCenter)
                    .ThenInclude(a => a.Area)
                    .Where(a => a.EmployeeId == employeeId && a.ReturnState == null)];
            }
            catch (Exception)
            {
                return [];
            }
        }

        public Assignment? GetByState(int stateId)
        {
            try
            {
                return _context.Assignments
                    .Include(a => a.AssignmentState)
                    .Include(a => a.Employee)
                    .Include(a => a.ReturnState)
                    .Where(a => a.AssignmentStateId == stateId || a.ReturnStateId == stateId)
                    .ToList()
                    .LastOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(Assignment assignment)
        {
            try
            {
                _context.Assignments.Update(assignment);
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
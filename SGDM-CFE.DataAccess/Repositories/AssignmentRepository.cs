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

        public List<Assignment> GetAll()
        {
            try
            {
                var assignments = _context.Assignments.ToList();
                return assignments;
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
                var assignments = _context.Assignments
                    .Where(a => a.EmployeeId == employeeId)
                    .ToList();
                return assignments;
            }
            catch (Exception)
            {
                return [];
            }
        }

        public Assignment? GetById(int id)
        {
            try
            {
                var assignment = _context.Assignments.Find(id);
                return assignment;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Assignment? GetByState(int stateId)
        {
            try
            {
                var assignment = _context.Assignments.FirstOrDefault(a => a.AssignmentStateId == stateId || a.ReturnStateId == stateId);
                return assignment;
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
                int assignmentId = assignment.Id;
                var existingAssignment = _context.Assignments.Find(assignmentId);
                if (existingAssignment != null)
                {
                    existingAssignment.ReturnDate = assignment.ReturnDate;
                    existingAssignment.ReturnStateId = assignment.ReturnStateId;
                    _context.Update(assignment);
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
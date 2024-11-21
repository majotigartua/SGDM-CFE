using SGDM_CFE.DataAccess.Repositories;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;

namespace SGDM_CFE.Test.UnitTests
{
    public class AssignmentRepositoryTests
    {
        private readonly Context _context;
        private readonly AssignmentRepository _assignmentRepository;

        public AssignmentRepositoryTests()
        {
            _context = new Context();
            _assignmentRepository = new AssignmentRepository(_context);
        }

        [Fact]
        public void Add()
        {
            var assignment = new Assignment
            {
                AssignmentDate = DateTime.Now,
                EmployeeId = 1,
                AssignmentStateId = 1
            };
            var result = _assignmentRepository.Add(assignment);
            Assert.True(result);
        }

        [Fact]
        public void GetByEmployee()
        {
            var employee = _context.Employees.First();
            int employeeId = employee.Id;
            var assignments = _assignmentRepository.GetByEmployee(employeeId);
            Assert.NotEmpty(assignments);
            Assert.All(assignments, a => Assert.Equal(a.EmployeeId, employeeId));
        }

        [Fact]
        public void GetByState()
        {
            var state = _context.States.First();
            int stateId = state.Id;
            var assignment = _assignmentRepository.GetByState(stateId);
            Assert.NotNull(assignment);
            Assert.True(assignment.AssignmentStateId == stateId || assignment.ReturnStateId == stateId);
        }

        [Fact]
        public void Update()
        {
            var assignment = _context.Assignments.First();
            assignment.ReturnDate = DateTime.Now;
            assignment.ReturnStateId = 2;
            var result = _assignmentRepository.Update(assignment);
            Assert.True(result);
        }
    }
}
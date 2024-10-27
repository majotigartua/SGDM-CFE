using SGDM_CFE.DataAccess.Repositories;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;

namespace SGDM_CFE.Test.UnitTests
{
    public class StateRepositoryTests
    {
        private readonly Context _context;
        private readonly StateRepository _stateRepository;

        public StateRepositoryTests()
        {
            _context = new Context();
            _stateRepository = new StateRepository(_context);
        }

        [Fact]
        public void Add()
        {
            var State = new State
            {
                HasFailures = false,
                FailuresDescription = "Test",
                RequiresMaintenance = false,
                IsFunctional = true,
                ReviewNotes = "Test",
                DeviceId = 1,
                WorkCenterBusinessProcessId = 1,
                WorkCenterCostCenterId = 1
            };
            var result = _stateRepository.Add(State);
            Assert.True(result);
        }

        [Fact]
        public void GetAll()
        {
            var result = _stateRepository.GetAll();
            Assert.NotNull(result);
        }

        [Fact]
        public void GetByAssignment()
        {
            var assignment = _context.Assignments.First();
            int assignmentId = assignment.Id;
            var states = _stateRepository.GetByAssignment(assignment);
            Assert.NotEmpty(states);
            Assert.All(states, s => Assert.True(s.AssignmentStateAssignments.Any(a => a.Id == assignmentId) || s.ReturnStateAssignments.Any(a => a.Id == assignmentId)));
        }

        [Fact]
        public void GetByBusinessProcess()
        {
            var workCenterBusinessProcess = _context.WorkCenterBusinessProcesses.First();
            int workCenterBusinessProcessId = workCenterBusinessProcess.Id;
            var states = _stateRepository.GetByBusinessProcess(workCenterBusinessProcess);
            Assert.NotEmpty(states);
            Assert.All(states, s => Assert.Equal(s.WorkCenterBusinessProcessId, workCenterBusinessProcessId));
        }

        [Fact]
        public void GetByCostCenter()
        {
            var workCenterCostCenter = _context.WorkCenterCostCenters.First();
            int workCenterCostCenterId = workCenterCostCenter.Id;
            var states = _stateRepository.GetByCostCenter(workCenterCostCenter);
            Assert.NotEmpty(states);
            Assert.All(states, s => Assert.Equal(s.WorkCenterCostCenterId, workCenterCostCenterId));
        }

        [Fact]
        public void GetByDevice()
        {
            var device = _context.Devices.First();
            int deviceId = device.Id;
            var states = _stateRepository.GetByDevice(device);
            Assert.NotEmpty(states);
            Assert.All(states, s => Assert.Equal(s.DeviceId, deviceId));
        }

        [Fact]
        public void GetById()
        {
            int stateId = 1;
            var state = _stateRepository.GetById(stateId);
            Assert.NotNull(state);
            Assert.Equal(state.Id, stateId);
        }

        [Fact]
        public void Update()
        {
            var state = _context.States.First();
            state.HasFailures = false;
            state.FailuresDescription = "Test";
            state.RequiresMaintenance = false;
            state.IsFunctional = true;
            state.ReviewNotes = "Test";
            state.DeviceId = 1;
            state.WorkCenterBusinessProcessId = 1;
            state.WorkCenterCostCenterId = 1;
            var result = _stateRepository.Update(state);
            Assert.True(result);
        }
    }
}
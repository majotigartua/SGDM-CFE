using Microsoft.EntityFrameworkCore;
using SGDM_CFE.DataAccess.Interfaces;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Repositories
{
    public class StateRepository(Context context) : IStateRepository
    {
        private readonly Context _context = context;

        public bool Add(State state)
        {
            try
            {
                _context.States.Add(state);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<State> GetAll()
        {
            try
            {
                var states = _context.States.ToList();
                return states;
            }
            catch (Exception)
            {
                return [];
            }
        }

        public List<State> GetByAssignment(int assignmentId)
        {
            try
            {
                var states = _context.States
                    .Include(s => s.AssignmentStateAssignments)
                    .Include(s => s.ReturnStateAssignments)
                    .Where(s => s.AssignmentStateAssignments.Any(a => a.Id == assignmentId) || s.ReturnStateAssignments.Any(a => a.Id == assignmentId))
                    .ToList();
                return states;
            }
            catch (Exception)
            {
                return [];
            }
        }

        public List<State> GetByBusinessProcess(int workCenterBusinessProcessId)
        {
            try
            {
                var states = _context.States
                    .Where(s => s.WorkCenterBusinessProcessId == workCenterBusinessProcessId)
                    .ToList();
                return states;
            }
            catch (Exception)
            {
                return [];
            }
        }

        public List<State> GetByCostCenter(int workCenterCostCenterId)
        {
            try
            {
                var states = _context.States
                    .Where(s => s.WorkCenterCostCenterId == workCenterCostCenterId)
                    .ToList();
                return states;
            }
            catch (Exception)
            {
                return [];
            }
        }

        public List<State> GetByDevice(int deviceId)
        {
            try
            {
                var states = _context.States
                    .Where(s => s.DeviceId == deviceId)
                    .ToList();
                return states;
            }
            catch (Exception)
            {
                return [];
            }
        }

        public State? GetById(int id)
        {
            try
            {
                var state = _context.States.Find(id);
                return state;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(State state)
        {
            try
            {
                int stateId = state.Id;
                var existingState = _context.States.Find(stateId);
                if (existingState != null)
                {
                    existingState.HasFailures = state.HasFailures;
                    existingState.FailuresDescription = state.FailuresDescription;
                    existingState.RequiresMaintenance = state.RequiresMaintenance;
                    existingState.IsFunctional = state.IsFunctional;
                    existingState.ReviewNotes = state.ReviewNotes;
                    existingState.WorkCenterBusinessProcessId = state.WorkCenterBusinessProcessId;
                    existingState.WorkCenterCostCenterId = state.WorkCenterCostCenterId;
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
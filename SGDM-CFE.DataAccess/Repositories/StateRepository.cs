using Microsoft.EntityFrameworkCore;
using SGDM_CFE.DataAccess.Interfaces;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Repositories
{
    public class StateRepository(Context context) : IStateRepository
    {
        private readonly Context _context = context;

        public State? GetByDevice(int deviceId)
        {
            try
            {
                return _context.States
                    .Include(s => s.Device)
                    .ThenInclude(d => d.WorkCenter)
                    .ThenInclude(wc => wc.Area)
                    .Include(s => s.Device)
                    .ThenInclude(d => d.MobileDevices)
                    .ThenInclude(md => md.SIMCard)
                    .Include(s => s.WorkCenterBusinessProcess)
                    .ThenInclude(wcbp => wcbp.BusinessProcess)
                    .Include(s => s.WorkCenterCostCenter)
                    .ThenInclude(wccb => wccb.CostCenter)
                    .Where(s => s.DeviceId == deviceId)
                    .ToList()
                    .LastOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
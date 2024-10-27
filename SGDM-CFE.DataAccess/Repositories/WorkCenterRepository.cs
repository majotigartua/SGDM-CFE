using Microsoft.EntityFrameworkCore;
using SGDM_CFE.DataAccess.Interfaces;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Repositories
{
    public class WorkCenterRepository(Context context) : IWorkCenterRepository
    {
        private readonly Context _context = context;

        public bool Add(WorkCenter workCenter)
        {
            try
            {
                _context.WorkCenters.Add(workCenter);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(WorkCenter workCenter)
        {
            try
            {
                int workCenterId = workCenter.Id;
                var existingWorkCenter = _context.WorkCenters.Find(workCenterId);
                if (existingWorkCenter != null)
                {
                    existingWorkCenter.IsDeleted = true;
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

        public List<WorkCenter> GetAll()
        {
            try
            {
                var workCenters = _context.WorkCenters.ToList();
                return workCenters;
            }
            catch (Exception)
            {
                return [];
            }
        }

        public List<WorkCenter> GetByArea(Area area)
        {
            try
            {
                int areaId = area.Id;
                var workCenters = _context.WorkCenters
                    .Include(w => w.Area)
                    .Where(w => w.Area.Id == areaId)
                    .ToList();
                return workCenters;
            }
            catch (Exception)
            {
                return [];
            }
        }

        public List<WorkCenter> GetByBusinessProcess(BusinessProcess businessProcess)
        {
            try
            {
                int businessProcessId = businessProcess.Id;
                var workCenters = _context.WorkCenterBusinessProcesses
                    .Where(wcbp => wcbp.BusinessProcessId == businessProcessId)
                    .Select(wcbp => wcbp.WorkCenter)
                    .ToList();
                return workCenters;
            }
            catch (Exception)
            {
                return [];
            }
        }

        public List<WorkCenter> GetByCostCenter(CostCenter costCenter)
        {
            try
            {
                int costCenterId = costCenter.Id;
                var workCenters = _context.WorkCenterCostCenters
                    .Where(wcbc => wcbc.CostCenterId == costCenterId)
                    .Select(wcbc => wcbc.WorkCenter)
                    .ToList();
                return workCenters;
            }
            catch (Exception)
            {
                return [];
            }
        }

        public WorkCenter? GetById(int id)
        {
            try
            {
                var workCenter = _context.WorkCenters.Find(id);
                return workCenter;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(WorkCenter workCenter)
        {
            try
            {
                int workCenterId = workCenter.Id;
                var existingWorkCenter = _context.WorkCenters.Find(workCenterId);
                if (existingWorkCenter != null)
                {
                    existingWorkCenter.Code = workCenter.Code;
                    existingWorkCenter.Name = workCenter.Name;
                    existingWorkCenter.AreaId = workCenter.AreaId;
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
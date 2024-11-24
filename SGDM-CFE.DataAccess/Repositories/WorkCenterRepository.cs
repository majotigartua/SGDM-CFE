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
                _context.Attach(workCenter);
                workCenter.IsDeleted = true;
                _context.Entry(workCenter).Property(w => w.IsDeleted).IsModified = true;
                _context.SaveChanges();
                return true;
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
                return [.. _context.WorkCenters
                    .Include(w => w.Area)
                    .Include(w => w.WorkCenterBusinessProcesses)
                    .ThenInclude(wcbp => wcbp.BusinessProcess)
                    .Include(w => w.WorkCenterCostCenters)
                    .ThenInclude(wccc => wccc.CostCenter)
                    .Where(wc => !wc.IsDeleted)];
            }
            catch (Exception)
            {
                return [];
            }
        }

        public List<WorkCenter> GetByArea(int areaId)
        {
            try
            {
                return [.. _context.WorkCenters
                    .Include(w => w.Area)
                    .Include(w => w.WorkCenterBusinessProcesses)
                    .ThenInclude(wcbp => wcbp.BusinessProcess)
                    .Include(w => w.WorkCenterCostCenters)
                    .ThenInclude(wcbc => wcbc.CostCenter)
                    .Where(w => !w.IsDeleted && w.Area.Id == areaId)];
            }
            catch (Exception)
            {
                return [];
            }
        }

        public bool Update(WorkCenter workCenter)
        {
            try
            {
                _context.WorkCenters.Update(workCenter);
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
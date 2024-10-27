using SGDM_CFE.DataAccess.Interfaces;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Repositories
{
    public class CostCenterRepository(Context context) : ICostCenterRepository
    {
        private readonly Context _context = context;

        public List<CostCenter> GetAll()
        {
            try
            {
                var costCenters = _context.CostCenters.ToList();
                return costCenters;
            }
            catch (Exception)
            {
                return [];
            }
        }

        public CostCenter? GetById(int id)
        {
            try
            {
                var costCenter = _context.CostCenters.Find(id);
                return costCenter;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<CostCenter> GetByWorkCenter(WorkCenter workCenter)
        {
            try
            {
                int workCenterId = workCenter.Id;
                var costCenters = _context.WorkCenterCostCenters
                    .Where(wccc => wccc.WorkCenterId == workCenterId)
                    .Select(wccc => wccc.CostCenter)
                    .ToList();
                return costCenters;
            }
            catch (Exception)
            {
                return [];
            }
        }
    }
}
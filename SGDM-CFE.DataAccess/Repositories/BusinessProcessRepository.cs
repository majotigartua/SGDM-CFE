using SGDM_CFE.DataAccess.Interfaces;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Repositories
{
    public class BusinessProcessRepository(Context context) : IBusinessProcessRepository
    {
        private readonly Context _context = context;

        public List<BusinessProcess> GetAll()
        {
            try
            {
                var businessProcesses = _context.BusinessProcesses.ToList();
                return businessProcesses;
            }
            catch (Exception)
            {
                return [];
            }
        }

        public BusinessProcess? GetById(int id)
        {
            try
            {
                var businessProcess = _context.BusinessProcesses.Find(id);
                return businessProcess;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<BusinessProcess> GetByWorkCenter(int workCenterId)
        {
            try
            {
                var businessProcesses = _context.WorkCenterBusinessProcesses
                    .Where(wcbp => wcbp.WorkCenterId == workCenterId)
                    .Select(wcbp => wcbp.BusinessProcess)
                    .ToList();
                return businessProcesses;
            }
            catch (Exception)
            {
                return [];
            }
        }
    }
}
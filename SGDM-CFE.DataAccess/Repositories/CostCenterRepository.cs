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
                return [.. _context.CostCenters];
            }
            catch (Exception)
            {
                return [];
            }
        }
    }
}
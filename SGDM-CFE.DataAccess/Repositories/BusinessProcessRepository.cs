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
                return [.. _context.BusinessProcesses];
            }
            catch (Exception)
            {
                return [];
            }
        }
    }
}
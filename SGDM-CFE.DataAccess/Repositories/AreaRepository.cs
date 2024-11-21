using SGDM_CFE.DataAccess.Interfaces;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Repositories
{
    public class AreaRepository(Context context) : IAreaRepository
    {
        private readonly Context _context = context;

        public List<Area> GetAll()
        {
            try
            {
                return [.. _context.Areas];
            }
            catch (Exception)
            {
                return [];
            }
        }
    }
}
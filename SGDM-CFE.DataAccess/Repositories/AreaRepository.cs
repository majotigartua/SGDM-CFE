using Microsoft.EntityFrameworkCore;
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
                var areas = _context.Areas.ToList();
                return areas;
            }
            catch (Exception)
            {
                return [];
            }
        }

        public Area? GetById(int id)
        {
            try
            {
                var area = _context.Areas.Find(id);
                return area;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public Area? GetByWorkCenter(int workCenterId)
        {
            try
            {
                var area = _context.Areas
                    .Include(a => a.WorkCenters)
                    .FirstOrDefault(a => a.WorkCenters.Any(wc => wc.Id == workCenterId));
                return area;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
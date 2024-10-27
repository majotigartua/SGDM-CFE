using Microsoft.EntityFrameworkCore;
using SGDM_CFE.DataAccess.Interfaces;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;
using Type = SGDM_CFE.Model.Models.Type;

namespace SGDM_CFE.DataAccess.Repositories
{
    public class TypeRepository(Context context) : ITypeRepository
    {
        private readonly Context _context = context;

        public List<Type> GetAll()
        {
            try
            {
                var types = _context.Types.ToList();
                return types;
            }
            catch (Exception)
            {
                return [];
            }
        }

        public Type? GetById(int id)
        {
            try
            {
                var type = _context.Types.Find(id);
                return type;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Type? GetByMobileDevice(MobileDevice mobileDevice)
        {
            try
            {
                int mobileDeviceId = mobileDevice.Id;
                var type = _context.Types
                    .Include(t => t.MobileDevices)
                    .FirstOrDefault(t => t.MobileDevices.Any(md => md.Id == mobileDeviceId));
                return type;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
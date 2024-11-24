using Microsoft.EntityFrameworkCore;
using SGDM_CFE.DataAccess.Interfaces;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Repositories
{
    public class MobileDeviceRepository(Context context) : IMobileDeviceRepository
    {
        private readonly Context _context = context;

        public bool Add(MobileDevice mobileDevice)
        {
            try
            {
                _context.MobileDevices.Add(mobileDevice);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(MobileDevice mobileDevice)
        {
            try
            {
                _context.MobileDevices.Attach(mobileDevice);
                mobileDevice.IsDeleted = true;
                _context.Entry(mobileDevice).Property(md => md.IsDeleted).IsModified = true;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public MobileDevice? GetBySIMCard(int simCardId)
        {
            try
            {
                return _context.MobileDevices
                    .Include(md => md.Device)
                    .Include(md => md.SIMCard)
                    .FirstOrDefault(md => md.SIMCard!.Id == simCardId);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<MobileDevice> GetByType(int typeId)
        {
            try
            {
                return [.. _context.MobileDevices
                    .Include(md => md.Device)
                    .ThenInclude(d => d.WorkCenter)
                    .ThenInclude(wc => wc.Area)
                    .Include(md => md.Type)
                    .Where(md => !md.IsDeleted && md.Type.Id == typeId)];
            }
            catch (Exception)
            {
                return [];
            }
        }

        public bool Update(MobileDevice mobileDevice)
        {
            try
            {
                _context.MobileDevices.Update(mobileDevice);
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
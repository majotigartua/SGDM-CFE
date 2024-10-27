using Microsoft.EntityFrameworkCore;
using SGDM_CFE.DataAccess.Interfaces;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;
using Type = SGDM_CFE.Model.Models.Type;

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
                int mobileDeviceId = mobileDevice.Id;
                var existingMobileDevice = _context.MobileDevices.Find(mobileDeviceId);
                if (existingMobileDevice != null)
                {
                    existingMobileDevice.IsDeleted = true;
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

        public List<MobileDevice> GetAll()
        {
            try
            {
                var mobileDevices = _context.MobileDevices.ToList();
                return mobileDevices;
            }
            catch (Exception)
            {
                return [];
            }
        }

        public MobileDevice? GetByDevice(Device device)
        {
            try
            {
                int deviceId = device.Id;
                var mobileDevice = _context.MobileDevices
                    .Include(md => md.Device)
                    .FirstOrDefault(md => md.Device.Id == deviceId);
                return mobileDevice;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public MobileDevice? GetById(int id)
        {
            try
            {
                var mobileDevice = _context.MobileDevices.Find(id);
                return mobileDevice;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public MobileDevice? GetBySIMCard(SIMCard simCard)
        {
            try
            {
                int simCardId = simCard.Id;
                var mobileDevice = _context.MobileDevices
                    .Include(md => md.SIMCard)
                    .FirstOrDefault(md => md.SIMCard != null && md.SIMCard.Id == simCardId);
                return mobileDevice;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<MobileDevice> GetByType(Type type)
        {
            try
            {
                int typeId = type.Id;
                var mobileDevices = _context.MobileDevices
                    .Include(md => md.Type)
                    .Where(md => md.Type.Id == typeId)
                    .ToList();
                return mobileDevices;
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
                int mobileDeviceId = mobileDevice.Id;
                var existingMobileDevice = _context.MobileDevices.Find(mobileDeviceId);
                if (existingMobileDevice != null)
                {
                    existingMobileDevice.SIMCardId = mobileDevice.SIMCardId;
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
using Microsoft.EntityFrameworkCore;
using SGDM_CFE.DataAccess.Interfaces;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Repositories
{
    public class DeviceRepository(Context context) : IDeviceRepository
    {
        private readonly Context _context = context;

        public bool Add(Device device)
        {
            try
            {
                _context.Devices.Add(device);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int deviceId)
        {
            try
            {
                var existingDevice = _context.Devices.Find(deviceId);
                if (existingDevice != null)
                {
                    existingDevice.IsDeleted = true;
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

        public List<Device> GetAll()
        {
            try
            {
                var devices = _context.Devices.ToList();
                return devices;
            }
            catch (Exception)
            {
                return [];
            }
        }

        public Device? GetById(int id)
        {
            try
            {
                var device = _context.Devices.Find(id);
                return device;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Device? GetByMobileDevice(int mobileDeviceId)
        {
            try
            {
                var device = _context.Devices
                    .Include(d => d.MobileDevices)
                    .FirstOrDefault(d => d.MobileDevices.Any(md => md.DeviceId == mobileDeviceId));
                return device;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Device? GetByOpticalReader(int opticalReaderId)
        {
            try
            {
                var device = _context.Devices
                    .Include(d => d.OpticalReaders)
                    .FirstOrDefault(d => d.OpticalReaders.Any(or => or.DeviceId == opticalReaderId));
                return device;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Device? GetByState(int stateId)
        {
            try
            {
                var device = _context.Devices
                    .Include(d => d.States)
                    .FirstOrDefault(d => d.States.Any(s => s.Id == stateId));
                return device;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Device> GetByWorkCenter(int workCenterId)
        {
            try
            {
                var devices = _context.Devices
                    .Where(d => d.WorkCenterId == workCenterId)
                    .ToList();
                return devices;
            }
            catch (Exception)
            {
                return [];
            }
        }

        public bool Update(Device device)
        {
            try
            {
                int deviceId = device.Id;
                var existingDevice = _context.Devices.Find(deviceId);
                if (existingDevice != null)
                {
                    existingDevice.InventoryNumber = device.InventoryNumber;
                    existingDevice.SerialNumber = device.SerialNumber;
                    existingDevice.IsCriticalMission = device.IsCriticalMission;
                    existingDevice.Notes = device.Notes;
                    existingDevice.WorkCenterId = device.WorkCenterId;
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
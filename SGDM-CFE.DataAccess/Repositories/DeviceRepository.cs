using SGDM_CFE.DataAccess.Interfaces;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Repositories
{
    public class DeviceRepository(Context context) : IDeviceRepository
    {
        private readonly Context _context = context;

        public List<Device> GetByWorkCenter(int workCenterId)
        {
            try
            {
                return [.. _context.Devices.Where(d => d.WorkCenterId == workCenterId)];
            }
            catch (Exception)
            {
                return [];
            }
        }
    }
}
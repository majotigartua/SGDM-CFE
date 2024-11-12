using Microsoft.EntityFrameworkCore;
using SGDM_CFE.DataAccess.Interfaces;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Repositories
{
    public class OpticalReaderRepository(Context context) : IOpticalReaderRepository
    {
        private readonly Context _context = context;

        public bool Add(OpticalReader opticalReader)
        {
            try
            {
                _context.OpticalReaders.Add(opticalReader);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int opticalReaderId)
        {
            try
            {
                var existingOpticalReader = _context.OpticalReaders.Find(opticalReaderId);
                if (existingOpticalReader != null)
                {
                    existingOpticalReader.IsDeleted = true;
                    _context.SaveChanges();
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<OpticalReader> GetAll()
        {
            try
            {
                var opticalReaders = _context.OpticalReaders
                    .Include(or => or.Device)
                    .ThenInclude(d => d.WorkCenter)
                    .ThenInclude(wc => wc.Area)
                    .Where(or => !or.IsDeleted)
                    .ToList();
                return opticalReaders;
            }
            catch (Exception)
            {
                return [];
            }
        }

        public OpticalReader? GetByDevice(int deviceId)
        {
            try
            {
                var opticalReader = _context.OpticalReaders.FirstOrDefault(o => o.DeviceId == deviceId);
                return opticalReader;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public OpticalReader? GetById(int id)
        {
            try
            {
                var opticalReader = _context.OpticalReaders.Find(id);
                return opticalReader;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
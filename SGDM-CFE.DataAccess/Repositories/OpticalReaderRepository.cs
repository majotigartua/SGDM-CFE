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

        public bool Delete(OpticalReader opticalReader)
        {
            try
            {
                _context.OpticalReaders.Attach(opticalReader);
                opticalReader.IsDeleted = true;
                _context.Entry(opticalReader).Property(or => or.IsDeleted).IsModified = true;
                _context.SaveChanges();
                return true;
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
                return [.. _context.OpticalReaders.Include(or => or.Device).ThenInclude(d => d.WorkCenter).ThenInclude(wc => wc.Area).Where(or => !or.IsDeleted)];
            }
            catch (Exception)
            {
                return [];
            }
        }

        public bool Update(OpticalReader opticalReader)
        {
            try
            {
                _context.OpticalReaders.Update(opticalReader);
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
using Microsoft.EntityFrameworkCore;
using SGDM_CFE.DataAccess.Interfaces;
using SGDM_CFE.Model;
using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Repositories
{
    public class SIMCardRepository(Context context) : ISIMCardRepository
    {
        private readonly Context _context = context;

        public bool Add(SIMCard simCard)
        {
            try
            {
                _context.SIMCards.Add(simCard);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(SIMCard simCard)
        {
            try
            {
                int simCardId = simCard.Id;
                var existingSIMCard = _context.SIMCards.Find(simCardId);
                if (existingSIMCard != null)
                {
                    existingSIMCard.IsDeleted = true;
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

        public List<SIMCard> GetAll()
        {
            try
            {
                var simCards = _context.SIMCards.ToList();
                return simCards;
            }
            catch (Exception)
            {
                return [];
            }
        }

        public SIMCard? GetById(int id)
        {
            try
            {
                var simCard = _context.SIMCards.Find(id);
                return simCard;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public SIMCard? GetByMobileDevice(MobileDevice mobileDevice)
        {
            try
            {
                int mobileDeviceId = mobileDevice.Id;
                var simCard = _context.SIMCards
                    .Include(sc => sc.MobileDevices)
                    .FirstOrDefault(sc => sc.MobileDevices.Any(md => md.Id == mobileDeviceId));
                return simCard;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(SIMCard simCard)
        {
            try
            {
                int SIMCardId = simCard.Id;
                var existingSIMCard = _context.SIMCards.Find(SIMCardId);
                if (existingSIMCard != null)
                {
                    existingSIMCard.SerialNumber = simCard.SerialNumber;
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
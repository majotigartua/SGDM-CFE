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
                _context.SIMCards.Attach(simCard);
                simCard.IsDeleted = true;
                _context.Entry(simCard).Property(sc => sc.IsDeleted).IsModified = true;
                _context.SaveChanges();
                return true;
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
                return [.. _context.SIMCards.Where(sc => !sc.IsDeleted)];
            }
            catch (Exception)
            {
                return [];
            }
        }

        public bool Update(SIMCard simCard)
        {
            try
            {
                _context.SIMCards.Update(simCard);
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
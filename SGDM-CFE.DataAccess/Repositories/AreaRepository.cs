using SGDM_CFE.DataAccess.Interfaces;
using SGDM_CFE.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SGDM_CFE.DataAccess.Repositories
{
    public class AreaRepository : IAreaRepository
    {

        public AreaRepository()
        {
        }

        public IEnumerable<Area> GetAll()
        {
            using (Entities _context = new Entities())
            {
                return _context.Areas.ToList();
            }
        }

        public Area GetById(int id)
        {
            return new Area();
        }

        public Area GetByWorkCenter(WorkCenter workCenter)
        {
            return new Area();
        }
    }
}
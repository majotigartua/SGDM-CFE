using SGDM_CFE.DataAccess.Interfaces;
using SGDM_CFE.Model;
using System;
using System.Collections.Generic;

namespace SGDM_CFE.DataAccess.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        public IEnumerable<Area> GetAll()
        {
            throw new NotImplementedException();
        }

        public Area GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Area GetByWorkCenter(WorkCenter workCenter)
        {
            throw new NotImplementedException();
        }
    }
}
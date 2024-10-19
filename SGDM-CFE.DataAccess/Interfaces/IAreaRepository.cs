using SGDM_CFE.Model;
using System.Collections.Generic;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IAreaRepository
    {
        IEnumerable<Area> GetAll();
        Area GetById(int id);
        Area GetByWorkCenter(WorkCenter workCenter);
    }
}
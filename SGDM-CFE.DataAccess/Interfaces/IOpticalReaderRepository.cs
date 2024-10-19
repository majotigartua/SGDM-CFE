using SGDM_CFE.Model;
using System.Collections.Generic;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IOpticalReaderRepository
    {
        void Add(OpticalReader opticalReader);
        void Delete(OpticalReader opticalReader);
        IEnumerable<OpticalReader> GetAll();
        OpticalReader GetByDevice(Device device);
        OpticalReader GetById(int id);
        void Update(OpticalReader opticalReader);
    }
}
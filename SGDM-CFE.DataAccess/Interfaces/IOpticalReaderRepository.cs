using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IOpticalReaderRepository
    {
        bool Add(OpticalReader opticalReader);
        bool Delete(OpticalReader opticalReader);
        List<OpticalReader> GetAll();
        OpticalReader? GetById(int id);
        OpticalReader? GetByDevice(Device device);
    }
}
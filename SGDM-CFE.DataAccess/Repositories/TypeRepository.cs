using SGDM_CFE.DataAccess.Interfaces;
using SGDM_CFE.Model;
using System;
using System.Collections.Generic;
using Type = SGDM_CFE.Model.Type;

namespace SGDM_CFE.DataAccess.Repositories
{
    public class TypeRepository : ITypeRepository
    {
        public IEnumerable<Type> GetAll()
        {
            throw new NotImplementedException();
        }

        public Type GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Type GetByMobileDevice(MobileDevice mobileDevice)
        {
            throw new NotImplementedException();
        }
    }
}
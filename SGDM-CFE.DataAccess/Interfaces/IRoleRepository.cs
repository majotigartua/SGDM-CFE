﻿using SGDM_CFE.Model.Models;

namespace SGDM_CFE.DataAccess.Interfaces
{
    public interface IRoleRepository
    {
        List<Role> GetAll();
        Role? GetById(int id);
        Role? GetByUser(User user);
    }
}
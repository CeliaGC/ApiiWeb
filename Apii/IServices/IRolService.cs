﻿using Entities.Entities;

namespace Apii.IServices
{
    public interface IRolService
    {
        int InsertUserRol(UserRol userRol);
        void DeleteRol(int Id);
    }
}

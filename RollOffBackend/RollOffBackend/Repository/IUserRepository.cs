﻿using RollOffBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollOffBackend.Repository
{
    public interface IUserRepository
    {
        Task<LoginTable> AuthenticateUserAsync(string email, string password);
    }
}
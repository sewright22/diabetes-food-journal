﻿using DataLayer.Data;

namespace Services
{
    public interface IUserService
    {
        public Task<User> AddUser(string userName, string password);
        public Task<bool> ValidateCredentials(string userName, string password);
    }
} 
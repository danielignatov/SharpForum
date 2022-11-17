﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SharpForum.API.Data.Repository.Interfaces;
using SharpForum.API.Models.Domain;
using SharpForum.API.Services.Caching;

namespace SharpForum.API.Data.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(
            IDbContextFactory<DataContext> dbContextFactory, 
            ICacheManager cacheManager, 
            ILogger logger) : base(dbContextFactory, cacheManager, logger)
        {
        }
    }
}
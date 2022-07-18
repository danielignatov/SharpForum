using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SharpForum.Domain;
using SharpForum.Persistence;
using SharpForum.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpForum.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(IDbContextFactory<DataContext> dbContextFactory, ILogger logger) : base(dbContextFactory, logger)
        {
        }
    }
}
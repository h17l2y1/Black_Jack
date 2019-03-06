using BlackJackDataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJackDataAccess.Repositories
{
    public class UserRepository : BaseGenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {

        }
    }
}

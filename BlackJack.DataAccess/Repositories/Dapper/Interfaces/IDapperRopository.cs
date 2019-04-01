﻿
using System.Threading.Tasks;

namespace BlackJackDataAccess.Repositories.Interfaces
{
    public interface IDapperRopository<TEntity> : IBaseGenericRepository<TEntity> where TEntity : class
    {

    }
}
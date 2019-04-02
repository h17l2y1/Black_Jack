﻿using BlackJackViewModels;
using BlackJackViewModels.Account;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace BlackJackServices.Services.Interfaces
{
    public interface IAccountService
    {
        Task<ResponseSignUpAccountView> AddAsync(RequestSignUpAccountView model);

        Task<ResponseRemoveAccountView> Remove(string id);

        Task<ResponseGetAccountView> Get(string id);

        Task<ResponseGetAllAccountView> GetAllAsync();

        JwtSecurityToken GetToken(RequestSignUpAccountView model);

        string GetTokenString(JwtSecurityToken jwt);

        bool UserIsExist(string userName);
    }
}

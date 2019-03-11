using BlackJackViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackServices.Services.Interfaces
{
    public interface IAccountService
    {
        Task AddAsync(RegisterViewModel model);

        Task RemoveAsync(string id);

        Task<object> FindByIdAsync(string id);

        Task<object> GetAllAsync();

        JwtSecurityToken GetToken(RegisterViewModel model);

        string GetTokenString(JwtSecurityToken jwt);

        bool UserIsExist(string userName);
    }
}

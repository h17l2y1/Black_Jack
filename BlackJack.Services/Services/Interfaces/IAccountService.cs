using BlackJackViewModels;
using BlackJackViewModels.Account;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlackJackServices.Services.Interfaces
{
    public interface IAccountService
    {
        Task<ResponseSignUpAccountView> AddAsync(string userName);

        Task<ResponseRemoveAccountView> Remove(string id);

        Task<ResponseGetAccountView> GetById(string id);

        Task<ResponseGetAllAccountView> GetAllAsync();

        Task<JwtSecurityToken> GetToken(string userName);

        string GetTokenString(JwtSecurityToken jwt);

        bool UserIsExist(string userName);

        Task<ResponseGetUsersAccount> GetUsers();
    }
}

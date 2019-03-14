using BlackJackViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace BlackJackServices.Services.Interfaces
{
    public interface IAccountService
    {
        Task AddAsync(RegisterView model);

        Task RemoveAsync(string id);

        Task<object> FindByIdAsync(string id);

        Task<object> GetAllAsync();

        JwtSecurityToken GetToken(RegisterView model);

        string GetTokenString(JwtSecurityToken jwt);

        bool UserIsExist(string userName);
    }
}

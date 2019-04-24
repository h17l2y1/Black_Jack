using BlackJackViewModels;
using BlackJackViewModels.Account;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlackJackServices.Services.Interfaces
{
    public interface IAccountService
    {
		Task<ResponseGetUsersAccount> GetUsers();

		Task<ResponseSignUpAccountView> SignUp(string userName);

        Task<ResponseGetAccountView> GetById(string id);

		Task<string> Logining(string userName);

	}
}

using BlackJackViewModels;
using BlackJackViewModels.Account;
using System.Threading.Tasks;

namespace BlackJackServices.Services.Interfaces
{
	public interface IAccountService
	{
		Task<GetUsersAccountView> GetUsers();

		Task<SignUpAccountResponseView> SignUp(string userName);

		Task<GetAccountResponseView> GetById(string id);

		Task<TokenAccountView> LogIn(string userName);

	}
}

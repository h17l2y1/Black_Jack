using BlackJackViewModels;
using BlackJackViewModels.Account;
using System.Threading.Tasks;

namespace BlackJackServices.Services.Interfaces
{
	public interface IAccountService
	{
		Task<ResponseGetUsersAccount> GetUsers();

		Task<ResponseSignUpAccountView> SignUp(string userName);

		Task<ResponseGetAccountView> GetById(string id);

		Task<ResponseTokenAccountView> Logining(string userName);

	}
}

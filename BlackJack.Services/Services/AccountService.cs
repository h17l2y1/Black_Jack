using BlackJack.Exceptions;
using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
using BlackJackEntities.Enums;
using BlackJackServices.Jwt;
using BlackJackServices.Services.Interfaces;
using BlackJackViewModels;
using BlackJackViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackServices.Services
{
	public class AccountService : IAccountService
	{
		private readonly UserManager<Player> _userManager;
		private readonly SignInManager<Player> _signInManager;
		private readonly AuthOptions _authOptions;
		private readonly IPlayerRepository _playerRepository;
		private readonly IMappingService _mappingService;
		private readonly IJwtTokenProvider _jwtTokenProvider;

		public AccountService(IOptions<AuthOptions> authOptions,
							  IPlayerRepository playerRepository,
							  UserManager<Player> userManager,
							  SignInManager<Player> signInManager,
							  IMappingService mappingService,
							  IJwtTokenProvider jwtTokenProvider)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_authOptions = authOptions.Value;
			_playerRepository = playerRepository;
			_mappingService = mappingService;
			_jwtTokenProvider = jwtTokenProvider;
		}

		public async Task<GetUsersAccountView> GetUsers()
		{
			var users = await _playerRepository.GetByRole(PlayersType.User.ToString());

			var userNames = users
			.Select(x => x.UserName)
			.ToList();
			var response = new GetUsersAccountView(userNames);

			return response;
		}

		public async Task<SignUpAccountResponseView> SignUp(string userName)
		{
			Player user = new Player
			{
				UserName = userName,
				Points = 100,
				Role = PlayersType.User.ToString()
			};
			await _userManager.CreateAsync(user);

			var response = _mappingService.AccountMapper(user, new SignUpAccountResponseView());
			return response;
		}

		public async Task<GetAccountResponseView> GetById(string id)
		{
			var user = await _userManager.FindByIdAsync(id);
			if (user == null)
			{
				throw new NotFoundException();
			}
			var response = _mappingService.AccountMapper(user, new GetAccountResponseView());
			return response;
		}

		public async Task<TokenAccountView> LogIn(string userName)
		{
			Player user = _userManager.Users.FirstOrDefault(x => x.UserName == userName);
			if (user == null)
			{
				await SignUp(userName);
				user = _userManager.Users.FirstOrDefault(x => x.UserName == userName);
			}
			var token = new TokenAccountView
			{
				Token = _jwtTokenProvider.GetTokenString(user)
			};
			return token;
		}
	}
}

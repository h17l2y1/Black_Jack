using BlackJackDataAccess.Repositories.Interface;
using BlackJackEntities.Entities;
using BlackJackServices.Services.Auth;
using BlackJackServices.Services.Interfaces;
using BlackJackViewModels;
using BlackJackViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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


        public AccountService(IOptions<AuthOptions> authOptions, UserManager<Player> userManager,
                                SignInManager<Player> signInManager, IPlayerRepository playerRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authOptions = authOptions.Value;
            _playerRepository = playerRepository;
        }

        public async Task<ResponseGetAllAccountView> GetAllAsync()
        {
            var playerList = await _userManager.Users.ToListAsync();

            var listView = new List<PlayerAccountView>();

            foreach (var player in playerList)
            {
                listView.Add(Mapper(player, new PlayerAccountView()));
            }

            var response = new ResponseGetAllAccountView(listView);
            return response;
        }

        public async Task<ResponseSignUpAccountView> AddAsync(string userName)
        {
            Player user = new Player
            {
                UserName = userName,
                Points = 100,
                Role = "User"
            };
            await _userManager.CreateAsync(user);

            var response = Mapper(user, new ResponseSignUpAccountView());
            return response;
        }

        public async Task<ResponseGetAccountView> GetById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var response = Mapper(user, new ResponseGetAccountView());
            return response;
        }

        private ClaimsIdentity GetIdentity(string userName)
        {
            Player user = _userManager.Users.FirstOrDefault(x => x.UserName == userName);
            if (user != null)
            {
                var claimsList = new List<Claim>
                {
                    new Claim("UserName", user.UserName),
                    new Claim("UserId",user.Id),
                    new Claim("Role", user.Role)
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                    claimsList,
                    "Token"
                    );

                return claimsIdentity;
            }
            return null;
        }

        public async Task<JwtSecurityToken> GetToken(string userName)
        {
            var identity = GetIdentity(userName);

            if (identity == null)
            {
                await AddAsync(userName);
                var newIdentity = GetIdentity(userName);
                return await GetNewToken(newIdentity);
            }
            return await GetNewToken(identity);
        }

        private async Task<JwtSecurityToken> GetNewToken(ClaimsIdentity identity)
        {
            var key = Encoding.ASCII.GetBytes(_authOptions.Key);
            var jwt = new JwtSecurityToken(
                issuer: _authOptions.Issuer,
                audience: _authOptions.Audience,
                claims: identity.Claims,
                expires: DateTime.UtcNow.AddDays(_authOptions.LifeTime),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                );
            return jwt;
        }

        public string GetTokenString(JwtSecurityToken jwt)
        {
            var stringToken = new JwtSecurityTokenHandler().WriteToken(jwt);
            return stringToken;
        }

        public bool UserIsExist(string newUser)
        {
            var userIsExist = _userManager.Users.FirstOrDefault(x => x.UserName == newUser);

            if (userIsExist != null)
            {
                return true;
            }
            return false;
        }

        private T Mapper<T>(Player player, T view) where T : PlayerAccountView
        {
            var response = view;
            view.UserId = player.Id;
            view.UserName = player.UserName;
            view.Points = player.Points;
            view.Role = player.Role;

            return response;
        }

        public async Task<ResponseRemoveAccountView> Remove(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);
            var response = Mapper(user, new ResponseRemoveAccountView());
            return response;
        }

        public async Task<ResponseGetUsersAccount> GetUsers()
        {
            var users = await _playerRepository.GetAllUsers();
            var list = new List<string>();
            foreach (var item in users)
            {
                list.Add(item.UserName);
            }
            var response = new ResponseGetUsersAccount(list);
            return response;
        }


    }
}
